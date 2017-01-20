using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;
using System.Collections.Generic;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour {
	//This is a template of how the settings menu would/could work 
	//It is not fully functional at the moment

	//__Variables__
	//Public to allow for drag and drop in inspector
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown textureQualityDropdown;
    public Dropdown antialiasingDropdown;
    public Dropdown vSyncDropdown;
    public AudioMixer masterMixer;

    private Resolution[] resolutions;

    void OnEnable()
    {
        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        vSyncDropdown.onValueChanged.AddListener(delegate { OnVSyncChange(); });
    }

    void Start()
    {
        resolutions = Screen.resolutions; //Get possible screen

        for (int i = 0; i < resolutions.Length; i++)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(ResToString(resolutions[i])));

            resolutionDropdown.value = i;

            resolutionDropdown.onValueChanged.AddListener(delegate { Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, fullscreenToggle.isOn); });

        }
        for (int j = 0; j < 4; j++)
        {
            if (j == 0)
            {
                antialiasingDropdown.options.Add(new Dropdown.OptionData("0x"));
                antialiasingDropdown.value = 0;
            } else
            {
                antialiasingDropdown.options.Add(new Dropdown.OptionData(((int)Mathf.Pow(2, j)).ToString()+ "x"));
                antialiasingDropdown.value = j;
            }
         }
        antialiasingDropdown.onValueChanged.AddListener(delegate { QualitySettings.antiAliasing = (int)Mathf.Pow(2, antialiasingDropdown.value); });
    }

    string ResToString(Resolution res)
    {
        return res.width + " x " + res.height;
    }

    public void OnFullscreenToggle()
    {
        Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnTextureQualityChange()
    {
        //QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
    }

    public void OnVSyncChange()
    {
        QualitySettings.vSyncCount = vSyncDropdown.value;
    }


    //Audio

    public void SetMusicVolume(float musicvolume)
    {
        Debug.Log(musicvolume);
        masterMixer.SetFloat("MusicVolume", musicvolume);
    }

    public void SetMasterVolume(float mastervolume)
    {
        masterMixer.SetFloat("MasterVolume", mastervolume);
    }

    public void SetEffectsVolume(float effectsvolume)
    {
        masterMixer.SetFloat("EffectsVolume", effectsvolume);
    }
}