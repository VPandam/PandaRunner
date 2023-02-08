using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 horizontalInput, verticalInput;
    CharacterController _characterController;
    Transform _transform;
    [SerializeField] float speed = 10;

    private Camera cam;
    private float halfScreen;

    private bool falling;
    
    void Start()
    {
        _transform = GetComponent<Transform>();
        _characterController = GetComponent<CharacterController>();
        cam = Camera.main;
        halfScreen = Screen.width / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(falling) return;
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            horizontalInput = (touch.position.x < halfScreen) ? Vector2.left : Vector2.right;
            Vector3 direction = horizontalInput;
            _characterController.Move(direction * speed * Time.deltaTime);
        }
        
    }

    public IEnumerator MoveOnFall()
    {
        falling = true;
        float counter = 0;
        while (counter < .5)
        {
            _characterController.Move(Vector3.down * Time.deltaTime * speed);
            counter += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(.2f);
        falling = false;
    }
}
