using UnityEngine;
using UnityEngine.InputSystem;

public class ChoosePlayerSubmenu : MonoBehaviour
{
    [SerializeField] SceneController sceneController;

    PlayerSelector playerSelector;

    void Start()
    {
        playerSelector = FindObjectOfType<PlayerSelector>();
    }

    void SelectPlayer(int player)
    {
        if (playerSelector.TrySetPlayers(player)) sceneController.LoadPlayPlayer();
    }

    void OnPlayer1(InputValue value)
    {
        SelectPlayer(1);
    }

    void OnPlayer2(InputValue value)
    {
        SelectPlayer(2);
    }
}
