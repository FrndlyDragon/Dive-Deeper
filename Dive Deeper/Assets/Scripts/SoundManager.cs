using System;
using UnityEngine;
using UnityEngine.Audio;
using Yarn.Unity;

/**
Just add a sound and give it a name. Remember to set volume and make sure pitch is set to 1. Singleton, so you can call it wherever. 
*/
public class SoundManager : MonoBehaviour
{
    [SerializeField] Sounds[] audioSounds;
    public static SoundManager instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }

        foreach (Sounds sounds in audioSounds) {
            sounds.source = gameObject.AddComponent<AudioSource>();
            sounds.source.playOnAwake = false;

            sounds.source.clip = sounds.audioClip;

            sounds.source.volume = GameManager.Instance.volume;
            sounds.source.pitch = sounds.soundPitch;
            sounds.source.loop = sounds.isLooping;
        }
    }

    [YarnCommand("play_sound")]
    public void PlaySound(string name, bool looping) {
        Sounds sound = Array.Find(audioSounds, sounds => sounds.soundName == name);

        if (sound == null) {
            Debug.LogWarning("Audio: " + name + " missing");
            return;
        }

        sound.source.Play();
        sound.source.loop = looping;
        Debug.Log("Playing " + name);
    }

    [YarnCommand("stop_sound")]
    public void StopSound(string name) {
        Sounds sound = Array.Find(audioSounds, sounds => sounds.soundName == name);

        if (sound == null) {
            Debug.LogWarning("Audio: " + name + " missing");
            return;
        }

        sound.source.Stop();
    }

    [YarnCommand("pause_sound")]
    public void PauseSound(string name) {
        Sounds sound = Array.Find(audioSounds, sounds => sounds.soundName == name);

        if (sound == null) {
            Debug.LogWarning("Audio: " + name + " missing");
            return;
        }

        sound.source.Pause();
    }

    [YarnCommand("unpause_sound")]
    public void UnpauseSound(string name) {
        Sounds sound = Array.Find(audioSounds, sounds => sounds.soundName == name);

        if (sound == null) {
            Debug.LogWarning("Audio: " + name + " missing");
            return;
        }

        sound.source.UnPause();
    }

    public void AdjustVolume(float volume) {
        foreach (Sounds sound in audioSounds) {
            sound.soundVol = volume;
            sound.source.volume = volume;
            GameManager.Instance.volume = volume;
        }
    }
}
