using Assets.Scripts.Character;
using UnityEngine;

[RequireComponent(typeof(View), typeof(PointMover))]

public class Thief : MonoBehaviour
{    
    [SerializeField] private View _view;
    [SerializeField] private PointMover _mover;       

    private void Awake()
    {
        _view = GetComponent<View>();
        _mover = GetComponent<PointMover>();        
    }

    private void OnEnable()
    {
        _mover.ChangeDirection += _view.ChangeDirection;
    }

    private void OnDisable()
    {
        _mover.ChangeDirection -= _view.ChangeDirection;                
    }
}
