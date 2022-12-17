using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolume : MonoBehaviour
{
    [SerializeField] Slider _volume;
    [SerializeField] AudioSource _mainTheme;
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    private void Update() {
        // Debug.Log(_mainTheme.volume);
        Debug.Log(_volume.value);
    }


    public void ChangeVolume()
    {
        AudioListener.volume = _volume.value;
        Save();
    }

    private void Load()
    {
        _volume.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", _volume.value);
    }
}
