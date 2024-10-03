using System;

class Program
{
  static void Main(string[] args)
  {
    QuizService quizService = new QuizService();
    QuizUI quizUI = new QuizUI(quizService);

    Console.WriteLine("Welcome to the Quizz App!");
    quizUI.StartQuiz();

  }



}