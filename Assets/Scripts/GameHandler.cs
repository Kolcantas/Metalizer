using UnityEditor.Animations;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private GameObject playerObject;
    private GameObject playerCharacterAnimationAdapeterObject;
    private Animator playerAnimator;

    void Awake()
    {
        /* Player Character */
        playerObject = new GameObject("PlayerCharacter", typeof(SpriteRenderer));
        playerObject.GetComponent<SpriteRenderer>().sprite = AssetCollection.instance.Knight_Idle_Default;
        playerObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
        playerObject.transform.position = new Vector3(0, 0, 0);

        playerObject.AddComponent<PlayerCharacter>();

        playerAnimator = playerObject.AddComponent<Animator>();
        playerAnimator.runtimeAnimatorController = AssetCollection.instance.animatorKnight;

        playerCharacterAnimationAdapeterObject = new GameObject("PlayerCharacterAnimationAdapter", typeof(CharacterAnimationAdapter));
        playerCharacterAnimationAdapeterObject.GetComponent<CharacterAnimationAdapter>().SetUp(playerAnimator, playerObject.GetComponent<PlayerCharacter>());
        
    }
    

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
