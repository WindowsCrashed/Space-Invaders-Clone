using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float playerResetDelay;

    void Start()
    {
        PlayerController.DieEvent.AddListener(() => ResetAfterPlayerDeath());    
    }

    IEnumerator ResetAfterPlayerDeathCoroutine()
    {
        FreezeGame();
        yield return new WaitForSecondsRealtime(playerResetDelay);
        LoadGame();
        UnfreezeGame();
    }

    void ResetAfterPlayerDeath()
    {
        StartCoroutine(ResetAfterPlayerDeathCoroutine());
    }

    void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public static void FreezeGame()
    {
        Time.timeScale = 0;
    }

    public static void UnfreezeGame()
    {
        Time.timeScale = 1;
    }
}
