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

  public void StartTimer(Object o)
  {
    _timer = new Timer(StartTimer, null, 0, 1000);
  }

  private void TimerCallback(Object o)
  {
    _timelimit--;
    if (_timelimit <= 0)
    {
      IsTimeUp = true;
      _timer.Dispose();
    }
  }

  public void StopTimer()
  {
    _timer.Dispose();
    IsTimeUp = false;
  }
}