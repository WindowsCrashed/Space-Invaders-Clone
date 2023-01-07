using UnityEngine;

public class BonusEnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject bonusEnemy;
    [SerializeField] float speed;

    public void Spawn()
    {
        GameObject enemy = Instantiate(bonusEnemy, transform.position, Quaternion.identity);
        enemy.transform.SetParent(FindObjectOfType<GameElements>().transform);
        if (enemy.TryGetComponent(out Rigidbody2D rb2d)) rb2d.velocity = transform.right * speed;
    }
}
