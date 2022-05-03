using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpBehaviour : PlayerBehaviour
{
    [SerializeField] [Range(0, 5)] private float _distanceToGroundCheck;
    [SerializeField] private float _forceOfJump;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = Player.gameObject.GetComponent<Rigidbody2D>();
    }

    private bool IsGrounded()
    { 
        RaycastHit2D hit = Physics2D.Raycast(Player.transform.position, Vector3.down, _distanceToGroundCheck);
        return hit.collider != null;
    } 

    public void Jump()
    {
        if (IsGrounded())
        {
            _rigidbody.velocity = Vector2.up * _forceOfJump;
        }       
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - _distanceToGroundCheck), Color.magenta);
    }
}
