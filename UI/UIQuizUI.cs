using System;

public class QuizUI
{
  private QuizService _quizService;
  private int _currentQuestionindex = 0;
  private QuestionTimer _timer;

  public QuizUI(QuizService quizService)
  {
    _quizService = quizService;
  }

  public void StartQuiz()
  {
    var questions = _quizService.GetQuestions();
    foreach (var question in questions)
    {
      Console.Clear();
      DisplayQuestion(question);

      _timer = new QuestionTimer(30);
      _timer.StartTimer();

      int answer = GetUserAnswer();

      if (_timer.IsTimeUp)
      {
        Console.WriteLine("Time is up!");
      }
      else
      {
        _quizService.SubmitAnswer(_currentQuestionindex, answer);
      }

      _currentQuestionindex++;
      Console.WriteLine($"Press Enter to continue...");
      Console.ReadLine();
    }

    ShowFinalScore();
  }

  



}