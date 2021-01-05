using KartGame.KartSystems;
using UnityEngine;
using UnityEngine.Events;

public class ArcadeKartPowerup : MonoBehaviour {

    public ArcadeKart.StatPowerup boostStats = new ArcadeKart.StatPowerup
    {
        MaxTime = 5
    };

    public static bool isCoolingDown { get; private set; }
    public static float lastActivatedTimestamp { get; private set; }

    public static float cooldown = 5f;
    private bool Triggered = false;

    public bool disableGameObjectWhenActivated;
    public UnityEvent onPowerupActivated;
    public UnityEvent onPowerupFinishCooldown;

    private void Awake()
    {
        lastActivatedTimestamp = -9999f;
    }


    private void Update()
    {
        if (isCoolingDown) {
            if (Time.time - lastActivatedTimestamp > cooldown) {
                //finished cooldown!
                isCoolingDown = false;
                Debug.Log("finished cooldown!");
                cooldown = 5f;
                onPowerupFinishCooldown.Invoke();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        var rb = other.attachedRigidbody;
        //if (isCoolingDown) return;
        if (isCoolingDown && !Triggered)
        {
            cooldown += 5f;
            Triggered = true;
            
            if (rb)
            {
                var kart = rb.GetComponent<ArcadeKart>();

                if (kart)
                {
                    //lastActivatedTimestamp = Time.time;
                    kart.AddPowerup(this.boostStats);
                    onPowerupActivated.Invoke();
                    isCoolingDown = true;
                    //if (disableGameObjectWhenActivated) this.gameObject.SetActive(false);
                }
            }
        }
        else if(!isCoolingDown)
        {
            if (rb)
            {
                var kart = rb.GetComponent<ArcadeKart>();

                if (kart)
                {
                    lastActivatedTimestamp = Time.time;
                    kart.AddPowerup(this.boostStats);
                    onPowerupActivated.Invoke();
                    Triggered = true;
                    isCoolingDown = true;
                    //if (disableGameObjectWhenActivated) this.gameObject.SetActive(false);
                }
            }
        }
        
    }

}
