namespace Business.ParserModels.Nodes
{
    public class QuantifierNode : WellFormedFormula
    {
        public string VariableSymbol { get; set; }

        public QuantifierNode(string symbol, string variableSymbol, NodeType nodeType)
            : base(symbol, nodeType)
        {
            VariableSymbol = variableSymbol;
        }

        public override bool IsValid() => ChildrenSize() == 1;

        public override string ToString()
        {
            return $"{base.ToString()}: {VariableSymbol}";
        }
    }
}
