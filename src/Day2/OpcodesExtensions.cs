using System.Linq;

namespace Day2
{
    public static class OpcodesExtensions
    {
        public static string ToStringValue(this int[] opcodes)
            => string.Join(',', opcodes);

        public static int[] ToOpcodes(this string input)
            => input
                .Split(',')
                .Select(c => int.Parse(c))
                .ToArray();
    }
}
