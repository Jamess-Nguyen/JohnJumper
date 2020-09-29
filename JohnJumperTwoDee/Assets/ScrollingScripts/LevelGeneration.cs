using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject Player;
    public GameObject Top;
    public GameObject Bot;
    private GameObject Zero, One, Two, Three, Four, Five, Six, Seven;
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
        Zero = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 50f, transform.position.z), Quaternion.identity);
        RandomGen();
        One = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 100f, transform.position.z), Quaternion.identity);
        RandomGen();
        Two = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 150f, transform.position.z), Quaternion.identity);
        RandomGen();
        Three = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 200f, transform.position.z), Quaternion.identity);
        RandomGen();
        Four = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 250f, transform.position.z), Quaternion.identity);
        RandomGen();
        Five = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 300f, transform.position.z), Quaternion.identity);
        RandomGen();
        Six = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 350f, transform.position.z), Quaternion.identity);
        RandomGen();
        Seven = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 400f, transform.position.z), Quaternion.identity);
    }

    private void Update()
    {
        if(Top.transform.position.y > Bot.transform.position.y)
        {
            if (Player.transform.position.y > Top.transform.position.y + 200)
            {
                Bot.transform.position = new Vector3(0, Top.transform.position.y + 400, 0);
                Destroy(Zero);
                RandomGen();
                Zero = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 50f, transform.position.z), Quaternion.identity);
                Destroy(One);
                RandomGen();
                One = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 100f, transform.position.z), Quaternion.identity);
                Destroy(Two);
                RandomGen();
                Two = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 150f, transform.position.z), Quaternion.identity);
                Destroy(Three);
                RandomGen();
                Three = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 200f, transform.position.z), Quaternion.identity);
                Destroy(Four);
                RandomGen();
                Four = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 250f, transform.position.z), Quaternion.identity);
                Destroy(Five);
                RandomGen();
                Five = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 300f, transform.position.z), Quaternion.identity);
                Destroy(Six);
                RandomGen();
                Six = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 350f, transform.position.z), Quaternion.identity);
                Destroy(Seven);
                RandomGen();
                Seven = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 400f, transform.position.z), Quaternion.identity);
            }
        }

        if(Top.transform.position.y < Bot.transform.position.y)
        {
            if (Player.transform.position.y < Top.transform.position.y + 200)
            {
                Bot.transform.position = new Vector3(0, Top.transform.position.y - 400, 0);
                Destroy(Zero);
                RandomGen();
                Zero = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 50f, transform.position.z), Quaternion.identity);
                Destroy(One);
                RandomGen();
                One = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 100f, transform.position.z), Quaternion.identity);
                Destroy(Two);
                RandomGen();
                Two = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 150f, transform.position.z), Quaternion.identity);
                Destroy(Three);
                RandomGen();
                Three = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 200f, transform.position.z), Quaternion.identity);
                Destroy(Four);
                RandomGen();
                Four = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 250f, transform.position.z), Quaternion.identity);
                Destroy(Five);
                RandomGen();
                Five = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 300f, transform.position.z), Quaternion.identity);
                Destroy(Six);
                RandomGen();
                Six = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 350f, transform.position.z), Quaternion.identity);
                Destroy(Seven);
                RandomGen();
                Seven = Instantiate(objects[rand], new Vector3(randPos, Bot.transform.position.y + 400f, transform.position.z), Quaternion.identity);
            }
        }

    }
}
