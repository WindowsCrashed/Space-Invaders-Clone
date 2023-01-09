using System;
using System.Collections;
using UnityEngine;

public class TaskObject
{
    readonly Action _action;
    readonly float _delay;
    readonly float _initialDelay;

    public TaskObject(Action action, float delay, float initialDelay)
    {
        _action = action;
        _delay = delay;
        _initialDelay = initialDelay;
    }

    public IEnumerator TaskCoroutine()
    {
        yield return new WaitForSecondsRealtime(_initialDelay);

        _action();

        yield return new WaitForSecondsRealtime(_delay);
    }
}
