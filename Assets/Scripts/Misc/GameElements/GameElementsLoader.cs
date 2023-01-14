using System.Collections.Generic;
using UnityEngine;

public class GameElementsLoader : MonoBehaviour
{
    [SerializeField] TaskChain chain;
    [SerializeField] GameElements gameElements;
    [SerializeField] List<EnemyElementsRow> enemyRows;

    void Start()
    {
        SetUpChain();
        chain.RunChain();
    }

    void SetUpChain()
    {
        chain.AddTask(TimeScaleController.FreezeGame);
        DisplayEnemies();
        chain.AddTask(TimeScaleController.UnfreezeGame, 1);
        chain.AddTask(DisplayPlayer);
        chain.AddTask(EnemyShooting.OnStartShooting.Invoke);
    }

    void DisplayEnemies()
    {
        foreach (EnemyElementsRow row in enemyRows)
        {
            foreach (GameObject enemy in row.Enemies)
            {
                chain.AddTask(() => enemy.SetActive(true), 0.02f);
            }
        }       
    }

    void DisplayPlayer()
    {
        gameElements.Player.SetActive(true);
    }
}
