using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Option : MonoBehaviour
{
    [SerializeField]
    public Scrollbar volumeScrollBar;

    [SerializeField]
    public Text volumeText;

    [SerializeField]
    public Toggle mutedToggle;

    [SerializeField]
    public TMP_Dropdown qualityDropdown;

    private float oldVolume = 0f;
    private bool skip = false;
    
    
    
    private void Awake()
    {
        if(!PlayerPrefs.HasKey("volume")) {
            PlayerPrefs.SetInt("volume", 100);
            volumeScrollBar.value = 1;
            OnVolumeChange(1f);
        } 
        else 
        {
            volumeScrollBar.value = PlayerPrefs.GetInt("volume") * 0.01f;
            OnVolumeChange(PlayerPrefs.GetInt("volume") * 0.01f);
        }   

        if(!PlayerPrefs.HasKey("quality")) {
            PlayerPrefs.SetInt("quality", 2);
            qualityDropdown.value = 2;
            QualitySettings.SetQualityLevel(2);
        } 
        else 
        {
            qualityDropdown.value = PlayerPrefs.GetInt("quality");
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality"));
        }

        volumeScrollBar.onValueChanged.AddListener(OnVolumeChange);
        mutedToggle.onValueChanged.AddListener(OnToggleMuted);
        qualityDropdown.onValueChanged.AddListener(delegate { OnChangeQulity(); });
    }


    private void OnVolumeChange ( float value ) {
        volumeText.text = string.Format("{0}", (int)(value * 100));
        if(skip) 
        {
            skip = false;
            return;
        }
        if(value == 0) 
        {
            mutedToggle.isOn = true;
        } 
        else 
        {
            mutedToggle.isOn = false;
        }
        if(value > 0) oldVolume = value;
        PlayerPrefs.SetInt("volume", (int)(value * 100));
        Main.Instance.SetAudioVolume(value);
    }

    private void OnToggleMuted ( bool value ) {
        if(value) 
        {
            volumeScrollBar.value = 0;
            Main.Instance.SetAudioVolume(0);
        } 
        else 
        {
            volumeScrollBar.value = oldVolume == 0 ? 1 : oldVolume;
            Main.Instance.SetAudioVolume(oldVolume);
        }
        skip = true;
    }

    private void OnChangeQulity() {
        QualitySettings.SetQualityLevel(qualityDropdown.value);
        PlayerPrefs.SetInt("quality", qualityDropdown.value);
    }

    
}
