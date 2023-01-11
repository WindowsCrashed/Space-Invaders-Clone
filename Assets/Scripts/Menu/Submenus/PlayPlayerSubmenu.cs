using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayPlayerSubmenu : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    [SerializeField] BlinkEffect blinkEffect;
    [SerializeField] TMP_Text score1Label;
    [SerializeField] TMP_Text score2Label;
    [SerializeField] GameObject playPlayer1;
    [SerializeField] GameObject playPlayer2;

    PlayerSelector playerSelector;

    void Start()
    {
        playerSelector = FindObjectOfType<PlayerSelector>();
        ShowPlayers();
    }

    void OnFire(InputValue value)
    {
        sceneController.LoadGame();
    }

    void ShowPlayer(TMP_Text scoreLabel, GameObject header, bool condition)
    {
        if (condition)
        {
            header.SetActive(true);
            scoreLabel.gameObject.SetActive(true);
            blinkEffect.Blink(scoreLabel);
        }
        else
        {
            header.SetActive(false);
            scoreLabel.gameObject.SetActive(false);
        }
    }

    void ShowPlayers()
    {
        ShowPlayer(score1Label, playPlayer1, playerSelector.Players >= 1);
        ShowPlayer(score2Label, playPlayer2, playerSelector.Players == 2);
    }
}
