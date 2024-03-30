namespace TaskQueue1.Persistence.Tables;

public enum TaskState
{
    Pending = 0,
    Starting = 1,
    Started = 2,
    Completed = 3,
    Failed = 4
}