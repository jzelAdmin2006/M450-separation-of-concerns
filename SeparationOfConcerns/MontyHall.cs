public class MontyHall
{
    public uint TimesPlayed { get; private set; }
    public uint TimesWonSticking { get; private set; }
    public uint TimesWonSwitching => TimesPlayed - TimesWonSticking;
    public double WinPercentageSticking => WinPercentage(TimesWonSticking);
    public double WinPercentageSwitching => WinPercentage(TimesWonSwitching);

    private readonly Random rand;

    public MontyHall(Random rand)
    {
        this.rand = rand;
    }

    public void Play(uint times)
    {
        TimesPlayed += times;
        for (int i = 0; i < times; i++)
        {
            if (StickingWinChance()) TimesWonSticking++;
        }
    }

    private bool StickingWinChance()
    {
        return rand.Next(3) == 0;
    }

    private double WinPercentage(uint TimesWon)
    {
        return (double)TimesWon / TimesPlayed * 100;
    }

    public override string ToString()
    {
        return $"played {TimesPlayed} times" + Environment.NewLine +
               $"won {TimesWonSticking} times by sticking to choice" + Environment.NewLine +
               $"won {TimesWonSwitching} times by changing the choice" + Environment.NewLine +
               $"sticking wins {WinPercentageSticking}% of games" + Environment.NewLine +
               $"changing wins {WinPercentageSwitching}% of games";
    }
}