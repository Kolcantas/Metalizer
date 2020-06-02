using UnityEngine;

public class TimedAttack : MonoBehaviour
{
    enum State
    {
        ReadyToAttack,
        Attacking
    }

    float timer;
    float attackTime;       // default 1s, in seconds

    State state;

    public void SetUp(float attackTime)
    {
        this.attackTime = attackTime;
    }


    void Start()
    {
        state = State.ReadyToAttack;
        timer = 0f;
    }

    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;

            if (timer < 0f)
            {
                timer = 0f;
                state = State.ReadyToAttack;
            }
        }
    }

    public bool TryToAttack()
    {
        if(state != State.ReadyToAttack)
        {
            return false;
        }
        else
        {
            timer = attackTime;
            state = State.Attacking;
            return true;
        }
    }
    
    public bool isAttacking() { return state == State.Attacking; }
}
