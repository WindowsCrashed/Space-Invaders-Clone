using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float playerResetDelay;
    [SerializeField] int playerLives;

    public int PlayerLives => playerLives;

    public static readonly UnityEvent TakeLifeEvent = new();

    void Awake()
    {
        TakeLifeEvent.AddListener(TakeLife);
        PlayerController.DieEvent.AddListener(ResetAfterPlayerDeath);    
    }

    IEnumerator ResetAfterPlayerDeathCoroutine()
    {
        FreezeGame();
        yield return new WaitForSecondsRealtime(playerResetDelay);

        GameOver(); // Temp
        
        SpawnPlayer();
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

    void SpawnPlayer()
    {
        Instantiate(player);
    }

    void TakeLife()
    {
        if (playerLives > 0) playerLives--;
    }

    void GameOver() // Temp
    {
        if (playerLives == 0) LoadGame();
    }

    void FreezeGame()
    {
        Time.timeScale = 0;
    }

    void UnfreezeGame()
    {
        Time.timeScale = 1;
    }
}
