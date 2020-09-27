using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    public AudioSource grunt;
    public AudioSource fallImpact;
    public AudioSource wallImpact;
    public AudioSource wallSlide;
    public AudioSource spikeImpact;
    public void Grunt() {
        grunt.Play();
    }

    public void Fall() {
        fallImpact.Play();
    }

    public void WallCollide() {
        wallImpact.Play();
    }

    public void WallSlide() {
        wallSlide.Play();
    }

    public void SpikeImpact() {
        spikeImpact.Play();
    }
}
