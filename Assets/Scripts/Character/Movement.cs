using UnityEngine;
using DG.Tweening;
using Assets.Scripts;
using System.Collections;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    private Transform _transform;        

    private UnityEvent<Vector2> _changeDirection = new UnityEvent<Vector2>();

    public bool IsMove { get; private set; }

    public event UnityAction<Vector2> ChangeDirection
    {
        add => _changeDirection.AddListener(value);
        remove => _changeDirection.RemoveListener(value);
    }

    private void OnValidate()
    {
        _transform = GetComponent<Transform>();
    }

    public void MovePath(Way way)
    {
        Tween tween = _transform.DOPath(way.Points, way.Points.Length * 2, PathType.CatmullRom).SetOptions(true);                       
        tween.SetEase(Ease.Linear).SetLoops(-1);

        IsMove = true; 
        StartCoroutine(ChangePosition());
    }

    private IEnumerator ChangePosition() 
    {         
        while(IsMove)
        {
            Vector2 position = _transform.position;
            
            yield return new WaitForSeconds(0.3f);
            _changeDirection.Invoke(new Vector2(position.x - _transform.position.x, position.y - _transform.position.y));            
        }        
    }
}
