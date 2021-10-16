using UnityEngine;

namespace Manager
{
    public class Spawner : MonoBehaviour
    {
        public GameObject monsterPrefab;
        public GameObject[] monsterSpawns;

        private void OnValidate()
        {
            // if (monsterSpawns == null)
                monsterSpawns = GameObject.FindGameObjectsWithTag("EnemySpawn");
        }

        private void Start()
        {
            foreach (GameObject monster in monsterSpawns)
            {
                Instantiate(monsterPrefab, monster.transform.position, monster.transform.rotation);
            }
        }
    }
}
