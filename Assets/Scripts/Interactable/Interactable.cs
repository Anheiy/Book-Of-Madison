using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Interactable : MonoBehaviour
{
    [HideInInspector]public GameObject Player;
    [HideInInspector] public InteractManager InteractManager;
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
    public bool locked;
    public DoorType doorType = DoorType.Normal;
    public Item Key;
    public string Code = "";
    public bool ignoreIntial;
    

    public abstract List<OptionPrompt> ScrollText();


    public abstract void Interact();
    private void Awake()
    {
        Player = GameObject.Find("Player");
        InteractManager = GameObject.Find("GameManager").GetComponent<InteractManager>();
    }

    private void Update()
    {
        if (Player != null)
        {
            float distance = Vector3.Distance(Player.transform.position, transform.position);
            if (distance < InteractManager.InteractRange)
            {
                InteractManager.ReplaceInteractObject(gameObject);
            }
        }
    }
}
