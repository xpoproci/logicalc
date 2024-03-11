namespace Business.ParserModels.Nodes
{
    public class OrNode : WellFormedFormula
    {
        private static string? _currentlyUsedSymbol;

        public OrNode(string symbol) : base(symbol, NodeType.OR)
        {
            _currentlyUsedSymbol = symbol;
        }

        public OrNode() : this("∨")
        {            
        }

        public override bool IsValid()
        {
            return ChildrenSize() == 2;
        }

        public override string GetStringRep()
        {
            var left = GetChildAt(0);
            var right = GetChildAt(1);

            return $"({left.GetStringRep()} {Symbol} {right.GetStringRep()})";
        }

        public override bool IsCNFClausule()
        {
            var left = GetChildAt(0);
            var right = GetChildAt(1);
            if ((left is AtomNode || left is PredicateNode) && (right is AtomNode || right is PredicateNode))
            {
                return true;
            }

            var result = true;
            foreach (var ch in Children)
            {
                result = result && ch.IsCNFClausule();
            }

            return result;
        }

        public override bool Evaluate()
        {
            var left = GetChildAt(0);
            var right = GetChildAt(1);
            return left.Evaluate() || right.Evaluate();
        }

        public override WellFormedFormula Copy()
        {
            var node = new OrNode(Symbol)
            {
                Flags = Flags
            };

            foreach (var child in Children)
            {
                node.AddChild(child.Copy());
            }

            return node;
        }
    }
}
