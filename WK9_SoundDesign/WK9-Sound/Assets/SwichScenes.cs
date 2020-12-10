using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichScenes : MonoBehaviour
{
    public string sceneName = null;
    // Start is called before the first frame update

    public void Switch()
    {
        if (!string.IsNullOrEmpty(sceneName))
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
