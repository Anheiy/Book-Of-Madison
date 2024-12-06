using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue Packet", fileName = "Dialogue Packet")]
public class DialoguePacket : ScriptableObject
{
    [System.Serializable]
    public struct Information
    {
        public string[] dialogue;
    }
    public string[] currentName;
    public List<Information> information = new List<Information>();
}
