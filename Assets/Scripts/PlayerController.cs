using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    private Rigidbody _rigidbody;
    private float _moveH = 0.0f;
    private float _moveV = 0.0f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _moveH = Input.GetAxisRaw("Horizontal");
        _moveV = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        SpeedControl(Speed);
    }

    public void SpeedControl(float Speed)
    {
        Vector3 direction = new Vector3(_moveH, 0.0f, _moveV);
        direction = direction.normalized;

        _rigidbody.AddForce(direction * Speed, ForceMode.Force);
    }

}
