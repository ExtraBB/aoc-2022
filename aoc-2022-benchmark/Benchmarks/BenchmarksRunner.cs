using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using System.Runtime.CompilerServices;
using Xunit.Abstractions;

namespace aoc_2022_test.Benchmarks
{
    public class BenchmarksRunner
    {
        private readonly ITestOutputHelper output;

        public BenchmarksRunner(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [MemberData(nameof(GetBenchmarkData))]
        public void RunIndividualBenchmarks(int day, int part)
        {
            var logger = new AccumulationLogger();

            var config = ManualConfig.Create(DefaultConfig.Instance)
                .AddLogger(logger)
                .AddFilter(new BenchmarkDotNet.Filters.NameFilter(name => name == $"Day{day}Part{part}"))
                .WithOptions(ConfigOptions.DisableOptimizationsValidator);

            BenchmarkRunner.Run<DaysBenchmark>(config);

            output.WriteLine(logger.GetLog());
        }

        [Fact]
        public void RunAllBenchmarks()
        {
            var logger = new AccumulationLogger();

            var config = ManualConfig.Create(DefaultConfig.Instance)
                .AddLogger(logger)
                .WithOptions(ConfigOptions.DisableOptimizationsValidator);

            BenchmarkRunner.Run<DaysBenchmark>(config);

            output.WriteLine(logger.GetLog());
        }

        public static IEnumerable<object[]> GetBenchmarkData()
        {
            List<object[]> data = new List<object[]>();
            for(int i = 1; i <= 24; i++)
            {
                data.Add(new object[] { i, 1 });
                data.Add(new object[] { i, 2 });
            }
            return data;
        }
    }
}
