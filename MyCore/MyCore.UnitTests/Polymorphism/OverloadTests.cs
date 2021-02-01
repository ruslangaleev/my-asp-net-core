using System;
using System.Collections.Generic;
using System.Text;
using MyCore.Services.Polymorphism;
using Xunit;

namespace MyCore.UnitTests.Polymorphism
{
    public class OverloadTests
    {
        [Fact]
        public void TestA()
        {
            var overload = new Overload();

            var result = overload.DisplayOverload(1);

            Assert.Equal(1, result);
        }

        [Fact]
        public void TestB()
        {
            var overload = new Overload();

            var value = 5;

            // статика недоступна!
            //var result = overload.DisplayOverload(out value);
            var result = Overload.DisplayOverload(out value);

            Assert.Equal(5, value);
            Assert.Equal(10, result);
        }

        [Fact]
        public void TestC()
        {
            var overload = new Overload();

            var p1 = new int[] {1, 2, 3};
            var p2 = new int[] {4, 5, 6};

            var result = overload.DisplayOverload(p1, p2);

            Assert.Equal(21, result);
        }
    }
}
