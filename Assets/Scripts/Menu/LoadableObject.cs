using System;
using UnityEngine;
using TMPro;

[System.Serializable]
public class LoadableObject
{
    [SerializeField] GameObject element;
    [SerializeField] ObjectEventType eventType;

    Action action;

    void Setup()
    {
        if (eventType == ObjectEventType.SetActive)
        {
            action = () => element.SetActive(true);
        }
        else if (eventType == ObjectEventType.Typewrite)
        {
            
            TypewriterEffect typewriter = UnityEngine.Object.FindObjectOfType<TypewriterEffect>();
            TMP_Text tmp;

            if (element.TryGetComponent(out TMP_Text component))
            {
                tmp = component;
            }
            else
            {
                tmp = element.GetComponentInChildren<TMP_Text>();
            }    

            action = () =>
            {
                element.SetActive(true);
                typewriter.Type(tmp.text, tmp);
            };       
        }
    }

    public void LoadElement()
    {
        Setup();
        action();
    }
}

public enum ObjectEventType
{
    SetActive,
    Typewrite
}
