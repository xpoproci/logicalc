using Business.ParserModels.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Business.DTOs.Formulas
{
    public class ClausuleCNFDto
    {
        public HashSet<ClausuleCNFFormula> Clausules { get; set; } = new();

        public bool IsEmpty()
        {
            var result = true;
            FixLiteralsValues();
            if (!Clausules.Any() || Clausules.Count == 1)
            {
                return result;
            }
            foreach (var formula in Clausules)
            {
                result = result && formula.IsEmpty;
            }

            return result;
        }

        public override string ToString()
        {
            if (Clausules.Count == 0) return string.Empty;

            return string.Join(" ∧ ", Clausules);
        }

        public void ConcatClausule(ClausuleCNFDto other)
        {
            Clausules = Clausules.Union(other.Clausules).ToHashSet();
            FixLiteralsValues();
        }

        public void FixLiteralsValues()
        {
            var allLiterals = new HashSet<ClausuleLiteral>();
            foreach (var c in Clausules)
            {
                //gather distinct literals
                allLiterals = allLiterals.Concat(c.Literals).ToHashSet();
            }

            var dict = new Dictionary<string, int>();
            var counter = 1;
            foreach (var literal in allLiterals)
            {
                var lWithoutMark = literal.Representation.Replace("¬", "");
                if (dict.ContainsKey(lWithoutMark))
                {
                    continue;
                }

                dict.Add(lWithoutMark, counter++);
            }

            //assign correct values
            foreach (var c in Clausules)
            {
                foreach (var l in c.Literals)
                {
                    var lWithoutMark = l.Representation.Replace("¬", "");
                    l.SetValue(dict[lWithoutMark]);
                }
            }

            //remove tautological clausule Formulas
            foreach(var c in Clausules)
            {
                c.RemoveTautologicalLiterals();
                if (!c.Literals.Any())
                {
                    Clausules.Remove(c);
                }
            }
        }

        public ClausuleCNFDto Parse(string clausule)
        {
            var c = JsonConvert.DeserializeObject<ClausuleCNFDto>(clausule);
            return c ?? new();
        }
    }

    public class ClausuleDNFDto
    {
        public HashSet<ClausuleDNFFormula> Clausules { get; set; } = new();

        public override string ToString()
        {
            if (Clausules.Count == 0) return string.Empty;

            return string.Join(" ∨ ", Clausules);
        }
    }

    public class ClausuleDNFFormula : IComparable<ClausuleDNFFormula>
    {
        public HashSet<ClausuleLiteral> Literals { get; set; } = new();

        public int CompareTo(ClausuleDNFFormula? other)
        {
            if (other == null) return 1;

            return Literals.SetEquals(other.Literals) ? 0 : 1;
        }

        public override string ToString()
        {
            if (Literals.Count == 0) return string.Empty;
            var literals = string.Join(" ∧ ", Literals);

            return $"({literals})";
        }
    }

    public class ClausuleCNFFormula : IComparable<ClausuleCNFFormula>
    {
        public HashSet<ClausuleLiteral> Literals { get; set; } = new();

        public bool IsEmpty => !Literals.Any();
        public int CompareTo(ClausuleCNFFormula? other)
        {
            if (other == null) return 1;

            return Literals.SetEquals(other.Literals) ? 0 : 1;
        }

        public override string ToString()
        {
            if (Literals.Count == 0) return string.Empty;
            var literals = string.Join(" ∨ ", Literals);

            return $"({literals})";
        }


        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (ClausuleCNFFormula)obj;
            return Literals.SetEquals(other.Literals);
        }

        public void RemoveTautologicalLiterals()
        {
            var result = new HashSet<ClausuleLiteral>();

            foreach (var l in Literals)
            {
                if (result.Select(x => x.Value).Contains(-l.Value))
                {
                    var toRemove = result.Where(x => x.Value == -l.Value).First();
                    result.Remove(toRemove);
                }
                else
                {
                    result.Add(l);
                }
            }

            Literals = result;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;

                // Assuming the order of literals does not matter, 
                // we can use an order-independent hash computation
                foreach (var literal in Literals)
                {
                    hash = hash * 31 + (literal != null ? literal.GetHashCode() : 0);
                }

                return hash;
            }
        }

    }

    public class ClausuleLiteral : IComparable<ClausuleLiteral>
    {
        public string Representation { get; set; } = string.Empty;

        public int Value { get; set; }

        public int CompareTo(ClausuleLiteral? other)
        {
            return Equals(other) ? 0 : 1;
        }

        public void SetValue(int value)
        {
            Value = Representation.StartsWith("¬") ? -value : value;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ClausuleLiteral other = (ClausuleLiteral)obj;
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Representation != null ? Representation.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return Representation;
        }
    }
}
