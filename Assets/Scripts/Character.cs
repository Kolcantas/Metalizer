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
        protected void TryToMove(Vector3 relativeMovement)
        {
            properties.moveDirection = relativeMovement.normalized;

            if (relativeMovement == new Vector3(0, 0, 0))
            {
                properties.isMoving = false;
            }
            else
            {
                properties.isMoving = true;
                transform.position += relativeMovement;
                updateAnimationFacing(properties.moveDirection);

                //Vector3 offsetToColliderBounds = properties.moveDirection * GetComponent<BoxCollider2D>().size.magnitude;

                //RaycastHit2D raycastHit = Physics2D.Raycast(transform.position + offsetToColliderBounds,
                //                                            properties.moveDirection,
                //                                            relativeMovement.magnitude - offsetToColliderBounds.magnitude);      // decrease distance with the offsetted origin

                ////RaycastHit2D raycastHit = Physics2D.Raycast(transform.position + hitboxOffset, properties.moveDirection, relativeMovement.magnitude);
                //if (raycastHit.collider == null)
                //{
                //    transform.position = targetPosition;
                //    updateAnimationFacing(properties.moveDirection);
                //    properties.isMoving = true;
                //}
                //else
                //{
                //    Debug.Log(offsetToColliderBounds);
                //    Debug.DrawLine(transform.position + offsetToColliderBounds, targetPosition);
                //    properties.isMoving = false;
                //}
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


        void OnDrawGizmosSelected()
        {
            Vector3 offset = GetComponent<BoxCollider2D>().offset;
            Vector3 size = GetComponent<BoxCollider2D>().size;

            size.x *= transform.localScale.x;
            size.y *= transform.localScale.y;
            offset.x *= transform.localScale.x;
            offset.y *= transform.localScale.y;

            Gizmos.color = new Color(1, 0, 0, 0.5F);
            Gizmos.DrawWireCube(transform.position + offset, size);
        }
    }
}
