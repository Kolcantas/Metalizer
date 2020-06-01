using UnityEngine;

public class CharacterAnimationAdapter : MonoBehaviour
{
    private Animator anim;
    private PlayerCharacter playerChar;
    public void SetUp(Animator anim, PlayerCharacter playerChar)
    {
        this.anim = anim;
        this.playerChar = playerChar;
    }

    void Update()
    {
        if(anim == null || playerChar == null)
        {
            Debug.Log("Uninitialized! Call SetUp() before any frame update!");
            return;
        }

        HandleAnimation(playerChar.getCharacterProperties());
    }


    private void HandleAnimation(PlayerCharacter.CharacterProperties prop)
    {
        anim.SetBool("isMoving", prop.isMoving);
        anim.SetBool("triggerAttack", prop.isAttacking);
    }
}
