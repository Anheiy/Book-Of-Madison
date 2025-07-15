using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class CodeMinigame : MonoBehaviour
{
    private string code = "";
    private Interactable interactable;
    GameStateManager state;
    //UI
    public GameObject CodeUI;
    public TextMeshProUGUI codeTMP;
    public AudioClip unlockClip;
    public AudioClip buttonClip;

    private void Start()
    {
        state = GameObject.Find("GameManager").GetComponent<GameStateManager>();
    }
    public void StartMinigame(Interactable interactable)
    {
        ChangeText("");
        codeTMP.color = Color.white;
        this.interactable = interactable;
        CodeUI.SetActive(true);
        state.PauseState();
        Cursor.visible = true;
    }
    public void SetCode(string key)
    {
        if(code.ToCharArray().Length < interactable.Code.Length)
        ChangeText(code + key);
        SFXManager.Instance.PlaySFX(buttonClip, volume: 0.1f);
        if (code.Length == interactable.Code.Length && interactable.locked == true)
        {
            if(code == interactable.Code)
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
        interactable.locked = false;
        codeTMP.transform.DOScale(1.2f, 0.3f).OnComplete(() => codeTMP.transform.DOScale(1f, 0.3f));
        StartCoroutine(WinTimer());
        state.PlayState();
        SFXManager.Instance.PlaySFX(unlockClip, volume: 20);
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
        state.PlayState();
    }
}
