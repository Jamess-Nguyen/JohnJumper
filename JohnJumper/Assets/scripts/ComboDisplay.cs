using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboDisplay : MonoBehaviour
{
    public int numCombos = 0;
    private int prevCombos = 0;
    private TextMeshProUGUI textCombo;
    private bool debounce;

    // Start is called before the first frame update
    void Start()
    {
        textCombo = GetComponent<TextMeshProUGUI>();
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
        prevCombos = numCombos;
    }
}
