using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu1 : MonoBehaviour
{
    public AudioMixer audioMixer;


    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("InGame", volume);
        
    }


}
