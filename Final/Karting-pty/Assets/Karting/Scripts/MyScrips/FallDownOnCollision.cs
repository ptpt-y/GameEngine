using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownOnCollision : MonoBehaviour
{
    public GameObject Tires;

    public void OnTriggerEnter(Collider other)
    {
        Tires.SetActive(true);
    }
}
