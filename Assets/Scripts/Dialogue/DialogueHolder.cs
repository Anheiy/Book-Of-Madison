using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : Interactable
{
    public DialoguePacket dialogue;
    DialogueManager dialogueManager;
    List<OptionPrompt> prompt = new List<OptionPrompt>();

    private void Start()
    {
        dialogueManager = GameObject.Find("GameManager").GetComponent<DialogueManager>();
    }
    public override void Interact()
    {
        dialogueManager.CollectDialogue(dialogue);
        Destroy(this); //Destroys this script
        Debug.Log("Hello!");
    }

    public override List<OptionPrompt> ScrollText()
    {
        return prompt;
    }
}
