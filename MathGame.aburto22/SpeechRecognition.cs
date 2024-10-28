
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace MathGame;

internal static class SpeechRecognition
{
  static string? speechKey = Environment.GetEnvironmentVariable("SPEECH_KEY");
  static string? speechRegion = Environment.GetEnvironmentVariable("SPEECH_REGION");

  private static string OutputSpeechRecognitionResult(SpeechRecognitionResult speechRecognitionResult)
  {
    switch (speechRecognitionResult.Reason)
    {
      case ResultReason.RecognizedSpeech:
        return speechRecognitionResult.Text;
      case ResultReason.NoMatch:
        throw new Exception("Did you say something? I couldn't understand what you just said.");
      case ResultReason.Canceled:
        CancellationDetails cancellation = CancellationDetails.FromResult(speechRecognitionResult);
        throw new Exception($"CANCELED: Reason={cancellation.Reason}");
      default:
        throw new Exception("There was an error!");
    }
  }

  internal static async Task<string> Listen()
  {
    string speech = "";

    while (speech == "")
    {
      try
      {
        SpeechConfig speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);
        speechConfig.SpeechRecognitionLanguage = Config.Locale;

        speechConfig.SetServiceProperty("SegmentationSilenceTimeoutMs", "300", ServicePropertyChannel.UriQueryParameter);
        speechConfig.SetServiceProperty("InitialSilenceTimeoutMs", "10000", ServicePropertyChannel.UriQueryParameter);

        AudioConfig audioConfig = AudioConfig.FromDefaultMicrophoneInput();
        SpeechRecognizer speechRecognizer = new SpeechRecognizer(speechConfig, audioConfig);

        Console.WriteLine("\nListening...");

        SpeechRecognitionResult speechRecognitionResult = await speechRecognizer.RecognizeOnceAsync();
        speech = OutputSpeechRecognitionResult(speechRecognitionResult);

        Console.WriteLine($"Heard: \"{speech}\"\n");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

    }
    return speech;
  }
}