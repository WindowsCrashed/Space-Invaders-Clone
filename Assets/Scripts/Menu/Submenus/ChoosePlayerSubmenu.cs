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

    void OnPlayer1(InputValue value)
    {
        playerSelector.SetPlayers(1);
        sceneController.LoadPlayPlayer();
    }

    void OnPlayer2(InputValue value)
    {
        playerSelector.SetPlayers(2);
        sceneController.LoadPlayPlayer();
    }
}
