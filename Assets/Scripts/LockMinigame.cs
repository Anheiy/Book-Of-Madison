using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LockMinigame : MonoBehaviour
{
    Interactable interactable;
    //
    public GameObject KeyUI;
    public GameObject Holder;
    public GameObject ObjectPrefab;
    public AudioClip unlockClip;
    public void StartMinigame(Interactable interactable)
    {
        this.interactable = interactable;
        KeyUI.SetActive(true);
        for (int i = Holder.transform.childCount - 1; i >= 0; i--)
        {
            Debug.Log(i);
            Destroy(Holder.transform.GetChild(i).gameObject);
        }
        GenerateOptions();
        Cursor.visible = true;
    }

    public void Unlock(Item key)
    {
        if(key == interactable.Key)
        {
            interactable.locked = false;
            ExitMinigame();
            SFXManager.Instance.PlaySFX(unlockClip, volume: 20);
        }
        else
        {

        }
    }
    public void GenerateOptions()
    {
        foreach (Item item in InventoryManager.items)
        {
            if (item != null)
            {
                GameObject obj = Instantiate(ObjectPrefab, Holder.transform);
                obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.itemName;
                obj.transform.GetChild(1).GetComponent<Image>().sprite = item.itemSprite;
                obj.GetComponent<Button>().onClick.AddListener(() => Unlock(item));
            }
        }
    }
    public void ExitMinigame()
    {
        KeyUI.SetActive(false);
        Cursor.visible = false;
    }
}
