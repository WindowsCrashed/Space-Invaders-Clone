using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    void OnFire(InputValue value)
    {
        FindObjectOfType<SceneController>().LoadInsertCoin();
    }
}
