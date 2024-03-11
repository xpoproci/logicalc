using System.Text;

namespace Business.ParserModels.Nodes
{
    public class PredicateNode : WellFormedFormula
    {
        private readonly string _predicateLetter;
        private readonly LinkedList<WellFormedFormula> _params;

        public PredicateNode(string symbol, LinkedList<WellFormedFormula> parameters) : base(symbol, NodeType.PREDICATE)
        {
            _predicateLetter = symbol;
            _params = parameters;
            foreach(var t in parameters)
            {
                AddChild(t);
            }
        }

        public PredicateNode(string symbol) : base(symbol, NodeType.PREDICATE)
        {
            _predicateLetter = symbol;
            _params = new();
        }

        /// <summary>
        /// P(x,y,z)
        /// </summary>
        /// <returns></returns>
        public override string GetStringRep()
        {
            var childrenString = string.Join(',', Children.Select(x => x.GetStringRep()).ToArray());

            return $"{_predicateLetter}({childrenString})";
        }

        public override bool IsValid()
        {
            return ChildrenSize() >= 1;
        }

        public override WellFormedFormula Copy()
        {
            var node = new PredicateNode(_predicateLetter)
            {
                Flags = Flags
            };

            foreach (var child in Children)
            {
                if(child == null) continue;
                node.AddChild(child.Copy());
            }

            return node;
        }
    }
}
