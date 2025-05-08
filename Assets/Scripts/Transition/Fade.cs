using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : Transition
{
    public Image fadeObj;

    public override IEnumerator FadeIn()
    {
        Debug.Log("Fade in");
        var Tweener = fadeObj.DOFade(1f, 0f);
        yield return Tweener.WaitForCompletion();
    }

    public override IEnumerator FadeOut()
    {
        Debug.Log("Fade out");
        var Tweener = fadeObj.DOFade(0f, 1f);
        yield return Tweener.WaitForCompletion();
    }
}
