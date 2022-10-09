using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private float yawn = 0.0f;
    private float pitch = 0.0f;
    
    public Vector2 moveVal;
    public Vector2 cameraMoveVal;
    
    [SerializeField]
    private Transform playerTransform;
    
    [SerializeField]
    private float moveSpeed = 3;
    [SerializeField]
    private float jumpSpeed = 50;

    [SerializeField] private Camera camera;

    
    /**
     * The distance to the ground, used for isGrounded calculation
     * Source: https://answers.unity.com/questions/196381/how-do-i-check-if-my-rigidbody-player-is-grounded.html
     */
    private float distToGround = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Collider playerCollider = gameObject.GetComponent<Collider>();
        distToGround = playerCollider.bounds.extents.y;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        playerTransform.Translate(new Vector3(moveVal.x, 0, moveVal.y) * moveSpeed * Time.deltaTime);
        playerTransform.Rotate(new Vector3(0, cameraMoveVal.x, 0));
        
        // camera.transform.Translate(new Vector3(0, 0, cameraMoveVal.x));
    }
    
    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
    
    void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();
    }

    void OnCamera(InputValue value)
    {
        cameraMoveVal = value.Get<Vector2>();
      
    }

    void OnJump()
    {
        if (IsGrounded())
        {
            Rigidbody playerRigidBody = gameObject.GetComponent<Rigidbody>();
            playerRigidBody.AddForce(new Vector3(0, this.jumpSpeed, 0));
        }
    }
    
   
}
