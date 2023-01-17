using UnityEngine;

[System.Serializable]
public class PlaybackSpeedRule
{
    [SerializeField] string clip;
    [SerializeField] int enemyCount;

    public string Clip => clip;
    public int EnemyCount => enemyCount;
}
