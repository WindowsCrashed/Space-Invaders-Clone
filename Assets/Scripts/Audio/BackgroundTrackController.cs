using System.Collections.Generic;
using UnityEngine;

public class BackgroundTrackController : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioController audioController;
    [SerializeField] List<PlaybackSpeedRule> rules;
    [SerializeField] string initialClip;

    public void StartBackgroundTrack()
    {
        audioController.PlayClip(initialClip);
    }

    public void ManagePlaybackSpeed(int enemyCount)
    {
        string clip = rules.Find(r => r.EnemyCount == enemyCount)?.Clip;
        if (clip != null) audioController.PlayClip(clip);
    }
}
