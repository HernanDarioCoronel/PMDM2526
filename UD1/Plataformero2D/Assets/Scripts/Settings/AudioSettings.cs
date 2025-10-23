using UnityEngine;

[CreateAssetMenu(fileName = "AudioSettings", menuName = "Scriptable Objects/AudioSettings")]
public class AudioSettings : ScriptableObject
{
    [Range(0.0f, 1.0f)]
    public float generalVolume = .5f;
    private float _generalVolume;
    private float _defaultGeneralVolume = .5f;

    [Range(0.0f, 1.0f)]
    public float musicVolume = .5f;
    private float _musicVolume;
    private float _defaultMusicVolume = .5f;

    [Range(0.0f, 1.0f)]
    public float sfxVolume = .5f;
    private float _sfxVolume;
    private float _defaultSfxVolume = .5f;

    public float GeneralVolume
    {
        get { return generalVolume; }
        set
        {
            generalVolume = Mathf.Clamp01(value);
            _generalVolume = Mathf.Clamp01(value);
        }
    }
    public float MusicVolume
    {
        get { return musicVolume; }
        set
        {
            musicVolume = Mathf.Clamp01(value);
            _musicVolume = Mathf.Clamp01(value);
        }
    }
    public float SfxVolume
    {
        get { return sfxVolume; }
        set
        {
            sfxVolume = Mathf.Clamp01(value);
            _sfxVolume = Mathf.Clamp01(value);
        }
    }

    public void MuteAll()
    {
        generalVolume = 0.0f;
        musicVolume = 0.0f;
        sfxVolume = 0.0f;
    }

    public void UnmuteAll()
    {
        generalVolume = _generalVolume;
        musicVolume = _musicVolume;
        sfxVolume = _sfxVolume;
    }

    public void MuteMusic()
    {
        musicVolume = 0.0f;
    }

    public void UnmuteMusic()
    {
        musicVolume = _musicVolume;
    }

    public void MuteSFX()
    {
        sfxVolume = 0.0f;
    }

    public void UnmuteSFX()
    {
        sfxVolume = _sfxVolume;
    }

    public void ResetToDefault()
    {
        generalVolume = _defaultGeneralVolume;
        musicVolume = _defaultMusicVolume;
        sfxVolume = _defaultSfxVolume;
    }
}
