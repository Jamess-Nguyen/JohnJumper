using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboDisplay : MonoBehaviour
{
    public int numCombos = 0;
    private int prevCombos = 0;
    public playerMovement playerMoveScript;
    private TextMeshProUGUI textCombo;
    private bool debounce;

    private Color coolPink;
    private Color gray = Color.gray;

    // Start is called before the first frame update
    void Start()
    {
        textCombo = GetComponent<TextMeshProUGUI>();
        coolPink = textCombo.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (prevCombos != numCombos) {
            if (numCombos > 0) {
                textCombo.text = numCombos.ToString() + "x";
            }   else {
                textCombo.text = "";
            }
        }
        if (numCombos > 0) {
            textCombo.color = Color.Lerp(gray, coolPink, playerMoveScript.currentTimeBetweenJumps / playerMoveScript.timeComboDecays);
        }
        prevCombos = numCombos;
    }
}
