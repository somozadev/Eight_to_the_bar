using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSystem/Line")]
public class DialogueLine : ScriptableObject
{
    [SerializeField] private DialogueCharacter speaker;
    [SerializeField] string text;

    public DialogueCharacter Speaker => speaker;
    public string Text => text;
}
