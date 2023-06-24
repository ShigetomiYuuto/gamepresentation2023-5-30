using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); //string sceneNameÇ…Ç∑ÇÈÇ±Ç∆Ç≈Ç¢ÇÎÇÒÇ»èÍñ Ç≈Ç±ÇÍÇégÇ¶ÇÈÇÊÇ§Ç…Ç∑ÇÈÅB
    }

    public void CloseGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        return;
#else
        Application.Quit();
#endif
    }
}
