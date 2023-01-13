using UnityEngine;
using UnityEngine.InputSystem;

public class CreditInputController : MonoBehaviour
{
    [SerializeField] int creditsToInsert;

    CreditKeeper creditKeeper;

    void Start()
    {
        creditKeeper = FindObjectOfType<CreditKeeper>();    
    }

    void OnCredit(InputValue value)
    {
        creditKeeper.AddCredit(creditsToInsert);
    }
}
