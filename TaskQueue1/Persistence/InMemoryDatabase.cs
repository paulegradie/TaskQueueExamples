using TaskQueue1.Persistence.Tables;

namespace TaskQueue1.Persistence;

internal class InMemoryDatabase
{
    public TaskTable TaskTable { get; } = new();
}