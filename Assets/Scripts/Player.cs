using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private const float Speed = 10f;
    [SerializeField] const float Gravity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput,0, 0);
        Vector3 velocity = direction * Speed;

        if (_controller.isGrounded)
            Debug.Log("i'm grounded");
        else
            velocity.y -= Gravity;
        
        
        _controller.Move(velocity * Time.deltaTime);
    }
}
