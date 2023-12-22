using UnityEngine;

namespace Assets.Scripts.Character
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class View : MonoBehaviour
    {
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        
        public  AnimatorControl AnimatorControl { get; private set; }

        private void OnValidate()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();            
            AnimatorControl = new AnimatorControl(_animator);            
        }

        public void DefineFlip(Vector2 direction)
        {
            _spriteRenderer.flipX = direction.x < 0;
        }
    }
}