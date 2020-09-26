using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeGen : MonoBehaviour
{
    public GameObject spikeFirst;
    public GameObject spike1;
    public GameObject spike2;
    public GameObject spike3;
    public GameObject spike4;
    public GameObject spike5;
    public GameObject spike6;
    public GameObject spikeLast;

    public float spikeLeft = 4.4f;
    public float spikeRight = 26.6f;

    List<bool> spikePos; // True is left, False is right.

    // Start is called before the first frame update
    void Start()
    {
        spikePos = new List<bool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
