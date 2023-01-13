using UnityEngine;
using UnityEngine.Events;

public class CreditKeeper : MonoBehaviour
{
    [SerializeField] int credit;

    readonly int maxCredit = 99;

    public int Credit => credit;

    public static readonly UnityEvent OnUpdateCredit = new();

    void Awake()
    {
        SingletonManager.ManageSingleton(this);    
    }

    void UpdateCredit(int amount, int multiplyer = 1)
    {
        credit = Mathf.Clamp(credit + (amount * multiplyer), 0, maxCredit);
        OnUpdateCredit.Invoke();
    }

    public void TakeCredit(int amount)
    {
        UpdateCredit(amount, -1);
    }

    public void AddCredit(int amount)
    {
        UpdateCredit(amount);
    }
}
