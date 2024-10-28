namespace MathGame;

internal class DivisionExercise(string question, int expected) : Exercise(question, expected)
{
  internal static DivisionExercise CreateEasyExercise()
  {
    Random dice = new();

    int second = dice.Next(1, 5);
    int result = dice.Next(1, 10);
    int first = result * second;

    return new DivisionExercise($"{first} / {second}", result);
  }

  internal static DivisionExercise CreateMediumExercise()
  {
    Random dice = new();

    int second = dice.Next(5, 10);
    int result = dice.Next(10, 20);
    int first = result * second;

    return new DivisionExercise($"{first} / {second}", result);
  }

  internal static DivisionExercise CreateHardExercise()
  {
    Random dice = new();

    int second = dice.Next(10, 20);
    int result = dice.Next(20, 50);
    int first = result * second;

    return new DivisionExercise($"{first} / {second}", result);
  }
}