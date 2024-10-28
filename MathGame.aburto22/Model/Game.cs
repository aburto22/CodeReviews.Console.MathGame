namespace MathGame;

internal class Game(GameType gameType, Level level)
{
  Level DifficultyLevel = level;
  GameType GameType = gameType;
  List<Exercise> Exercises = [];

  int Rounds = 5;

  internal async Task Play()
  {
    DateTime start = DateTime.Now;

    while (Exercises.Count < Rounds)
    {
      Console.Clear();
      if (Exercises.Count > 0)
      {
        Console.WriteLine($"You have responded {GetCorrectExercisesCount()} out of {Exercises.Count} correct exercises.");
      }
      else
      {
        Console.WriteLine("First exercise.");
      }
      Console.WriteLine($"There are {Rounds - Exercises.Count} exercises to go.");
      Console.WriteLine();

      Exercise exercise = CreateExercise();
      Exercises.Add(exercise);

      await exercise.PresentExercise();
    }

    DateTime end = DateTime.Now;

    Console.Clear();

    Result result = MockDatabase.AddResult(GetCorrectExercisesCount(), Rounds, GameType, DifficultyLevel, end - start);

    Console.WriteLine("And you are done!\n");
    Console.WriteLine($"Operation: {result.GameType}");
    Console.WriteLine($"Difficult: {result.Level}");
    Console.WriteLine($"Correct responses: {result.Score} out of {result.Max}");
    Console.WriteLine($"Completed on: {result.Duration:mm\\:ss}");
    Console.WriteLine("\nSay anything to continue");
    await SpeechRecognition.Listen();
  }

  internal Exercise CreateExercise()
  {
    return GameType switch
    {
      GameType.Addition => CreateAdditionExercise(),
      GameType.Subtraction => CreateSubtractionExercise(),
      GameType.Multiply => CreateMultiplyExercise(),
      GameType.Division => CreateDivisionExercise(),
      GameType.Random => CreateRandomExercise(),
      _ => throw new ArgumentOutOfRangeException(),
    };
  }

  internal Exercise CreateAdditionExercise()
  {
    return DifficultyLevel switch
    {
      Level.Easy => AdditionExercise.CreateEasyExercise(),
      Level.Medium => AdditionExercise.CreateMediumExercise(),
      Level.Hard => AdditionExercise.CreateHardExercise(),
      _ => throw new ArgumentOutOfRangeException(),
    };
  }

  internal Exercise CreateSubtractionExercise()
  {
    return DifficultyLevel switch
    {
      Level.Easy => SubtractionExercise.CreateEasyExercise(),
      Level.Medium => SubtractionExercise.CreateMediumExercise(),
      Level.Hard => SubtractionExercise.CreateHardExercise(),
      _ => throw new ArgumentOutOfRangeException(),
    };
  }

  internal Exercise CreateMultiplyExercise()
  {
    return DifficultyLevel switch
    {
      Level.Easy => MultiplyExercise.CreateEasyExercise(),
      Level.Medium => MultiplyExercise.CreateMediumExercise(),
      Level.Hard => MultiplyExercise.CreateHardExercise(),
      _ => throw new ArgumentOutOfRangeException(),
    };
  }

  internal Exercise CreateDivisionExercise()
  {
    return DifficultyLevel switch
    {
      Level.Easy => DivisionExercise.CreateEasyExercise(),
      Level.Medium => DivisionExercise.CreateMediumExercise(),
      Level.Hard => DivisionExercise.CreateHardExercise(),
      _ => throw new ArgumentOutOfRangeException(),
    };
  }

  internal Exercise CreateRandomExercise()
  {
    Random dice = new();
    int operation = dice.Next(0, 4);

    return operation switch
    {
      0 => CreateAdditionExercise(),
      1 => CreateSubtractionExercise(),
      2 => CreateMultiplyExercise(),
      3 => CreateDivisionExercise(),
      _ => throw new ArgumentOutOfRangeException(),
    };
  }

  private int GetCorrectExercisesCount()
  {
    return Exercises.Where(exercise => exercise.IsCorrect()).Count();
  }
}