public int MaxTwoEvents(int[][] events) =>
    events
        .SelectMany(e => new[] {
            (Time: e[0], IsStart: true, Value: e[2]),
            (Time: e[1] + 1, IsStart: false, Value: e[2])})
        .Order()
        .Aggregate(
            (Result: 0, MaxEnded: 0),
            (a, e) => e.IsStart
                ? (Math.Max(a.Result, e.Value + a.MaxEnded), a.MaxEnded)
                : (a.Result, Math.Max(a.MaxEnded, e.Value)),
            a => a.Result);
