using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;

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
        GameManager.FreezeGame();
    }
}
