using FluentAssertions;

namespace Algorithms.Another;

public class GraphTests
{
    public class Graph
    {
        public Graph(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public Graph[] Children { get; init; } = Array.Empty<Graph>();

        public static IReadOnlyCollection<int> GetAllIdsWithDfsRecurse(Graph parent)
        {
            var ids = new List<int> { parent.Id };
            GetChildrenRecurse(parent.Children, ids);

            return ids;
        }

        private static void GetChildrenRecurse(IEnumerable<Graph> graphs, ICollection<int> ids)
        {
            foreach (Graph graph in graphs)
            {
                ids.Add(graph.Id);
                GetChildrenRecurse(graph.Children, ids);
            }
        }

        public static IReadOnlyCollection<int> GetIdsWithBfs(Graph graph)
        {
            var ids = new List<int> { graph.Id };
            var queue = new Queue<Graph>();
            queue.Enqueue(graph);

            while (queue.Count > 0)
            {
                Graph currentNode = queue.Dequeue();
                foreach (Graph child in currentNode.Children)
                {
                    ids.Add(child.Id);
                    queue.Enqueue(child);
                }
            }

            return ids;
        }
    }

    private readonly Graph _graph = new Graph(0)
    {
        Children = new[]
        {
            new Graph(1)
            {
                Children = new[]
                {
                    new Graph(11),
                    new Graph(12)
                    {
                        Children = new[]
                        {
                            new Graph(121)
                        }
                    },
                    new Graph(13),
                }
            },
            new Graph(2)
            {
                Children = new[]
                {
                    new Graph(21)
                    {
                        Children = new[]
                        {
                            new Graph(211)
                        }
                    }
                }
            },
        }
    };

    [Fact]
    public void DfsTest()
    {
        Graph.GetAllIdsWithDfsRecurse(_graph).Should().BeEquivalentTo(new[] { 0, 1, 11, 12, 121, 13, 2, 21, 211 });
    }

    [Fact]
    public void BfsTest()
    {
        Graph.GetIdsWithBfs(_graph).Should().BeEquivalentTo(new[] { 0, 1, 2, 11, 12, 13, 21, 121, 211 });
    }
}