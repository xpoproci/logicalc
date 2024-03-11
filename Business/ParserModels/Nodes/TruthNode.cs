namespace Business.ParserModels.Nodes
{
    public class TruthNode : WellFormedFormula
    {
        private static string _currentlyUsedSymbol = "⊤";

        public TruthNode() : base(_currentlyUsedSymbol, NodeType.TRUTH)
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
            var node = new TruthNode()
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
