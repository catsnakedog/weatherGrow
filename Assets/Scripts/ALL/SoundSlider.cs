using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ; 
public class SoundSlider : MonoBehaviour
{
   [SerializeField] Slider VolumeSlider ;

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musicvolume"))
        {
            PlayerPrefs.SetFloat("musicvolume",1) ;

        }
        else{
            Load() ; 
        }
    }

    // Update is called once per frame
public void ChangeVolume()
{
    AudioListener.volume = VolumeSlider.value ;
}
public void Load()
{
    VolumeSlider.value = PlayerPrefs.GetFloat("musicvolume",VolumeSlider.value);
}

private void Save()
{
    PlayerPrefs.SetFloat("musicvolume",VolumeSlider.value) ; 
}
}
