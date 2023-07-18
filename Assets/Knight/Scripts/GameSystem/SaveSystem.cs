using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveSystem : MonoBehaviour
{
    public LoadedData loadedData { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ResetData()
    {
        Debug.Log("reset data");
        GameObject.FindObjectOfType<GameManager>().saveSystem.loadedData = new LoadedData();
    }


    public void SaveData(int playerHealth, Vector3 playerPosition)
    {
        Debug.Log("saved");
        loadedData = new LoadedData();
        loadedData.health = playerHealth;
        loadedData.position = playerPosition;
    }

}

public class LoadedData
{
    public int health = 0;
    public Vector3 position = new Vector3(-28, -3, 0);
}
