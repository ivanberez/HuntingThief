using UnityEngine;
using DG.Tweening;

public class WarningLight : MonoBehaviour
{
    private const float DurationShake = 1f;
    private const float StrengthShake = 1f;

    private Vector3 _normalScale;
    private Tween _tween;

    private void Awake()
    {
        _normalScale = transform.localScale;
    }

    public void TurnOn()
    {
        _tween = transform.DOShakeScale(DurationShake, StrengthShake).From().SetLoops(-1, LoopType.Yoyo);
    }

    public void TurnOff()
    {
        _tween.Kill();
        transform.localScale = _normalScale;
    }
}