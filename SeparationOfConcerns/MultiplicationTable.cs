using System.Text;

namespace SeparationOfConcerns;

public class MultiplicationTable
{
    private readonly List<uint> _numbers;
    private readonly Lazy<List<List<uint>>> _resultGrid;
    private readonly Lazy<int> _columnWidth;

    public List<List<uint>> ResultGrid => _resultGrid.Value;
    private int ColumnWidth => _columnWidth.Value;

    public MultiplicationTable(params uint[] numbers)
    {
        _numbers = numbers.ToList();
        _resultGrid = new Lazy<List<List<uint>>>(CalculateTable);
        _columnWidth = new Lazy<int>(CalculateColumnWidth);
    }

    private List<List<uint>> CalculateTable() => _numbers.Select(row => _numbers.Select(col => row * col).ToList()).ToList();

    private int CalculateColumnWidth() => (int)Math.Log10(ResultGrid.SelectMany(row => row).Max()) + 2;

    public override string ToString()
    {
        return new StringBuilder()
            .AppendFormat($"{{0,{ColumnWidth}}}", "*").Append(" ||").AppendLine(CreateHeader())
            .AppendLine(CreateSeparator())
            .AppendJoin(Environment.NewLine, CreateRows())
            .ToString();
    }

    private IEnumerable<string> CreateRows() => _numbers.Select((num, index) => FormatNumber(num) + " ||" + string.Join(" |", ResultGrid[index].Select(FormatNumber)) + " |");

    private string CreateHeader() => string.Join(" |", _numbers.Select(FormatNumber)) + " |";

    private string CreateSeparator() => new('=', ColumnWidth * (_numbers.Count + 1) + 2 * _numbers.Count + 3);

    private string FormatNumber(uint number) => string.Format($"{{0,{ColumnWidth}}}", number);
}
