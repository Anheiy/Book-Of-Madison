using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Interactable : MonoBehaviour
{
    public GameObject Player;
     
    [Serializable]
    public struct OptionPrompt
    {
        public string PromptText;
        public OptionButton[] buttons;
    }
    [Serializable]
    public struct OptionButton
    {
        public string text;
        public UnityEvent selectionEvent;
    }
    public bool ignoreIntial;
    [HideInInspector] public InteractHolder InteractHolder;

    public abstract List<OptionPrompt> ScrollText();


    public abstract void Interact();
    private void Awake()
    {
        Player = GameObject.Find("Player");
        InteractHolder = GameObject.Find("GameManager").GetComponent<InteractHolder>();
    }

    private void Update()
    {
        if (Player != null)
        {
            float distance = Vector3.Distance(Player.transform.position, transform.position);
            if (distance < InteractHolder.InteractRange)
            {
                InteractHolder.ReplaceInteractObject(gameObject);
            }
        }
    }
}
