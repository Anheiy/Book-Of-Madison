using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;
    public GameObject player;
    public GameObject SFXObj;
    public const float hearing_range = 40;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlaySFX(AudioClip clip, float volume = 1f, float pitch = 1f, GameObject location = null)
    {

        if (location == null)
            location = player;
        if (Vector3.Distance(player.transform.position, location.transform.position) > hearing_range)
            return;

        GameObject sfx = Instantiate(SFXObj, location.transform.position, Quaternion.identity);
        AudioSource source = sfx.GetComponent<AudioSource>();
        source.clip = clip;
        source.pitch = pitch;

        // Set 3D settings
        source.spatialBlend = 1f; // Fully 3D
        source.rolloffMode = AudioRolloffMode.Logarithmic;
        source.minDistance = 1f;
        source.maxDistance = hearing_range;
        source.volume = volume;

        source.Play();
        StartCoroutine(HandleSFX(clip.length, sfx));
    }
    public void PlayRandomSFX(AudioClip[] clips, float volume = 1f, float pitch = 1f, GameObject location = null)
    {
        AudioClip clip = clips[Random.Range(0, clips.Length)];
        PlaySFX(clip, volume, pitch, location);
    }
    IEnumerator HandleSFX(float length, GameObject obj)
    {
        yield return new WaitForSeconds(length);
        Destroy(obj);
    }
}
