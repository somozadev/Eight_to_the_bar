
public class DialogueSequencer
{
    public delegate void DialogueCallback(Dialogue dialogue);
    public delegate void DialogueNodeCallback(DialogueNode node);

    public DialogueCallback OnDialogueStart;
    public DialogueCallback OnDialogueEnd;
    public DialogueNodeCallback OnDialogueNodeStart;
    public DialogueNodeCallback OnDialogueNodeEnd;

    private Dialogue current_dialogue;
    private DialogueNode current_node;

    public void StartDialogue(Dialogue dialogue)
    {
        if (current_dialogue == null)
        {
            current_dialogue = dialogue;
            OnDialogueStart?.Invoke(current_dialogue);
            StartDialogueNode(dialogue.First_node);
        }
        else
            throw new DialogueException("There is another dialogue running, cant start a new one!");

    }
    public void EndDialogue(Dialogue dialogue)
    {
        if (current_dialogue == null)
        {
            StopDialogueNode(current_node);
            OnDialogueEnd?.Invoke(current_dialogue);
            current_dialogue = null;
        }
        else
            throw new DialogueException("Trying to stop a dialogue that is not running.");
    }
    private bool CanStartNode(DialogueNode node) { return (current_node == null || node == null || current_node.CanBeFollowedByNode(node)); }
    public void StartDialogueNode(DialogueNode node)
    {
        if (CanStartNode(node))
        {
            StopDialogueNode(current_node);
            current_node = node;

            if (current_node != null)
                OnDialogueNodeStart?.Invoke(current_node);
            else
                EndDialogue(current_dialogue);
        }
        else
            throw new DialogueException("Failed to start dialogue node.");
    }
    private void StopDialogueNode(DialogueNode node)
    {
        if(current_node == node)
        {
            OnDialogueNodeEnd?.Invoke(current_node);
            current_node = null;
        }
        else
            throw new DialogueException("Cant stop a dialogue that is not running!");
    }
}

public class DialogueException : System.Exception
{
    public DialogueException(string message) : base(message)
    {

    }
}
