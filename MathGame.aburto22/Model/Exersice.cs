namespace MathGame;

internal class Exercise(string question, int expected)
{
  readonly string Question = question;
  readonly int Expected = expected;
  int Actual;

  internal async Task PresentExercise()
  {
    int result;

    while (true)
    {
      (_, int ConsoleTopStart) = Console.GetCursorPosition();

      Console.WriteLine($"What is the result of {Question}");
      string speech = await SpeechRecognition.Listen();

      if (speech.EndsWith('.'))
      {
        speech = speech[0..^1];
      }

      if (int.TryParse(speech, out result))
      {
        break;
      }
      else
      {
        Console.WriteLine($"{speech} is not a valid number. Try again.");
        Thread.Sleep(Config.DelayTime);

        (_, int ConsoleTopEnd) = Console.GetCursorPosition();

        Console.SetCursorPosition(0, ConsoleTopStart);
        for (int i = ConsoleTopStart; i <= ConsoleTopEnd; i++)
        {
          Console.WriteLine(new string(' ', Console.WindowWidth));
        }
        Console.SetCursorPosition(0, ConsoleTopStart);
      }
    }

    Actual = result;

    if (IsCorrect())
    {
      Console.WriteLine("This is the correct answer!");
    }
    else
    {
      Console.WriteLine($"The correct answer is {Expected}, but you entered {Actual}");
    }

    Thread.Sleep(Config.DelayTime);
  }

  internal bool IsCorrect()
  {
    return Actual == Expected;
  }
}