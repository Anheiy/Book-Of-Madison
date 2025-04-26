using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum DoorType {Normal, Locked, Code}

public class Door : Interactable
{
    public GameObject _cameraToDisable;
    public GameObject _cameraToEnable;
    public Transform _TeleportLocation;
    public Transition transition;
    public UnityEvent OpenEvents;
    public List<OptionPrompt> prompt;
    [Space]
    public List<OptionPrompt> lockedPrompt;
    public bool locked;
    public DoorType doorType = DoorType.Normal;
    public Item Key;
    public string Code = "";
    CodeMinigame codeMinigame;
    LockMinigame lockMinigame;
    private void Start()
    {
        codeMinigame = GameObject.Find("GameManager").GetComponent<CodeMinigame>();
        lockMinigame = GameObject.Find("GameManager").GetComponent<LockMinigame>();
    }

    public override void Interact()
    {
        
    }

    public void OpenDoor()
    {
        Player.transform.position = new Vector3(_TeleportLocation.position.x, _TeleportLocation.position.y + 2, _TeleportLocation.position.z);
        Teleport();
    }
    public void OpenLockedDoor()
    {
        Debug.Log("Code");
        if(doorType == DoorType.Locked)
        {
            lockMinigame.StartMinigame(this);
        }
        else if (doorType == DoorType.Code)
        {
            codeMinigame.StartMinigame(this);
        }

    }

    public override List<OptionPrompt> ScrollText()
    {
        if (!locked)
            return prompt;
        else
            return lockedPrompt;
    }

    public void SwitchCamera()
    {
        if(_cameraToDisable != null) 
        _cameraToDisable.SetActive(false);
        if(_cameraToEnable != null)
        _cameraToEnable.SetActive(true);
    }
    public void Teleport()
    {
        StartCoroutine(waitTeleport());
    }

    IEnumerator waitTeleport()
    {
        yield return transition.FadeIn();
        SwitchCamera();
        yield return new WaitForSeconds(2f);
        if(OpenEvents != null) 
            OpenEvents.Invoke();
        yield return transition.FadeOut();
    }

}
