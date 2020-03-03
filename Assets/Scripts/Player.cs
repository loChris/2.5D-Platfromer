using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private float _speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        //define direction based on that input
        Vector3 direction = new Vector3(horizontalInput,0, 0);

        //move based that direction
        transform.Translate(direction * (_speed * Time.deltaTime));
    }
}
