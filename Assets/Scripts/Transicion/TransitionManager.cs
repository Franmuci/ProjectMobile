using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{

    [SerializeField] GameObject sceneTransition;
    [SerializeField] GameObject loadingPanel;
    [SerializeField] Slider progressBar;
    SceneTransition transition;


    private void Awake()
    {
        transition = sceneTransition.GetComponent<SceneTransition>();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        yield return transition.AnimateTransitionIn();

        loadingPanel.SetActive(false);

        do
        {
            progressBar.value = scene.progress;
            yield return null;
        } while (scene.progress < 0.9);

        yield return new WaitForSeconds(1f);

        scene.allowSceneActivation = true;

        loadingPanel.SetActive(true);

        yield return transition.AnimateTransitionOut();
    }

}
