using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColliderEnd : MonoBehaviour
{

    [SerializeField] LevelManager levelManager;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Alien"))
        {
            levelManager.ColliderEndHit();
            Destroy(gameObject);
        }
            
    }



}


