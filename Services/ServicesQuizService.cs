using System;
using System.Collections.Generic;

public class QuizService
{
  private List<Question> _questions;
  private int _score = 0;

  public QuizService()
  {
    _questions = LoadQuestions();
    ShuffleQuestions();
  }


  private List<Question> LoadQuestions()
  {
    return new List<Question>
    {
      new Question
      {
        Text = "What is the capital of france?",
        Options = new List<string> {"Berlin", "Madrid", "Paris", "Bergen"}
      },
      //add questions here
    };
  }

  private void ShuffleQuestions()
  {
    Random rand = new Random();
    for (int i = _questions.Count - 1; i > 0; i--)
    {
      int j =rand.Next(0, i + i)
      var temp = _questions[i];
      _questions[i] = _questions[j];
      _questions[j] = temp;
    }
  }

  public List<Question> GetQuestions() => _questions;

  public void Submitanswer(int questionIndex, int answerIndex)
  {
    if (_questions[questionIndex].CorrectAnswerIndex == answerIndex)
    {
      _score++;
    }
  }

  public int Getscore() => _score;

}