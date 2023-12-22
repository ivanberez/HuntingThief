using UnityEngine;
using DG.Tweening;

public class Alarm : MonoBehaviour
{    
    private Vector3 _normalScale;
    private Tween _tween;

    private void Awake()
    {
        _normalScale = transform.localScale;
    }

    public void Run()
    {
        _tween = transform.DOShakeScale(1f, 1f).From().SetLoops(-1, LoopType.Yoyo);
    }

    public void Stop() 
    {
        _tween.Kill();
        transform.localScale = _normalScale;
    }
}
