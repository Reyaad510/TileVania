using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    // Config
    [SerializeField] float moveSpeed = 1f;

    // cached component references
    Rigidbody2D myRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // If True then enemy moves right
        if (IsFacingRight())
        {
            
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        // If False enemy moves left
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
       
    }



    
    // If negative localScale then IsFacingRight is false and if positive then is True
    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }



    // Enemy velocity. If moving right will be +1 and left will be -1. The minus will flip it
    // box collider on enemy says when the box collider exits a trigger volume(exits the collision) then trigger localScale flipping for the enemy
    // OnTriggerExit2D works because the small box collider on the enemy goes past the collider against the wall. This makes it seem as if the enemy collider had left bcuz the foreground is a composite collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }

    
}
