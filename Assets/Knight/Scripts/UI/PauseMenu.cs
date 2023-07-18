using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPause = false;

    private void Start()
    {
        Time.timeScale = 1;
    }
    public void Pause()
    {
        isPause = true;       
        StartCoroutine(Wait());
    }

    public void Resume()
    {
        isPause = false;       
        Time.timeScale = 1;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.7f);
        Time.timeScale = 0;
    }
}
