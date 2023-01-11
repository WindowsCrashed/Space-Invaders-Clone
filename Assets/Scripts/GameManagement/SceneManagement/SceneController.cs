using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour 
{
    [SerializeField] SceneTransition transition;

    bool isLoading;

    IEnumerator LoadSceneCoroutine(string scene)
    {
        TimeScaleController.FreezeGame();
        transition.PlayTransition("Wipe");
        yield return new WaitForSecondsRealtime(transition.SelectedTransition.Duration);
        SceneManager.LoadScene(scene);
        TimeScaleController.UnfreezeGame();
    }

    void LoadScene(string name)
    {
        if (!isLoading)
        {
            isLoading = true;
            StartCoroutine(LoadSceneCoroutine(name));
        }
    }

    public void LoadGame()
    {
        LoadScene("Game");       
    }

    public void LoadChoosePlayer()
    {
        LoadScene("ChoosePlayer");    
    }
}
