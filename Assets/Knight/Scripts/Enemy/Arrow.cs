using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public PowerData powerData;

    private Damagable dmg;

    private float speed = 10f;
    private float distance = 50f;


    private void Awake()
    {
        dmg = GameObject.Find("Player").GetComponent<Damagable>();

    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        DestroyByDistance();
    }

    void DestroyByDistance()
    {
        var cam = Camera.main;
        var distanceFromCamera = Vector3.Distance(transform.position, cam.transform.position);

        if (distanceFromCamera > distance)
        {
            gameObject.SetActive(false);
        }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            if (!dmg.isDead)
            {
                dmg.TakeDamage(powerData.attackDamage);
            }
        }      
    }
    


}
