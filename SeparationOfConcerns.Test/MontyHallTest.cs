namespace SeparationOfConcerns.Test;

public class MontyHallTest
{
    [Fact]
    public void TestStatsAreRealistic()
    {
        var montyHall = new MontyHall(new());

        montyHall.Play(1000);

        Assert.Equal(1000u, montyHall.TimesPlayed);
        Assert.InRange(montyHall.TimesWonSticking, 233u, 433u);
        Assert.InRange(montyHall.TimesWonSwitching, 566u, 766u);
        Assert.InRange(montyHall.WinPercentageSticking, 23.3, 43.3);
        Assert.InRange(montyHall.WinPercentageSwitching, 56.6, 76.6);
    }

    [Fact]
    public void TestFormattingIsCorrect()
    {
        var montyHall = new MontyHall(new FakeRandom());

        montyHall.Play(3);
        var result = montyHall.ToString();

        Assert.Equal("played 3 times" + Environment.NewLine +
                     "won 0 times by sticking to choice" + Environment.NewLine +
                     "won 3 times by changing the choice" + Environment.NewLine +
                     "sticking wins 0% of games" + Environment.NewLine +
                     "changing wins 100% of games", result);
    }

    private class FakeRandom : Random
    {
        public override int Next(int maxValue)
        {
            return int.MinValue;
        }
    }
}