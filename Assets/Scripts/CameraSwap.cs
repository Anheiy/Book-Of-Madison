using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public GameObject _cameraToDisable;
    public GameObject _cameraToEnable;

    public void SwitchCamera()
    {
        _cameraToDisable.SetActive(false);
        _cameraToEnable.SetActive(true);
    }
}
