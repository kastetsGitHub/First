using System.Collections;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private float _quicknessOfVolume;
    private IEnumerator _coroutine;
    private bool _isPlay = true;

    public void PlaySound(AudioClip clip)
    {
        if (_isPlay)
        {
            _coroutine = TurnUpVolume(clip);
            StartCoroutine(_coroutine);
        }
    }

    public void StopSound()
    {
        StopCoroutine(_coroutine);
        StartCoroutine(TurnDownVolume());
    }

    public void RegulationVolume(float volume)
    {
        _soundSource.volume = volume;
    }

    private IEnumerator TurnUpVolume(AudioClip clip)
    {
        _isPlay = false;
        _soundSource.clip = clip;
        _soundSource.volume = 0;
        _soundSource.Play();
        float maxVolume = 1f;
        float currentTime = Time.time;
        float totalTime = Time.time + _soundSource.clip.length;

        while (currentTime < totalTime)
        {
            currentTime = Time.time;
            _soundSource.volume = Mathf.MoveTowards(_soundSource.volume, maxVolume, _quicknessOfVolume * Time.deltaTime);
            yield return null;
        }

        _isPlay = true;        
    }

    private IEnumerator TurnDownVolume()
    {
        _isPlay = false;
        float minVolume = 0f;

        while (_soundSource.volume > minVolume)
        {
            _soundSource.volume = Mathf.MoveTowards(_soundSource.volume, minVolume, _quicknessOfVolume * Time.deltaTime);
            yield return null;
        }

        _isPlay = true;
    }
}
