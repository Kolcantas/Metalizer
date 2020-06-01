using UnityEngine;
using UnityEditor.Animations;
using Characters;

namespace Factory
{
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

        public override GameObject CreateCharacter(Vector3 initPos)
        {
            playerObject = new GameObject(_name, typeof(SpriteRenderer));
            playerObject.transform.position = initPos;

            playerObject.AddComponent<PlayerCharacter>();

            playerAnimator = playerObject.AddComponent<Animator>();
            playerAnimator.runtimeAnimatorController = _animator;

            playerObject.GetComponent<PlayerCharacter>().AssignAnimationAdapter(playerAnimator);
            playerObject.GetComponent<PlayerCharacter>().movementScaler = 5f;
            playerObject.GetComponent<PlayerCharacter>().hitboxOffset = new Vector3(0, -0.3f, 0);

            return playerObject;
        }
    }

}