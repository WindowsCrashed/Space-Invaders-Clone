using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
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
