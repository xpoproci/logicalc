using Business.DTOs.Formulas;
using Business.ParserModels.Nodes;
using System.Text;

namespace Business.ParserModels
{
    public class WellFormedFormula
    {
        ///properties
        public NodeType NodeType { get; set; }
        public LinkedList<WellFormedFormula> Children { get; set; }
        public LinkedList<bool> TruthValues { get; private set; }
        public string? Symbol { get; set; }

        private int _flags;
        public int Flags { get { return _flags; } set { _flags |= value; } }

        ///constructors
        public WellFormedFormula(string? symbol, NodeType nodeType)
        {
            Symbol = symbol;
            NodeType = nodeType;
            Children = new();
            TruthValues = new();
        }

        public WellFormedFormula(NodeType nodeType): this(null, nodeType)
        {
        }

        public WellFormedFormula() : this(null, NodeType.ROOT)
        {            
        }

        private static string GetStandardizedString(string str)
        {
            if (str == null) { return string.Empty; }
            var result = str.Replace(" ", ""); //spaces
            result = result.Replace("[~¬!]|(not|NOT)", "~");
            result = result.Replace("[∧^⋅]|(and|AND)", "&"); // AND
            result = result.Replace("[\\|+\\|\\|]|(or|OR)", "∨"); // OR
            result = result.Replace("[→⇒⊃>]|(implies|IMPLIES)", "→"); // IMP
            result = result.Replace("[⇔≡↔]|(<>|iff|IFF)", "↔"); // BICOND
            result = result.Replace("[⊻≢⩒↮]|(xor|XOR)", "⊕"); // XOR
            result = result.Replace("[(]", "#");
            result = result.Replace("[)]", "#"); // We need to standardize these as well!

            return result;
        }

        public virtual WellFormedFormula Copy()
        {
            var t = new WellFormedFormula(Symbol, NodeType)
            {
                Flags = Flags
            };
            CopyHelper(this, t);
            return t;
        }

        private static void CopyHelper(WellFormedFormula root, WellFormedFormula newTree)
        {
            foreach (var ch in root.Children)
            {
                newTree.AddChild(ch.Copy());
            }
        }

        public void ClearHighlighting()
        {
            SetHighlighted(false);
            foreach (var ch in Children)
            {
                ClearHighlightingHelper(ch);
            }
        }


        private void ClearHighlightingHelper(WellFormedFormula root)
        {
            foreach (var ch in root.Children)
            {
                ch.SetHighlighted(false);
                ClearHighlightingHelper(ch);
            }
        }


        public WellFormedFormula? GetChildAt(int i)
        {
            try
            {
                return Children.ElementAt(i);
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }

        public string PrintSyntaxTree()
        {
            return PrintSyntaxTreeHelper(0).ToString();
        }

        public bool IsClosable()
        {
            if (IsPredicate() || IsAtom())
            {
                return true;
            }
            // Nodes of type ~P are good.
            else if (IsNegation() && GetChildAt(0) != null && (GetChildAt(0).IsPredicate() || GetChildAt(0).IsAtom()))
                return true;
            // Nodes of type ~identity are good.
            else if (IsNegation() && GetChildAt(0) != null && GetChildAt(0).IsIdentity())
            {
                return true;
            }
            // Nodes of type identity are good.
            else
            {
                return IsIdentity();
            }
        }

        public int ChildrenSize()
        {
            return Children.Count;
        }

        public void AddChild(WellFormedFormula node)
        {
            Children.AddLast(node);
        }

        public void SetChild(int index, WellFormedFormula node)
        {
            var head = Children.First;
            var currentIndex = 0;

            while (head != null && currentIndex != index)
            {
                head = head.Next;
                currentIndex++;
            }

            if (head != null && currentIndex == index)
            {
                head.Value = node;
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
        }

        #region NodeType helpers
        public bool IsRoot()
        {
            return NodeType == NodeType.ROOT;
        }

        public bool IsAtom()
        {
            return NodeType == NodeType.ATOM;
        }

        public bool IsNegation()
        {
            return NodeType == NodeType.NEG;
        }

        public bool IsDoubleNegation()
        {
            return NodeType == NodeType.NEG && GetChildAt(0) != null &&
                    GetChildAt(0)?.NodeType == NodeType.NEG;
        }

        public bool IsNegImp()
        {
            return NodeType == NodeType.NEG && GetChildAt(0) != null &&
                    GetChildAt(0)?.NodeType == NodeType.IMP;
        }

        public bool IsNegAnd()
        {
            return NodeType == NodeType.NEG && GetChildAt(0) != null &&
                    GetChildAt(0)?.NodeType == NodeType.AND;
        }

        public bool IsNegOr()
        {
            return NodeType == NodeType.NEG && GetChildAt(0) != null &&
                    GetChildAt(0)?.NodeType == NodeType.OR;
        }

        public bool IsNegAtom()
        {
            return NodeType == NodeType.NEG && GetChildAt(0) != null &&
                    (GetChildAt(0)?.NodeType == NodeType.ATOM ||
                    GetChildAt(0)?.NodeType == NodeType.PREDICATE);
        }

        public bool IsNegExclusiveOr()
        {
            return NodeType == NodeType.NEG && GetChildAt(0) != null &&
                    GetChildAt(0)?.NodeType == NodeType.XOR;
        }

        public bool IsNegIdentity()
        {
            return NodeType == NodeType.NEG && GetChildAt(0) != null &&
                    GetChildAt(0)?.NodeType == NodeType.IDENTITY;
        }

        public bool IsAnd()
        {
            return NodeType == NodeType.AND;
        }

        public bool IsOr()
        {
            return NodeType == NodeType.OR;
        }

        public bool IsImp()
        {
            return NodeType == NodeType.IMP;
        }

        public bool IsBicond()
        {
            return NodeType == NodeType.BICOND;
        }

        public bool IsExclusiveOr()
        {
            return NodeType == NodeType.XOR;
        }

        public bool IsIdentity()
        {
            return NodeType == NodeType.IDENTITY;
        }

        public bool IsQuantifier()
        {
            return NodeType == NodeType.EXISTENTIAL || NodeType == NodeType.UNIVERSAL;
        }

        public bool IsExistential()
        {
            return NodeType == NodeType.EXISTENTIAL;
        }

        public bool IsUniversal()
        {
            return NodeType == NodeType.UNIVERSAL;
        }

        public bool IsBinaryOp()
        {
            return IsAnd() || IsOr() || IsImp() || IsBicond() || IsExclusiveOr() || IsIdentity();
        }

        public bool IsPredicate()
        {
            return NodeType == NodeType.PREDICATE;
        }

        public bool IsConstant()
        {
            return NodeType == NodeType.CONSTANT;
        }

        public bool IsVariable()
        {
            return NodeType == NodeType.VARIABLE;
        }

        public bool IsPropositionalWff()
        {
            return (Flags & NodeFlag.PROPOSITIONAL) != 0;
        }

        public bool IsPredicateWff()
        {
            return (Flags & NodeFlag.PREDICATE) != 0;
        }

        public virtual bool IsCNFClausule()
        {
            var result = true;
            foreach (var ch in Children)
            {
                result = result && ch.IsCNFClausule();
            }
            return result;
        }

        public bool IsDNF()
        {
            return (Flags & NodeFlag.DNF) != 0;
        }
        #endregion

        public ClausuleCNFDto GetCNFClausule()
        {
            var clausule = new ClausuleCNFDto();
            var clausuleFormula = new ClausuleCNFFormula();
            var stack = new Stack<WellFormedFormula>();

            var usedAtomNodes = new List<WellFormedFormula>();

            stack.Push(this);
            while(stack.Count > 0)
            {
                var cl = new ClausuleLiteral();
                var ch = stack.Pop();
                if (ch.IsNegAtom())
                {
                    cl.Representation = ch.GetStringRep();
                    clausuleFormula.Literals.Add(cl);
                    usedAtomNodes.Add(ch.Children.First());
                }
                else if (ch.IsAtom() || ch.IsPredicate())
                {
                    if(usedAtomNodes.Where(x=> ReferenceEquals(x, ch)).Any())
                    {
                        continue;
                    }
                    usedAtomNodes.Add(ch);
                    cl.Representation = ch.GetStringRep();
                    clausuleFormula.Literals.Add(cl);
                }
                foreach(var c in ch.Children)
                {
                    stack.Push(c);
                }
            }
            clausuleFormula.Literals = clausuleFormula.Literals.OrderBy(x => x.Representation).ToHashSet();

            clausule.Clausules.Add(clausuleFormula);
            return clausule;
        }

        public void SetTruthValue(bool b, int index)
        {
            if (index >= TruthValues.Count)
            {
                TruthValues.AddLast(b);
            }
            else
            {
                var head = TruthValues.First;
                var currentIndex = 0;

                while (head != null && currentIndex != index)
                {
                    head = head.Next;
                    currentIndex++;
                }

                if (head != null && currentIndex == index)
                {
                    head.Value = b;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
        }

        public bool IsHighlighted()
        {
            return (Flags & NodeFlag.HIGHLIGHT) != 0;
        }

        public void SetHighlighted(bool highlighted)
        {
            if (highlighted)
            {
                Flags |= NodeFlag.HIGHLIGHT;
            }
            else
            {
                Flags &= ~NodeFlag.HIGHLIGHT;
            }
        }

        public virtual string GetStringRep()
        {
            StringBuilder str = new();
            foreach (var ch in Children)
            {
                str.Append(ch.GetStringRep());
            }
            return str.ToString();
        }

        public virtual bool IsValid()
        {
            var result = true;

            foreach(var ch in Children)
            {
                result = result && ch.IsValid();
            }

            return result;
        }

        public List<AtomNode> GetAtoms()
        {
            var atoms = new List<AtomNode>();

            if(ChildrenSize() == 0 && this is AtomNode)
            {
                atoms.Add(this as AtomNode);
            }
            else
            {
                foreach(var ch in Children)
                {
                    atoms.AddRange(ch.GetAtoms());
                }
            }

            return atoms;
        }

        public virtual bool Evaluate() {
            var result = true;

            foreach (var ch in Children)
            {
                result = result && ch.Evaluate();
                Console.WriteLine($"{ch.GetStringRep()} - {result}");
            }

            return result;
        }

        public bool IsPalindromeWff()
        {
            var s = GetStringRep();
            var n = s.Length;
            for (int i = 0; i < (n / 2); ++i)
            {
                if (s[i] != s[n - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            return NodeType.ToString();
        }

        public StringBuilder PrintSyntaxTreeHelper(int indent)
        {
            StringBuilder sb = new();
            sb.Append(RepeatLinq(" ", Math.Max(0, indent)));
            sb.Append(ToString());

            if (!(Children.Count == 0))
            {
                sb.Append(" (\n");
                bool isFirstChild = true;
                foreach (var child in Children)
                {
                    if (!isFirstChild)
                    {
                        sb.Append(",\n");
                    }
                    isFirstChild = false;
                    sb.Append(child.PrintSyntaxTreeHelper(indent + 2));
                }
                sb.Append(')');
            }

            return sb;
        }

        public static string RepeatLinq(string text, int n)
        {
            return string.Concat(Enumerable.Repeat(text, (int)n));
        }

        public virtual bool ContainsImplication()
        {
            if (IsImp())
            {
                return true;
            }

            foreach (var ch in Children)
            {
                if (ch.ContainsImplication())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
