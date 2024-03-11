namespace Business.ParserModels.Nodes
{
    public class VariableNode : WellFormedFormula
    {
        public VariableNode(string symbol) : base(symbol, NodeType.VARIABLE)
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
            var node = new AtomNode(Symbol)
            {
                Flags = Flags
            };
            return node;
        }
    }
}
