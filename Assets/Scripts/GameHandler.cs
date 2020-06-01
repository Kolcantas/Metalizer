using UnityEditor.Animations;
using UnityEngine;
using Factory;

public class GameHandler : MonoBehaviour
{
    private GameObject playerObject;
    private GameObject playerCharacterAnimationAdapeterObject;
    private Animator playerAnimator;

    void Awake()
    {
        PlayerCharacterFactory playFact = new PlayerCharacterFactory("WorstPlayerEver", AssetCollection.instance.animatorKnight);
        playFact.CreateCharacter();
    }
    

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
