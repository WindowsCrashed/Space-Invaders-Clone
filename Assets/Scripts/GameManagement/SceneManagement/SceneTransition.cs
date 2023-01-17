using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] List<TransitionObject> transitions;

    public TransitionObject SelectedTransition { get; private set; }

    public void PlayTransition(string name)
    {
        SelectedTransition = transitions.Find(t => t.Name == name);
        SelectedTransition.PlayTransition();
    }
}
