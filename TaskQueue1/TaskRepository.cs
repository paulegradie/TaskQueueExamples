using TaskQueue1.Persistence;
using TaskQueue1.Persistence.Tables;

namespace TaskQueue1;

internal class TaskRepository(InMemoryDatabase inMemoryDatabase)
{
    public void AddNewTask()
    {
        var newId = 0;
        var keys = inMemoryDatabase.TaskTable.Tasks.Keys;
        if (keys.Count > 0)
        {
            newId = inMemoryDatabase.TaskTable.Tasks.Keys.Max() + 1;
        }

        inMemoryDatabase.TaskTable.Tasks.Add(newId, new QueueTask(newId, false, TaskState.Pending));
    }

    public QueueTask? GetNextTask()
    {
        var ids = inMemoryDatabase.TaskTable.Tasks.Keys.Order().ToList();
        foreach (var id in ids)
        {
            if (!inMemoryDatabase.TaskTable.Tasks.TryGetValue(id, out var task)) continue;
            if (task.IsProcessed) continue;
            return task;
        }

        return null;
    }
}