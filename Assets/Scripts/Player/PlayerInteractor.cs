using System.Linq.Expressions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] GameObject current_object;
    [SerializeField] bool isInteracting;
    private bool isCanvasShown;
    [SerializeField] Canvas interact_canvas;
    void Awake()
    {
        isCanvasShown = false;
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered trigger with: " + other.gameObject.name + "\n with tag: " + other.gameObject.tag);
        if (other.GetComponent<IInteractable>() != null && current_object == null)
        {
            current_object = other.gameObject;
            if (!isCanvasShown)
            {
                interact_canvas.gameObject.SetActive(true);
                isCanvasShown = true;
            }
        }
    }
    bool interacted = false;
    void OnTriggerStay(Collider other)
    {
        if (!interacted && isInteracting && current_object != null)
        {
            other.GetComponent<IInteractable>().Interact();
            interact_canvas.gameObject.SetActive(false);
            interacted = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (current_object == other.gameObject)
        {
            other.GetComponent<IInteractable>().EndInteract();
            current_object = null;
            interact_canvas.gameObject.SetActive(false);
            isCanvasShown = false;
            interacted = false;
        }
    }


    private void OnInteractor(InputValue value)
    {
        isInteracting = Convert.ToBoolean(value.Get<float>());
    }
}
