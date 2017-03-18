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

        (int x, int y) GetValue() => (1,2);
        (int, int) GetValue2() => (100, 200);

        (int age, string name, double salary) GetInfo() => (20, "wk", 100.0);

        int Process((int x, string y, double z) p) => p.x;

        [Fact]
        public void ValueTuples() {
            var (a,b) = (100, 200);

            var (x,y) = GetValue();
            var value = GetValue();
            Assert.True(x == 1);
            Assert.True(y == 2);
            Assert.True(value.ToTuple().Item1 == 1);

            var value2 = GetValue2();
            Assert.True(value2.Item1 == 100);

            var (age, name, salary) = GetInfo();
            Assert.True(age == 20);

            var p = (100, "wk", 100.0);
            var result = Process(p);
            Assert.True(result == 100);
        }

        [Fact]
        public void LocalFunction() {
            var v = GetValue();
            Assert.True(v == 100);

            int GetValue() => 100;
        }

        // Old Value Pattern => Swich Case 
        // C# 7 Type Pattern => Pattern Matching

        [Fact]
        public void PatternMaching() {
            Car x = new Toyota { T = 100 };
            switch(x) {
                case Toyota t when (t.T == 100) :
                    Assert.True(t.T == 100);
                    break;
                case Nisson n :
                    break;
                default:
                    break;
            }
        }
    }
    class Car {}
    class Toyota : Car {
        public int T { set;get; }
    }
    class Nisson : Car {
        public int N { set;get;}
    }
}