public class CustomProcess
{
    public int Id { get; set; }
    public int BurstTime { get; set; }

    public CustomProcess(int id, int burstTime)
    {
        Id = id;
        BurstTime = burstTime;
    }
}

public class ProcessScheduler
{
    Queue<CustomProcess> queue;

    public ProcessScheduler()
    {
        queue = new Queue<CustomProcess>();
    }

    public void AddProcess(CustomProcess process)
    {
        queue.Enqueue(process);
    }

    public async void RunFIFO()
    {
        while (queue.Count > 0)
        {
            var process = queue.Dequeue();
            Console.WriteLine($"Процесс {process.Id} выполняется.");
            await Task.Delay(process.BurstTime);
            Console.WriteLine($"Процесс {process.Id} завершён.");
        }
    }

    public void RunProcessesConcurrently()
    {
        while (queue.Count > 0)
        {
            var process = queue.Dequeue();
            Task.Run(async () =>
            {
                Console.WriteLine($"Процесс {process.Id} запущен.");
                await Task.Delay(process.BurstTime);
                Console.WriteLine($"Процесс {process.Id} завершён.");
            });
        }
    }
}
class Program
{
    static void Main(string[] args)
    {

    }
}
