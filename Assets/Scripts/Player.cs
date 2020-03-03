using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private float _yVelocity;
    private const float Speed = 10f;
    [SerializeField] private const float Gravity = 1f;
    [SerializeField] private const float JumpHeight = 50f;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * Speed;

        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _yVelocity = JumpHeight;
        }
        else
            _yVelocity -= Gravity;

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }
}
