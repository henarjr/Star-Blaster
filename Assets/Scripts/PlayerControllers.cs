using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllers : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float leftBoundPadding;
    [SerializeField] float rightBoundPadding;
    [SerializeField] float topBoundPadding;
    [SerializeField] float bottomBoundPadding;

    Shooter playerShooter;
   
    InputAction moveAction;
    InputAction fireAction;

    Vector3 moveVector;
    Vector2 minBounds;
    Vector2 maxBounds;


    void Start()
    {
        playerShooter = GetComponent<Shooter>();
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Fire");

        InitBounds();   
    }

    
    void Update()
    {
        MovePlayer();
        FireShooter();
    }
      
    void InitBounds()
    {
        Camera maincamera = Camera.main;
        minBounds = maincamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = maincamera.ViewportToWorldPoint(new Vector2(1, 1));

        //Debug.Log($"Min: {minBounds}");
        //Debug.Log($"Max: {maxBounds}");
    }



    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position + moveVector * moveSpeed * Time.deltaTime;

        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + leftBoundPadding, maxBounds.x - rightBoundPadding);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y + bottomBoundPadding, maxBounds.y - topBoundPadding);

        //Debug.Log("Player Y: " + transform.position.y);

        transform.position = newPos;
    }

    void FireShooter()
    {
        playerShooter.isFiring = fireAction.IsPressed();
    }

}
