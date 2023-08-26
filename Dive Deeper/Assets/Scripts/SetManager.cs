using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SetManager : MonoBehaviour
{
    [SerializeField] private InteractableSet[] sets;
    private int prevSet = 0;

    [YarnCommand("activate_set")]
    public void ActivateSet(int setIndex) {        
        InteractableSet interactableSet = sets[prevSet];

        foreach (GameObject gameObject in interactableSet.interactableObjects) {
            gameObject.SetActive(false);
        }

        interactableSet = sets[setIndex];

        foreach (GameObject gameObject in interactableSet.interactableObjects) {
            gameObject.SetActive(true);
        }

        prevSet = setIndex;
    }
}
