using FluentAssertions;

namespace Algorithms.Another;

public class SeaFight
{
    public static IEnumerable<object[]> ShipsData => new[] { new object[] { ShipsField, ShipsCount } };

    private static readonly bool[,] ShipsField =
    {
        { true,  false, false, false },
        { false, false, true,  true  },
        { true,  false, false, false },
        { true,  false, false, true  }
    };
    private static readonly int ShipsCount = 4;


    [Theory]
    [MemberData(nameof(ShipsData))]
    public void CalculateShips(bool[,] matrix, int expectedCount)
    {
        int width = matrix.GetLength(0);
        int height = matrix.GetLength(1);

        int count = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                bool ship = matrix.SafetyGetItem(i, j);
                if (!ship)
                    continue;

                bool right = matrix.SafetyGetItem(i, j + 1);
                bool bottom = matrix.SafetyGetItem(i + 1, j);
                if (!right && !bottom)
                    count++;
            }
        }

        count.Should().Be(expectedCount);
    }
}