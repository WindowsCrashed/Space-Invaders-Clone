using UnityEngine;

public class Projectile : MonoBehaviour, IProjectile
{
    public void Explode()
    {
        GetComponent<Rigidbody2D>().Sleep();
        GetComponent<Destroyer>().Explode();
    }
}
