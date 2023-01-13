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
}
