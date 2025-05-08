using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textbox;
    public TextMeshProUGUI namebox;
    public CanvasGroup textPanel;
    //
    public DialoguePacket packet;
    private int informationIndex = 0;
    private int dialogueIndex = 0;
    private Coroutine currentCoroutine;
    public bool isDialogLocked = false;
    //
    GameStateManager state;
    private void Start()
    {
        state = GameObject.Find("GameManager").GetComponent<GameStateManager>();
    }
    public void CollectDialogue(DialoguePacket packet)
    {
        if (this.packet == null)
        {
            textPanel.alpha = 1;
            textPanel.DOFade(1, 0.2f);
            
            this.packet = packet;
            SwapText();
            state.PauseState();
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            SwapText();
        }
    }
    private void SwapText()
    {
        if (isDialogLocked == false)
        {
            if (currentCoroutine != null)
                StopCoroutine(currentCoroutine);
            if (packet != null)
            {
                if (packet.information.Count > informationIndex)
                {

                    //if the informationIndex exists
                    if (!(packet.information[informationIndex].dialogue.Length - 1 < dialogueIndex))
                    {

                        LoadDialogue(packet.information[informationIndex].dialogue[dialogueIndex]);
                        dialogueIndex++;

                    }
                    else
                    {
                        informationIndex++;
                        dialogueIndex = 0;
                        if (packet.information.Count > informationIndex)
                        {
                            LoadDialogue(packet.information[informationIndex].dialogue[dialogueIndex]);
                            dialogueIndex++;
                        }
                        else
                        {
                            //if the informationIndex dont exist reset it
                            CloseDialog();
                        }
                    }

                }
            }
        }
    }
    public void CloseDialog()
    {
        textPanel.DOFade(0, 0.3f);
        packet = null;
        dialogueIndex = 0;
        informationIndex = 0;
        state.PlayState();
    }

    private void LoadDialogue(string dialogue)
    {
        if(packet.currentName.Length > 0 && packet.currentName[informationIndex] != null)
            namebox.text = packet.currentName[informationIndex];
        else
            namebox.text = "";
        char[] characters = dialogue.ToCharArray();
        currentCoroutine = StartCoroutine(CharacterSeperator(characters));
    }

    IEnumerator CharacterSeperator(char[] characters)
    {
        string currentLength = "";
        for(int i = 0; i < characters.Length; i++)
        {
            currentLength += characters[i];
            textbox.text = currentLength;
            yield return new WaitForSeconds(0.04f);
        }
    }
}
