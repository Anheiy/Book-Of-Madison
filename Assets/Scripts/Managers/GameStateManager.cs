using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    enum State { paused, play}
    State currentstate = State.play;

    private void Update()
    {
        if(currentstate == State.paused)
        {
            Movement.lockMovement = true;
            Rotation.LockRotation = true;
        }
        if (currentstate == State.paused)
        {
            Movement.lockMovement = false;
            Rotation.LockRotation = false;
        }
    }
    public void Pause()
    {
        currentstate = State.paused;
    }
    public void Unpause()
    {
        currentstate = State.paused;
    }
}
