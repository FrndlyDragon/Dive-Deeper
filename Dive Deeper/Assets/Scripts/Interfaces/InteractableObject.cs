using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject: MonoBehaviour
{
    // In Case we have diffrenet promts 
    // relatively close together or
    // two prompts on the same object
    char _promptChar { get; set; }

    public virtual void Interact(){}

    /* Would be used if for example other 
     * parts of the case need to be completed 
     * before the interaction
     */ 
    public bool CanInteract(){return false;}

}
