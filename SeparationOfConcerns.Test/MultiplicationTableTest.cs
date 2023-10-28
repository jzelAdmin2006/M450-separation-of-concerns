namespace SeparationOfConcerns.Test;

public class MultiplicationTableTest
{
    [Fact]
    public void TestResultGridContainsProducts()
    {
        var table = new MultiplicationTable(1, 2, 3);

        var result = table.ResultGrid;

        Assert.Equal(new List<List<uint>>()
        {
            new List<uint>() { 1, 2, 3 },
            new List<uint>() { 2, 4, 6 },
            new List<uint>() { 3, 6, 9 }
        }, result);
    }

    [Fact]
    public void TestFormattingIsCorrect()
    {
        var table = new MultiplicationTable(1, 2, 3);

        var result = table.ToString();

        Assert.Equal(" * || 1 | 2 | 3 |" + Environment.NewLine +
                     "=================" + Environment.NewLine +
                     " 1 || 1 | 2 | 3 |" + Environment.NewLine +
                     " 2 || 2 | 4 | 6 |" + Environment.NewLine +
                     " 3 || 3 | 6 | 9 |", result);
    }
}