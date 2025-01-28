using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Alien"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameManager.Instance.AddPoints(10);
        }

        Invoke(nameof(DestroyLate), 4);
        
    }

    private void DestroyLate()
    {
        try
        {
            Destroy(gameObject);
        }
        catch (UnassignedReferenceException)
        {
            print("Couldnt Destroy");
        }


    }
}
