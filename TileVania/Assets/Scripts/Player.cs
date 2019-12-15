using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField] float runSpeed = 5f;

    // State
    bool isAlive = true;

    // Cached component references
    Rigidbody2D myRigidBody;
    Animator myAnimator;



    // Start is called before the first frame update
    void Start()
    {
        // cache Rigidbody
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
    }

    private void Run()
    {
        // get horizontal axis
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value is between -1 to +1
        // create vector2  that will give us the x and y for movement left and right
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        // Using this so can switch from idle animation to running if we are running
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        // if running playerHasHorizontalSpeed will be true, else it will be false
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);

        
    }


    private void FlipSprite()
    {
        // when absolut value of movement  is greater than zero(mathf.epsilon) our bool will return true
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            // If we are moving then localScale is either +1 or -1 depending on sign of movemtn. 
            // Mathf.Sign will be positive 1 or negative 1 depending on if the number in it is poistive or negative. So if pos 1 will mean scale x = 1 meaning face right. If neg 1 then scale x = -1 meaning face left
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }
}
