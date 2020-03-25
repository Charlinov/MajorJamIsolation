using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonCharacterControl : MonoBehaviour
{
    public float moveSpeed;

    private Vector3 PlayerMovement;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMovement = Vector3.zero;


        PlayerMovement += transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        PlayerMovement += transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        controller.SimpleMove(PlayerMovement);
    }
}