using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplay : Interactable
{
    public List<OptionPrompt> prompt;
    public GameObject UIToDisplay;
    public override void Interact()
    {

    }

    public override List<OptionPrompt> ScrollText()
    {
        return prompt;
    }

    public void DisplayUI()
    {
        UIToDisplay.SetActive(true);
        Cursor.visible = true;
    }
    public void RemoveUI()
    {
        UIToDisplay.SetActive(false);
        Cursor.visible = false;
    }
}
