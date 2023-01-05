using UnityEngine;

public static class TimeScaleController
{
    public static void FreezeGame()
    {
        Time.timeScale = 0;
    }

    public static void UnfreezeGame()
    {
        Time.timeScale = 1;
    }
}
