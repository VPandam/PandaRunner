using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    Transform _transform;
    [SerializeField] float speed = 3;
    private void Start()
    {
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {

        _transform.Translate(Vector3.back * speed * Time.deltaTime);


    }
}
