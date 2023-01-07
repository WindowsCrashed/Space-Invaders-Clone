using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float playerRespawnDelay;
    [SerializeField] float gameOverDelay;
    [SerializeField] Spawner spawner;

    Coroutine respawnCoroutine;

    public static readonly UnityEvent OnPlayerDestroyed = new();
    public static readonly UnityEvent OnGameOver = new();
    public static readonly UnityEvent OnGameStart = new();
    public static readonly UnityEvent OnGameWon = new();

    void Awake()
    {
        PlayerController.OnDie.AddListener(Respawn);
        OnGameOver.AddListener(GameOver);
        OnGameWon.AddListener(GameWon);
    }

    void Start()
    {
        OnGameStart.Invoke();
    }

    IEnumerator RespawnCoroutine()
    {
        TimeScaleController.FreezeGame();
        yield return new WaitForSecondsRealtime(playerRespawnDelay);
        spawner.SpawnPlayer();
        TimeScaleController.UnfreezeGame();
    }

    IEnumerator RestartGameCoroutine()
    {
        yield return new WaitForSecondsRealtime(gameOverDelay);
        SceneController.LoadGame();
        TimeScaleController.UnfreezeGame();
    }

    IEnumerator ContinuePlayingCoroutine()
    {
        TimeScaleController.FreezeGame();
        yield return new WaitForSecondsRealtime(playerRespawnDelay); // Temp
        spawner.DespawnGameElements();
        yield return new WaitForSecondsRealtime(0.5f); // Temp
        spawner.SpawnGameElements();
        TimeScaleController.UnfreezeGame();
    }

    void Respawn()
    {
        respawnCoroutine = StartCoroutine(RespawnCoroutine());
    }

    void GameOver()
    {
        StopCoroutine(respawnCoroutine);
        respawnCoroutine = null;
        StartCoroutine(RestartGameCoroutine());
    }

    void GameWon()
    {     
        StartCoroutine(ContinuePlayingCoroutine());
    }
}
