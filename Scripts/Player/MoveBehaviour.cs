using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : PlayerBehaviour
{
    [SerializeField] [Range(0, 100f)] float _speed;

    public void MoveForward() => Player.transform.position += _speed * Time.deltaTime * transform.right;

    public void MoveBackward() => Player.transform.position += _speed * Time.deltaTime * -transform.right;
}
