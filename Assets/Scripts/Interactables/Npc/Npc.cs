using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour, IInteractable
{
    [SerializeField] TransformSaver start_transform;
    void Awake()
    {
        start_transform = new TransformSaver(transform);
    }

    public void EndInteract()
    {
        GameManager.Instance.dialogueManager.ForceEndDialogue();
        transform.rotation = start_transform.Rotation;
        Debug.Log("ENDING INTERACTING WITH NPC");
    }

    public void Interact()
    {
        GameManager.Instance.player.playerMovement.RotateToLookAt(transform);
        RotateToLookAt(GameManager.Instance.player.playerMovement.rotation);
        GameManager.Instance.dialogueManager.StartDialogue();
        Debug.Log("INTERACTING WITH NPC");
    }
    private void SetOldTransform()
    {
        transform.position = start_transform.Position;
        transform.rotation = start_transform.Rotation;
    }
    private void RotateToLookAt(Transform looker)
    {
        Vector3 thisPos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 otherPos = new Vector3(looker.position.x, 0, looker.position.z);
        transform.rotation = Quaternion.LookRotation(-(thisPos - otherPos));
    }

}
