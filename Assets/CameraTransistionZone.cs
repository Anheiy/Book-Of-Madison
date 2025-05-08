using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransistionZone : MonoBehaviour
{
    public GameObject cameraToDisable;
    public GameObject cameraToEnable;
    private void OnTriggerEnter(Collider other)
    {
        cameraToDisable.SetActive(false);
        cameraToEnable.SetActive(true);
    }
}
