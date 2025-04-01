using UnityEngine.SceneManagement;

namespace Domir.Client.SceneManagement
{
    public class SceneLoader
    {
        public void LoadAsync(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}