using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour 
{
    [SerializeField] SceneTransition transition;

    IEnumerator LoadSceneCoroutine(string scene)
    {
        TimeScaleController.FreezeGame();
        transition.PlayTransition("Wipe");
        yield return new WaitForSecondsRealtime(transition.SelectedTransition.Duration);
        SceneManager.LoadScene(scene);
        TimeScaleController.UnfreezeGame();
    }

    public void LoadGame()
    {
        StartCoroutine(LoadSceneCoroutine("Game"));
    }
}
