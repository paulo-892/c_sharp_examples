using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max) =>
        (
            from multiple in multiples
            where multiple != 0
            select Enumerable.Range(multiple, int.Max(0, max - multiple)
                )
                .Where(x => x % multiple == 0)
                .ToList()).ToList().SelectMany(x => x).ToHashSet().Sum();
}