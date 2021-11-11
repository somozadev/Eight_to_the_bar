using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiDialogueText : MonoBehaviour, DialogueNodeVisitor
{
    [SerializeField] private TextMeshProUGUI speaker_text;
    [SerializeField] private TextMeshProUGUI dialogue_text;

    [SerializeField] RectTransform choices_box_transform;
    [SerializeField] UiDialogueChoice dialogue_choice_prefab;

    [SerializeField] DialogueChannel dialogueChannel;

    private bool listen_to_input = false;
    private DialogueNode next_node = null;

    void Awake()
    {
        dialogueChannel.OnDialogueNodeStart += OnDialogueNodeStart;
        dialogueChannel.OnDialogueNodeEnd += OnDialogueNodeEnd;
        gameObject.SetActive(false);

        choices_box_transform.gameObject.SetActive(false);
    }
    void OnDestroy()
    {
        dialogueChannel.OnDialogueNodeEnd -= OnDialogueNodeEnd;
        dialogueChannel.OnDialogueNodeStart -= OnDialogueNodeStart;
    }
    void Update()
    {
        if (listen_to_input)//&& input listen to submit
            dialogueChannel.RaiseRequestDialogueNode(next_node);
    }
    private void OnDialogueNodeStart(DialogueNode node)
    {
        gameObject.SetActive(true);
        dialogue_text.text = node.Dialogue_Line.Text;
        speaker_text.text = node.Dialogue_Line.Speaker.Character;
        node.Accept(this);
    }
    private void OnDialogueNodeEnd(DialogueNode node)
    {
        next_node = null;
        listen_to_input = false;
        dialogue_text.text = "";
        speaker_text.text = "";
        foreach (Transform child in choices_box_transform)
            Destroy(child.gameObject);

        gameObject.SetActive(false);
        choices_box_transform.gameObject.SetActive(false);
    }
    public void Visit(BasicDialogueNode node)
    {
        listen_to_input = true;
        next_node = node.Next_node;
    }
    public void Visit(ChoiceDialogueNode node)
    {
        choices_box_transform.gameObject.SetActive(true);
        foreach(DialogueChoice choice in node.Choices)
        {
            UiDialogueChoice newChoice = Instantiate(dialogue_choice_prefab,choices_box_transform);
            newChoice.Choice = choice;
        }
    }

}
