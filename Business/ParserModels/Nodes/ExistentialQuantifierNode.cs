namespace Business.ParserModels.Nodes
{
    public class ExistentialQuantifierNode : QuantifierNode
    {
        public ExistentialQuantifierNode(string symbol, string variableSymbol) : base(symbol, variableSymbol, NodeType.EXISTENTIAL)
        {
        }

        public ExistentialQuantifierNode(string variableSymbol) :
        base($"(∃{variableSymbol})", variableSymbol, NodeType.EXISTENTIAL)
        {
        }

        public ExistentialQuantifierNode() : this(null, null)
        {
        }

        public override WellFormedFormula Copy()
        {
            var node = new ExistentialQuantifierNode(Symbol, VariableSymbol)
            {
                Flags = Flags
            };

            foreach (var child in Children)
            {
                node.AddChild(child.Copy());
            }

            return node;
        }

        public override string GetStringRep()
        {
            var first = GetChildAt(0);
            return Symbol + first.GetStringRep();
        }
    }
}
