using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SceneTransition : MonoBehaviour
{

    [SerializeField] Image image;

    public IEnumerator AnimateTransitionIn()
    {
        image.rectTransform.anchoredPosition = new Vector2(-1000f, 0f);
        var tweener = image.rectTransform.DOAnchorPosX(0f, 1f);
        yield return tweener.WaitForCompletion();
    }

    public IEnumerator AnimateTransitionOut()
    {
        //image.rectTransform.anchoredPosition = new Vector2(-1000f,0f);
        var tweener = image.rectTransform.DOAnchorPosX(1000f, 1f);
        yield return tweener.WaitForCompletion();
    }
}
