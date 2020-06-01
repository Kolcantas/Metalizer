using UnityEngine;
using UnityEditor.Animations;
using Characters;
using GameCore;

namespace Factory
{
    public class PlayerCharacterFactory : CharacterFactory
    {
        private AnimatorController _animator;
        private string _name;
        private HitBox _hitBox;

        public PlayerCharacterFactory(string name, AnimatorController animator, HitBox hitBox)
        {
            _name = name;
            _animator = animator;
            _hitBox = hitBox;
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

            playerObject.AddComponent<BoxCollider2D>();
            playerObject.GetComponent<BoxCollider2D>().size = new Vector2(_hitBox.sizeX, _hitBox.sizeY);
            playerObject.GetComponent<BoxCollider2D>().offset = new Vector2(_hitBox.offsetX, _hitBox.offsetY);

            playerObject.AddComponent<Rigidbody2D>();
            playerObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            playerObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            return playerObject;
        }
    }

}