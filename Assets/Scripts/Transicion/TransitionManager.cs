using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{

    public static TransitionManager instance;

    [SerializeField] GameObject sceneTransition;
    [SerializeField] GameObject loadingPanel;
    [SerializeField] Slider progressBar;
    SceneTransition transition;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        transition = sceneTransition.GetComponent<SceneTransition>();
    }

    public void LoadScene(string sceneName)
    {
        print("uno");
        StartCoroutine(LoadSceneAsync(sceneName));
        print("final");
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        print("dos");

        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        print("tres");


        yield return transition.AnimateTransitionIn();

        loadingPanel.SetActive(true);

        print("cuatro");

        do
        {
            print("hi");
            progressBar.value = scene.progress;
            yield return null;

        } while (scene.progress < 0.9f);

        print("cinco");

        yield return new WaitForSeconds(1f);

        print("sei");

        scene.allowSceneActivation = true;

        print("siete");

        loadingPanel.SetActive(false);

        print("ocho");

        yield return transition.AnimateTransitionOut();

        print("nueve");
    }

}
