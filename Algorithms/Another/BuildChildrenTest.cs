using FluentAssertions;

namespace Algorithms.Another;

public class BuildChildrenTest
{
    private record Empl(int Id, int ParentId, IEnumerable<int> Children = null)
    {
        public int Id = Id; // unique
        public int ParentId = ParentId;
        public IEnumerable<int> Children = Children; // ?    
    }

    // in
    //             {1, 0, null}
    //     {11, 1, null}   {12, 1, null}
    // {111, 11, null}


    // out
    //               {1, 0, [11, 12]}
    //     {11, 1, [111]}   {12, 1, []}
    // {111, 11, []}

    [Fact]
    public void RunTest()
    {
        var input = new[]
        {
            new Empl(1, 0),
            new Empl(11, 1),
            new Empl(12, 1),
            new Empl(111, 11)
        };

        IEnumerable<Empl> outPut = BuildChildren(input);
        outPut.Should().BeEquivalentTo(new[]
        {
            new Empl(1, 0, new[] { 11, 12 }),
            new Empl(11, 1, new[] { 111 }),
            new Empl(12, 1, Array.Empty<int>()),
            new Empl(111, 11, Array.Empty<int>())
        });
    }

    private static IEnumerable<Empl> BuildChildren(IReadOnlyCollection<Empl> empls)
    {
        var result = new List<Empl>(empls.Select(e => e with { Children = Array.Empty<int>() }));
        foreach (IGrouping<int, int> team in empls.GroupBy(k => k.ParentId, v => v.Id))
        {
            Empl head = result.FirstOrDefault(x => x.Id == team.Key);
            if (head == null)
                continue;

            head.Children = team.ToArray();
        }

        return result;
    }
}