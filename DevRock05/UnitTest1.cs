using Xunit;
using System;

namespace DevRock05
{
    public class UnitTest1
    {
        ref int Test(int index, ref int[] array) {
            return ref array[index];
        }

        [Fact]
        public void RefReturn() {
            var a = new int [] { 1,2,3};
            ref var index = ref Test(0, ref a);
            Assert.True(index == 1);

            index = 100;

            Assert.Equal(a, new [] { 100, 2, 3});
        }

        int Go(object a) {
            var x = a ?? throw new Exception("ex");
            return 0;
        }

        [Fact]
        public void ThrowExcpetion() {
            Exception ex = Assert.Throws<Exception>(() => Go(null));
            Assert.Equal(ex.Message, "ex");
        }

    }
}
