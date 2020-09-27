using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class creditsButton : MonoBehaviour
{
    public string GameplaySceneName = "Credits";
    private Button creditButton;
    // Start is called before the first frame update
    void Start()
    {
        creditButton = GetComponent<Button>();
        creditButton.onClick.AddListener(OnCreditButtonClick);        
    }

    void OnCreditButtonClick() {
        SceneManager.LoadScene(GameplaySceneName, LoadSceneMode.Single);
    }
}
