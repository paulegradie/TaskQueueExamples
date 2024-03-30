namespace TaskQueue1.Persistence.Tables;

public class QueueTask(int id, bool isProcessed, TaskState taskState)
{
    public int Id { get; } = id;
    public bool IsProcessed { get; private set; } = isProcessed;
    private TaskState TaskState { get; set; } = taskState;
    public DateTime UpdatedAt { get; set; }
    
    public void SetToStarted()
    {
        if (!TaskState.Equals(TaskState.Pending))
        {
            throw new InvalidOperationException("Task state is not 'pending'");
        }

        TaskState = TaskState.Started;
        UpdatedAt = DateTime.Now;
    }

    public void SetToComplete()
    {
        if (!TaskState.Equals(TaskState.Started))
        {
            throw new InvalidOperationException("Task not started");
        }

        IsProcessed = true;
        TaskState = TaskState.Completed;
        UpdatedAt = DateTime.Now;
    }
}