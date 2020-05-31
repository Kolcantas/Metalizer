using UnityEditor.Animations;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private GameObject playerObject;
    private Animator playerAnimator;

    void Awake()
    {
        playerObject = new GameObject("PlayerCharacter", typeof(SpriteRenderer));
        playerObject.GetComponent<SpriteRenderer>().sprite = AssetCollection.instance.Knight_Idle_Default;
        playerObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
        playerObject.transform.position = new Vector3(0, 0, 0);

        playerAnimator = playerObject.AddComponent<Animator>();
        playerAnimator.runtimeAnimatorController = AssetCollection.instance.animatorKnight;
        playerObject.AddComponent<PlayerCharacter>().SetUp(playerAnimator);
        
    }
    

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
