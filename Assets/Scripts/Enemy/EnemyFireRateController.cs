using UnityEngine;

public class EnemyFireRateController : MonoBehaviour
{
    [SerializeField] float minShootingTime;
    [SerializeField] float maxShootingTime;
    [SerializeField] float shootingTimeDecrement;

    public float MinShootingTime => minShootingTime;
    public float MaxShootingTime => maxShootingTime;

    void Awake()
    {
        GameManager.OnGameWon.AddListener(IncreaseFireRate);    
    }

    void IncreaseFireRate()
    {
        maxShootingTime = Mathf.Clamp(maxShootingTime - shootingTimeDecrement, minShootingTime, float.MaxValue);
    }
}
