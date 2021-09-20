using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO - make abstract
public class Interactable : MonoBehaviour
{
    public float radius;
    public bool isFocus = false;

    public Transform interactionTransform;

    private Transform player;
    private bool hasInteracted;


    // TODO - make abstract
    public virtual void Interact()
    {
        // This method is meant to be overridden
        Debug.Log("Interacting with " + transform.name);
    }


    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            var distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
	        }
	    }
    }


    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }


    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
