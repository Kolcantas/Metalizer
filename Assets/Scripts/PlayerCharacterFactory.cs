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
    private GameObject playerCharacterAnimationAdapeterObject;
    private Animator playerAnimator;

    public override GameObject CreateCharacter()
    {
        playerObject = new GameObject(_name, typeof(SpriteRenderer));
        playerObject.GetComponent<SpriteRenderer>().sprite = AssetCollection.instance.Knight_Idle_Default;
        playerObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
        playerObject.transform.position = new Vector3(0, 0, 0);

        playerObject.AddComponent<PlayerCharacter>();

        playerAnimator = playerObject.AddComponent<Animator>();
        playerAnimator.runtimeAnimatorController = _animator;

        playerCharacterAnimationAdapeterObject = new GameObject(_name + "AnimationAdapter", typeof(CharacterAnimationAdapter));
        playerCharacterAnimationAdapeterObject.GetComponent<CharacterAnimationAdapter>().SetUp(playerAnimator, playerObject.GetComponent<PlayerCharacter>());

        return playerObject;
    }
}
