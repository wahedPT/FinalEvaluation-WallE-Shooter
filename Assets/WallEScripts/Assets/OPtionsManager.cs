using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OPtionsManager : MonoBehaviour
{
    public Slider VOlslider;
    public AudioManager audioManager;
    //private AudioManager audioManager; we can take is to and drag and drop the audio manager


    // Start is called before the first frame update
    void Start()
    {
        print(PlayerPrefsManager.GetMasterVolume());
        VOlslider.value = PlayerPrefsManager.GetMasterVolume();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
       // audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        audioManager.SetVolume("BackGround", VOlslider.value);
    }
  
    public void SaveandExit()
    {
        PlayerPrefsManager.SetMasterVolume(VOlslider.value);
        print(PlayerPrefsManager.GetMasterVolume());
    }

    public void SetDeafualt()
    {
        VOlslider.value = 0.5f;
    }
}
