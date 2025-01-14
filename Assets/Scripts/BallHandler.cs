using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class BallHandler : MonoBehaviour
{

    private Vector3 screenSize;
    private Vector3 screenPixel;
    private Rigidbody2D currentBallRigidbody;
    //private SpringJoint2D currentBallSpringJoint;

    //[SerializeField] private Rigidbody2D pivot;
    [SerializeField] private GameObject prefabBall;
    //[SerializeField] private float detachDelay = 0.5f;
    //[SerializeField] private float respawnDelay = 2.5f;

    private bool isDragging = false;


    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }


    private void Start()
    {
        screenPixel = new Vector3(Screen.height/2, Screen.width/2, 0.0f);
        screenSize = Camera.main.ScreenToWorldPoint(screenPixel);
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        //Exit update if no ball left
        if(currentBallRigidbody == null) return;


        //If I am not touching the screen

        if(Touch.activeTouches.Count <= 0)
        //if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            //if the ball was being dragged, launch it


            if (isDragging) 
            {
                //currentBallRigidbody.bodyType = RigidbodyType2D.Dynamic;

                LaunchBall();

                isDragging = false;

                //Invoke(nameof(SpawnBall), 0.5f);
            }
            return;

        }

        currentBallRigidbody.bodyType = RigidbodyType2D.Kinematic;

        //Mark the ball is being dragged
        isDragging = true;

        //Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector2 touchPosition = Vector2.zero;

        //Iterate through all active touches
        foreach(Touch touch in Touch.activeTouches)
        {
            touchPosition += touch.screenPosition;
        }

        touchPosition /= Touch.activeTouches.Count;


        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);

        currentBallRigidbody.position = Vector2.MoveTowards( currentBallRigidbody.position , new Vector2(worldPosition.x, currentBallRigidbody.position.y) ,0.2f);
        //currentBallRigidbody.position = new Vector3(worldPosition.x, worldPosition.y,0.0f);

        print("Ball Position: " + currentBallRigidbody.gameObject.transform.position); 
        print("World Position: " + worldPosition); 
    }


    private void LaunchBall()
    {
        //The ball will be one time use
        //currentBallRigidbody = null;

        //Schedule the ball's detachment after a delay
        //Invoke(nameof(DetachBall), detachDelay);

    }

    private void DetachBall()
    {
        //Disable the springjoint disconnecting the ball from the pivot
        //currentBallSpringJoint.enabled = false;

        //currentBallSpringJoint = null;
        
        //TODO Respawn a new ball after a delay
    }

    /// <summary>
    /// Spawn a ball and attaches it to the pivot using SpringJoint2D
    /// </summary>
    private void SpawnBall()
    {
        GameObject newBall = Instantiate(prefabBall,new Vector3(0, -4.0f, 0), Quaternion.identity);

        print("Size"+screenSize);
        print("Pixel"+screenPixel);
        
        currentBallRigidbody = newBall.GetComponent<Rigidbody2D>();
        //currentBallSpringJoint = newBall.GetComponent<SpringJoint2D>();
        //currentBallSpringJoint.connectedAnchor = pivot.position;
        //Vector3[] positions = { newBall.transform.position, pivot.position };
        //newBall.AddComponent<LineRenderer>().SetPositions(positions: positions);
    }
}
