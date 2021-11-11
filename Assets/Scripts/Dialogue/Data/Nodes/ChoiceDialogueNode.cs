using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "DialogueSystem/ChoiceDialogue")]
public class ChoiceDialogueNode : DialogueNode
{
    [SerializeField] private DialogueChoice[] choices;
    public DialogueChoice[] Choices => choices;

    public override bool CanBeFollowedByNode(DialogueNode node) { return choices.Any(x => x.Choice_node == node); }

    public override void Accept(DialogueNodeVisitor visitor) { visitor.Visit(this); }
}

[System.Serializable]
public class DialogueChoice
{
    [SerializeField]
    private string choice_preview;
    [SerializeField]
    private DialogueNode choice_node;

    public string Choice_preview => choice_preview;
    public DialogueNode Choice_node => choice_node;
}