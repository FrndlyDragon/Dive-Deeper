using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/* 
 * This script will be placed as a component on a player and 
 * will be used to detect interactable objects and interact with them irl
 */
public class InteractionDetector : MonoBehaviour
{
   private List<InteractableObject> _interacrableInRange = new List<InteractableObject>();

    // Update is called once per frame
    void Update()
    {
        // TODO: call interaction here depending on key pressed or smth else idk
    }

    private void OnTriggerRange(Collider2D other) 
    {
        // GerComponents() beacuse we might have multiple interactions 
        // on same collider
        InteractableObject[] interactables = other.GerComponents<InteractableObject>();

        if (interactables.Length() != 0) {
            foreach(InteractableObject interactable in interactables) 
            {
                if (interactable.CanInteract()) {
                    _interacrableInRange.Add(interactable);
                }
            }
        }

    }

    private void OnTriggerExit(Collider2D other) 
    {
        InteractableObject[] interactables = other.GerComponents<InteractableObject>();

        foreach(InteractableObject interactable in interactables) 
        {
            if (_interacrableInRange.Contains(interactable)) 
            {
                _interacrableInRange.Remove(interactable);
            }
        }
    }


}
