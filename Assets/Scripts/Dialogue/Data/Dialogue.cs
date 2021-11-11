using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSystem/Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField] private DialogueNode first_node;
    public DialogueNode First_node => first_node;
}
