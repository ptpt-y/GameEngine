using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void GoToClothScene()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToSpringBoneScene()
    {
        SceneManager.LoadScene(0);
    }

}
