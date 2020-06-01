using UnityEngine;
using UnityEditor.Animations;
using Characters;

namespace Factory
{

    public class EnemyCharacterFactory : CharacterFactory
    {
        private AnimatorController _animator;
        private string _name;
        private float _animScale;

        public EnemyCharacterFactory(string name, AnimatorController animator, float animationScale = 1f)
        {
            _name = name;
            _animator = animator;
            _animScale = animationScale;
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

            return characterObject;
        }
    }

}
