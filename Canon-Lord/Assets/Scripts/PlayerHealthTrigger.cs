using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthTrigger : MonoBehaviour
{
    //quando inimigo passa do local, checa se chegou e o player leva dano

    HpScript playerHp;

    void Start()
    {
        playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<HpScript>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            float enemyDamage = collision.gameObject.GetComponent<EnemyScript>().Damage;

            playerHp.RemoveHp(enemyDamage);
        }
    }
}
