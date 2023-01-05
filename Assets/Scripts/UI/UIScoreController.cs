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
        
        ScoreKeeper.OnUpdateScore.AddListener(() => UpdateScore(score1, scoreKeeper.Score));
        ScoreKeeper.OnUpdateHiScore.AddListener(() => UpdateScore(hiscore, scoreKeeper.HiScore));
        GameManager.OnGameStart.AddListener(ClearScore);
    }

    void UpdateScore(TMP_Text label, int score)
    {
        label.text = score.ToString().PadLeft(4, '0');
    }

    void ClearScore()
    {
        scoreKeeper.ResetScore();
        UpdateScore(score1, scoreKeeper.Score);
        UpdateScore(hiscore, scoreKeeper.HiScore);
    }
}
