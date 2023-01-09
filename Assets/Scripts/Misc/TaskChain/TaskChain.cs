using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskChain : MonoBehaviour
{
    readonly List<TaskObject> coroutines = new();

    IEnumerator TaskExecutionCoroutine()
    {
        foreach (TaskObject coroutine in coroutines)
        {
            yield return StartCoroutine(coroutine.TaskCoroutine());
        }
    }

    public void AddTask(Action action, float delay = 0, float initialDelay = 0)
    {
        coroutines.Add(new TaskObject(action, delay, initialDelay));
    }

    public TaskChainHandler StartChain(Action action, float delay = 0, float initialDelay = 0)
    {
        AddTask(action, delay, initialDelay);
        return new TaskChainHandler(this);
    }

    public void RunChain()
    {
        StartCoroutine(TaskExecutionCoroutine());
    }
}
