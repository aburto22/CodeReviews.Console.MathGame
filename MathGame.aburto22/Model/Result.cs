using Microsoft.VisualBasic;

namespace MathGame;

internal class Result(int id, int score, int max, GameType gameType, Level level, TimeSpan duration)
{
  internal readonly int Id = id;
  internal readonly int Score = score;
  internal readonly int Max = max;
  internal readonly GameType GameType = gameType;
  internal readonly Level Level = level;
  internal readonly TimeSpan Duration = duration;

  internal void DisplayResult()
  {
    Console.WriteLine($"{Id}: {GameType} ({Level}): {Score}/{Max} ({Score / (decimal)Max:P0}). Completed on {Duration:mm\\:ss}");
  }
}