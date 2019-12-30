using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WayPointList")]
public class WaypointsList : ScriptableObject
{
    [Header ("Enemy Parameters")]
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int enemyNumber = 1;
    [SerializeField] float moveSpeed;

    [Header ("Waypoints Prefab")]
    [SerializeField] GameObject pathPrefab;

    [Header("Wave Parameters")]
    [SerializeField] float timeToNextWave;
    [SerializeField] float timeBetweenSpawn;
    [SerializeField] float spawnRandomFactor;
    
    // Start is called before the first frame update
    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }

    public float GetTimeBetweenSpawn() { return timeBetweenSpawn; }

    public float GetSpawnRandomFactor()
    {
        spawnRandomFactor = Random.Range(spawnRandomFactor * (-1), spawnRandomFactor);
        return spawnRandomFactor;
    }

    public int GetEnemyNumber() { return enemyNumber; }

    public float GetMoveSpeed() { return moveSpeed; }

    public float GetTimeNextWave() { return timeToNextWave; }

}
