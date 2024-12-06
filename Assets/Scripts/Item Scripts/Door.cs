using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : Interactable
{
    public GameObject _cameraToDisable;
    public GameObject _cameraToEnable;
    public Transform _TeleportLocation;
    public Transition transition;
    public UnityEvent unityEvent;
    public List<OptionPrompt> prompt;
    public override void Interact()
    {
        Player = GameObject.Find("Player");
        Player.transform.position = new Vector3(_TeleportLocation.position.x, _TeleportLocation.position.y + 2, _TeleportLocation.position.z);
        Teleport();
    }

    public override List<OptionPrompt> ScrollText()
    {
        return prompt;
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
        if(unityEvent != null) 
            unityEvent.Invoke();
        yield return transition.FadeOut();
    }

}
