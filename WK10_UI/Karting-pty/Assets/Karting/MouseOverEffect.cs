using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverEffect : MonoBehaviour
{
    //public Button btn;
    //public Sprite initSprite;
    //public Sprite focusSprite;
    public void PointEnter()
    {
        //myImage.sprite = focusSprite;
        //btn.GetComponent<Image>().sprite = focusSprite;
        transform.localScale = new Vector3(2.224457f, 14.62112f, 2.224457f);

    }
    public void PointExit()
    {
        //myImage.sprite = initSprite;
        //btn.GetComponent<Image>().sprite = initSprite;
        transform.localScale = new Vector3(1.968546f, 12.93905f, 1.968546f);
    }
}
