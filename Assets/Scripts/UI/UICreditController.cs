using UnityEngine;
using TMPro;

public class UICreditController : MonoBehaviour
{
    [SerializeField] TMP_Text creditLabel;

    CreditKeeper creditKeeper;

    void Awake()
    {
        creditKeeper = FindObjectOfType<CreditKeeper>();
        CreditKeeper.OnUpdateCredit.AddListener(UpdateCredit);
        
        UpdateCredit();
    }

    void UpdateCredit()
    {
        creditLabel.text = $"Credit {creditKeeper.Credit.ToString().PadLeft(2, '0')}";
    }
}
