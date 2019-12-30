using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [Header("Scriptable Object")]
    [SerializeField] WaypointsList waypointScriptableObject;

    List<Transform> waypoints;

    int waypointIndex = 0;

    void Start()
    {
        //pega o waypoint do scriptable object e coloca o objeto no transform da lista
        waypoints = waypointScriptableObject.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        Move();
    }

    //coloca a configuração da wave com o waypoint
    public void SetWaveConfig(WaypointsList waveConfig)
    {
        this.waypointScriptableObject = waveConfig;
    }

    private void Move()
    {
        //compara o index do waypoint com o total da lista
        if (waypointIndex < waypoints.Count)
        {
            //seta a posição do proximo waypoint e salva a velocidade de movimento
            var targetPosition = waypoints[waypointIndex].position;
            var movementThisFrame = waypointScriptableObject.GetMoveSpeed() * Time.deltaTime;
            

            //rotaciona o objeto em relação ao proximo waypoint
            Vector3 diff = targetPosition - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

            //movimenta o objeto
            transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, movementThisFrame);

            //ao chegar no local, passa para o proximo waypoint
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        } 
        //destroi ao chegar no ultimo waypoint
        else
        {
            Destroy(gameObject);
        }
    }
}
