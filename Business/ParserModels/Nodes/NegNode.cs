namespace Business.ParserModels.Nodes
{
    public class NegNode : WellFormedFormula
    {
        private static string? _currentlyUsedSymbol;

        public NegNode(string symbol) : base(symbol, NodeType.NEG)
        {
            _currentlyUsedSymbol = symbol;
        }

        public NegNode() : this("¬")
        {            
        }

        public override string GetStringRep()
        {
            var left = GetChildAt(0);
            var space = Symbol.ToLower().Equals("not") ? " " : "";
            return $"{Symbol}{space}{left.GetStringRep()}";
        }

        public override bool IsValid() => ChildrenSize() == 1;

        public override bool Evaluate()
        {
            var child = GetChildAt(0);
            return !child.Evaluate();
        }

        public override bool IsCNFClausule()
        {
            return IsNegAtom();
        }

        public override WellFormedFormula Copy()
        {
            var node = new NegNode(Symbol)
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
