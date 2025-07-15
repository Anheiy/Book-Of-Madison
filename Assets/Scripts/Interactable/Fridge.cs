using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct FridgeObjects
{
    public List<GameObject> obj;
}
public class Fridge : Interactable
{
    public List<FridgeObjects> objects = new List<FridgeObjects>();
    public GameObject fridgeSpawnPoint;
    public List<OptionPrompt> prompt;
    public AudioClip shake_clip;
    public override void Interact()
    {
        this.transform.DOShakePosition(0.2f, strength: 0.5f, vibrato: 100);
        SFXManager.Instance.PlaySFX(shake_clip, location: this.gameObject);
        if(objects.Count != 0)
        {
            foreach (GameObject obj in objects[objects.Count - 1].obj)
            {
                Instantiate(obj, fridgeSpawnPoint.transform.position, Quaternion.identity);
            }
            objects.RemoveAt(objects.Count - 1);
        }
    }

    public override List<OptionPrompt> ScrollText()
    {
        return prompt;
    }
}
