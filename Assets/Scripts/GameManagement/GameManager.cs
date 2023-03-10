using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float playerRespawnDelay;
    [SerializeField] float gameOverDelay;
    [SerializeField] float restartDelay;
    [SerializeField] Spawner spawner;
    [SerializeField] SceneController sceneController;
    [SerializeField] AudioManager audioManager;

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
        
        audioManager.PauseAllSources();
        
        yield return new WaitForSecondsRealtime(playerRespawnDelay);
        
        spawner.SpawnPlayer();
        audioManager.ResumeAllSources();
        
        TimeScaleController.UnfreezeGame();
    }

    IEnumerator RestartGameCoroutine()
    {
        yield return new WaitForSecondsRealtime(gameOverDelay);
        
        sceneController.LoadChoosePlayer();
    }

    IEnumerator ContinuePlayingCoroutine()
    {
        TimeScaleController.FreezeGame();
        
        yield return new WaitForSecondsRealtime(restartDelay);
        
        RespawnGameElements();
    }

    void Respawn()
    {
        respawnCoroutine = StartCoroutine(RespawnCoroutine());
    }

    void RespawnGameElements()
    {
        spawner.DespawnGameElements();
        spawner.SpawnGameElements();
    }

    void GameOver()
    {
        TimeScaleController.FreezeGame();

        audioManager.StopAllSources();

        if (respawnCoroutine != null)
        {
            StopCoroutine(respawnCoroutine);
            respawnCoroutine = null;
        }
        
        StartCoroutine(RestartGameCoroutine());
    }

    void GameWon()
    {
        audioManager.StopAllSources();
        StartCoroutine(ContinuePlayingCoroutine());
    }
}
