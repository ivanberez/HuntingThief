using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour
{
    private const float MaxVolume = 1f;
    private const float MinVolume = 0f;

    [Range(1f, 3f)]
    [SerializeField] private float _durationChange;
    [SerializeField] private AudioSource _source;

    private void OnValidate() => _source = GetComponent<AudioSource>();

    public void Play()
    {
        _source.Play();
        _source.DOFade(MaxVolume, _durationChange);
    }

    public void Stop()
    {
        _source.DOFade(MinVolume, _durationChange).OnComplete(() => _source.Stop());
    }
}