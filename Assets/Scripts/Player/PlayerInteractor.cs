using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] GameObject current_object;
    [SerializeField] bool isInteracting;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger with: " + other.gameObject.name + "\n with tag: " + other.gameObject.tag);

        // if (other.gameObject.tag == "Interactable" && current_object == null)
        if (other.GetComponent<IInteractable>() != null && current_object == null)
        {
            current_object = other.gameObject;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (isInteracting && current_object != null)
        {
            other.GetComponent<IInteractable>().Interact();

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (current_object == other.gameObject)
            current_object = null;
    }


    private void OnInteractor(InputValue value)
    {
        isInteracting = Convert.ToBoolean(value.Get<float>());
    }
}
