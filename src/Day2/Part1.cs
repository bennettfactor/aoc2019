namespace Day2
{
    public class Part1
    {
        public int Solve(string input, int pos1Value, int pos2Value)
        {
            var opcodes = input.ToOpcodes();

            opcodes[1] = pos1Value;
            opcodes[2] = pos2Value;

            return IntcodeRunner.Run(opcodes)[0];
        }
    }
}
