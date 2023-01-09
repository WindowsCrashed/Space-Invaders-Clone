using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] List<TransitionObject> transitions;

    public TransitionObject SelectedTransition { get; private set; }

    public void PlayTransition(string name)
    {
        SelectedTransition = transitions.Where(t => t.Name == name).First();
        SelectedTransition.PlayTransition();
    }
}
