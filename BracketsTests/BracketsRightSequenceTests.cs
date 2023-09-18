using BracketsRightSequence;

namespace BracketsTests
{
    public class BracketsRightSequenceTests
    {
        [Theory]
        [InlineData("(){}[][][]()", true)]
        public void CheckSequencePositiveTests(string input, bool expected)
        {
            bool actual = BracketValidator.IsRightSequence(input);

            Assert.Equal(expected, actual);
        }
    }
}