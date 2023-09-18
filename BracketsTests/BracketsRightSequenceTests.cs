using BracketsRightSequence;

namespace BracketsTests
{
    public class BracketsRightSequenceTests
    {
        [Theory]
        [InlineData("", true)]
        [InlineData("(){}[][][]()", true)]
        [InlineData("()()", true)]
        [InlineData("()[][]", true)]
        [InlineData("{}{}[][]", true)]
        [InlineData("({[]})()[]", true)]
        [InlineData("[(({[]})()[])]", true)]
        [InlineData("{{{{{{[(({[]})()[])]}}}}}}", true)]
        [InlineData("{([][])({[]{}})}", true)]
        public void CheckSequenceRightTests(string input, bool expected)
        {
            bool actual = BracketValidator.IsRightSequence(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("(){}[][][]()(", false)]
        [InlineData("(){}[][]]()", false)]
        [InlineData("(){[][][]()", false)]
        [InlineData("){}[][][]()", false)]
        [InlineData("()(", false)]
        [InlineData("(][]", false)]
        [InlineData("{}{][]", false)]
        [InlineData("({[]}))[]", false)]
        [InlineData("[(([]})()[])]", false)]
        [InlineData("{{{{{{[(({[]})()[])]}}}}}", false)]
        [InlineData("{{{{{[(({[]})()[])]}}}}}}", false)]
        [InlineData("{([][))({[]{}})}", false)]
        public void CheckSequenceWrongTests(string input, bool expected)
        {
            bool actual = BracketValidator.IsRightSequence(input);

            Assert.Equal(expected, actual);
        }
    }
}