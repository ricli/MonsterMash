﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {


    public EnemySpawnData[] enemySpawns;

    [System.Serializable]
    public struct EnemySpawnData
    {
        public GameObject prefab;
        public float minSpawnDelay;  // number of seconds between spawns at hardest difficulty
        public float maxSpawnDelay;  // number of seconds between spawns at the start
        public float timeUntilMaxSpawnDelay; // number of seconds between enemy beginning to spawn and the enemy spawning at its maximum rate
        public float firstSpawnTime;     // How many seconds to wait before this enemy type spawns

        [HideInInspector]
        public float spawnTimer;
        [HideInInspector]
        public float currentSpawnDelay;

        // While the constructor is not required if you are always setting it in the inspector it is good practice
        public EnemySpawnData(GameObject _prefab, float _minSpawnDelay, float _maxSpawnDelay, float _timeUntilMaxSpawnDelay, float _firstSpawnTime)
        {
            prefab = _prefab;
            minSpawnDelay = _minSpawnDelay;
            maxSpawnDelay = _maxSpawnDelay;
            timeUntilMaxSpawnDelay = _timeUntilMaxSpawnDelay;
            firstSpawnTime = _firstSpawnTime;
            spawnTimer = maxSpawnDelay;
            currentSpawnDelay = maxSpawnDelay;
        }
    }

	void Update () {
        for ( int i = 0; i < enemySpawns.Length; i++) {
            enemySpawns[i].firstSpawnTime -= Time.deltaTime; 
            if(enemySpawns[i].firstSpawnTime > 0) // Wait firstSpawnTime seconds before you spawn this enemy type
            {
                continue;
            }


            float lerpX = Mathf.Abs(enemySpawns[i].firstSpawnTime) / enemySpawns[i].timeUntilMaxSpawnDelay;
            lerpX = Mathf.Clamp(lerpX, 0.0f, 1.0f);
            enemySpawns[i].currentSpawnDelay = Mathf.Lerp(enemySpawns[i].maxSpawnDelay, enemySpawns[i].minSpawnDelay, lerpX);
            enemySpawns[i].spawnTimer -= Time.deltaTime;
            if (enemySpawns[i].spawnTimer <= 0)
            {
                enemySpawns[i].spawnTimer = enemySpawns[i].currentSpawnDelay;
                Vector3 position = new Vector3(Random.Range(-30, 30), Random.Range(-20, 20), 0);
                GameObject fish = (GameObject) Instantiate(enemySpawns[i].prefab, position, Quaternion.identity);
                float size = Random.Range(.05f, .3f);
                fish.GetComponent<Interaction>().size = size;
            }
        }
	}    
}
