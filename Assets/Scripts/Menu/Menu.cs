using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    [Header("Step by step loading")]

    [Header("Screen elements to load")]
    [SerializeField] List<LoadableElement> elements;

    [Header("Screen Loader Task Chain")]
    [SerializeField] TaskChain chain;

    void Start()
    {
        LoadMenuScreenGradually();    
    }

    void LoadMenuScreenGradually()
    {
        foreach (LoadableElement element in elements)
        {
            chain.AddTask(() => element.Load(), element.Delay, element.InitialDelay);
        }

        chain.RunChain();
    }

    void OnFire(InputValue value)
    {
        FindObjectOfType<SceneController>().LoadChoosePlayer();
    }
}
