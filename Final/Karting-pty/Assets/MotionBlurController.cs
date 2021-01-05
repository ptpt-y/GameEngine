using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MotionBlurController : MonoBehaviour
{
    public Camera mainCam;
    public void TurnOnMotionBlur()
    {
        mainCam.GetComponent<MotionBlurEffects>().enabled = true;
        mainCam.GetComponent<PostProcessLayer>().enabled = false;
    }
    public void TurnOffMotionBlur()
    {
        mainCam.GetComponent<MotionBlurEffects>().enabled = false;
        mainCam.GetComponent<PostProcessLayer>().enabled = true;
    }
}
