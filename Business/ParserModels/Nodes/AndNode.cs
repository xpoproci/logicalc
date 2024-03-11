namespace Business.ParserModels.Nodes
{
    public class AndNode : WellFormedFormula
    {
        public AndNode(string symbol) : base(symbol, NodeType.AND)
        {
        }

        public AndNode() : this("∧")
        {            
        }

        public override string GetStringRep()
        {
            var left = GetChildAt(0);
            var right = GetChildAt(1);

            return $"({left.GetStringRep()} {Symbol} {right.GetStringRep()})";
        }

        public override bool IsValid()
        {
            return ChildrenSize() == 2;
        }

        public override bool IsCNFClausule()
        {
            return false;
        }

        public override bool Evaluate()
        {
            var left = GetChildAt(0);
            var right = GetChildAt(1);
            return left.Evaluate() && right.Evaluate();
        }

        public override WellFormedFormula Copy()
        {
            var node = new AndNode(Symbol)
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
