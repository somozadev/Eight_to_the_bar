using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSystem/BasicNode")]
public class BasicDialogueNode : DialogueNode
{
    [SerializeField] private DialogueNode next_node;
    public DialogueNode Next_node => next_node;

    public override bool CanBeFollowedByNode(DialogueNode node) { return next_node == node; }

    public override void Accept(DialogueNodeVisitor visitor) { visitor.Visit(this); }
}
