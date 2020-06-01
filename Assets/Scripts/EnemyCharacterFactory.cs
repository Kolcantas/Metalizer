using UnityEngine;
using UnityEditor.Animations;
using Characters;
using GameCore;

namespace Factory
{

    public class EnemyCharacterFactory : CharacterFactory
    {
        private AnimatorController _animator;
        private string _name;
        private float _animScale;
        private HitBox _hitBox;

        public EnemyCharacterFactory(string name, AnimatorController animator, HitBox hitBox, float animationScale = 1f)
        {
            _name = name;
            _animator = animator;
            _animScale = animationScale;
            _hitBox = hitBox;
        }


        private GameObject characterObject;
        private Animator characterAnimator;

        public override GameObject CreateCharacter(Vector3 initPos)
        {
            characterObject = new GameObject(_name, typeof(SpriteRenderer));
            characterObject.transform.position = initPos;
            characterObject.transform.localScale = characterObject.transform.localScale * _animScale;

            characterObject.AddComponent<EnemyCharacter>();

            characterAnimator = characterObject.AddComponent<Animator>();
            characterAnimator.runtimeAnimatorController = _animator;

            characterObject.GetComponent<EnemyCharacter>().AssignAnimationAdapter(characterAnimator);
            characterObject.GetComponent<EnemyCharacter>().movementScaler = 0.1f;

            characterObject.AddComponent<BoxCollider2D>();
            characterObject.GetComponent<BoxCollider2D>().size = new Vector2(_hitBox.sizeX, _hitBox.sizeY);
            characterObject.GetComponent<BoxCollider2D>().offset = new Vector2(_hitBox.offsetX, _hitBox.offsetY);

            characterObject.AddComponent<Rigidbody2D>();
            characterObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            characterObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

            return characterObject;
        }
    }

}
