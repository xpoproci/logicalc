using Business.Functions;
using Business.Input;
namespace Tests.Functions
{
    public class UCNFConversionTests
    {
        [Theory]
        [InlineData("not P", "¬P")]
        [InlineData("(A or B)", "(A ∨ B)")]
        [InlineData("(A or (B or C))", "(A ∨ (B ∨ C))")]
        [InlineData("((A or (B or C)) & C)", "((A ∨ (B ∨ C)) ∧ C)")]
        [InlineData("(P -> Q)", "(¬P ∧ Q)")]
        public void TestRemovingImplications(string input, string expected)
        {
            var adapter = new LogicParserAdapter();
            var trees = adapter.GetAbstractSyntaxTree(input);

            Assert.NotNull(trees);
            Assert.True(adapter.IsValid);
            Assert.True(trees.Count == 1);

            var node = trees.ElementAt(0);

            var cnfConverter = new UCNFConverter(node);

            var result = cnfConverter.EliminateImplications();

            Assert.Equal(node.GetStringRep(), expected);
        }
    }
}
