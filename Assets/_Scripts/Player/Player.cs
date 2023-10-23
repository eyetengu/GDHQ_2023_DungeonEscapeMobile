using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private bool _grounded;
    [SerializeField] private float _jumpForce = 5.0f;
    private bool _resetJump = false;
    [SerializeField] private float _speed = 3.5f;
    private PlayerAnimation _playerAnim;
    private SpriteRenderer _playerSpriteRenderer;
    private SpriteRenderer _swordAttackRenderer;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();  
        _animator = GetComponentInChildren<Animator>();
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _swordAttackRenderer= transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement();

        if(Input.GetMouseButtonDown(0) && _grounded) 
        {
            _playerAnim.Attack();
        }
        //IsGrounded();
    }

    private void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _grounded = IsGrounded();

        Flip(move);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            Debug.Log("Jumping");
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
            _playerAnim.Jump(true);
        }

        _rb.velocity = new Vector2(move * _speed, _rb.velocity.y);
        if (_playerAnim == null)
            Debug.Log("Animator null");
        else
            _playerAnim.Move(move);    
    }

    private bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.7f, 1 << 8);        

        if (hitInfo.collider !=null)
        {
            //Debug.Log("IS GROUNDED");
            if (_resetJump == false)
            {
                _playerAnim.Jump(false);
                return true;
            }
        }
        //Debug.Log("Is NOT Grounded");
        return false;
    }  

    void Flip(float move) 
    {
          
        if (move < 0)
        {
            _playerSpriteRenderer.flipX = true;
            _swordAttackRenderer.flipY = true;
            _swordAttackRenderer.flipX = true;

            Vector3 newPos = _swordAttackRenderer.transform.localPosition;
            newPos.x = -1.01f;
            _swordAttackRenderer.transform.localPosition = newPos;
        }

        else if (move > 0)
        {
            _playerSpriteRenderer.flipX = false;
            _swordAttackRenderer.flipY = false;
            _swordAttackRenderer.flipX = false;

            Vector3 newPos = _swordAttackRenderer.transform.localPosition;
            newPos.x = 1.01f;
            _swordAttackRenderer.transform.localPosition = newPos;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -.85f, 0));
    }
    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump= false;
    }
}
