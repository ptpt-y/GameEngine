using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KartGame.KartSystems;
using UnityEngine.Events;

public class SpeedDown : MonoBehaviour
{
    Rigidbody rb;
    public UnityEvent onFrozenActivated;
    public UnityEvent onFrozenFinish;
    bool isFrozen = false;
    public void OnTriggerEnter(Collider other)
    {
        //var rb = other.attachedRigidbody;
        rb = other.attachedRigidbody;
        if (rb && !isFrozen)
        {
            isFrozen = true;
            Debug.Log("减速垫");
            var kart = rb.GetComponent<ArcadeKart>();
            kart.Rigidbody.velocity = new Vector3(0, 0, 0);
            kart.SetCanMove(false);
            onFrozenActivated.Invoke();
            Invoke("FinishFrozen", 5f);
        }
    }
    public void FinishFrozen()
    {
        Debug.Log("Finish FROZEN!");
        onFrozenFinish.Invoke();
        var kart = rb.GetComponent<ArcadeKart>();
        kart.SetCanMove(true);
        //isFrozen = true;
        Destroy(gameObject);
    }
}
