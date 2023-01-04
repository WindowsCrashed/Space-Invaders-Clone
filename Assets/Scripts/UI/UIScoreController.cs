using UnityEngine;
using TMPro;

public class UIScoreController : MonoBehaviour
{
    [SerializeField] TMP_Text score1;
    [SerializeField] TMP_Text score2;
    [SerializeField] TMP_Text hiscore;

    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        ScoreKeeper.OnUpdateScore.AddListener(UpdateScore);
        UpdateScore();
    }

    public void UpdateScore()
    {
        score1.text = scoreKeeper.Score.ToString().PadLeft(4, '0');
    }
}
