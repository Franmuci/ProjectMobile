using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class ScapeshipController : MonoBehaviour
{


    private Rigidbody2D currentSpaceshipRigidbody;
    private GameObject currentSpaceship;
    private float shootTimer;
    private Transform shootPoint;



    [SerializeField] private GameObject prefabStarship;
    [SerializeField] private GameObject prefabShoot;
    [SerializeField] private float fireRate;



    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }


    private void Awake()
    {
        shootTimer = 0.0f;


        SpawnStarship();
    }

    void Update()
    {
        StarshipShoot();
        StarshipMove();

    }



    private void SpawnStarship()
    {
        currentSpaceship = Instantiate(prefabStarship, new Vector3(0, -4.0f, 0), Quaternion.identity);

        currentSpaceshipRigidbody = currentSpaceship.GetComponentInChildren<Rigidbody2D>();

        shootPoint = currentSpaceship.transform.GetChild(1).GetComponent<Transform>();

        currentSpaceshipRigidbody.bodyType = RigidbodyType2D.Kinematic;
    }


    private void StarshipMove()
    {
        if (currentSpaceshipRigidbody == null || Touch.activeTouches.Count <= 0) return;


        Vector2 touchPosition = Vector2.zero;


        //Iterate through all active touches
        foreach (Touch touch in Touch.activeTouches)
        {
            touchPosition += touch.screenPosition;
        }

        touchPosition /= Touch.activeTouches.Count;


        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);

        currentSpaceship.transform.position = Vector2.MoveTowards(currentSpaceshipRigidbody.position, new Vector2(worldPosition.x, currentSpaceshipRigidbody.position.y), 0.2f);

    }

    private void StarshipShoot()
    {
        TimeUp();
        if (shootTimer >= fireRate)
        {
            shootTimer = 0.0f;
            print(shootPoint.position);
            Instantiate(prefabShoot, shootPoint.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForceY(400);
        }
    }

    private void TimeUp()
    {
        shootTimer += Time.deltaTime;
    }

}
