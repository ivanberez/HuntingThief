using UnityEngine;
using DG.Tweening;

public class AlarmZone : MonoBehaviour
{
    private const float MaxVolume = 1;
    private const float MinVolume = 0;

    [SerializeField] private string _targetTag = "Thief";
    [SerializeField] private Alarm[] _alarms;    
    
    [Header("Sound")]
    [SerializeField] private AudioSource _audio;    
    [Range(1, 5)]
    [SerializeField] private float _durationChangeSound;

    private void StartAlert()
    {
        foreach (Alarm alarm in _alarms)
            alarm.Run();

        _audio.Play();
        _audio.DOFade(MaxVolume, _durationChangeSound);
    }

    private void StopAlert()
    {
        foreach (Alarm alarm in _alarms)
            alarm.Stop();

        _audio.DOFade(MinVolume, _durationChangeSound).OnComplete(()=> _audio.Stop());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _targetTag)
            StartAlert();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == _targetTag)
            StopAlert();
    }    
}
