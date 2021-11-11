using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiDialogueChoice : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI choice;
    [SerializeField] private DialogueChannel dialogueChannel;

    private DialogueNode choice_next_node;
    public DialogueChoice Choice { set { choice.text = value.Choice_preview; choice_next_node = value.Choice_node; } }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        dialogueChannel.RaiseRequestDialogueNode(choice_next_node);
    }
}
