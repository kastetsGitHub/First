using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private MoveBehaviour _moveBehaviour;
    [SerializeField] private JumpBehaviour _jumpBehaviour;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _moveBehaviour.MoveForward();
        }

        else if (Input.GetKey(KeyCode.A))
        {
            _moveBehaviour.MoveBackward();
        }

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            _jumpBehaviour.Jump();
        }
    }
}
