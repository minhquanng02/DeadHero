using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SaveSystem saveSystem;
    public GameObject player;

    private void Awake()
    {
        SceneManager.sceneLoaded += Initialize;
        DontDestroyOnLoad(gameObject);
    }


    private void Initialize(Scene scene, LoadSceneMode sceneMode)
    {
        var playerInput = FindObjectOfType<PlayerInput>();

        if (playerInput != null)
            player = playerInput.gameObject;

        saveSystem = FindObjectOfType<SaveSystem>();

        if (player != null)
        { 
            player.GetComponent<PlayerDamagable>().currentHealth = saveSystem.loadedData.health;
            player.transform.position = saveSystem.loadedData.position;
        }      
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void SaveData()
    {
        if (player != null)
            saveSystem.SaveData(player.GetComponent<PlayerDamagable>().currentHealth, player.transform.position);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
