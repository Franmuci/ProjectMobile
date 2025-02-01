using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SceneTransition : MonoBehaviour
{

    [SerializeField] Image image;

    public IEnumerator AnimateTransitionIn()
    {

        Time.timeScale = 1.0f;
        print("In1");

        image.rectTransform.anchoredPosition = new Vector2(0f, 0f);
        print("In2");


        var tweener = image.rectTransform.DOScale(new Vector3(1f,1f,1f),1f);
        print("In3");

        print(tweener);

        yield return tweener.WaitForCompletion();
        print("In4");

    }

    public IEnumerator AnimateTransitionOut()
    {
        Time.timeScale = 1.0f;
        var tweener = image.rectTransform.DOScale(new Vector3(0f, 0f, 0f), 1f);
        yield return tweener.WaitForCompletion();
    }
}
