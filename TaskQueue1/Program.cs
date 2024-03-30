using TaskQueue1;
using TaskQueue1.Persistence;

var cancellationToken = new CancellationTokenSource().Token;

var database = new InMemoryDatabase();
var taskRepository = new TaskRepository(database);

var queue = new TaskQueue(taskRepository);
var thread = new Thread(() => queue.StartMainTaskLoop(cancellationToken));
thread.Start();

while (true)
{
    Console.WriteLine("Adding a new task...");
    taskRepository.AddNewTask();
    await Task.Delay(5_000, cancellationToken);
}