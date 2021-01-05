using UnityEngine;
using UnityEngine.SceneManagement;

namespace KartGame.UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        [Tooltip("What is the name of the scene we want to load when clicking the button?")]
        public string SceneName;

        [Tooltip("What audio clip should play when player click the button")]
        public AudioClip ClickSound;
        public void LoadTargetScene() 
        {
            //if (ClickSound)
            //{
            //    AudioUtility.CreateSFX(ClickSound, transform.position, AudioUtility.AudioGroups.Collision, 0f);
            //}

            //yield return new WaitForSeconds(clickSound.length);
            if (SceneManager.GetActiveScene().name == "LoseScene")
            {
                SceneName = EndGameShowScore.GetLevelName();
            }
            if(SceneManager.GetActiveScene().name == "WinScene")
            {
                string s = EndGameShowScore.GetLevelName();
                if (s == "MainScene")
                    SceneName = "Level2Scene";
                if (s == "Level2Scene")
                    SceneName = "Level3Scene";
                if (s == "Level3Scene")
                    SceneName = "MainScene";
            }
            if (ClickSound)
            {
                Invoke("LoadSceneNow", ClickSound.length);
            }
            else
                LoadSceneNow();

            //SceneManager.LoadSceneAsync(SceneName);
        }
        public void LoadSceneNow()
        {
            SceneManager.LoadSceneAsync(SceneName);
        }
        public void LoadScoreBoard()
        {
            SceneManager.LoadSceneAsync("ScoreBoard");
        }
        public void LoadMenu()
        {
            SceneManager.LoadSceneAsync("IntroMenu");
        }
    }
}
