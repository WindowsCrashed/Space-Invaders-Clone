using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TMP_Text textLabel;
    [SerializeField] string text;
    [SerializeField] TypewriterEffect typewriterEffect;

    void Start()
    {
        GameManager.OnGameOver.AddListener(DisplayMessage);    
    }

    void DisplayMessage()
    {
        typewriterEffect.Type(text, textLabel);
    }
}
