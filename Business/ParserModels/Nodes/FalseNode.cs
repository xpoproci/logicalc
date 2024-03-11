namespace Business.ParserModels.Nodes
{
    public class FalseNode : WellFormedFormula
    {
        private static string _currentlyUsedSymbol = "⊥";

        public FalseNode() : base(_currentlyUsedSymbol, NodeType.FALSE)
        {
        }

        public override string GetStringRep()
        {
            return Symbol;
        }

        public override bool IsValid()
        {
            return ChildrenSize() == 0 && Symbol != null;
        }

        public override WellFormedFormula Copy()
        {
            var node = new FalseNode()
            {
                Flags = Flags
            };
            return node;
        }

        public override string ToString()
        {
            return $"{base.ToString()}: {Symbol}";
        }
    }
}
