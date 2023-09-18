namespace BracketsRightSequence
{


    public class BracketValidator
    {
        public static bool IsRightSequence(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || !input.Any(c => BracketCollection.HasAny(c)))
            {
                return true;
            }

            Stack<BracketType> openedBrackets = new();

            foreach (char c in input)
            {
                KeyValuePair<BracketType, Brackets>? bracketsPair = BracketCollection.GetBrackets(c);

                if (bracketsPair == null)
                {
                    continue;
                }

                bool isStart = bracketsPair?.Value.Start.Equals(c) ?? false;
                BracketType bracketType = bracketsPair?.Key ?? BracketType.Common;

                if (isStart)
                {
                    openedBrackets.Push(bracketType);
                    continue;
                }

                if(openedBrackets.Count == 0 || openedBrackets.Peek() != bracketType) 
                {
                    return false;
                }

                openedBrackets.Pop();
            }

            return openedBrackets.Count == 0;
        }
    }
}