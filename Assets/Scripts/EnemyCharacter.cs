using UnityEngine;

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

        private void Awake()
        {
            setDefaultCharacterProperties();
            Debug.Log("Enemy Character Awake");
        }

        void Start()
        {
            state = State.Strolling;
        }


        void Update()
        {
            switch (state)
            {
                case State.Standing:
                    properties.isMoving = false;
                    break;
                case State.Strolling:
                    state = HandleStrollingState();
                    break;
                case State.Chasing:

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
    }

}
