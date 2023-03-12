using UnityEngine;
using UnityEngine.UI;

public class SetupAudio : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectSlider;

    [SerializeField] private Text musicVolumeValueDisplay;
    [SerializeField] private Text soundEffectVolumeValueDisplay;

    private void OnEnable()
    {
        musicSlider.value = SoundInvoker.Instance.MusicVolume;
        effectSlider.value = SoundInvoker.Instance.SoundEffectVolume;

        musicVolumeValueDisplay.text = Mathf.RoundToInt(SoundInvoker.Instance.MusicVolume * 100f) + "";
        soundEffectVolumeValueDisplay.text = Mathf.RoundToInt(SoundInvoker.Instance.SoundEffectVolume * 100f)  + "";
        
        musicSlider.onValueChanged.AddListener(OnMusicVolumeValueChanged);
        effectSlider.onValueChanged.AddListener(OnSoundEffectVolumeValueChanged);
    }

    private void OnDisable()
    {
        musicSlider.onValueChanged.RemoveListener(OnMusicVolumeValueChanged);
        effectSlider.onValueChanged.RemoveListener(OnSoundEffectVolumeValueChanged);
    }

    private void OnMusicVolumeValueChanged(float value)
    {
        musicVolumeValueDisplay.text = Mathf.RoundToInt(value * 100f) + "";
        SoundInvoker.Instance.ChangeMusicVolume(value);
    }

    private void OnSoundEffectVolumeValueChanged(float value)
    {
        soundEffectVolumeValueDisplay.text = Mathf.RoundToInt(value * 100f) + "";
        SoundInvoker.Instance.ChangeSoundEffectVolume(value);
    }
}
