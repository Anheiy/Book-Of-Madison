using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAddons : MonoBehaviour
{
    public AudioClip clip;

    [Header("Hiss Settings")]
    public float minInterval = 3f;
    public float maxInterval = 12f;

    private void Start()
    {
        ScheduleNextHiss();
    }

    private void ScheduleNextHiss()
    {
        float delay = Random.Range(minInterval, maxInterval);
        Invoke(nameof(PlayHiss), delay);
    }

    private void PlayHiss()
    {
        if (gameObject.activeInHierarchy)
        {
            SFXManager.Instance.PlaySFX(clip, location: gameObject);
            ScheduleNextHiss();
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
