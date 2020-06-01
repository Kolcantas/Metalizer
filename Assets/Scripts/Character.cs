using UnityEngine;

namespace Characters
{
    public abstract class Character : MonoBehaviour
    {
        /* Standard state variables (used by Animation) */
        public struct CharacterProperties
        {
            public bool isMoving;
            public Vector3 moveDirection;

            public bool isAttacking;
            public bool alive;
            public bool takingHit;
        }

        public CharacterProperties properties;
        public CharacterProperties getCharacterProperties() { return properties; }


        public float healthInPercentage = 100f;


        /* Animation Adapter */
        private GameObject animationAdapter = null;
        public void AssignAnimationAdapter(Animator anim)
        {
            if(animationAdapter != null)
            {
                RemoveAnimationAdapter();
            }

            animationAdapter = new GameObject("Animation Adapter", typeof(CharacterAnimationAdapter));
            animationAdapter.GetComponent<CharacterAnimationAdapter>().SetUp(this, anim);
        }

        public void RemoveAnimationAdapter()
        {
            Object.Destroy(animationAdapter);
        }


        /* Animation Facing */
        private bool facingRight = true;         // by deafult facing right

        public void updateAnimationFacing(Vector3 moveDir)
        {
            /* Adjust animation */
            if (moveDir.x != 0.0f || moveDir.y != 0.0f)
            {
                bool movingRight = moveDir.x > 0.0f ? true : false;

                if (facingRight ^ movingRight)
                {
                    facingRight = !facingRight;

                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                }
            }
        }
    }
}
