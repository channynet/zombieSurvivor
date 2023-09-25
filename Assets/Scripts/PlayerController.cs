using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float speed;
    public float jumpForce;
    public bool grounded;
    public Vector3 boxSize = new Vector3(1f, 0.1f, 1f);
    public LayerMask groundLayer;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 center = transform.position - new Vector3(0f, boxSize.y / 2f, 0f);
        Collider2D[] colliders = Physics2D.OverlapBoxAll(center, boxSize, 0f, groundLayer);
        grounded = colliders.Length > 0;
        Debug.Log(colliders.Length );
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(horizontal * speed, rigidbody.velocity.y); 
        rigidbody.velocity = velocity;
        if (Input.GetKeyDown(KeyCode.Space)&&grounded)
        {
            
            rigidbody.AddForce(jumpForce * transform.up,ForceMode2D.Impulse);
        }
    }
    void OnDrawGizmosSelected()
    {
        // Draw the detection area in the Unity editor for visualization.
        Gizmos.color = Color.green;
        Vector3 center = transform.position - new Vector3(0f, boxSize.y / 2f, 0f);
        Gizmos.DrawWireCube(center, boxSize);
    }
}
