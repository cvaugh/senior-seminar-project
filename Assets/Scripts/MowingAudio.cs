using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MowingAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip mowingSounds;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(mowingSounds, .3f);
    }

}
