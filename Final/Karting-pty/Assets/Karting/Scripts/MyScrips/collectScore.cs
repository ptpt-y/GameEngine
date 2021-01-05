using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectScore : MonoBehaviour
{
    public AudioSource collectSound;
    public int value;

    private void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        ScoringSystem.scoreNum += value;
        Destroy(gameObject);
    }
}
