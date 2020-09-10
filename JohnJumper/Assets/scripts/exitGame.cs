using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exitGame : MonoBehaviour
{
    private Button exitButton;

    private void Start() {
        exitButton = GetComponent<Button>();
        exitButton.onClick.AddListener(OnButtonExitClick);
    }
    void OnButtonExitClick() {
        // Quit the game.
        Application.Quit();
    }
}
