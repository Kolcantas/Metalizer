using Characters;
using UnityEngine;

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
        switch(state)
        {
            case State.Standing:
                properties.isMoving = false;
                break;
            case State.Strolling:
                state = HandleStrollingState();
                break;
            default:
                break;
        }
    }

    /** @returns NextState */
    private State HandleStrollingState()
    {
        TryToMove(new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0));

        return State.Strolling;
    }
}
