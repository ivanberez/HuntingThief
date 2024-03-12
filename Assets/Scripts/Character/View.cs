using UnityEngine;

namespace Assets.Scripts.Character
{
    [RequireComponent(typeof(Animator), typeof(SpriteRenderer))]    
    public class View : MonoBehaviour
    {
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;               

        private void OnValidate()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();                        
        }

        public void ChangeDirection(Vector2 direction)
        {
            _animator.SetFloat("XDirection", direction.x);
            _animator.SetFloat("YDirection", direction.y);

            _spriteRenderer.flipX = direction.x < 0;
        }
    }
}