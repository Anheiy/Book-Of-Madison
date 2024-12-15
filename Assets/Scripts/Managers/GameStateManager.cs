using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    enum State { paused, play, scope}
    private State currentstate = State.play;
    Movement movement;
    Rotation rotation;
    DialogueManager dialogueManager;
    InteractManager interactManager;

    private void Start()
    {
        movement = GameObject.Find("Player").GetComponent<Movement>();
        rotation = GameObject.Find("Player").GetComponent<Rotation>();
        dialogueManager = GetComponent<DialogueManager>();
        interactManager = GetComponent<InteractManager>();
    }
    public void PauseState()
    {
        currentstate = State.paused;
        HandleState();
    }
    public void PlayState()
    {
        currentstate = State.play;
        HandleState();
    }
    public void ScopeState()
    {
        currentstate = State.scope;
        HandleState();
        
    }

    public void HandleState()
    {
        if (currentstate == State.paused)
        {
            movement.lockMovement = true;
            rotation.LockRotation = true;
            Debug.Log("pause state");
        }
        else if (currentstate == State.play)
        {
            movement.lockMovement = false;
            rotation.LockRotation = false;
            interactManager.isInteractLocked = false;
            dialogueManager.isDialogLocked = false;
            Debug.Log("play state");
        }
        else if (currentstate == State.scope)
        {
            movement.lockMovement = true;
            interactManager.isInteractLocked = true;
            dialogueManager.isDialogLocked = true;
            Debug.Log("scope state");
        }
    }
    public string GetState()
    {
        return currentstate.ToString();
    }
}
