using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public int Players { get; private set; } = 1;

    void Awake()
    {
        SingletonManager.ManageSingleton(this);    
    }

    public void SetPlayers(int players)
    {       
        Players = Mathf.Clamp(players, 1, 2);
        FindObjectOfType<CreditKeeper>().TakeCredit(Players);
    }

    public bool TrySetPlayers(int players)
    {
        CreditKeeper creditKeeper = FindObjectOfType<CreditKeeper>();        
        Players = Mathf.Clamp(players, 1, 2);

        if (creditKeeper != null && creditKeeper.Credit >= Players)
        {
            creditKeeper.TakeCredit(Players);
            return true;
        }

        return false;
    }
}
