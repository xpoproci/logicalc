namespace Business.ParserModels.Nodes
{
    public class XorNode : WellFormedFormula
    {
        private static string? _currentlyUsedSymbol;

        public XorNode(string symbol) : base(symbol, NodeType.XOR)
        {
            _currentlyUsedSymbol = symbol;
        }

        public XorNode() : this(_currentlyUsedSymbol ?? "⊕")
        {
        }

        public override string GetStringRep()
        {
            var left = GetChildAt(0);
            var right = GetChildAt(1);

            return $"({left.GetStringRep()} {Symbol} {right.GetStringRep()})";
        }

        public override WellFormedFormula Copy()
        {
            var node = new XorNode(Symbol)
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
