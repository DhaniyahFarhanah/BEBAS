using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBackgroundAudio : MonoBehaviour
{

    private AudioSource forestAudioSource;
    [SerializeField]private AudioSource wardAudioSource;


    private void Awake()
    {
        TryGetComponent(out forestAudioSource);
    }

    private void Start()
    {
        DoorEnterScript.EnteredWard += ChangeAudio;
    }
    private void OnDestroy()
    {
        DoorEnterScript.EnteredWard -= ChangeAudio;
    }


    private void ChangeAudio()
    {
        forestAudioSource.enabled = false;
        wardAudioSource.enabled = true;
    }
}
