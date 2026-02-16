// See https://aka.ms/new-console-template for more information
using aoc2025;
using System.Diagnostics.Metrics;


Console.WriteLine("01. test.txt: {0}", _01.start("test.txt"));
Console.WriteLine("01. data.txt: {0}", _01.start("data.txt"));

Console.WriteLine("01_2. test.txt: {0}", _01_2.start("test.txt"));
Console.WriteLine("01_2. data.txt: {0}", _01_2.start("data.txt"));

Console.WriteLine("02. test.txt: {0}", _02.start("test.txt"));
Console.WriteLine("02. data.txt: {0}", _02.start("data.txt"));

Console.WriteLine("02_2. test.txt: {0}", _02_2.start("test.txt"));
// Console.WriteLine("02_2. data.txt: {0}", _02_2.start("data.txt"));

Console.WriteLine("03. test.txt: {0}", _03.start("test.txt"));
Console.WriteLine("03. data.txt: {0}", _03.start("data.txt"));

Console.WriteLine("03_2. test.txt: {0}", _03_2.start("test.txt"));
Console.WriteLine("03_2. data.txt: {0}", _03_2.start("data.txt"));

Console.WriteLine("04. test.txt: {0}", _04.start("test.txt"));
Console.WriteLine("04. data.txt: {0}", _04.start("data.txt"));

Console.WriteLine("04_2. test.txt: {0}", _04_2.start("test.txt"));
// Console.WriteLine("04_2. data.txt: {0}", _04_2.start("data.txt"));

Console.WriteLine("05. test.txt: {0}", _05.start("test.txt"));
Console.WriteLine("05. data.txt: {0}", _05.start("data.txt"));

Console.WriteLine("05_2. test.txt: {0}", _05.start2("test.txt"));
Console.WriteLine("05_2. data.txt: {0}", _05.start2("data.txt"));

Console.WriteLine("06. test.txt: {0}", _06.start("test.txt"));
Console.WriteLine("06. data.txt: {0}", _06.start("data.txt"));

Console.WriteLine("06_2. test.txt: {0}", _06.start2("test.txt"));
Console.WriteLine("06_2. data.txt: {0}", _06.start2("data.txt"));

Console.WriteLine("07. test.txt: {0}", _07.start("test.txt"));
Console.WriteLine("07. data.txt: {0}", _07.start("data.txt"));

/* bool isTimelineCalcDone = false;
int _07Counter = 0;
_07.start3("test.txt", (int counter) =>
{
    _07Counter += counter;
});

while (!isTimelineCalcDone)
{
    var oldCounter = _07Counter;
    Thread.Sleep(500);

    if (oldCounter == _07Counter)
    {
        isTimelineCalcDone = true;
    }
}
Console.WriteLine("07_2. test.txt: {0}", _07Counter); */
Console.WriteLine("07_2. test.txt: {0}", _07.start4("test.txt"));
Console.WriteLine("07_2. data.txt: {0}", _07.start4("data.txt"));