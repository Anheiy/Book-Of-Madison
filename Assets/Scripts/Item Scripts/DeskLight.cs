using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DeskLight : Interactable
{
    public Light Light;
    public int currentIndex = 0;
    [System.Serializable]
    public struct LightState
    {
        public int range;
        public Color color;
    }
    public List<OptionPrompt> prompt;

    public LightState[] state;
    public override void Interact()
    {

    }
    public void turnOn()
    {
        currentIndex++;
        if (currentIndex > state.Length - 1)
        {
            currentIndex = 0;
        }
        Light.range = state[currentIndex].range;
        Light.color = state[currentIndex].color;
        Debug.Log($"current index: {currentIndex}");
    }

    public override List<OptionPrompt> ScrollText()
    {
        return prompt;
    }
}
