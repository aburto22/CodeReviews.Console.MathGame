using Microsoft.VisualBasic;

namespace MathGame;

internal static class MockDatabase
{
  private static readonly List<Result> results = [];

  internal static Result AddResult(int correct, int total, GameType gameType, Level level, TimeSpan duration)
  {
    Result result = new Result(results.Count + 1, correct, total, gameType, level, duration);
    results.Add(result);
    return result;
  }

  internal static List<Result> GetResults()
  {
    return results;
  }
}