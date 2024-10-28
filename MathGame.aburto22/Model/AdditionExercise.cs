namespace MathGame;

internal class AdditionExercise(string question, int expected) : Exercise(question, expected)
{
  internal static AdditionExercise CreateEasyExercise()
  {
    Random dice = new();

    int result = dice.Next(10, 50);
    int second = dice.Next(0, result);
    int first = result - second;

    return new AdditionExercise($"{first} + {second}", result);
  }

  internal static AdditionExercise CreateMediumExercise()
  {
    Random dice = new();

    int result = dice.Next(50, 150);
    int second = dice.Next(0, result - 10);
    int first = result - second;

    return new AdditionExercise($"{first} + {second}", result);
  }

  internal static AdditionExercise CreateHardExercise()
  {
    Random dice = new();

    int result = dice.Next(150, 1000);
    int second = dice.Next(0, result - 100);
    int first = result - second;

    return new AdditionExercise($"{first} + {second}", result);
  }
}