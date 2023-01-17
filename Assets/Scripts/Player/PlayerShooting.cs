using System.Collections;
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
        ToogleFiring(value.isPressed);
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            StartShooting();
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopShooting();
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

    void ToogleFiring(bool value)
    {
        isFiring = value;
    }

    void StartShooting()
    {      
        firingCoroutine = StartCoroutine(FireContinuously());
    }

    void StopShooting()
    {        
        StopCoroutine(firingCoroutine);
        firingCoroutine = null;
    }
}
