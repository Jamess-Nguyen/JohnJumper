using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource Sponge;
    public AudioSource Disable;
    public AudioSource Jumpy;
    public AudioSource Landing;
    public void SpongeSound()
    {
        Sponge.Play();
    }
    public void DisableSound()
    {
        Disable.Play();
    }
    public void JumpSound()
    {
        Jumpy.Play();
    }
    public void LandSound()
    {
        Landing.Play();
    }

}
