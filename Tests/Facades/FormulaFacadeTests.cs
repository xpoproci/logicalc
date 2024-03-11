using Business.DTOs.Formulas;
using Business.Facades;
using Business.Functions;
using Business.Input;
using Data.Models;

namespace Tests.Functions
{
    public class FormulaFacadeTests
    {
        private FormulaFacade _formulaFacade;
        public FormulaFacadeTests()
        {
            _formulaFacade = new FormulaFacade();
        }

        [Fact]
        public void TestResolveTwoEmptyClausuleFormulas()
        {
            var cf1 = new ClausuleCNFFormula();
            var cf2 = new ClausuleCNFFormula();


            var result = _formulaFacade.ResolveClausuleFormulas(cf1, cf2);
            Assert.True(!result.Literals.Any());
        }

        [Fact]
        public void TestResolveTwoNonMatchingClausuleFormulas()
        {
            var cf1 = new ClausuleCNFFormula();
            cf1.Literals.Add(new ClausuleLiteral() { Value = 1 });
            var cf2 = new ClausuleCNFFormula();
            cf2.Literals.Add(new ClausuleLiteral() { Value = 2 });


            var result = _formulaFacade.ResolveClausuleFormulas(cf1, cf2);
            Assert.True(result.Literals.Count() == 2);
        }

        [Fact]
        public void TestResolveTwoMatchingClausuleFormulas()
        {
            var cf1 = new ClausuleCNFFormula();
            cf1.Literals.Add(new ClausuleLiteral() { Value = 1 });
            var cf2 = new ClausuleCNFFormula();
            cf2.Literals.Add(new ClausuleLiteral() { Value = -1 });


            var result = _formulaFacade.ResolveClausuleFormulas(cf1, cf2);
            Assert.True(result.Literals.Count() == 0);
        }

        [Fact]
        public void TestResolveTwoMatchingAndAdditionalClausuleFormulas()
        {
            var cf1 = new ClausuleCNFFormula();
            cf1.Literals.Add(new ClausuleLiteral() { Value = 1 });
            var cf2 = new ClausuleCNFFormula();
            cf2.Literals.Add(new ClausuleLiteral() { Value = -2 });
            cf2.Literals.Add(new ClausuleLiteral() { Value = -1 });


            var result = _formulaFacade.ResolveClausuleFormulas(cf1, cf2);
            Assert.True(result.Literals.Count() == 1);
        }

        [Theory]
        [InlineData("!(A or !A)")]
        [InlineData("(A or !A)")]
        [InlineData("!((A -> B) or (B->A))")]
        [InlineData("((A -> B) or (B->A))")]
        [InlineData("!(((A -> B) and (B  -> C)) -> (A  -> C))")]
        [InlineData("!((P & Q)&B)")]
        [InlineData("!(A and !A)")]
        [InlineData("!((A and B) and !(A and B))")]
        [InlineData("!((A or B) and (!A and !B))")]
        [InlineData("!((A -> B) and (A and !B))")]
        [InlineData("!((A <-> B) and (A and !B))")]
        [InlineData("!((A <-> B) and (B and !A))")]
        [InlineData("!(((A -> B) & A) -> B)")]
        [InlineData("(((P & Q)&B)->!S)")]
        [InlineData("(((P & Q)&B)->S)")]
        public void TestResolutionSolver(string input)
        {
            var adapter = new LogicParserAdapter();
            var trees = adapter.GetAbstractSyntaxTree(input);

            Assert.NotNull(trees);
            Assert.True(adapter.IsValid);
            Assert.True(trees.Count == 1);

            var node = trees.ElementAt(0);
            Assert.True(node.IsPropositionalWff());

            var tt = new TruthTable(node);
            tt.GenerateTruthTable();

            var c = tt.GetUCNFClausule();

            _formulaFacade.ResolveClausule(c);

            Assert.True(c.Clausules.Count == 0);
        }

        [Theory]
        [InlineData("(A or !A)", LogicType.Propositional, true, true)]
        [InlineData("!(A or !A)", LogicType.Propositional, true, false)]
        [InlineData("!(A or !A)", LogicType.Propositional, false, true)]
        [InlineData("!(A or !(A)", LogicType.Propositional, false, false)]
        [InlineData("(A(x) or !A(x))", LogicType.Propositional, false, false)]
        [InlineData("!(A or !A)", LogicType.Predicate, false, false)]
        [InlineData("(A(x) or !A(x))", LogicType.Predicate, true, true)]
        [InlineData("!(A(x) or !A(x))", LogicType.Predicate, false, true)]
        [InlineData("!(A(x) or !A(x)))", LogicType.Predicate, false, false)]
        public async Task TestInputValidation(string input, LogicType type, bool isClausule, bool expected)
        {
            var result = await _formulaFacade.ValidateInputAsync(input, type, isClausule);
            Assert.Equal(expected, result);
        }
    }
}
