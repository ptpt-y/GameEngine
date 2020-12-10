using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play3DSound : MonoBehaviour
{
    private GameObject mainCamera = null;
    public GameObject cubeObject = null;

    private Vector3 direction;
    private uint playingID = 0;
    private void Awake()
    {
        mainCamera = GameObject.Find("Main Camera");
        cubeObject = GameObject.Find("Cube");
        Vector3 tempPos = mainCamera.transform.position;
        tempPos.x -= 100;
        transform.position = tempPos;
    }
    // Start is called before the first frame update
    void Start()
    {
        direction.x = 1;
        direction.y = 0;
        direction.z = 0;

        this.gameObject.AddComponent<AkGameObj>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playingID == 0)
        {
            playingID = AkSoundEngine.PostEvent("Play_ShotGun", this.gameObject);
        }
        float distance = Vector3.Distance(transform.position, mainCamera.transform.position);
        if(distance > 100)
        {
            direction = -direction;
        }
        transform.Translate(direction * 10 * Time.deltaTime, Space.World);
    }
}
