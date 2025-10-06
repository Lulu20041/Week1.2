
using System.Threading.Tasks;
using System.Diagnostics;

string file1 = "Файл 1";
string file2 = "Файл 2";
string file3 = "Файл 3";

Stopwatch watch = new Stopwatch();

Console.WriteLine("Синхронно");
watch.Start();
Console.WriteLine(ProcessData(file1));
Console.WriteLine(ProcessData(file2));
Console.WriteLine(ProcessData(file3));
watch.Stop();

TimeSpan ts = watch.Elapsed;
Console.WriteLine("Обработка всех файлов завершена за " + ts);
watch.Reset();

Console.WriteLine("Асинхронно");
watch.Start();
var task1 = ProcessDataAsync(file1);
var task2 = ProcessDataAsync(file2);
var task3 = ProcessDataAsync(file3);


await Task.WhenAll(task1, task2, task3).ContinueWith(t => watch.Stop());

var results = await Task.WhenAll(task1, task2, task3);

foreach (var result in results)
{
    Console.WriteLine(result);
}

ts = watch.Elapsed;
Console.WriteLine("Обработка всех файлов завершена за " + ts);




string ProcessData(string dataName)
{
    Stopwatch watch = new Stopwatch();
    watch.Start();
    Thread.Sleep(3000);
    watch.Stop();
    TimeSpan ts = watch.Elapsed;
    return $"Обработка {dataName} завершена за {ts}";
}

async Task<string> ProcessDataAsync(string dataName)
{
    Stopwatch watch = new Stopwatch();
    watch.Start();
    await Task.Delay(3000);
    watch.Stop();
    TimeSpan ts = watch.Elapsed;
    return $"Обработка {dataName} завершена за {ts}";
}