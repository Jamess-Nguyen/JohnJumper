using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject Player;
    public GameObject Top;
    public GameObject Bot;
    private GameObject Mob;
    int rand;
    int randPos;

    private void RandomGen()
    {
        rand = Random.Range(0, objects.Length);
        randPos = Random.Range(-25, 25);
    }
    // Start is called before the first frame update
    void Start()
    {
        RandomGen();
        Mob = Instantiate(objects[rand], new Vector3(randPos, transform.position.y, transform.position.z), Quaternion.identity);
    }

    private void Update()
    {
        if(Top.transform.position.y > Bot.transform.position.y)
        {
            if(Player.transform.position.y < Bot.transform.position.y + 190.4f)
            {
                Destroy(Mob);
                RandomGen();
                Mob = Instantiate(objects[rand], new Vector3(randPos, transform.position.y, transform.position.z), Quaternion.identity);
                //Top.transform.position = new Vector3(Top.transform.position.x, Bot.transform.position.y - 190.4f, Top.transform.position.z);
            }
        }
    }
}
