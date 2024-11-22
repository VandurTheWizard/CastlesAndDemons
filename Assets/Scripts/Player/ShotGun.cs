using UnityEngine;
using UnityEngine.EventSystems;

public class ShotGun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    private bool canShot;

    void Start()
    {
        canShot = true;
    }

    void Update()
    {
        if (Input.GetButton("Fire1")){
            shot();
        }
    }

    private void shot(){
        if(Input.GetButton("Fire1") && canShot && bulletPrefab != null && EventSystem.current.IsPointerOverGameObject() == false){
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            canShot = false;
            Invoke("nowCanShot", 0.5f);
        }
    }

    void nowCanShot(){
        canShot = true;
    }
}
