using UnityEngine;
using UnityEngine.InputSystem;

public class CreditInputController : MonoBehaviour
{
    [SerializeField] int creditsToInsert;

    CreditKeeper creditKeeper;

    void Awake()
    {
        creditKeeper = FindObjectOfType<CreditKeeper>();    
    }

    void OnCredit(InputValue value)
    {
        creditKeeper.AddCredit(creditsToInsert);
    }
}
