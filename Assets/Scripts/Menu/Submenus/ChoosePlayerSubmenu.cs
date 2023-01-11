using UnityEngine;
using UnityEngine.InputSystem;

public class ChoosePlayerSubmenu : MonoBehaviour
{
    [SerializeField] SceneController sceneController;

    void OnPlayer1(InputValue value)
    {
        sceneController.LoadGame();
    }
}
