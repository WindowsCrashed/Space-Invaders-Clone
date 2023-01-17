using UnityEngine;

[System.Serializable]
public class SoundClip
{
    [SerializeField] string name;
    [SerializeField] AudioClip clip;
    [SerializeField, Range(0f, 1f)] float volume;
    [SerializeField] bool loop;

    public string Name => name;
    public AudioClip Clip => clip;
    public float Volume => volume;
    public bool Loop => loop;

    public AudioSource Source { get; set; }
}
