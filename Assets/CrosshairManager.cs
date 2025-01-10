using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairManager : MonoBehaviour
{
    public GameObject scopeCrosshairPrefab;
    public GameObject normalCrosshairPrefab;
    public Material ofInterestMat;
    public Material normalMat;
    public Camera mainCamera;
    public GameStateManager stateManager;

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 viewportPoint = new Vector3(mousePos.x / Screen.width, mousePos.y / Screen.height, 0);
        Ray ray = mainCamera.ViewportPointToRay(viewportPoint);

        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject.GetComponent<Damageable>() != null)
            {
                scopeCrosshairPrefab.GetComponent<MeshRenderer>().material = ofInterestMat;
            }
            else
            {
                scopeCrosshairPrefab.GetComponent<MeshRenderer>().material = normalMat;
            }
            // Get the point where the ray hit
            Vector3 hitPoint = hit.point;
            scopeCrosshairPrefab.transform.position = hitPoint;
            normalCrosshairPrefab.transform.position = hitPoint;
            Cursor.visible = false;
        }

        scopeCrosshairPrefab.SetActive(stateManager.GetState() == "scope");
        normalCrosshairPrefab.SetActive(!(stateManager.GetState() == "scope"));


    }
}
