using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSystem/Character")]
public class DialogueCharacter : ScriptableObject
{

    [SerializeField] string character;
    public string Character => character;

}
