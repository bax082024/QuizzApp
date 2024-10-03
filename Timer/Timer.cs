using System;
using System.Threading;

public class QuestionTimer
{
  private int _timelimit;
  private Timer _timer;
  public bool IsTimeUp { get; private set;}

  public QuestionTimer(int seconds)
  {
    _timelimit = seconds;
    IsTimeUp = false;
  }

  


}