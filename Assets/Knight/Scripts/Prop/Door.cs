using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject bossPrefab;
    public GameObject door;
    public GameObject minimap;

    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bossPrefab.SetActive(true);
            door.SetActive(true);
            minimap.SetActive(false);

            AudioManager.Instance.musicSource.Stop();
            AudioManager.Instance.PlayMusic("Fight");


        }
    }
}
