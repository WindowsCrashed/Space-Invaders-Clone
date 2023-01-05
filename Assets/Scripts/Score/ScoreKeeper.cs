using UnityEngine;
using UnityEngine.Events;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] int score2;
    [SerializeField] int hiscore;

    readonly int maxScore = 9999;

    public static UnityEvent OnUpdateScore = new();
    public static UnityEvent OnUpdateHiScore = new();

    public int Score => score;
    public int HiScore => hiscore;

    void Awake()
    {
        SingletonManager.ManageSingleton(this);
        GameManager.OnGameOver.AddListener(SetHiScore);
    }

    void SetHiScore()
    {
        if (score > hiscore) hiscore = score;
        OnUpdateHiScore.Invoke();
    }

    public void IncrementScore(int points)
    {
        score = Mathf.Clamp(score + points, 0, maxScore);
        OnUpdateScore.Invoke();
    }

    public void ResetScore()
    {
        score = 0;
    }
}
