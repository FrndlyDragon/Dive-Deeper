using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



/* 
 * This script will be placed as a component on a player and 
 * will be used to detect interactable objects and interact with them irl
 */
public class InteractionDetector : MonoBehaviour
{
    private List<InteractableObject> _interacrableInRange = new List<InteractableObject>();
    public bool selected;
    public SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        // TODO: call interaction here depending on key pressed or smth else idk
        if (selected) {
            if (Input.GetMouseButtonDown(0)) {
                InteractableObject interactableObject = this.GetComponent<InteractableObject>();
                interactableObject.Interact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // GetComponents() beacuse we might have multiple interactions 
        // on same collider
        InteractableObject[] interactables = other.GetComponents<InteractableObject>();

        if (interactables.Length != 0) {
            foreach(InteractableObject interactable in interactables) 
            {
                if (interactable.CanInteract()) {
                    _interacrableInRange.Add(interactable);
                }
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        InteractableObject[] interactables = other.GetComponents<InteractableObject>();

        foreach(InteractableObject interactable in interactables) 
        {
            if (_interacrableInRange.Contains(interactable)) 
            {
                _interacrableInRange.Remove(interactable);
            }
        }
    }

    private void OnMouseOver() {
        //Debug.Log("Selected");
        selected = true;
        spriteRenderer.color = Color.white;
    }

    private void OnMouseExit() {
        //Debug.Log("Unselected");
        selected = false;
        spriteRenderer.color = Color.grey;
    }
}
