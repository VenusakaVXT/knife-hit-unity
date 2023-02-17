using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio assign;

    private void Awake()
    {
        assign = this;
    }

    public void playSound(string str, float volumeSound)
    {
        AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.volume *= volumeSound;
        // Pass the audio in to play
        audioSource.PlayOneShot((AudioClip)Resources.Load("Sound/" + str, typeof(AudioClip)));
    }
}
