using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace CombatSystemNS
{
    public class CombatSystem
    {
        public static CombatSystem instance = null;

        List<GameObject> _playerCharacters;
        List<GameObject> _enemyCharacters;

        public CombatSystem(ref List<GameObject> players, ref List<GameObject> enemies)
        {
            instance = this;
            _playerCharacters = players;
            _enemyCharacters = enemies;
        }

        public List<GameObject> GetPlayerCharacters() { return _playerCharacters; }
        public List<GameObject> GetEnemyCharacters() { return _enemyCharacters; }
        public int GetEnemyCharacterCount() { return _enemyCharacters.Count; }


        static public float DistanceOf(Transform tf1, Transform tf2)    { return (tf1.position - tf2.position).magnitude; }
        static public float DistanceOf(GameObject go1, GameObject go2)  { return DistanceOf(go1.transform, go2.transform); }
        static public bool AreInRange(Transform char1, Transform char2, float range) { return (char1.position - char2.position).magnitude < range; }
        static public bool AreInRange(GameObject char1, GameObject char2, float range) { return AreInRange(char1.transform, char2.transform, range); }

        public GameObject GetNearestTargetFrom(GameObject src, ref List<GameObject> listOfTargets)
        {
            if(listOfTargets.Count == 0)
                return null;

            float minimumDistance = DistanceOf(src, listOfTargets[0]);
            GameObject nearestTarget = listOfTargets[0];

            foreach(GameObject target in listOfTargets)
            {
                float dist = DistanceOf(src, target);
                if (dist < minimumDistance)
                {
                    minimumDistance = dist;
                    nearestTarget = target;
                }
            }

            return nearestTarget;
        }

        public GameObject GetNearestPlayerCharacterFrom(GameObject src)
        {
            return GetNearestTargetFrom(src, ref _playerCharacters);
        }

        private float closeCombatRange = 1f;
        public GameObject IsAnyEnemyInCloseCombatRangeFrom(GameObject src)
        {
            GameObject nearestEnemy = GetNearestTargetFrom(src, ref _enemyCharacters);
            if (AreInRange(nearestEnemy, src, closeCombatRange))
                return nearestEnemy;
            else
                return null;
        }

    }
}
