using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Header ("Bullet Damage")]
    [SerializeField] float damage;

    [Header ("Damage Effects")]
    [SerializeField] List<GameObject> damageFx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //randomizar o valor para instanciar o damageFx - remove o parent e muda sua escala para destruir
            int randomIndex = Random.Range(0, damageFx.Count - 1);
            GameObject damageFxClone = Instantiate(damageFx[randomIndex], this.transform);
            damageFxClone.transform.SetParent(null);
            damageFxClone.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Destroy(damageFxClone, 0.3f);

            //checa se o inimigo tem o script HPScript para diminuir hp e depois destruir
            HpScript hpScript = collision.gameObject.GetComponent<HpScript>();
            if (hpScript)
            {
                hpScript.RemoveHp(damage);
            }
            Destroy(gameObject);
        }
    }

}
