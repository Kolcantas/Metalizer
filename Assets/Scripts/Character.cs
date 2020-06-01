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
            public bool isAlive;
            public bool takingHit;

            public float healthInPercentage;
        }

        public CharacterProperties properties;
        public CharacterProperties getCharacterProperties() { return properties; }
        public void setDefaultCharacterProperties()
        {
            properties.isMoving = false;
            properties.moveDirection = new Vector3(0, 0, 0);
            properties.isAttacking = false;
            properties.isAlive = true;
            properties.takingHit = false;
            properties.healthInPercentage = 100f;
        }

        public float movementScaler = 5.0f;
        public Vector3 hitboxOffset = new Vector3(0,0,0);


        /* Animation Adapter */
        private GameObject animationAdapter = null;
        public GameObject getAnimationAdapter() { return animationAdapter; }
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


        /* Movement */
        protected void TryToMove(Vector3 direction)
        {
            properties.moveDirection = direction;

            if (direction == new Vector3(0, 0, 0))
            {
                properties.isMoving = false;
            }
            else
            {
                Vector3 targetPosition = transform.position + direction * Time.deltaTime * movementScaler;
                RaycastHit2D raycastHit = Physics2D.Raycast(transform.position + hitboxOffset, direction, Time.deltaTime * movementScaler);
                if (raycastHit.collider == null)
                {
                    transform.position = targetPosition;
                    updateAnimationFacing(direction);
                    properties.isMoving = true;
                }
                else
                {
                    Debug.Log(raycastHit.collider);
                    properties.isMoving = false;
                }
            }
        }

        /* Animation Facing */
        private bool facingRight = true;         // by deafult facing right

        protected void updateAnimationFacing(Vector3 moveDir)
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
