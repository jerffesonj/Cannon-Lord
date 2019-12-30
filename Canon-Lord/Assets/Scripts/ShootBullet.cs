using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [Header ("Bullet Parameters")]
    [SerializeField] float bulletSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawn;

    [Header("Shoot Parameters")]
    [SerializeField] float shootTimer;
    [SerializeField] int maxBullet;
    
    [SerializeField] AudioClip shootSound;
    [SerializeField] List<GameObject> shootFlash;

    [Header ("Reloading Parameters")]
    [SerializeField] float reloadingTime;

    float timeToShoot;

    // Start is called before the first frame update
    void Start()
    {
        CurrentBullet = maxBullet;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameController.instance.GameOver)
        {
            ShootBulletOnClick();
            Reload();
        }
    }

    void Reload()
    {
        if (Input.GetButtonDown("Reload"))
        {
            if (!IsReloading)
            {
                StartCoroutine(ReloadingCoroutine());
            }
        }
    }

    void ShootBulletOnClick()
    {

        timeToShoot += Time.deltaTime;
        if (timeToShoot >= shootTimer)
        {
            timeToShoot = shootTimer;
        }

        if (timeToShoot >= shootTimer)
        {
            if (CurrentBullet > 0)
            {
                if (!IsReloading)
                {
                    if (Input.GetButton("Shoot"))
                    {
                        //instancia randomicamente um flash quando atira e destroi depois de 0.1s
                        int randomIndex = UnityEngine.Random.Range(0, shootFlash.Count - 1);
                        GameObject flashClone = Instantiate(shootFlash[randomIndex], bulletSpawn);
                        Destroy(flashClone, 0.3f);

                        //instancia o som do tiro
                        GameController.instance.GetComponent<AudioSource>().PlayOneShot(shootSound, 0.2f);

                        //instancia a bala, adiciona força para mover, remove o parent e muda sua escala pra depois destruir caso não toque em nenhum local
                        InstantiateBullet(bullet, bulletSpawn, bulletSpeed);

                        //reseta o tempo para atirar e remove uma bala
                        timeToShoot = 0;
                        CurrentBullet -= 1;
                    }
                }
            }
        }
    }

    void InstantiateBullet(GameObject bullet, Transform bulletSpawn, float bulletSpeed)
    {
        GameObject bulletClone = Instantiate(bullet, bulletSpawn);
        bulletClone.GetComponent<Rigidbody2D>().AddForce(bulletSpeed * this.transform.right);
        bulletClone.transform.parent = null;
        bulletClone.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        Destroy(bulletClone, 1.5f);
    } 

    IEnumerator ReloadingCoroutine()
    {
        IsReloading = true;
        yield return new WaitForSeconds(reloadingTime);
        CurrentBullet = maxBullet;
        IsReloading = false;
    }

    public int CurrentBullet { get; private set; } 
    public int MaxBullet { get { return maxBullet; } }
    public bool IsReloading { get; private set; }
}
