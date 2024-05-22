// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;
using System.Diagnostics;

List<string> fruits =
[
    "Apple",
    "Banana",
    "Bilberry",
    "Blackberry",
    "Blackcurrant",
    "Blueberry",
    "Cherry",
    "Coconut",
    "Cranberry",
    "Date",
    "Fig",
    "Grape",
    "Guava",
    "Jack-fruit",
    "Kiwi fruit",
    "Lemon",
    "Lime",
    "Lychee",
    "Mango",
    "Melon",
    "Olive",
    "Orange",
    "Papaya",
    "Plum",
    "Pineapple",
    "Pomegranate",
];

  Console.WriteLine("Printing list using foreach loop\n");

  var stopWatch = Stopwatch.StartNew();
  foreach (string fruit in fruits)
  {
      Console.WriteLine("Fruit Name: {0}, Thread Id= {1}", fruit, Thread.CurrentThread.ManagedThreadId);
  }
  Console.WriteLine("foreach loop execution time = {0} seconds\n", stopWatch.Elapsed.TotalSeconds);
  Console.WriteLine("Printing list using Parallel.ForEach");


  stopWatch = Stopwatch.StartNew();
  Parallel.ForEach(fruits, fruit =>
  {
      Console.WriteLine("Fruit Name: {0}, Thread Id= {1}", fruit, Thread.CurrentThread.ManagedThreadId);

  }
  );
  Console.WriteLine("Parallel.ForEach() execution time = {0} seconds", stopWatch.Elapsed.TotalSeconds);


  stopWatch = Stopwatch.StartNew();
  var rangePartitioner = Partitioner.Create(0, fruits.Count);
  string[] results = new string[fruits.Count];
  Parallel.ForEach(rangePartitioner, (range, loopState) =>
  {
    // Loop over each range element without a delegate invocation.
    for (int i = range.Item1; i < range.Item2; i++)
    {
        results[i] = fruits[i] + " partitioned";
        Console.WriteLine("Fruit Name: {0}, Thread Id= {1}", results[i], Thread.CurrentThread.ManagedThreadId);
    }
  }
  );
  Console.WriteLine("Parallel.ForEach() using Partitioner execution time = {0} seconds", stopWatch.Elapsed.TotalSeconds);

  Console.Read();
