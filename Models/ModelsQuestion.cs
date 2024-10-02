using System.Collections.Generic;

public class Question
{
  public string Text { get; set;}
  public List<string> Options { get; set;}
  public int CorrectAnswerIndex { get; set;}
  public string ImagePath { get; set;}
}