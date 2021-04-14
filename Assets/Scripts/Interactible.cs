using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    [SerializeField] private Transform interactibleTransform;
    public float radius = 3f;
    bool isFocus = false;
    Transform player;
    bool alreadyInteracted =false;

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        alreadyInteracted = false;
    }
    public void OnDefocused()
    {
        isFocus = false; 
        player = null;
    }

    public virtual void Interact()
    {
        Debug.Log("You were interacted with " + transform.name);

    }
    private void Update()
    {
        if (isFocus && !alreadyInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance<=radius)
            {
                Interact();
                alreadyInteracted = true;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (interactibleTransform == null)
            interactibleTransform = transform;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
