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

    public float spikeLeft = -11.4f; // 4.4f
    public float spikeRight = 11.6f; // 26.6f
    [Range(-1,1)]
    
    private SpriteRenderer spikeFirst_sr;
    private SpriteRenderer spike1_sr;
    private SpriteRenderer spike2_sr;
    private SpriteRenderer spike3_sr;
    private SpriteRenderer spike4_sr;
    private SpriteRenderer spike5_sr;
    private SpriteRenderer spike6_sr;
    private SpriteRenderer spikeLast_sr;

    [Range(-1,1)]
    private int First = -1;
    [Range(-1,1)]
    private int Second = -1;
    [Range(-1,1)]
    private int secondLast = -1;
    [Range(-1,1)]
    private int Last = -1; 
    private List<bool> spikePos; // True is left, False is right.

    // Start is called before the first frame update
    void Start()
    {
        spikePos = new List<bool>();
        spikeFirst_sr = spikeFirst.GetComponent<SpriteRenderer>();
        spike1_sr = spike1.GetComponent<SpriteRenderer>();
        spike2_sr = spike2.GetComponent<SpriteRenderer>();
        spike3_sr = spike3.GetComponent<SpriteRenderer>();
        spike4_sr = spike4.GetComponent<SpriteRenderer>();
        spike5_sr = spike5.GetComponent<SpriteRenderer>();
        spike6_sr = spike6.GetComponent<SpriteRenderer>();
        spikeLast_sr = spikeLast.GetComponent<SpriteRenderer>();
        GenerateSpikePos();
        SetSpikePos();
    }

    // Generate the random left right stuff for the spikes.
    public void GenerateSpikePos(bool up=true)
    {
        if (up) {
            // generate spikes moving up
            if (spikePos.Count > 0) {
                Last = spikePos[spikePos.Count-1] ? 1 : 0;
                secondLast = spikePos[spikePos.Count-2] ? 1 : 0;
                spikePos.Clear();
            }
            for (int i = 0; i < 8; i++) {
                bool val = Random.Range(0, 2) == 1;
                spikePos.Add(val);
            }
            if ((Last != -1) && (secondLast != -1)) {
                spikePos[1] = (Last == 1 ? true : false);
                spikePos[0] = (secondLast == 1 ? true : false);
            }
        }   else {
            // generate spikes moving down
            if (spikePos.Count > 0) {
                First = spikePos[0] ? 1 : 0;
                Second = spikePos[1] ? 1 : 0;
                spikePos.Clear();
            }
            for (int i = 0; i < 8; i++) {
                bool val = Random.Range(0, 2) == 1;
                spikePos.Add(val);
            }
            if ((First != -1) && (Second != -1)) {
                spikePos[spikePos.Count-1] = (First == 1 ? true : false);
                spikePos[spikePos.Count-2] = (Second == 1 ? true : false);
            }
        }
        
    }

    public void SetSpikePos()
    {
        for (int i = 0; i < 8; i++) {
            switch (i) {
                case 7:
                    spikeLast.transform.position = new Vector2(returnLR(spikePos[7]), spikeLast.transform.position.y);
                    if (spikePos[7]) spikeLast_sr.flipX = false;
                    else spikeLast_sr.flipX = true;
                    break;
                case 6:
                    spike6.transform.position = new Vector2(returnLR(spikePos[6]), spike6.transform.position.y);
                    if (spikePos[6]) spike6_sr.flipX = false;
                    else spike6_sr.flipX = true;
                    break;
                case 5:
                    spike5.transform.position = new Vector2(returnLR(spikePos[5]), spike5.transform.position.y);
                    if (spikePos[5]) spike5_sr.flipX = false;
                    else spike5_sr.flipX = true;
                    break;
                case 4:
                    spike4.transform.position = new Vector2(returnLR(spikePos[4]), spike4.transform.position.y);
                    if (spikePos[4]) spike4_sr.flipX = false;
                    else spike4_sr.flipX = true;
                    break;
                case 3:
                    spike3.transform.position = new Vector2(returnLR(spikePos[3]), spike3.transform.position.y);
                    if (spikePos[3]) spike3_sr.flipX = false;
                    else spike3_sr.flipX = true;
                    break;
                case 2:
                    spike2.transform.position = new Vector2(returnLR(spikePos[2]), spike2.transform.position.y);
                    if (spikePos[2]) spike2_sr.flipX = false;
                    else spike2_sr.flipX = true;
                    break;
                case 1:
                    spike1.transform.position = new Vector2(returnLR(spikePos[1]), spike1.transform.position.y);
                    if (spikePos[1]) spike1_sr.flipX = false;
                    else spike1_sr.flipX = true;
                    break;
                case 0:
                    spikeFirst.transform.position = new Vector2(returnLR(spikePos[0]), spikeFirst.transform.position.y);
                    if (spikePos[0]) spikeFirst_sr.flipX = false;
                    else spikeFirst_sr.flipX = true;
                    break;
            }
        }
    }

    // True is left, False is right.
    private float returnLR(bool b)
    {
        if (b) return spikeLeft;
        else return spikeRight; 
    }
}
