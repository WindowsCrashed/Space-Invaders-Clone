using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] int points;

    ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();    
    }

    public void ScorePoints()
    {
        scoreKeeper.IncrementScore(points);
    }
}
