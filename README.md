# AOC-2022
![Actions Status](https://github.com/ExtraBB/aoc-2022/actions/workflows/dotnet.yml/badge.svg)

This repository contains my solutions for Advent of Code 2022.

## Running the solutions
The solutions are implemented as a class library. The only way to run them is via the xUnit test project:

```
dotnet test aoc-2022-test
```

## Benchmarking the solutions
The solutions can be benchmarked using the `aoc-2022-benchmark` project:

```
dotnet test aoc-2022-benchmark
```

## Input data
The input data is stored in the `aoc-2022-data` project, which is referenced by both the `aoc-2022-test` and `aoc-2022-benchmark` project.