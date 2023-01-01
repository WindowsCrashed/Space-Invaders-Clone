using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform gun;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed;
    [SerializeField] float fireRate;

    bool isFiring = false;
    Coroutine firingCoroutine;

    void Update()
    {
        Fire();    
    }

    void OnFire(InputValue value)
    {
        ToogleFiring();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            Shooter.Shoot(projectile, gun, projectileSpeed);
            yield return new WaitForSeconds(fireRate);
        }
    }

    void ToogleFiring()
    {
        isFiring = !isFiring;
    }
}
