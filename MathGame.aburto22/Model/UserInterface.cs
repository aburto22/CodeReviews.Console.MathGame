namespace MathGame;

internal static class UserInterface
{
  static Level DifficultyLevel = Level.Easy;

  internal static async Task MainMenu()
  {
    while (true)
    {
      Console.Clear();
      Console.WriteLine("Welcome to the Math Game\n");
      Console.WriteLine("This game uses speech recognition, so use your voice to choose a menu option and to respond to questions.\n");
      Console.WriteLine($"Your current difficulty level is: {DifficultyLevel}\n");
      Console.WriteLine("What do you want to do next?");
      Console.WriteLine("- Play");
      Console.WriteLine("- See results");
      Console.WriteLine("- Change difficulty");
      Console.WriteLine("- Exit");

      string speech = await SpeechRecognition.Listen();

      if (speech.Contains("play", StringComparison.OrdinalIgnoreCase))
      {
        await PlayMenu();
      }
      else if (speech.Contains("results", StringComparison.OrdinalIgnoreCase))
      {
        await DisplayResults();
      }
      else if (speech.Contains("difficulty", StringComparison.OrdinalIgnoreCase))
      {
        await ChangeDifficultyLevel();
      }
      else if (speech.Contains("exit", StringComparison.OrdinalIgnoreCase))
      {
        Console.WriteLine("Thanks for playing!");
        Thread.Sleep(Config.DelayTime);
        break;
      }
      else
      {
        Console.WriteLine($"That's not a valid choice.");
        Thread.Sleep(Config.DelayTime);
      }
    }
  }

  private static async Task PlayMenu()
  {
    while (true)
    {
      Console.Clear();
      Console.WriteLine($"Your current difficulty level is: {DifficultyLevel}\n");
      Console.WriteLine("What operation do you want to play with?");
      Console.WriteLine($"- {GameType.Addition} (+)");
      Console.WriteLine($"- {GameType.Subtraction} (-)");
      Console.WriteLine($"- {GameType.Multiply} (*)");
      Console.WriteLine($"- {GameType.Division} (/)");
      Console.WriteLine($"- {GameType.Random}");
      Console.WriteLine("- Go back");

      string speech = await SpeechRecognition.Listen();

      GameType gameType;

      if (speech.Contains("back", StringComparison.OrdinalIgnoreCase))
      {
        break;
      }
      else if (speech.Contains(GameType.Addition.ToString(), StringComparison.OrdinalIgnoreCase))
      {
        gameType = GameType.Addition;
      }
      else if (speech.Contains(GameType.Subtraction.ToString(), StringComparison.OrdinalIgnoreCase))
      {
        gameType = GameType.Subtraction;
      }
      else if (speech.Contains(GameType.Multiply.ToString(), StringComparison.OrdinalIgnoreCase))
      {
        gameType = GameType.Multiply;
      }
      else if (speech.Contains(GameType.Division.ToString(), StringComparison.OrdinalIgnoreCase))
      {
        gameType = GameType.Division;
      }
      else if (speech.Contains(GameType.Random.ToString(), StringComparison.OrdinalIgnoreCase))
      {
        gameType = GameType.Random;
      }
      else
      {
        Console.WriteLine("That's not a valid choice.");
        Thread.Sleep(Config.DelayTime);
        continue;
      }

      Game game = new Game(gameType, DifficultyLevel);

      await game.Play();

      break;
    }
  }

  private static async Task ChangeDifficultyLevel()
  {
    while (true)
    {
      Console.Clear();
      Console.WriteLine($"Your current difficulty level is: {DifficultyLevel}\n");
      Console.WriteLine($"What difficulty level do you want to choose?");
      Console.WriteLine($"- {Level.Easy}");
      Console.WriteLine($"- {Level.Medium}");
      Console.WriteLine($"- {Level.Hard}");
      Console.WriteLine("- Go back");

      string speech = await SpeechRecognition.Listen();

      if (speech.Contains(Level.Easy.ToString(), StringComparison.OrdinalIgnoreCase))
      {
        Console.WriteLine($"Difficulty level set to \"{Level.Easy}\"");
        Thread.Sleep(2000);
        break;
      }
      else if (speech.Contains(Level.Medium.ToString(), StringComparison.OrdinalIgnoreCase))
      {
        DifficultyLevel = Level.Medium;
        Console.WriteLine($"Difficulty level set to \"{Level.Medium}\"");
        Thread.Sleep(Config.DelayTime);
        break;
      }
      else if (speech.Contains(Level.Hard.ToString(), StringComparison.OrdinalIgnoreCase))
      {
        DifficultyLevel = Level.Hard;
        Console.WriteLine($"Difficulty level set to \"{Level.Hard}\"");
        Thread.Sleep(Config.DelayTime);
        break;
      }
      else if (speech.Contains("back", StringComparison.OrdinalIgnoreCase))
      {
        break;
      }
      else
      {
        Console.WriteLine("That's not a valid choice.");
        Thread.Sleep(Config.DelayTime);
        continue;
      }
    }
  }

  private static async Task DisplayResults()
  {
    List<Result> results = MockDatabase.GetResults();

    Console.Clear();

    if (results.Count == 0)
    {
      Console.WriteLine("You don't have any saved results.");
    }
    else
    {
      Console.WriteLine("Previous results");
      foreach (Result result in MockDatabase.GetResults())
      {
        result.DisplayResult();
      }
    }

    Console.WriteLine("\nSay anything to continue");
    await SpeechRecognition.Listen();
  }
}