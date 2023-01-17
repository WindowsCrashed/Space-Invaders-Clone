using UnityEngine;

public class EnemyProjectile : MonoBehaviour, IProjectile
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile")) Explode("Death Midair");
    }

    public void Explode(string sprite = "Death")
    {
        GetComponent<Rigidbody2D>().Sleep();
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponentInChildren<Animator>().enabled = false;
        GetComponent<Destroyer>().Explode(null, sprite);
    }
}
