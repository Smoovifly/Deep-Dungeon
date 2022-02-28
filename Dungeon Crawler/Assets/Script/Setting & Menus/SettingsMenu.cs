using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    private MouseLook mouseSensitivity;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetmouseSensitivity(float Sensitivity)
    {
        _ = (mouseSensitivity);
    }


}
