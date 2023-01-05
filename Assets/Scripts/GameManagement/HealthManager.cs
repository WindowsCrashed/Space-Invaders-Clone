using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int playerLives;
    
    public int PlayerLives => playerLives;

    void Awake()
    {
        GameManager.OnPlayerDestroyed.AddListener(LivesHandler);
    }

    void TakeLife()
    {
        if (playerLives > 0) playerLives--;
    }

    void LivesHandler()
    {
        TakeLife();
        if (playerLives == 0) GameManager.OnGameOver.Invoke();
    }
}
