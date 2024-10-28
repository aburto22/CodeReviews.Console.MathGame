namespace MathGame;

internal class MultiplyExercise(string question, int expected) : Exercise(question, expected)
{
  internal static MultiplyExercise CreateEasyExercise()
  {
    Random dice = new();

    int first = dice.Next(1, 10);
    int second = dice.Next(1, 5);
    int result = first * second;

    return new MultiplyExercise($"{first} * {second}", result);
  }

  internal static MultiplyExercise CreateMediumExercise()
  {
    Random dice = new();

    int first = dice.Next(10, 50);
    int second = dice.Next(5, 10);
    int result = first * second;

    return new MultiplyExercise($"{first} * {second}", result);
  }

  internal static MultiplyExercise CreateHardExercise()
  {
    Random dice = new();

    int first = dice.Next(10, 50);
    int second = dice.Next(10, 20);
    int result = first * second;

    return new MultiplyExercise($"{first} * {second}", result);
  }
}