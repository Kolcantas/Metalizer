using UnityEditor.Animations;
using UnityEngine;
using Factory;

public class GameHandler : MonoBehaviour
{
    PlayerCharacterFactory playFact;
    EnemyCharacterFactory goblinFactory;

    void Awake()
    {
        playFact = new PlayerCharacterFactory("WorstPlayerEver", AssetCollection.instance.animatorKnight);
        playFact.CreateCharacter();

        goblinFactory = new EnemyCharacterFactory("GoblinFactory", AssetCollection.instance.animatorGoblin, 3f);
    }
    

    private void Start()
    {
        for(int i=0; i < 5; i++)
        {
            goblinFactory.CreateCharacter(new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0));
        }
    }


    void Update()
    {
        
    }
}
