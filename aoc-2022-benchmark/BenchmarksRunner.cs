using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using Xunit.Abstractions;

namespace aoc_2022_benchmark
{
    public class BenchmarksRunner
    {
        private readonly ITestOutputHelper output;

        public BenchmarksRunner(ITestOutputHelper output)
        {
            this.output = output;
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
    }
}
