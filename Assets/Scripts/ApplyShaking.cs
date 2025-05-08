using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ApplyShaking : MonoBehaviour
{
    public float repeatRate = 1;
    public float strength = 1;
    private void Start()
    {
        InvokeRepeating("Shake", 0, repeatRate);
    }
    public void Shake()
    {
        this.transform.DOShakePosition(0.1f, strength);
    }
}
