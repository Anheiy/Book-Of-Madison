using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject 
{
    public string itemName = "Placeholder Name";
    public string itemDescription = "Placeholder Text";
    public Sprite itemSprite;
    public GameObject HeldPrefab;
    public GameObject WorldPrefab;
}
