using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpScript : MonoBehaviour
{
    [SerializeField] float hp;

    [Header ("Hurt Sounds")]
    [SerializeField] List<AudioClip> hitSounds;

    [Header("Death Sounds")]
    [SerializeField] List<AudioClip> deathSounds;

    EnemyScript enemyScript;
    SpriteRenderer spriteRenderer;
    Material whiteMat;
    Material defaultMaterial;
    // Start is called before the first frame update
    void Start()
    {
        if (CompareTag("Enemy")) 
            enemyScript = GetComponent<EnemyScript>();
                
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        whiteMat = Resources.Load(("WhiteFlash"), typeof(Material)) as Material;
        defaultMaterial = spriteRenderer.material;
    }

    public void RemoveHp(float damage)
    {
        hp -= damage;

        if(!GameController.instance.GameOver)
            spriteRenderer.material = whiteMat;

        PlayerHp();

        EnemyHp();
    }

    public void AddHP(float value)
    {
        hp += value;
    }

    void ResetMaterial()
    {
        spriteRenderer.material = defaultMaterial;
    }

    void PlayerHp()
    {
        if (this.CompareTag("Player"))
        {
            if (hp <= 0)
            {
                GameController.instance.IsGameOver(true);
                Invoke("ResetMaterial", 0.1f);
            }
            else
            {

                Invoke("ResetMaterial", 0.1f);
            }
        }
    }

    void EnemyHp()
    {
        if (this.CompareTag("Enemy"))
        {
            if (hp <= 0)
            {
                GameObject enemyDeadAnim = Instantiate(enemyScript.DeadAnim, this.transform);
                enemyDeadAnim.transform.SetParent(null);
                enemyDeadAnim.transform.localScale = new Vector3(2, 2, 2);
                Destroy(enemyDeadAnim, 0.5f);

                PlaySound(deathSounds);

                GameController.instance.AddPoints(enemyScript.EnemyPoints);

                Destroy(gameObject);
            }
            else
            {
                PlaySound(hitSounds);
            }
        }
    }

    void PlaySound(List<AudioClip> audioList)
    {
        int randomHitIndex = Random.Range(0, audioList.Count - 1);
        AudioSource.PlayClipAtPoint(audioList[randomHitIndex], this.transform.position);
        Invoke("ResetMaterial", 0.1f);
    }

    public float Hp { get { return hp; } set { hp = value; } }
}
