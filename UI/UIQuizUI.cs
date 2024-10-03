using System;

public class QuizUI
{
    private QuizService _quizService;
    private int _currentQuestionIndex = 0; // Fixed variable name
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
            _timer.StartTimer(null); 

            int answer = GetUserAnswer();

            if (_timer.IsTimeUp)
            {
                Console.WriteLine("Time is up!");
            }
            else
            {
                _quizService.SubmitAnswer(_currentQuestionIndex, answer);
            }

            _currentQuestionIndex++;
            Console.WriteLine($"Press Enter to continue...");
            Console.ReadLine();
        }

        ShowFinalScore();
    }

    private void DisplayQuestion(Question question)
    {
        Console.WriteLine($"Question {_currentQuestionIndex + 1}: {question.Text}");
        for (int i = 0; i < question.Options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {question.Options[i]}");
        }
    }

    private int GetUserAnswer()
    {
        int answer = -1;
        while (answer < 1 || answer > 4)
        {
            Console.Write("Select your answer (1 - 4): ");
            if (!int.TryParse(Console.ReadLine(), out answer))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        }
        return answer - 1; // Convert 1-based index to 0-based index
    }

    private void ShowFinalScore()
    {
        Console.WriteLine($"Your final score is: {_quizService.GetScore()}");
    }
}
