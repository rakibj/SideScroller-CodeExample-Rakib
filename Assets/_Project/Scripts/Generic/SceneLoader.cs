using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Generic
{
    public class SceneLoader : MonoBehaviour
    {
        public void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
