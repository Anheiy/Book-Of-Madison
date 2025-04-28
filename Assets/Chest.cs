using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chest : Interactable
{
    public List<OptionPrompt> prompt;
    [Space]
    public List<OptionPrompt> lockedPrompt;
    CodeMinigame codeMinigame;
    LockMinigame lockMinigame;
    public Transform lid;
    public List<GameObject> droppedObjects;


    public override void Interact()
    {
        
    }

    public override List<OptionPrompt> ScrollText()
    {
        if (!locked)
            return prompt;
        else
            return lockedPrompt;
    }

    private void Start()
    {
        codeMinigame = GameObject.Find("GameManager").GetComponent<CodeMinigame>();
        lockMinigame = GameObject.Find("GameManager").GetComponent<LockMinigame>();
    }
    public void OpenChest()
    {
        lid.DORotate(new Vector3(90, 0, 0), 1.5f, RotateMode.WorldAxisAdd);
        foreach (GameObject obj in droppedObjects)
        {
            Instantiate(obj, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        }
        Destroy(this);
    }
    public void UnlockChest()
    {
        if (doorType == DoorType.Locked)
        {
            lockMinigame.StartMinigame(this);
        }
        else if (doorType == DoorType.Code)
        {
            codeMinigame.StartMinigame(this);
        }
    }

}
