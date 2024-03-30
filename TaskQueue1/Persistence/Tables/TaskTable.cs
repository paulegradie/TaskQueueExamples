namespace TaskQueue1.Persistence.Tables;

internal class TaskTable
{
    public Dictionary<int, QueueTask> Tasks { get; } = new();
}