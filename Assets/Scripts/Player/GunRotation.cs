using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    private Vector3 objetivo;
    private Camera camara;
    private SpriteRenderer sprite;

    void Start(){
        camara = Camera.main;
        Transform childObject = transform.Find("Gun");
        sprite = childObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        objetivo = camara.ScreenToWorldPoint(Input.mousePosition);

        float anguloRadiales = Mathf.Atan2(objetivo.y - transform.position.y, objetivo.x - transform.position.x);
        float anguloGrados = (180 / Mathf.PI) * anguloRadiales;
        transform.rotation = Quaternion.Euler(0, 0, anguloGrados);

        if(anguloGrados > 90 || anguloGrados < -90){
            sprite.flipY = true;
        }else{
            sprite.flipY = false;
        }
    }
}
