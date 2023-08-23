using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager instance;
    [SerializeField] private Backgrounds[] backgrounds;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer backgroundRenderer;

    private void Start() {
        if (instance == null) {
            instance = this;
        }
    }

    [YarnCommand("change_background")]
    public void ChangeBackground(string name) {
        Backgrounds requestedBG = Array.Find(backgrounds, bg => bg.bgName == name);

        if (requestedBG == null) {
            Debug.LogWarning(name + " does not exist");
        }

        spriteRenderer.sprite = requestedBG.bgSprite;
    }

    [YarnCommand("fade_out")]
    public Coroutine FadeTitleOut(float time) {
        return StartCoroutine(ImageAlphaChange(0, time));
    }

    [YarnCommand("fade_in")]
    public Coroutine FadeTitleIn(float time) {
        return StartCoroutine(ImageAlphaChange(1, time));
    }

    IEnumerator ImageAlphaChange(float alpha, float time) {
        float timer = time;
        float startAlpha = alpha;
        Color c = backgroundRenderer.color;
        while (timer > 0f) {
            yield return null;
            timer -= Time.deltaTime;
            c.a = Mathf.Abs(startAlpha - Mathf.Clamp01(timer/time));
            backgroundRenderer.color = c; 
        }
    }
}
