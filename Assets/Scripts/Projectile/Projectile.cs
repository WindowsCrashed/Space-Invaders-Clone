using UnityEngine;

public class Projectile : MonoBehaviour
{
    public void Explode()
    {
        GetComponent<Rigidbody2D>().Sleep();
        GetComponent<Destroyer>().Explode();
    }
}
