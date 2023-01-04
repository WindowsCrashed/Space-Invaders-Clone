using System.Collections;
using UnityEngine;

public class BonusEnemyController : MonoBehaviour, IEnemyController
{
    [SerializeField] float lifeTime;
    [SerializeField] Score score;
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] SpriteController spriteController;

    public bool IsDead { get; private set; }

    void Start()
    {
        StartCoroutine(LifeCycleCoroutine());
    }

    IEnumerator LifeCycleCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    void SetDead()
    {
        IsDead = true;
    }

    public void Die()
    {
        SetDead();
        rb2d.Sleep();
        spriteController.AnimateAuto("Death");
        score.ScorePoints();
    }
}
