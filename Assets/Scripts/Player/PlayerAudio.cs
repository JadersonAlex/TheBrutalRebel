using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{

    private AudioSource audioSource;


    public AudioClip coinSound;
    public AudioClip jumpSound;
    public AudioClip hitSound;

    public AudioClip buttonSound;




    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    public void PlaySFX(AudioClip sfx)
    {
        audioSource.PlayOneShot(sfx); // dando play no audio
    }
}
