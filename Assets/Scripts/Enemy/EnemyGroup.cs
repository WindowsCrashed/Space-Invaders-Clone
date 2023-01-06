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
}
