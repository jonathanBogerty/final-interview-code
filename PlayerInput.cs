using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;

    [HideInInspector] public PlayerControls Attack;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Attack = new PlayerControls();
    }
    
    private void OnEnable()
    {
        Attack.Enable();
    }

    private void OnDisable()
    {
        Attack.Disable();
    }
}
