using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : Interactable
{
    public List<GameObject> objects = new List<GameObject>();
    public GameObject fridgeSpawnPoint;
    public List<OptionPrompt> prompt;
    public override void Interact()
    {
        this.transform.DOShakePosition(0.2f, strength: 0.5f, vibrato: 100);
        if(objects.Count != 0)
        {
            Instantiate(objects[objects.Count - 1], fridgeSpawnPoint.transform.position, Quaternion.identity);
            objects.RemoveAt(objects.Count - 1);
        }
    }

    public override List<OptionPrompt> ScrollText()
    {
        return prompt;
    }
}
