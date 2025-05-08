using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInteractable : Interactable
{
    public List<OptionPrompt> prompt;
    public override void Interact()
    {
       
    }

    public override List<OptionPrompt> ScrollText()
    {
        return prompt;
    }


}
