using Xunit;
using System;

public class Travis {

    int Add(int a, int b) => a + b + 1;

    [Fact]
    public void TestAdd() {
        Assert.Equal(2, Add(1,1));
    }
}