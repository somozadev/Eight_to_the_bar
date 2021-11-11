using System;
using UnityEngine;


[CreateAssetMenu(menuName = "DialogueSystem/Dialogue_Channel")]
public class DialogueChannel : ScriptableObject
{
    public delegate void DialogueCallback(Dialogue dialogue);
    public DialogueCallback OnDialogueRequested;
    public DialogueCallback OnDialogueStart;
    public DialogueCallback OnDialogueEnd;

    public delegate void DialogueNodeCallback(DialogueNode dialogue);
    public DialogueNodeCallback OnDialogueNodeRequested;
    public DialogueNodeCallback OnDialogueNodeStart;
    public DialogueNodeCallback OnDialogueNodeEnd;

    public void RaiseRequestDialogue(Dialogue dialogue) { OnDialogueRequested?.Invoke(dialogue); }
    public void RaiseDialogueStart(Dialogue dialogue) { OnDialogueStart?.Invoke(dialogue); }
    public void RaiseDialogueEnd(Dialogue dialogue) { OnDialogueEnd?.Invoke(dialogue); }
    
    public void RaiseRequestDialogueNode(DialogueNode dialogue) { OnDialogueNodeRequested?.Invoke(dialogue); }
    public void RaiseDialogueNodeStart(DialogueNode dialogue) { OnDialogueNodeStart?.Invoke(dialogue); }
    public void RaiseDialogueNodeEnd(DialogueNode dialogue) { OnDialogueNodeEnd?.Invoke(dialogue); }


}
