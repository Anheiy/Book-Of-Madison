using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour 
{
    public abstract IEnumerator FadeIn();
    public abstract IEnumerator FadeOut();
}
