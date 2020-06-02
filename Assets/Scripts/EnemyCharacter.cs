using UnityEngine;
using CombatSystemNS;

namespace Characters
{
    public class EnemyCharacter : Character
    {
        private enum State
        {
            Standing,
            Strolling,
            Chasing
        }

        private State state;
        TimedAttack timedAttack;

        private void Awake()
        {
            setDefaultStatus();
            timedAttack = gameObject.AddComponent<TimedAttack>();
            timedAttack.SetUp(5f);
        }

        void Start()
        {
            state = State.Chasing;
        }

        private void Update()
        {
            
        }

        void FixedUpdate()
        {
            switch (state)
            {
                case State.Standing:
                    status.isMoving = false;
                    break;
                case State.Strolling:
                    state = HandleStrollingState();
                    break;
                case State.Chasing:
                    state = HandleChasingState();
                    break;
                default:
                    break;
            }
        }


        /** @returns NextState */
        private State HandleStrollingState()
        {
            TryToMove(GenerateNextStrollingMovement());
            return State.Strolling;
        }

        Vector3 relativeMovement = new Vector3(0, 0, 0);
        private float elapsedTime = 0;
        private Vector3 GenerateNextStrollingMovement()
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > 3f)
            {
                relativeMovement = new Vector3(0, 0, 0);
                elapsedTime = 0;
            }
            else if (elapsedTime > 2f)
            {
                if (relativeMovement == new Vector3(0, 0, 0))
                {
                    relativeMovement = new Vector3(Random.Range(-.01f, .01f), Random.Range(-.01f, .01f), 0);
                }
            }

            return relativeMovement;
        }

        GameObject targetPlayer;
        private State HandleChasingState()
        {
            targetPlayer = CombatSystem.instance.GetNearestPlayerCharacterFrom(this.gameObject);

            if(true == CombatSystem.AreInRange(this.transform, targetPlayer.transform, 1.5f) )
            {
                HandleAttack();
            }

            TryToMove((targetPlayer.transform.position - this.transform.position).normalized * .05f);

            return State.Chasing;
        }

        private void HandleAttack()
        {
            if (true == timedAttack.TryToAttack())
            {
                Collider2D[] charactersHit = Physics2D.OverlapCircleAll(transform.position, 1.5f);
                foreach (Collider2D characterHit in charactersHit)
                {
                    if (characterHit == this.GetComponent<Collider2D>())
                        continue;

                    characterHit.GetComponentInParent<Character>().takeDamage(30f);
                }
            }

            status.isAttacking = timedAttack.isAttacking();
        }

    }

}
