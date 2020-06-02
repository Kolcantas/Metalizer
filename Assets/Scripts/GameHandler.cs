using UnityEngine;
using Factory;
using CombatSystemNS;
using System.Collections.Generic;
using Characters;

namespace GameCore
{
    public class GameHandler : MonoBehaviour
    {
        PlayerCharacterFactory playFact;
        EnemyCharacterFactory goblinFactory;

        List<GameObject> playerCharacters = new List<GameObject>();
        List<GameObject> enemyCharacters = new List<GameObject>();

        CombatSystem combatSystem;

        void Awake()
        {
            combatSystem = new CombatSystem(ref playerCharacters, ref enemyCharacters);

            playFact = new PlayerCharacterFactory("WorstPlayerEver", AssetCollection.instance.animatorKnight,
                                                                     AssetCollection.instance.hitBox_Kinght);
            playerCharacters.Add(playFact.CreateCharacter());

            goblinFactory = new EnemyCharacterFactory("Goblin", AssetCollection.instance.animatorGoblin,
                                                                AssetCollection.instance.hitBox_Goblin, 3f);
        }


        private void Start()
        {
            for (int i = 0; i < 3; i++)
            {
                enemyCharacters.Add(goblinFactory.CreateCharacter(new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0)));
            }

            Debug.Log(combatSystem.GetEnemyCharacterCount());
        }


        void Update()
        {

        }
    }
}
