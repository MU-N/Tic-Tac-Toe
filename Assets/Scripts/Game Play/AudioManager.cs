using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.AudioSource = gameObject.AddComponent<AudioSource>();
            sound.AudioSource.clip = sound.clip;
            sound.AudioSource.volume = sound.volume;
            sound.AudioSource.loop = sound.loop;
        }
        FindObjectOfType<AudioManager>().playAudio("theme");
    }

    public void playAudio(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Audio sourec {name} not found");
            return;
        }
        s.AudioSource.Play();

        //how to play audio
        //FindObjectOfType<AudioManager>().playAudio("");

        // play item
        //FindObjectOfType<AudioManager>().playAudio("item");

        // play click
        //FindObjectOfType<AudioManager>().playAudio("click");

        // play death
        //FindObjectOfType<AudioManager>().playAudio("death");

        // play door
        //FindObjectOfType<AudioManager>().playAudio("door");

        // play deawer
        //FindObjectOfType<AudioManager>().playAudio("deawer");

        // play lose
        //FindObjectOfType<AudioManager>().playAudio("lose");

        // play victory
        //FindObjectOfType<AudioManager>().playAudio("victory");

        // play theme
        //FindObjectOfType<AudioManager>().playAudio("theme");
    }
}
