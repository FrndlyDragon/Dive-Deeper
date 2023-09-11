using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

/**
Just add a sound and give it a name. Remember to set volume and make sure pitch is set to 1. Singleton, so you can call it wherever. 
*/
public class SoundManager : MonoBehaviour
{
    [SerializeField] Sounds[] audioSounds;
    public static SoundManager instance;

    void Start() {
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

        if (SceneManager.GetActiveScene().buildIndex == 0) {
            PlaySound("Space_Calm", true);
        }
    }

    [YarnCommand("play_sound")]
    public void PlaySound(string name, bool looping) {
        Sounds sound = Array.Find(audioSounds, sounds => sounds.soundName == name);

        if (sound == null) {
            Debug.LogWarning("Audio: " + name + " missing");
            return;
        }

        sound.source.volume = 0f;
        sound.source.Play();
        sound.source.loop = looping;
        StartCoroutine(FadeVolIn(sound.source));

        Debug.Log("Playing " + name);
    }

    [YarnCommand("stop_sound")]
    public void StopSound(string name) {
        Sounds sound = Array.Find(audioSounds, sounds => sounds.soundName == name);

        if (sound == null) {
            Debug.LogWarning("Audio: " + name + " missing");
            return;
        }

        StartCoroutine(FadeVolOut(sound.source));
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

    public IEnumerator FadeVolIn(AudioSource audioSource) {
        float temp = 0f;
        while (audioSource.volume < GameManager.Instance.volume) {
            yield return null;
            temp += Time.deltaTime;
            audioSource.volume = GameManager.Instance.volume * temp/2f;
            //Debug.Log(audioSource.volume);
        }

    }

    public IEnumerator FadeVolOut(AudioSource audioSource) {
        float temp = 2f;
        while (audioSource.volume > 0) {
            yield return null;
            temp -= Time.deltaTime;
            audioSource.volume = GameManager.Instance.volume * temp/2f;
            //Debug.Log(audioSource.volume);
        }

        audioSource.Stop();
    }
}
