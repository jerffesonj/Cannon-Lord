using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header ("Enemy Parameters")]
    [SerializeField] float damage;
    [SerializeField] float enemyPoints;

    [Header ("Death Animation")]
    [SerializeField] GameObject deadAnimation;
   
    public float Damage { get { return damage; } }
    public float EnemyPoints { get { return enemyPoints; } }

    public GameObject DeadAnim { get { return deadAnimation; } }

}
