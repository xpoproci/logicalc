using Business.ParserModels;

namespace Business.Functions
{
    public class UCNFConverter
    {
        private readonly WellFormedFormula _tree;

        public UCNFConverter(WellFormedFormula tree)
        {
            _tree = tree;
        }

        public WellFormedFormula EliminateImplications()
        {
            if (!_tree.ContainsImplication())
            {
                return _tree;
            }



            return _tree;
        }

        public void MoveNegationsInwards()
        {

        }

        public void DistributeOrOverAnd()
        {

        }
    }
}
