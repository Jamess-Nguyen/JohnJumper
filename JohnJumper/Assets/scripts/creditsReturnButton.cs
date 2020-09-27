using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class creditsReturnButton : MonoBehaviour
{
    public string GameplaySceneName = "Title";
    private Button creditsRButton;
    // Start is called before the first frame update
    void Start()
    {
        creditsRButton = GetComponent<Button>();
        creditsRButton.onClick.AddListener(OnCreditRButtonClick);        
    }

    void OnCreditRButtonClick() {
        SceneManager.LoadScene(GameplaySceneName, LoadSceneMode.Single);
    }
}
