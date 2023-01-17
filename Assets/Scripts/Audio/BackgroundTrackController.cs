using System.Collections.Generic;
using UnityEngine;

public class BackgroundTrackController : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] List<PlaybackSpeedRule> rules;
    [SerializeField] string initialClip;

    string currentClip;

    public void StartBackgroundTrack()
    {
        audioManager.PlayClip(initialClip);
        currentClip = initialClip;
    }

    public void StopBackgroundTrack()
    {
        audioManager.StopClip(currentClip);
    }

    public void ManagePlaybackSpeed(int enemyCount)
    {
        string clip = rules.Find(r => r.EnemyCount == enemyCount)?.Clip;

        if (clip != null)
        {
            audioManager.StopClip(currentClip);
            audioManager.PlayClip(clip);
            currentClip = clip;
        }
    }
}
