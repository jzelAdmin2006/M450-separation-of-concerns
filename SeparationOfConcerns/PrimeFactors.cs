using System.Data;

public class PrimeFactors
{
    private readonly List<uint> _numbers;
    private readonly Lazy<Dictionary<uint, List<uint>>> _result;

    public Dictionary<uint, List<uint>> Result => _result.Value;

    public PrimeFactors(params uint[] numbers)
    {
        _numbers = numbers.ToList();
        _result = new Lazy<Dictionary<uint, List<uint>>>(CalculatePrimeFactors);
    }

    private Dictionary<uint, List<uint>> CalculatePrimeFactors()
    {
        return _numbers.ToDictionary(number => number, CalculatePrimeFactors);
    }

    private List<uint> CalculatePrimeFactors(uint number)
    {
        var factors = new List<uint>();

        foreach (var factor in PossiblePrimeFactors(number))
        {
            while (number % factor == 0)
            {
                factors.Add(factor);
                number /= factor;
            }
        }

        if (number > 1)
            factors.Add(number);

        return factors;
    }

    private static IEnumerable<uint> PossiblePrimeFactors(uint number)
    {
        return Enumerable.Range(2, (int)Math.Sqrt(number) - 1)
                                                 .Select(n => (uint)n)
                                                 .Where(n => number % n == 0);
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, Result.Select(pair => $"{pair.Key}: {string.Join(" ", pair.Value)}"));
    }
}
