using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;

    PlayerMovement playerMovement;
    PlayerShooting playerShooting;

    public static readonly UnityEvent DieEvent = new();

    public bool IsDead { get; private set; }

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponent<PlayerShooting>();
    }

    void SetDead()
    {
        IsDead = true;
    }

    void PlayDeathAnimation()
    {
        animator.SetBool("isDead", true);
    }

    void DisableControls()
    {
        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }

    public void Die()
    {
        SetDead();
        DisableControls();
        PlayDeathAnimation();
        DieEvent.Invoke();
    }
}
