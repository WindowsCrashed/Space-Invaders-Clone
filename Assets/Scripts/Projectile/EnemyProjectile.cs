using UnityEngine;

public class EnemyProjectile : MonoBehaviour, IProjectile
{
    public void Explode()
    {
        GetComponent<Rigidbody2D>().Sleep();
        GetComponentInChildren<Animator>().enabled = false;
        GetComponent<Destroyer>().Explode();
    }
}
