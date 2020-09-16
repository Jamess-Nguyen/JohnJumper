using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public string GameplaySceneName = "MainGameplay";
    private Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(OnStartButtonClick);        
    }

    void OnStartButtonClick() {
        SceneManager.LoadScene(GameplaySceneName, LoadSceneMode.Single);
    }
}
