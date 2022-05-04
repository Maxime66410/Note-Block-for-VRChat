// By Maxime66410

using System;
using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

public class noteBlock : UdonSharpBehaviour
{
    [Header("Integration Component")]
    private AudioChorusFilter _audioChorusFilter;
    [SerializeField] private Slider _sliderChangeAudio;
    [SerializeField] private TextMeshProUGUI _textSliderNumber;
    public AudioClip[] _audioClips;
    public AudioSource _audioSource;
    [UdonSynced] public int TypeSound;
    [UdonSynced] public float SliderValue;
    public GameObject prefabEfect;
    private float TimeToDisable = 0.0f;

    void Start()
    {
        if (_audioChorusFilter == null)
        {
            _audioChorusFilter = this.gameObject.GetComponent<AudioChorusFilter>();
        }
    }

    public void Update()
    {
        _textSliderNumber.text = SliderValue.ToString();
        _audioChorusFilter.depth = SliderValue;
        _sliderChangeAudio.value = SliderValue;

        if (prefabEfect.activeSelf)
        {
            TimeToDisable = TimeToDisable + Time.deltaTime;

            if (TimeToDisable >= 1.0f)
            {
                prefabEfect.SetActive(false);
                TimeToDisable = 0.0f;
            }
        }
    }

    public void SyncSlider()
    {
        SliderValue = _sliderChangeAudio.value;
    }

    public override void OnPickupUseUp()
    {
        SendCustomNetworkEvent(NetworkEventTarget.All, "LaunchSound");
    }

    public void LaunchSound()
    {
        _audioSource.PlayOneShot(_audioClips[TypeSound]);
        prefabEfect.SetActive(true);
    }

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
