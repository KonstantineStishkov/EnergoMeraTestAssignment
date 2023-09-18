using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketsRightSequence
{
    public enum BracketType
    {
        Common,
        Square,
        Curly
    }

    public struct Brackets
    {
        public char Start;
        public char End;

        public Brackets(char start, char end)
        {
            Start = start;
            End = end;
        }
    }

    public class BracketCollection
    {
        public static Dictionary<BracketType, Brackets> CommonBrackets => new Dictionary<BracketType, Brackets>()
        {
            { BracketType.Common, new Brackets('(', ')') },
            { BracketType.Square, new Brackets('[', ']') },
            { BracketType.Curly, new Brackets('{', '}') },
        };

        public static bool HasAny(char c)
        {
            return CommonBrackets.Any(b => b.Value.Start.Equals(c) || b.Value.End.Equals(c));
        }

        public static KeyValuePair<BracketType, Brackets>? GetBrackets(char c)
        {
            return CommonBrackets.FirstOrDefault(b => b.Value.Start.Equals(c) || b.Value.End.Equals(c));
        }
    }
}
