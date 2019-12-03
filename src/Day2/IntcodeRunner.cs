using System.Linq;

namespace Day2
{
    public static class IntcodeRunner
    {
        public static int[] Run(int[] opcodes)
        {
            for (int i = 0; opcodes[i] != 99; i += 4)
            {
                var operation = opcodes[i];

                var input1 = opcodes[opcodes[i + 1]];
                var input2 = opcodes[opcodes[i + 2]];

                int result = 0;
                if (operation == 1)
                {
                    result = input1 + input2;
                }
                else if (operation == 2)
                {
                    result = input1 * input2;
                }

                opcodes[opcodes[i + 3]] = result;
            }

            return opcodes;
        }
    }
}
