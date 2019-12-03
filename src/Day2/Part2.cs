using System;
using System.Linq;

namespace Day2
{
    public class Part2
    {
        public (int noun, int verb) GetNounAndVerb(string input, int desiredOutput)
        {
            var opcodes = input.ToOpcodes();

            for (int i = 0; i <= 99; i++)
            {
                for (int j = 0; j <= 99; j++)
                {
                    var newOpcodes = opcodes.ToArray();
                    newOpcodes[1] = i;
                    newOpcodes[2] = j;

                    var output = IntcodeRunner.Run(newOpcodes);
                    if (output[0] == desiredOutput)
                    {
                        return (i, j);
                    }
                }
            }

            throw new ArgumentException("Invalid input.");
        }
    }
}
