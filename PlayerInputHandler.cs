using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public GameObject Player;
    PlayerMovement PlayerMovement;

    private void Awake()
    {
        if (Player != null)
            PlayerMovement = Player.GetComponent<PlayerMovement>();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        //PlayerMovment.OnMove(context);      
    }
}
