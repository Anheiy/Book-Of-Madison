using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject rotationObject;
    public Camera mainCamera;          // Reference to the camera
    public float rotationSpeed = 5f;   // Adjust the rotation speed as needed
    public bool LockRotation = false;

    void Update()
    {
        // Adjust mouse position for Render Texture in fullscreen mode
        if (!LockRotation)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 viewportPoint = new Vector3(mousePos.x / Screen.width, mousePos.y / Screen.height, 0);
            Ray ray = mainCamera.ViewportPointToRay(viewportPoint);

            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Get the point where the ray hit
                Vector3 hitPoint = hit.point;

                // Calculate the direction from the player to the hit point
                Vector3 direction = hitPoint - rotationObject.transform.position;
                // Set the direction vector to only affect the Y-axis
                direction.y = 0;

                // Calculate the target rotation
                Quaternion targetRotation = Quaternion.LookRotation(direction.normalized);

                // Smoothly rotate towards the target rotation
                rotationObject.transform.rotation = Quaternion.Slerp(rotationObject.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
