namespace Business.ParserModels.Nodes
{
    public class ConstantNode : WellFormedFormula
    {
        public ConstantNode(string symbol) : base(symbol, NodeType.CONSTANT)
        {
        }

        public override string GetStringRep()
        {
            return Symbol;
        }

        public override bool IsValid() => Symbol != null;

        public override WellFormedFormula Copy()
        {
            var node = new ConstantNode(Symbol)
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
