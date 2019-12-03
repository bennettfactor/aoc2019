using Xunit;

namespace Day2.Tests
{
    public class IntcodeRunnerTests
    {
        [Fact]
        public void Sample1()
        {
            var output = IntcodeRunner.Run("1,0,0,0,99".ToOpcodes()).ToStringValue();
            Assert.Equal("2,0,0,0,99", output);
        }

        [Fact]
        public void Sample2()
        {
            var output = IntcodeRunner.Run("2,3,0,3,99".ToOpcodes()).ToStringValue();
            Assert.Equal("2,3,0,6,99", output);
        }

        [Fact]
        public void Sample3()
        {
            var output = IntcodeRunner.Run("2,4,4,5,99,0".ToOpcodes()).ToStringValue();
            Assert.Equal("2,4,4,5,99,9801", output);
        }


        [Fact]
        public void Sample4()
        {
            var output = IntcodeRunner.Run("1,1,1,4,99,5,6,0,99".ToOpcodes()).ToStringValue();
            Assert.Equal("30,1,1,4,2,5,6,0,99", output);
        }
    }
}
