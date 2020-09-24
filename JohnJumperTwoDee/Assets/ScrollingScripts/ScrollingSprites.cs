using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingSprites : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Top;
    public GameObject Bot;
    public GameObject Player;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Top.transform.position.y > Bot.transform.position.y)
        {
            if(Player.transform.position.y > Top.transform.position.y + 729)
            {
                Bot.transform.position = new Vector3(Bot.transform.position.x, Top.transform.position.y + 1458, Bot.transform.position.z);
            }
            else if(Player.transform.position.y < Bot.transform.position.y + 729)
            {
                Top.transform.position = new Vector3(Top.transform.position.x, Bot.transform.position.y - 1458, Top.transform.position.z);
            }
        }
        else if(Bot.transform.position.y > Top.transform.position.y)
        {
            if(Player.transform.position.y > Bot.transform.position.y + 729)
            {
                Top.transform.position = new Vector3(Top.transform.position.x, Bot.transform.position.y + 1458, Top.transform.position.z);
            }
            else if(Player.transform.position.y < Top.transform.position.y + 729)
            {
                Bot.transform.position = new Vector3(Bot.transform.position.x, Top.transform.position.y - 1458, Bot.transform.position.z);
            }
        }
    }
}
