using UnityEngine;

public class PlayerProjectile : MonoBehaviour, IProjectile
{
    public void Explode()
    {
        GetComponent<Rigidbody2D>().Sleep();
        GetComponent<Destroyer>().Explode();
    }
}
