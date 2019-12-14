using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidBody;

    [SerializeField] float runSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // cache Rigidbody
        myRigidBody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    private void Run()
    {
        // get horizontal axis
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value is between -1 to +1
        // create vector2  that will give us the x and y for movement left and right
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
    }
}
