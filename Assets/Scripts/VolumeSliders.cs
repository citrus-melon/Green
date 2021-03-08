using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSliders : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource music;
    [SerializeField]
    private AudioMixer mixer;
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider SFXslider;

    void Awake() {
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        if(PlayerPrefs.HasKey("music")) musicSlider.value = PlayerPrefs.GetFloat("music");
        if (PlayerPrefs.HasKey("SFX")) SFXslider.value = PlayerPrefs.GetFloat("SFX");
    }
    public void musicChange(float sliderValue) {
        music.volume = sliderValue;
        PlayerPrefs.SetFloat("music", sliderValue);
    }

    public void sfxChange(float sliderValue) {
        mixer.SetFloat("SFXvol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFX", sliderValue);
    }

    public void save() {
        PlayerPrefs.Save();
    }
}
