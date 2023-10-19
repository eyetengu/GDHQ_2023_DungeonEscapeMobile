using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;    
    [SerializeField] private float _jumpForce = 5.0f;
    private bool _resetJump = false;    

    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();        
    }

    void Update()
    {
        Movement();
        IsGrounded();
    }

    private void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(move, _rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            Debug.Log("Jumping");
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.7f, 1 << 8);
        Debug.Log("Colliding with: " + hitInfo.collider.name);

        if (hitInfo.collider !=null)
        {
            Debug.Log("Colliding with: " + hitInfo.collider.name);
            if(_resetJump == false)
                return true;    
        }
        return false;
    }  

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump= false;
    }
}
