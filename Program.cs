
using System.Threading.Tasks;

string file1 = "Файл 1";
string file2 = "Файл 2";
string file3 = "Файл 3";

Console.WriteLine("Синхронно");

Console.WriteLine(ProcessData(file1));
Console.WriteLine(ProcessData(file2));
Console.WriteLine(ProcessData(file3));

Console.WriteLine("Асинхронно");

var task1 = ProcessDataAsync(file1);
var task2 = ProcessDataAsync(file2);
var task3 = ProcessDataAsync(file3);

var results = await Task.WhenAll(task1, task2, task3);

foreach (var result in results)
{
    Console.WriteLine(result);
}

string ProcessData(string dataName)
{
    Thread.Sleep(3000);
    return $"Обработка {dataName} завершена за 3 секунды";
}

async Task<string> ProcessDataAsync(string dataName)
{
    await Task.Delay(3000);
    return $"Обработка {dataName} завершена за 3 секунды";
}