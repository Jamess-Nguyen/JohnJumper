using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PostMenu : MonoBehaviour
{
    public GameObject Player;
    public BasicMovement Bm;
    public GameObject Canvas;
    public WhiteFlash WF;
    private float Timer = 0;
    // Update is called once per frame
    private void Start()
    {
        Canvas.SetActive(false);
    }

    public void Update()
    {
        if(Timer >= .85)
        {
            Canvas.SetActive(true);
        }

        else if (WF.PostFlash == true)
        {
            Timer += 1 * Time.deltaTime;
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Canvas.SetActive(false);
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}
