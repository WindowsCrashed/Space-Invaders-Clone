using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyElementsRow
{
    [SerializeField] List<GameObject> enemies;

    public List<GameObject> Enemies => enemies;
}
