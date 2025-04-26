using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class CodeMinigame : MonoBehaviour
{
    private string code = "";
    private Door door;
    GameStateManager state;
    //UI
    public GameObject CodeUI;
    public TextMeshProUGUI codeTMP;

    private void Start()
    {
        state = GameObject.Find("GameManager").GetComponent<GameStateManager>();
    }
    public void StartMinigame(Door door)
    {
        ChangeText("");
        codeTMP.color = Color.white;
        this.door = door;
        CodeUI.SetActive(true);
        state.PauseState();
        Cursor.visible = true;
    }
    public void SetCode(string key)
    {
        ChangeText(code + key);
        if(code.Length == door.Code.Length)
        {
            if(code == door.Code)
            {
                Win();
            }
            else
            {
                Lose();
            }
        }
    }

    public void Win()
    {
        codeTMP.color = Color.green;
        door.locked = false;
        codeTMP.transform.DOScale(1.2f, 0.3f).OnComplete(() => codeTMP.transform.DOScale(1f, 0.3f));
        StartCoroutine(WinTimer());
    }
    public void Lose()
    {
        ChangeText("");
    }

    public void ChangeText(string code)
    {
        this.code = code;
        codeTMP.text = this.code;
    }

    IEnumerator WinTimer()
    {
        
        yield return new WaitForSeconds(2);
        ExitMinigame();
    }

    public void ExitMinigame()
    {
        CodeUI.SetActive(false);
        Cursor.visible = false;
    }
}
