using Characters;
using UnityEngine;

namespace Factory
{
    public abstract class CharacterFactory
    {
        public abstract GameObject CreateCharacter(Vector3 initPos);
        public GameObject CreateCharacter()
        {
            return CreateCharacter(new Vector3(0, 0, 0));
        }
    }
}

