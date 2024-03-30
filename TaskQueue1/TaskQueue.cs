using TaskQueue1.Persistence.Tables;

namespace TaskQueue1;

internal class TaskQueue
{
    private readonly TaskRepository _taskRepository;

    public TaskQueue(TaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task StartMainTaskLoop(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var task = await CheckForNewTask();
            if (task is null)
            {
                Console.WriteLine("No new tasks yet...");
            }
            else
            {
                try
                {
                    await ProcessNewTask(task);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing task");
                }
            }

            await Task.Delay(2_000, cancellationToken);
        }
    }

    private async Task ProcessNewTask(QueueTask task)
    {
        task.SetToStarted();
        Console.WriteLine($"Processing Task: {task.Id}");
        task.SetToComplete();
        await Task.CompletedTask;
    }

    private Task<QueueTask?> CheckForNewTask()
    {
        return Task.FromResult(_taskRepository.GetNextTask());
    }
}