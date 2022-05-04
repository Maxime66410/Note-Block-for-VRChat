// By Maxime66410

using System; // Unused
using TMPro;    // TextMesh Pro is an easy-to-use system for high-quality text.
using UdonSharp;    // Library UdonSharp
using UnityEngine;  //  Library Unity
using UnityEngine.UI;   //  Library UI Unity
using VRC.SDKBase;  // Unused
using VRC.Udon; // Unused
using VRC.Udon.Common.Interfaces;   // VRC Library for network

public class noteBlock : UdonSharpBehaviour
{
    [Header("Integration Component")]
    private AudioChorusFilter _audioChorusFilter;   // Component Audio Filter
    [SerializeField] private Slider _sliderChangeAudio; // Component Slider UI
    [SerializeField] private TextMeshProUGUI _textSliderNumber; // Component ->Text<- Mesh Pro
    public AudioClip[] _audioClips; // Component Array Clip
    public AudioSource _audioSource;    // Component Audio Source
    public GameObject prefabEfect;  // Component GameObject for Effect
    
    
    [Header("Global Value")]
    [UdonSynced] public int TypeSound;  // Type of Sound (SYNC)
    [UdonSynced] public float SliderValue;  // SliderValue (SYNC)
    private float TimeToDisable = 0.0f; //  Time Disable Effect (NO SYNC)

    void Start()    // Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
    {
        if (_audioChorusFilter == null) // if audio Chorus if empty, then search in the gameobject
        {
            _audioChorusFilter = this.gameObject.GetComponent<AudioChorusFilter>();
        }
    }

    public void Update()    // Update is called every frame, if the MonoBehaviour is enabled.
    {
        _textSliderNumber.text = SliderValue.ToString();    // Set text with Slider Value
        _audioChorusFilter.depth = SliderValue; // Set value in Depth of Chorus Filter
        _sliderChangeAudio.value = SliderValue; // Set Value on Slider

        if (prefabEfect.activeSelf) // If effect is ON
        {
            TimeToDisable = TimeToDisable + Time.deltaTime; // Add Time Secondes

            if (TimeToDisable >= 1.0f)  // if TimeToDisable is greater than 1.0f
            {
                prefabEfect.SetActive(false);   // Disable Effect
                TimeToDisable = 0.0f;   // Reset Timer
            }
        }
    }

    public void SyncSlider()    // Sync Slider
    {
        SliderValue = _sliderChangeAudio.value;
    }

    public override void OnPickupUseUp()    // if Player Use Pickup
    {
        SendCustomNetworkEvent(NetworkEventTarget.All, "LaunchSound");  // Launch All Function -> LaunchSound -> ALL
    }

    public void LaunchSound()   // Function to Launch Song
    {
        _audioSource.PlayOneShot(_audioClips[TypeSound]);   // Plays an AudioClip, and scales the AudioSource volume by volumeScale.
        prefabEfect.SetActive(true);    // Enable Effect
    }

    /// <summary>
    /// A bit of a mess, but that's how I set a type of sound.
    /// We can clearly improve or optimize all this, but I let you do as you see fit.
    /// It's a quick little script.
    /// </summary>
    
    public void setBanjo()
    {
        TypeSound = 0;
    }
    
    public void setBass()
    {
        TypeSound = 1;
    }
    
    public void setBd()
    {
        TypeSound = 2;
    }
    
    public void setBell()
    {
        TypeSound = 3;
    }
    
    public void setDidgeridoo()
    {
        TypeSound = 4;
    }
    
    public void setCowbell()
    {
        TypeSound = 5;
    }
    
    public void setFlute()
    {
        TypeSound = 6;
    }
    
    public void setHarp()
    {
        TypeSound = 7;
    }
    
    public void setGuitar()
    {
        TypeSound = 8;
    }
    
    public void setHat()
    {
        TypeSound = 9;
    }
    
    public void setXylophone()
    {
        TypeSound = 10;
    }
    
    public void setIcechime()
    {
        TypeSound = 11;
    }
    
    public void setSnare()
    {
        TypeSound = 12;
    }
    
    public void setPling()
    {
        TypeSound = 13;
    }
    
    public void setXylobone()
    {
        TypeSound = 14;
    }
    
    public void setBit()
    {
        TypeSound = 15;
    }
}
