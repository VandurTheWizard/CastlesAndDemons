using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShotGun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float shotCooldown = 2f;
    private bool canShot;
    private RangeBullet aim;

    void Start()
    {
        canShot = true;
        aim = transform.GetChild(1).gameObject.GetComponent<RangeBullet>();
        shotCooldown = gameObject.GetComponent<PlayerStats>().ShotCooldown;
    }

    void Update()
    {
        shot();
    }

    private void shot(){
        //Comprueba de que el Raycast del hijo 1 del jugador esta colisionando con un enemigo para disparar
        if(aim.EnemyDetected && canShot && bulletPrefab != null){
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            canShot = false;
            Debug.Log("CoolDownShot" + shotCooldown);
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
