using Characters;
using Factory;
using UnityEngine;
using UnityEditor.Animations;

public class PlayerCharacterFactory : CharacterFactory
{
    private AnimatorController _animator;
    private string _name;

    public PlayerCharacterFactory(string name, AnimatorController animator)
    {
        _name = name;
        _animator = animator;
    }


    private GameObject playerObject;
    private Animator playerAnimator;

    public override GameObject CreateCharacter()
    {
        playerObject = new GameObject(_name, typeof(SpriteRenderer));
        playerObject.transform.position = new Vector3(0, 0, 0);

        playerObject.AddComponent<PlayerCharacter>();

        playerAnimator = playerObject.AddComponent<Animator>();
        playerAnimator.runtimeAnimatorController = _animator;

        playerObject.GetComponent<PlayerCharacter>().AssignAnimationAdapter(playerAnimator);

        return playerObject;
    }
}
