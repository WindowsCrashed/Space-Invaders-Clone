using System.Collections;
using UnityEngine;
using TMPro;

public class BlinkEffect : MonoBehaviour
{
    [SerializeField] float interval;

    IEnumerator BlinkCoroutine(TMP_Text label)
    {
        int value = 1;

        while (true)
        {
            yield return new WaitForSecondsRealtime(interval);
            value = Mathf.Abs(value - 1);
            label.alpha = value * 100;
        }
    }

    public void Blink(TMP_Text label)
    {
        StartCoroutine(BlinkCoroutine(label));
    }
}
