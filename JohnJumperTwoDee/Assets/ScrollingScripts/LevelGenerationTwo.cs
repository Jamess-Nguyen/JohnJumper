using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerationTwo : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject Player;
    public GameObject Top;
    public GameObject Bot;
    private GameObject Zero2, One2, Two2, Three2, Four2, Five2, Six2, Seven2;
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
        Zero2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 50f, transform.position.z), Quaternion.identity);
        RandomGen();
        One2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 100f, transform.position.z), Quaternion.identity);
        RandomGen();
        Two2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 150f, transform.position.z), Quaternion.identity);
        RandomGen();
        Three2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 200f, transform.position.z), Quaternion.identity);
        RandomGen();
        Four2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 250f, transform.position.z), Quaternion.identity);
        RandomGen();
        Five2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 300f, transform.position.z), Quaternion.identity);
        RandomGen();
        Six2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 350f, transform.position.z), Quaternion.identity);
        RandomGen();
        Seven2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 400f, transform.position.z), Quaternion.identity);
    }
    private void Update()
    {
        if (Top.transform.position.y > Bot.transform.position.y)
        {
            if (Player.transform.position.y < Bot.transform.position.y + 200)
            {
                Top.transform.position = new Vector3(0, Bot.transform.position.y - 400, 0);
                if(Top.transform.position.y > 0)
                {
                    Destroy(Zero2);
                    RandomGen();
                    Zero2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 50f, transform.position.z), Quaternion.identity);
                    Destroy(One2);
                    RandomGen();
                    One2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 100f, transform.position.z), Quaternion.identity);
                    Destroy(Two2);
                    RandomGen();
                    Two2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 150f, transform.position.z), Quaternion.identity);
                    Destroy(Three2);
                    RandomGen();
                    Three2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 200f, transform.position.z), Quaternion.identity);
                    Destroy(Four2);
                    RandomGen();
                    Four2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 250f, transform.position.z), Quaternion.identity);
                    Destroy(Five2);
                    RandomGen();
                    Five2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 300f, transform.position.z), Quaternion.identity);
                    Destroy(Six2);
                    RandomGen();
                    Six2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 350f, transform.position.z), Quaternion.identity);
                    Destroy(Seven2);
                    RandomGen();
                    Seven2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 400f, transform.position.z), Quaternion.identity);
                }
                else
                {
                    Destroy(Zero2);
                    Destroy(One2);
                    Destroy(Two2);
                    Destroy(Three2);
                    Destroy(Four2);
                    Destroy(Five2);
                    Destroy(Six2);
                    Destroy(Seven2);
                }

            }
        }

        if (Top.transform.position.y < Bot.transform.position.y)
        {
            if (Player.transform.position.y > Bot.transform.position.y + 200)
            {
                Top.transform.position = new Vector3(0, Bot.transform.position.y + 400, 0);
                Destroy(Zero2);
                RandomGen();
                Zero2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 50f, transform.position.z), Quaternion.identity);
                Destroy(One2);
                RandomGen();
                One2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 100f, transform.position.z), Quaternion.identity);
                Destroy(Two2);
                RandomGen();
                Two2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 150f, transform.position.z), Quaternion.identity);
                Destroy(Three2);
                RandomGen();
                Three2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 200f, transform.position.z), Quaternion.identity);
                Destroy(Four2);
                RandomGen();
                Four2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 250f, transform.position.z), Quaternion.identity);
                Destroy(Five2);
                RandomGen();
                Five2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 300f, transform.position.z), Quaternion.identity);
                Destroy(Six2);
                RandomGen();
                Six2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 350f, transform.position.z), Quaternion.identity);
                Destroy(Seven2);
                RandomGen();
                Seven2 = Instantiate(objects[rand], new Vector3(randPos, Top.transform.position.y + 400f, transform.position.z), Quaternion.identity);
            }
        }

    }
}
