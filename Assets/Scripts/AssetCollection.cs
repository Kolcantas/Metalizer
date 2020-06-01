using UnityEditor.Animations;
using UnityEngine;

namespace GameCore
{
    public struct HitBox
    {
        public float sizeX;
        public float sizeY;
        public float offsetX;
        public float offsetY;
    }

    public class AssetCollection : MonoBehaviour
    {
        public static AssetCollection instance;

        private void Awake()
        {
            instance = this;
        }

        //public struct SpriteCollectionType
        //{
        //    public Sprite Knight_Idle_Default;
        //}
        //public SpriteCollectionType SpriteCollection;

        public Sprite Knight_Idle_Default;

        public AnimatorController animatorKnight;
        public HitBox hitBox_Kinght = new HitBox { sizeX = 1f, sizeY = 1.5f, offsetX = 0f, offsetY = -.5f };

        public AnimatorController animatorGoblin;
        public float goblinScale;
        public HitBox hitBox_Goblin = new HitBox { sizeX = 0.4f, sizeY = 0.4f, offsetX = 0f, offsetY = -.1f };

    }

}
