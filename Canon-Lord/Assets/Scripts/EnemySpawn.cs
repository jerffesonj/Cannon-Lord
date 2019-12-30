using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header ("Scriptable Waypoints List")]
    [SerializeField] List<WaypointsList> waypointsList;

    [SerializeField] int startingWave = 0;

    WaypointsList currentWave;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    IEnumerator SpawnAllWaves()
    {
        //checa qual a wave que começa e inicia a coroutine de spawn de todos os inimigos
        for (int waveIndex = startingWave; waveIndex < waypointsList.Count; waveIndex++)
        {
            currentWave = waypointsList[waveIndex];
            //if (!GameController.instance.GameOver)
            {
                yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            }
        }
    }

 
    private IEnumerator SpawnAllEnemiesInWave(WaypointsList waypointsLists)
    {
        //instancia cada inimigo de uma vez indicado no scriptable object e informa qual waypoint deve seguir
        for (int enemyNumber = 1; enemyNumber <= waypointsLists.GetEnemyNumber(); enemyNumber++)
        {
            var newEnemy = Instantiate(waypointsLists.GetEnemyPrefab(), waypointsLists.GetWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPath>().SetWaveConfig(waypointsLists);
            yield return new WaitForSeconds(waypointsLists.GetTimeBetweenSpawn() + waypointsLists.GetSpawnRandomFactor());
        }

        yield return new WaitForSeconds(waypointsLists.GetTimeNextWave());

        RepeatWave();
        
    }
    //checa a ultima wave da lista para repetir a lista
    void RepeatWave()
    {
        int lastWave = waypointsList.Count;
        print(lastWave);
        if (currentWave == waypointsList[lastWave - 1])
        {
            lastWave = 0;
            currentWave = waypointsList[0];
            if (!GameController.instance.GameOver)
            {
                StartCoroutine(SpawnAllWaves());
            }
        }
    }
}