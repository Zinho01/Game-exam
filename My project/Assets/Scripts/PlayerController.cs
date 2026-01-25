using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    public float speed;
    public float jumpForce;
    private bool canMove; 
    private Rigidbody2D theRB2D;
    
    // variables voor ground checks
    public bool grounded;
    public LayerMask whatIsGrd;
    public Transform grdChecker;
    public float grdCheckRadius;

    // Timer variables
    public float airTime;
    public float airTimeCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        theRB2D = GetComponent<Rigidbody2D>();
        airTime = airTimeCounter;
    }

    // Update is called once per frame
    void Update()
    {
        // dit code, block, zorgt ervoor dat de player naar links en naar rechts kan bewegen
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            canMove = true;
        }
    }

    private void FixedUpdate()
    {
        // Hier definieer ik dat mijn character op de grond is
        grounded = Physics2D.OverlapCircle(grdChecker.position, grdCheckRadius, whatIsGrd);
        
        // Hier roep ik de code functies op. Deze zijn bewegen en springen.
        MovePlayer();
        Jump();
    }
    
    
    void MovePlayer()
    {
        // met dit stukje code kan ik er voor zorgen hoe snel de player kan bewegen in het spel
        if (canMove)
        {
            theRB2D.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, theRB2D.velocity.y);
        }
    }

    void Jump()
    {
        // Hier check ik dat mijn character op de grond staat
        if (grounded == true)
        {
            // zodra er input wordt gegeven kan de player springen 
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                theRB2D.velocity = new Vector2(theRB2D.velocity.x, jumpForce);
            }
        }
        // Tijdens het springen landt de player meteen om de grond.
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (airTimeCounter > 0)
            {
                theRB2D.velocity = new Vector2(theRB2D.velocity.x, jumpForce);
                airTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            airTimeCounter = 0;
        }

        if (grounded)
        {
            airTimeCounter = airTime;
        }

    }
    
}
