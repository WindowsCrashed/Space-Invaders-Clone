using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;

    public static readonly UnityEvent DieEvent = new();

    public bool IsDead { get; private set; }

    void SetDead()
    {
        IsDead = true;
    }

    void PlayDeathAnimation()
    {
        animator.SetBool("isDead", true);
    }

    public void Die()
    {
        SetDead();
        GetComponent<PlayerMovement>().enabled = false;
        PlayDeathAnimation();
        DieEvent.Invoke();
    }
}
