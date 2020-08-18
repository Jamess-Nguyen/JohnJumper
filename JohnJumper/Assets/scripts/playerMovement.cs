using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public GameObject playerObject;
    public float speed = 5;
    private float x_axis = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            Debug.Log("Hello World!");
        }

        x_axis = Input.GetAxisRaw("Horizontal"); // Returns -1 if moving left, 0 is not moving, 1 if moving right
    }

    // Fixed update is called after a set time
    void FixedUpdate()
    {
        switch (x_axis)
        {
            case 1:
                playerObject.GetComponent<Position> = playerObject.GetComponent<Position> + speed * Time.deltaTime;
                break;
            case -1:
                playerObject.GetComponent<Position> = playerObject.GetComponent<Position> - speed * Time.deltaTime;
                break;
        }
    }
}
