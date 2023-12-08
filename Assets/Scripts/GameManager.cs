using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;
    private AudioSource _audioSource => GetComponent<AudioSource>();
    

    public void PlaySound(int clip)
    {
        _audioSource.Stop();
        _audioSource.PlayOneShot(_audioClips[clip], 1f);
    }
}
