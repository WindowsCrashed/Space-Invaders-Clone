using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float playerRespawnDelay;
    [SerializeField] float gameOverDelay;

    Coroutine respawnCoroutine;

    public static readonly UnityEvent OnPlayerDestroyed = new();
    public static readonly UnityEvent OnGameOver = new();
    public static readonly UnityEvent OnGameStart = new();
    
    public static readonly UnityEvent OnGameWin = new(); // Temp

    void Awake()
    {
        PlayerController.OnDie.AddListener(Respawn);
        OnGameOver.AddListener(GameOver);
        
        OnGameWin.AddListener(Win); // Temp
    }

    void Start()
    {
        OnGameStart.Invoke();
    }

    IEnumerator RespawnCoroutine()
    {
        TimeScaleController.FreezeGame();
        yield return new WaitForSecondsRealtime(playerRespawnDelay);
        SpawnPlayer();
        TimeScaleController.UnfreezeGame();
    }

    IEnumerator RestartGameCoroutine()
    {
        yield return new WaitForSecondsRealtime(gameOverDelay);
        SceneController.LoadGame();
        TimeScaleController.UnfreezeGame();
    }

    void Respawn()
    {
        respawnCoroutine = StartCoroutine(RespawnCoroutine());
    }

    void SpawnPlayer()
    {
        Instantiate(player);
    }

    void GameOver()
    {
        StopCoroutine(respawnCoroutine);
        respawnCoroutine = null;
        StartCoroutine(RestartGameCoroutine());
    }

    // Temp
    void Win()
    {
        TimeScaleController.FreezeGame();
        StartCoroutine(RestartGameCoroutine());
    }
}
