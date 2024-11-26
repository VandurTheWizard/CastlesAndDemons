using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShotGun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float shotCooldown = 2f;
    [SerializeField] private RangeBullet gun;
    private bool canShot;
    

    void Start()
    {
        canShot = true;
        shotCooldown = gameObject.GetComponent<PlayerStats>().ShotGunCooldown;
    }

    void Update()
    {
        shot();
    }

    private void shot(){
        //Comprueba de que el Raycast del hijo 1 del jugador esta colisionando con un enemigo para disparar
        if(gun.EnemyDetected && canShot && bulletPrefab != null){
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            canShot = false;
            Invoke("nowCanShot", shotCooldown);

        }
        /*
        if(Input.GetButton("Fire1") && canShot && bulletPrefab != null && EventSystem.current.IsPointerOverGameObject() == false){
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            canShot = false;
            Invoke("nowCanShot", 0.5f);
        }
        */
    }

    public void SetShotCooldown(float newCooldown){
        shotCooldown = newCooldown;
    }

    void nowCanShot(){
        canShot = true;
    }
}
