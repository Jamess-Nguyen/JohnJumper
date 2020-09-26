using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public GameObject player;
    public Image innerPanel;
    public TextMeshProUGUI resultText;
    public Button retryButton;
    public Button quitButton;
    public string MainMenuSceneName = "Title";

    private Image outerPanel;
    private Image retryButtonImage;
    private Image quitButtonImage;
    private TextMeshProUGUI retryButtonText;
    private TextMeshProUGUI quitButtonText;
    private playerMovement player_movement;
    private bool ScreenDisplay = false; 
    private bool ScreenUnDisplay = false;
    private ScoreCalculator player_scorecalc;

    // Start is called before the first frame update
    void Start()
    {
        player_movement = player.GetComponent<playerMovement>();
        player_scorecalc = player.GetComponent<ScoreCalculator>();
        outerPanel = GetComponent<Image>();
        
        retryButtonImage = retryButton.GetComponent<Image>();
        retryButtonText = retryButton.GetComponentInChildren<TextMeshProUGUI>();
        quitButtonImage = quitButton.GetComponent<Image>();
        quitButtonText = quitButton.GetComponentInChildren<TextMeshProUGUI>();

        retryButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(ReturnMainMenu);
        CloseScoreDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player_movement.inPlay && !player_movement.beforeplay) {
            // Open the GUI once.
            if (!ScreenDisplay) {
                ScreenDisplay = true;
                OpenScoreDisplay();
            }
            ScreenUnDisplay = false;
        } else {
            // Close the GUI once.
            ScreenDisplay = false;
            if (!ScreenUnDisplay) {
                ScreenUnDisplay = true;
                CloseScoreDisplay();
            }
        }
    }

    // Restart the game (reset player variables) and place the player back at the spawn.
    void RestartGame()
    {
        player_movement.ResetCharacter();
        player_scorecalc.maxHeightFromGround = 0;
    }

    // Return to main menu
    void ReturnMainMenu()
    {
        SceneManager.LoadScene(MainMenuSceneName, LoadSceneMode.Single);
        player_scorecalc.maxHeightFromGround = 0;
    }

    // Hide the GUI and disable the buttons
    void CloseScoreDisplay()
    {
        retryButton.enabled = false;
        retryButtonImage.enabled = false;
        retryButtonText.enabled = false;
        quitButton.enabled = false;
        quitButtonImage.enabled = false;
        quitButtonText.enabled = false;
        outerPanel.enabled = false;
        innerPanel.enabled = false;
        resultText.enabled = false;
    }

    // Unhide the GUI and enable the buttons
    void OpenScoreDisplay()
    {
        retryButton.enabled = true;
        retryButtonImage.enabled = true;
        retryButtonText.enabled = true;
        quitButton.enabled = true;
        quitButtonImage.enabled = true;
        quitButtonText.enabled = true;
        outerPanel.enabled = true;
        innerPanel.enabled = true;
        resultText.enabled = true;
        resultText.text = "You scaled " + player_scorecalc.maxHeightFromGround.ToString() + " feet before falling.";
    }
}
