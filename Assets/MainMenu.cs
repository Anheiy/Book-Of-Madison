using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    public GameObject MadiOBJ;
    private void Start()
    {
        MadiOBJ.transform.DOLocalMoveY(MadiOBJ.transform.localPosition.y + 5f, 2)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }
    public void CloseApplication()
    {
        Application.Quit();
    }

    public static void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
