using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public AudioClip buttonSound;
    
    private AudioSource audioSource;

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ButtonSFX"))
        {
            PlaySFX(buttonSound);
        }
        
    }





    public void PlaySFX(AudioClip sfx)
    {
        audioSource.PlayOneShot(sfx); // dando play no audio
    }
}
