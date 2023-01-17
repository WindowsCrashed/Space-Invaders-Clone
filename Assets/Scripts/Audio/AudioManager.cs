using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] List<SoundClip> clips;

    void Awake()
    {
        foreach (SoundClip clip in clips)
        {
            clip.Source = gameObject.AddComponent<AudioSource>();
            clip.Source.clip = clip.Clip;
            clip.Source.volume = clip.Volume;
            clip.Source.loop = clip.Loop;
        }
    }

    public void PlayClip(string name)
    {
        clips.Find(c => c.Name == name)?.Source.Play();
    }

    public void StopClip(string name)
    {
        clips.Find(c => c.Name == name)?.Source.Stop();
    }

    public SoundClip GetClip(string name)
    {
        return clips.Find(c => c.Name == name);
    }
}
