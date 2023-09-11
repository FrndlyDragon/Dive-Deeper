using UnityEngine;

[System.Serializable]
public class Sounds
{
    public AudioClip audioClip;

    public string soundName;

    [Range(0f, 1f)]
    public float soundVol;
    [Range(-3f, 3f)]
    public float soundPitch;

    public bool isLooping;

    [HideInInspector]
    public AudioSource source;
}
