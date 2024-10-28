namespace MathGame;

internal class SubtractionExercise(string question, int expected) : Exercise(question, expected)
{
  internal static SubtractionExercise CreateEasyExercise()
  {
    Random dice = new();

    int result = dice.Next(1, 10);
    int second = dice.Next(1, 10);
    int first = result + second;

    return new SubtractionExercise($"{first} - {second}", result);
  }

  internal static SubtractionExercise CreateMediumExercise()
  {
    Random dice = new();

    int result = dice.Next(10, 50);
    int second = dice.Next(10, 50);
    int first = result + second;

    return new SubtractionExercise($"{first} - {second}", result);
  }

  internal static SubtractionExercise CreateHardExercise()
  {
    Random dice = new();

    int result = dice.Next(50, 100);
    int second = dice.Next(50, 100);
    int first = result + second;

    return new SubtractionExercise($"{first} - {second}", result);
  }
}