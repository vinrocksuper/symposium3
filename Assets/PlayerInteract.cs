using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;
    // Start is called before the first frame update
    public void update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)
        {
            if (currentInterObjScript.talks)
            {
                currentInterObjScript.Talk();
            }
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2d(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
    }
    void OnTriggerExit2d(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }

    }
}