using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] bool playOnAwake;
    [SerializeField] List<SoundClip> clips;
     
    int index = 0;

    void Awake()
    {
        if (playOnAwake) PlayClip(index);
    }

    void RunClip(SoundClip clip)
    {
        source.clip = clip.Clip;
        source.volume = clip.Volume;
        source.loop = clip.Loop;
        source.Play();
    }

    public void PlayClip(int index)
    {
        SoundClip clip = clips[index];
        RunClip(clip);
    }

    public void PlayClip(string name)
    {
        SoundClip clip = clips.Find(c => c.Name == name);
        RunClip(clip);
    }

    public void PlayNext()
    {
        index = index < clips.Count ? index + 1 : 0;
        PlayClip(index);        
    }

    public void StopClip()
    {
        source.Stop();
    }

    public void PauseClip()
    {
        source.Pause();
    }

    public void ResumeClip()
    {
        source.UnPause();
    }
}
