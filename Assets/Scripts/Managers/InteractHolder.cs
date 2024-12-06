using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractHolder : MonoBehaviour
{
    public GameObject InteractObject;
    public GameObject Player;
    public Range range;
    //
    public CanvasGroup TextUI;
    public TextMeshProUGUI InteractText;
    public int currentTextIndex = 0;
    //
    public GameObject OptionPrompt;
    public GameObject OptionsLocation;
    //also checks if it is in a line infront of player
    public float InteractRange = 2;
    private Tween fadeTween;
    //
    private GameStateManager GameState;
    private void Start()
    {
        GameState = GameObject.Find("GameManager").GetComponent<GameStateManager>();
    }

    private void Update()
    {
        if (InteractObject != null)
        {
            CheckRange();
            CheckInfront();
        }
        if (Input.GetKeyDown(KeyCode.E))
            Interact();
        else if (Input.GetKeyDown(KeyCode.Q))
            Deselect();
    }
    public void ReplaceInteractObject(GameObject obj)
    {
        if (InteractObject == obj)
            return;

        if ((InteractObject == null && range.ObjectsInfront.Contains(obj))
    || (InteractObject != null
        && Vector3.Distance(Player.transform.position, InteractObject.transform.position) > Vector3.Distance(Player.transform.position, obj.transform.position)
        && range.ObjectsInfront.Contains(obj)
        && Vector3.Distance(Player.transform.position, obj.transform.position) <= InteractRange))
        {
            InteractObject = obj;
            EnableUI();
            Debug.Log("Replaced InteractObject");
        }
    }

    public void CheckRange()
    {
        if (InteractObject == null) return;

        float distance = Vector3.Distance(Player.transform.position, InteractObject.transform.position);
        if (InteractObject.GetComponent<Interactable>() == null || distance > InteractRange)
        {
            Debug.Log($"Object out of range: {InteractObject.name}, Distance: {distance}");
            DisableUI();
        }
    }

    public void CheckInfront()
    {
        if (InteractObject == null) return;

        if (!range.ObjectsInfront.Contains(InteractObject))
        {
            Debug.Log($"Object not infront");
            DisableUI();
        }
    }


    public void Interact()
    {
        if(InteractObject == null)
            return ;
        
        List<Interactable.OptionPrompt> text = InteractObject.GetComponent<Interactable>().ScrollText();
        if (text.Count > currentTextIndex)
        {
            if ((currentTextIndex != 0) && InteractObject.GetComponent<Interactable>().ignoreIntial)
            {
                GameState.Pause();
            }
            else if(!InteractObject.GetComponent<Interactable>().ignoreIntial)
            {
                GameState.Unpause();
            }
            InteractText.text = text[currentTextIndex].PromptText;
            //Add Option Prompts
            for (int i = 0; i < OptionsLocation.transform.childCount; i++)
            {
                Destroy(OptionsLocation.transform.GetChild(i).gameObject);
            }
            for (int i = 0; i < text[currentTextIndex].buttons.Length; i++)
            {
                GameObject button = Instantiate(OptionPrompt, OptionsLocation.transform);
                button.GetComponent<TextMeshProUGUI>().text = "<sprite=" + (i + 2) +"> " +text[currentTextIndex].buttons[i].text;
            }
            if (currentTextIndex - 1 != -1 && text[currentTextIndex].buttons[0].selectionEvent != null)
            {
                text[currentTextIndex - 1].buttons[0].selectionEvent.Invoke();
            }
        }
        
        currentTextIndex++;
        if(text.Count < currentTextIndex)
        {
            Debug.Log("Text Count: "+ text.Count + "currentTextIndex: " + currentTextIndex);
            InteractObject.GetComponent<Interactable>().Interact();
            Deselect();
            
            
        }
        
    }
    public void Deselect()
    {
        StartCoroutine(DisableandEnableTimer());
    }
    public void DisableUI()
    {
        if (fadeTween != null)
        {
            fadeTween.Kill();
        }
        fadeTween = TextUI.DOFade(0, 0.1f).OnComplete(() =>
        {
            Debug.Log("Faded");
            for (int i = 0; i < OptionsLocation.transform.childCount; i++)
            {
                Destroy(OptionsLocation.transform.GetChild(i).gameObject);
            }
            
            currentTextIndex = 0;
            Movement.lockMovement = false;
            Rotation.LockRotation = false;
            
        });
        InteractObject = null;
    }
    public void EnableUI()
    {
        if (currentTextIndex == 0 && OptionsLocation.transform.childCount == 0)
        {
            if (!InteractObject.GetComponent<Interactable>().ignoreIntial)
            {
                InteractText.text = "What's this?";
                GameObject button = Instantiate(OptionPrompt, OptionsLocation.transform);
                button.GetComponent<TextMeshProUGUI>().text = "<sprite=2> Examine";
            }
            else
            {
                Interact();
            }
            fadeTween = TextUI.DOFade(1, 0.1f);
        }

        
    }
    IEnumerator DisableandEnableTimer()
    {
        DisableUI();
        yield return new WaitForSeconds(0.3f);
        if(InteractObject != null)
        EnableUI();
    }

}
