using UnityEditor.Animations;
using UnityEngine;

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

}
