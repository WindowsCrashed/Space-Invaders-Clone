using System;

public class TaskChainHandler
{
    readonly TaskChain _chain;

    public TaskChainHandler(TaskChain chain)
    {
        _chain = chain;
    }

    public TaskChainHandler Then(Action action, float delay = 0, float initialDelay = 0)
    {
        _chain.AddTask(action, delay, initialDelay);
        return new TaskChainHandler(_chain);
    }
}
