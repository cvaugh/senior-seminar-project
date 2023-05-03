using UnityEngine;

public class MowingAudio : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip mowingSounds;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(mowingSounds, .3f);
    }
}
