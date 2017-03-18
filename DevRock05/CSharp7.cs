using Xunit;
using System;

namespace DevRock05
{
    public class CSharp7
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

        // C# 6
        int GetData() => 5;
        int Multiply(int a, int b) => a * b;

        int _a = 0;
        public int A { 
            get => _a; 
            set => _a = value; 
        }

        public CSharp7() => _a = 100; 

        [Fact]
        public void ExpressionBodyMember() {
            int GetData() => 5;

            var value = GetData();
            Assert.True(value == 5);
        }

        [Fact]
        public void BinaryLiteral() {
            var x = 100_100;
            Assert.True(x == 100_100);

            Assert.True(7 == 0b111);

            var k  = 100_100.00_01;
        }

        [Fact]
        public void ValueTuples() {
            var (a,b) = (100, 200);
        }
    }
}