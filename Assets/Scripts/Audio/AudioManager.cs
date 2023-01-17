using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public void StopAllSources()
    {
        FindObjectsOfType<AudioController>().ToList()
            .ForEach(c => c.StopClip());
    }

    public void PauseAllSources()
    {
        FindObjectsOfType<AudioController>().ToList()
            .ForEach(c => c.PauseClip());
    }

    public void ResumeAllSources()
    {
        FindObjectsOfType<AudioController>().ToList()
            .ForEach(c => c.ResumeClip());
    }
}
