using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private const float MaxVolume = 1f;
    private const float MinVolume = 0f;
    private const float DurationShake = 1f;
    private const float StrengthShake = 1f;

    [Range(1, 3)]
    [SerializeField] private float _durationChangeSound;
    [SerializeField] private AlarmZone _alarmZone;    
    
    private AudioSource _audioSource;    
    private Vector3 _normalScale;
    private Tween _tween;    

    private void Awake()
    {         
        _audioSource = GetComponent<AudioSource>();
        _normalScale = transform.localScale;        
    }

    private void OnEnable()
    {
        _alarmZone.Alerting += Switching;
    }

    private void OnDisable()
    {
       _alarmZone.Alerting -= Switching;
    }

    private void Switching(bool isAlert)
    {
        if (isAlert)
            Run();
        else
            Stop();
    }

    private void Run()
    {
        _tween = transform.DOShakeScale(DurationShake, StrengthShake).From().SetLoops(-1, LoopType.Yoyo);        
        _audioSource.Play();
        _audioSource.DOFade(MaxVolume, _durationChangeSound);
    }

    private void Stop() 
    {
        _tween.Kill();
        _audioSource.DOFade(MinVolume, _durationChangeSound).OnComplete(() => _audioSource.Stop());
        transform.localScale = _normalScale;
    }
}