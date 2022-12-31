using UnityEngine;

public class Projectile : MonoBehaviour
{
    public void Explode()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Destroyer>().Explode();
    }
}
