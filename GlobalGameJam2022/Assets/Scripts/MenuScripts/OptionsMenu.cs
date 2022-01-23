using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown reolutionDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        reolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) 
        { 
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height) currResIndex = i;
        }
      
        reolutionDropdown.AddOptions(options);
        reolutionDropdown.value = currResIndex;
        reolutionDropdown.RefreshShownValue();
    }

    public void setResolution (int resolIndex)
    {
        Resolution resolution = resolutions[resolIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void setQuality(int qualIndex)
    {
        QualitySettings.SetQualityLevel(qualIndex);
    }

    public void setFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
}
