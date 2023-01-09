using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LoadableElement
{
    [SerializeField] float initialDelay = 0;
    [SerializeField] float delay = 0;
    [SerializeField] List<LoadableObject> elements;

    public float InitialDelay => initialDelay;
    public float Delay => delay;

    public void Load()
    {
        foreach (LoadableObject element in elements)
        {
            element.LoadElement();
        }
    }
}
