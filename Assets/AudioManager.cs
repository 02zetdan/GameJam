using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System.Globalization;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    private void Start()
    {
        Play("Background Music");
    }
    private Sound FindSound(string name)
    {
        Sound foundSound = null;
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                foundSound = s;
                break;
            }
        }
        return foundSound;
    }
    public void Play(string name)
    {
        Sound foundSound = FindSound(name);
        if (foundSound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        foundSound.source.Play();
    }
    public void Stop(string name) 
    {
        Sound foundSound = FindSound(name);
        if (foundSound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        foundSound.source.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
