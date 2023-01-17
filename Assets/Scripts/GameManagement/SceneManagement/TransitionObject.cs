using UnityEngine;

public class TransitionObject : MonoBehaviour
{
    [SerializeField] string transitionName;
    [SerializeField] Animator animator;
    [SerializeField] float duration;

    public string Name => transitionName;
    public float Duration => duration;

    public void PlayTransition()
    {
        animator.SetTrigger("ApplyTransition");
    }
}
