using UnityEngine;

namespace Characters
{
    public abstract class Character : MonoBehaviour
    {
        /* Standard state variables (used by Animation) */
        public struct Status
        {
            public bool isMoving;
            public Vector3 moveDirection;

            public bool isAttacking;
            public bool isAlive;
            public bool takingHit;

            public float health;
            public float maxHealth;
            public float healthInPercentage;
        }

        public Status status;
        public Status getStatus() { return status; }
        public void setDefaultStatus()
        {
            status.isMoving = false;
            status.moveDirection = new Vector3(0, 0, 0);
            status.isAttacking = false;
            status.isAlive = true;
            status.takingHit = false;
            status.maxHealth = 100f;
            status.health = status.maxHealth;
            status.healthInPercentage = 100f;
        }

        public float movementScaler = 5.0f;

        /** @returns killed after damage? */
        public bool takeDamage(float dmg)
        {
            status.health -= dmg;

            Debug.Log("Damage taken!" + status.health);

            if (status.health < 0f)
            {
                status.health = 0f;
                status.isAlive = false;
            }

            status.healthInPercentage = status.health / status.maxHealth * 100f;

            return !status.isAlive;
        }


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
            status.moveDirection = relativeMovement.normalized;

            if (relativeMovement == new Vector3(0, 0, 0))
            {
                status.isMoving = false;
            }
            else
            {
                status.isMoving = true;
                transform.position += relativeMovement;
                updateAnimationFacing(status.moveDirection);
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

            Gizmos.color = new Color(0, 1, 1, 0.5f);
            Gizmos.DrawSphere(transform.position, 3f);
        }
    }
}
