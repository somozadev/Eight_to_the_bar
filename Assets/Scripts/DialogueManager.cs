using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public void StartDialogue()
    {
        GameManager.Instance.cameraMovement.MoveCameraToChat();
    }
    public void ForceEndDialogue()
    {
        GameManager.Instance.cameraMovement.MoveCameraToCafeteria();
    }
}