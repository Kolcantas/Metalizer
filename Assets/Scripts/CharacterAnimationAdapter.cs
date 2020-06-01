using Characters;
using UnityEngine;

/** @brief Link between Character and AnimationStateMachine */
public class CharacterAnimationAdapter : MonoBehaviour
{
    private Character _character;
    private Animator _animator;

    public void SetUp(Character character, Animator anim)
    {
        _character = character;
        _animator = anim;
    }

    void Update()
    {
        HandleAnimation(_character.getCharacterProperties());
    }

    public void HandleAnimation(PlayerCharacter.CharacterProperties prop)
    {
        if (_character == null || _animator == null)
        {
            Debug.Log("Uninitialized! Call SetUp() before any frame update!");
            return;
        }

        _animator.SetBool("isMoving", prop.isMoving);
        _animator.SetBool("triggerAttack", prop.isAttacking);
    }
}
