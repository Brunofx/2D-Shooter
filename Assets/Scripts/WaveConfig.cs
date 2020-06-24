using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enemy wave config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] int numberOfEnemies = 5;


    public GameObject GetEnemyPrefab() {
        return enemyPrefab;
    }
    
    public List<Transform> GetWaypoints() {
        List<Transform> waveWaypoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform) {
            waveWaypoints.Add(child);
        }
        
        return waveWaypoints;
    }

    public float getTimeBetweenSpawn() {
        return timeBetweenSpawn;
    }

    public float getSpawnRandomFactor() {
        return spawnRandomFactor;
    }

    public float GetMoveSpeed() {
        return moveSpeed;
    }

    public int getNumberOfEnemies() {
        return numberOfEnemies;
    }



}
