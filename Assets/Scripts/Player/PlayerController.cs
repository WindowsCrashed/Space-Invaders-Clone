using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerShooting playerShooting;
    [SerializeField] AudioSource audioSource;

    public static readonly UnityEvent OnDie = new();    

    public bool IsDead { get; private set; }

    void Awake()
    {
        GameManager.OnGameWon.AddListener(DisableControls);
        GameManager.OnGameOver.AddListener(DisableControls);
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
        audioSource.Play();
        OnDie.Invoke();
    }
}
