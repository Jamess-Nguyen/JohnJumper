using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource Sponge;
    public void SpongeSound()
    {
        Sponge.Play();
    }
}
