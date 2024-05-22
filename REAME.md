Benchmark comparing traditional foreach and Parallel.ForEach and Parallel.ForEach using Partitioner.

Here we clearly see that traditional foreach ie way faster than other options, but
you should keep in mind that if you are doing any bulk task inside the foreach loop then use Parallel.Foreach is very fast so you can go for Parallel.Foreach. But if you're just iterating and doing a little tasks inside loop then go for traditional for loop. 