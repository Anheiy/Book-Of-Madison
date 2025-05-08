using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplay : Interactable
{
    public List<OptionPrompt> prompt;
    public GameObject UIToDisplay;
    [HideInInspector] public GameStateManager state;
    private void OnEnable()
    {
        state = GameObject.Find("GameManager").GetComponent<GameStateManager>();
    }
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
        state.PauseState();
    }
    public void RemoveUI()
    {
        UIToDisplay.SetActive(false);
        Cursor.visible = false;
        state.PlayState();
    }
}
