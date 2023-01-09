using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] float typeInterval;

    IEnumerator TypingCoroutine(string textToType, TMP_Text textLabel)
    {
        string text = string.Empty;

        foreach (char c in textToType)
        {
            text += c;
            textLabel.text = text;
            yield return new WaitForSecondsRealtime(typeInterval);
        }
    }

    public void Type(string text, TMP_Text textLabel)
    {
        StartCoroutine(TypingCoroutine(text, textLabel));
    }
}
