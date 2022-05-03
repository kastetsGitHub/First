using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBehaviour : MonoBehaviour
{
    protected Player Player;   
    void Awake()
    {
        Player = FindObjectOfType<Player>();
    }

}
