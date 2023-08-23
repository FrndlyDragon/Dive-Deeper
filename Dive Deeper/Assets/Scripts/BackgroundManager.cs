using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager instance;
    [SerializeField] private Backgrounds[] backgrounds;
    [SerializeField] private Sprite transitionSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;

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

    [YarnCommand("fade_transition")]
    public void FadeTransition(float fadeIn, float fadeOut) {
        
    }
}
