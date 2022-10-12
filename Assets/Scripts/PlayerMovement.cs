using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput, verticalInput;
    CharacterController _characterController;
    Transform _transform;
    [SerializeField] float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = _transform.right * horizontalInput;
        _characterController.Move(direction * speed * Time.deltaTime);
    }
}
