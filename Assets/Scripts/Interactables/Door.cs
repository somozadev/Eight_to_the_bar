using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public void EndInteract()
    {
        Debug.Log("STOP INTERACTING WITH DOOR");
    }

    public void Interact()
    {
        Debug.Log("INTERACTING WITH DOOR");
    }


}
