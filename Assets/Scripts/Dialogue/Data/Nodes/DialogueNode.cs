using UnityEngine;

public abstract class DialogueNode : ScriptableObject
{
    [SerializeField] DialogueLine dialogue_line;
    public DialogueLine Dialogue_Line => dialogue_line;

    public abstract bool CanBeFollowedByNode(DialogueNode node);
    public abstract void Accept(DialogueNodeVisitor visitor);
}
