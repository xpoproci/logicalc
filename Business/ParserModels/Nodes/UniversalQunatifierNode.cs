namespace Business.ParserModels.Nodes
{
    public class UniversalQunatifierNode : QuantifierNode
    {
        public UniversalQunatifierNode(string symbol, string variableSymbol) : base(symbol, variableSymbol, NodeType.UNIVERSAL)
        {
        }

        public UniversalQunatifierNode(string variableSymbol) :
        base($"(∀{variableSymbol})", variableSymbol, NodeType.UNIVERSAL)
        {
        }

        public UniversalQunatifierNode() : this(null, null)
        {
        }

        public override WellFormedFormula Copy()
        {
            var node = new UniversalQunatifierNode(Symbol, VariableSymbol)
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
