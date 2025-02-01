using DG.Tweening;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.DOMoveX(transform.position.x + 0.5f, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        transform.DOMoveY(transform.position.y - 0.5f, 3f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.InOutSine);
    }

    

}
