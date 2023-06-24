using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); //string sceneName�ɂ��邱�Ƃł����ȏ�ʂł�����g����悤�ɂ���B
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
