using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    enum State { paused, play, scope}
    private State currentstate = State.play;
    Movement movement;
    Rotation rotation;
    DialogueManager dialogueManager;
    InteractManager interactManager;

    public GameObject DeathUI;
    public GameObject WinUI;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene("MainMenu");
        }
    }
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
        }
        else if (currentstate == State.play)
        {
            movement.lockMovement = false;
            rotation.LockRotation = false;
            interactManager.isInteractLocked = false;
            dialogueManager.isDialogLocked = false;
        }
        else if (currentstate == State.scope)
        {
            movement.lockMovement = true;
            interactManager.isInteractLocked = true;
            dialogueManager.isDialogLocked = true;
        }
    }
    public string GetState()
    {
        return currentstate.ToString();
    }
    public void Death()
    {
        Cursor.visible = true;
        DeathUI.SetActive(true);
    }

    public void Win()
    {
        Cursor.visible = true;
        WinUI.SetActive(true);
    }
    public void CloseApplication()
    {
        Application.Quit();
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
