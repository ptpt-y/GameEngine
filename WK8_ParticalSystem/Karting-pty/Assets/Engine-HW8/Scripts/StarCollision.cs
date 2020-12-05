using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollision : MonoBehaviour
{
    public Rigidbody triggerBody;
    //public GameObject starPartical;
    public ParticleSystem starPartical;

    void OnTriggerEnter(Collider other)
    {
        //do not trigger if there's no trigger target object
        if (triggerBody == null) return;

        //only trigger if the triggerBody matches
        var hitRb = other.attachedRigidbody;
        if (hitRb == triggerBody)
        {
            //starPartical.SetActive(true);
            starPartical.Play();
            this.gameObject.SetActive(false);
        }
    }
}
