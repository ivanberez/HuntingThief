using UnityEngine;

namespace Assets.Scripts.Character
{
    public class AnimatorControl 
    {        
        private readonly Animator _animator;               

        public AnimatorControl(Animator animator)
        {            
            _animator = animator;                               
        } 

        public void ChangeParams(Vector2 directionVector)
        {
            Vector2 vectorCoreection = VectorCorrection(directionVector);            
          
            _animator.SetFloat("XDirection", vectorCoreection.x);
            _animator.SetFloat("YDirection", vectorCoreection.y);
        }

        private Vector2 VectorCorrection(Vector2 changedPosition)
        {
            var x = changedPosition.x < 0 ? -changedPosition.x : changedPosition.x;
            var y = changedPosition.y < 0 ? -changedPosition.y : changedPosition.y;

            if (x > y)
            {
                return new Vector2(changedPosition.x, 0);
            }
            else
            {
                return new Vector2(0, changedPosition.y);
            }
        }
    }
}
