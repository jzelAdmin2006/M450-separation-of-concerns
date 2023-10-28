namespace SeparationOfConcerns.Test;

public class PrimeFactorsTest
{
    [Fact]
    public void TestResultContainsPrimeFactors()
    {
        var factors = new PrimeFactors(42, 99, 1234);

        var result = factors.Result;

        Assert.Equal(new Dictionary<uint, List<uint>>()
        {
            { 42, new List<uint>() { 2, 3, 7 } },
            { 99, new List<uint>() { 3, 3, 11 } },
            { 1234, new List<uint>() { 2, 617 } }
        }, result);
    }

    [Fact]
    public void TestFormattingIsCorrect()
    {
        var factors = new PrimeFactors(42, 99, 1234);

        var result = factors.ToString();

        Assert.Equal("42: 2 3 7" + Environment.NewLine +
                     "99: 3 3 11" + Environment.NewLine +
                     "1234: 2 617", result);
    }
}