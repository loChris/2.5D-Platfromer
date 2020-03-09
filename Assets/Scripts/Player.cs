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
    private bool _canDoubleJump = false;
    private UIManager _uiManager;
    [SerializeField] private int _coins;
    [SerializeField] private const float Gravity = 1f;
    [SerializeField] private const float JumpHeight = 40f;

    // Start is called before the first frame update
    void Start()
    {
        GetGameComponents();
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
            {
                _yVelocity = JumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_canDoubleJump)
                {
                    _yVelocity += JumpHeight * 1.5f;
                    _canDoubleJump = false;
                }
            }
            _yVelocity -= Gravity;
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }

    private void GetGameComponents()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    public void AddCoins()
    {
        _coins++;
        _uiManager.UpdateCoinDisplay(_coins);
    }
}
