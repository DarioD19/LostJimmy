using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteeps : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] _clips;
    private AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void Step()
    {
        AudioClip clip = GetRandomClip();
        _audioSource.PlayOneShot(clip);
        _audioSource.PlayDelayed(0.2f);
    }
    private AudioClip GetRandomClip()
    {
        return _clips[UnityEngine.Random.Range(0, _clips.Length)];
    }
}
