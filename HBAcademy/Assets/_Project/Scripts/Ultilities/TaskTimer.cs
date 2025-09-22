using System;
using System.Diagnostics;
using UnityEngine;

public class TaskTimer : IDisposable
{
    private Stopwatch _stopwatch;
    private string _taskName;
    private bool _showLog;
    private bool _isStopped;

    public long ElapsedMilliseconds;

    public TaskTimer(string taskName = "Task", bool showLog = true)
    {
        _taskName = taskName;
        _showLog = showLog;
        _isStopped = false;
        if (_stopwatch == null)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }
        else _stopwatch.Restart();
    }

    public void Stop()
    {
        _isStopped = true;
        _stopwatch.Stop();
        ElapsedMilliseconds = _stopwatch.ElapsedMilliseconds;
        if (_showLog) UnityEngine.Debug.Log($"{_taskName}: {_stopwatch.ElapsedMilliseconds}ms");
    }

    public void Dispose()
    {
        if (!_isStopped) Stop();
    }
}
