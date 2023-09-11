using UnityEngine;
using Yarn.Unity;

public class ObjectDialogueTrigger : InteractableObject
{
    public string dialogueNode;
    
    public override void Interact()
    {
        Debug.Log("Activating");
        DialogueRunner dialogueRunner = GameObject.FindObjectOfType<DialogueRunner>();
        dialogueRunner.StartDialogue(dialogueNode);
    }
}
