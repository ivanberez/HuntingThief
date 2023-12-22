using Assets.Scripts;
using Assets.Scripts.Character;
using UnityEngine;

[RequireComponent(typeof(View))]
[RequireComponent(typeof(Movement))]

public class Thief : MonoBehaviour
{
    [SerializeField] private Way _way;
    [SerializeField] private View _view;
    [SerializeField] private Movement _movement;
    

    private void OnValidate()
    {
        _view = GetComponent<View>();
        _movement = GetComponent<Movement>();
    }

    private void Awake()
    {
        _movement.ChangeDirection += _view.AnimatorControl.ChangeParams;        
        _movement.ChangeDirection += _view.DefineFlip;
    }

    private void Start()
    {
        _movement.MovePath(_way);        
    }    

    private void OnDisable()
    {
        _movement.ChangeDirection -= _view.AnimatorControl.ChangeParams;        
        _movement.ChangeDirection -= _view.DefineFlip;
    }
}
