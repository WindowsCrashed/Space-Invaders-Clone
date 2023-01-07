using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] List<EnemyColumn> columns;

    public List<EnemyColumn> Columns => columns;

    public void RemoveColumn(EnemyColumn column)
    {
        columns.Remove(column);
    }

    public int CountEnemies()
    {
        int counter = 0;

        foreach (EnemyColumn column in Columns)
        {
            counter += column.Enemies.Count;
        }

        if (counter == 0) GameManager.OnGameWon.Invoke();

        return counter;
    }
}
