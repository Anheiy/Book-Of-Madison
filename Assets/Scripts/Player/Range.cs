using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    public List<GameObject> ObjectsInfront = new List<GameObject>();

    private Collider rangeCollider;

    private void Awake()
    {
        // Get the collider of the trigger
        rangeCollider = GetComponent<Collider>();
        if (!rangeCollider || !rangeCollider.isTrigger)
        {
            //Debug.LogError("The Range object needs a Collider with 'Is Trigger' enabled.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!ObjectsInfront.Contains(other.gameObject) && IsValidTarget(other))
        {
            ObjectsInfront.Add(other.gameObject);
            //Debug.Log($"Added {other.gameObject.name} to ObjectsInfront.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        RemoveFromList(other.gameObject);
    }

    private void Update()
    {
        // Clean up destroyed or deactivated objects
        ObjectsInfront.RemoveAll(obj => obj == null || !obj.activeInHierarchy);

        // Check if objects are still within the trigger zone
        ObjectsInfront.RemoveAll(obj => !IsObjectInRange(obj));
    }

    private void RemoveFromList(GameObject obj)
    {
        if (ObjectsInfront.Contains(obj))
        {
            ObjectsInfront.Remove(obj);
            //Debug.Log($"Removed {obj.name} from ObjectsInfront.");
        }
    }

    private bool IsObjectInRange(GameObject obj)
    {
        if (obj == null || !obj.activeInHierarchy)
        {
            return false;
        }

        // Check if the object's bounds overlap the trigger's bounds
        Collider objCollider = obj.GetComponent<Collider>();
        return objCollider != null && rangeCollider.bounds.Intersects(objCollider.bounds);
    }

    private bool IsValidTarget(Collider other)
    {
        // Ensure the object is a valid target for interaction
        return other.gameObject.GetComponent<Interactable>() != null;
    }
}