using UnityEngine;
using UnityEngine.InputSystem;

public class InsertCoinSubmenu : MonoBehaviour
{
    void OnFire(InputValue value)
    {
        FindObjectOfType<SceneController>().LoadChoosePlayer();
    }
}
