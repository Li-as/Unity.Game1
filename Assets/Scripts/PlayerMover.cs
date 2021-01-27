using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private bool _isInAir;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = new Vector2(_speed, 0);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isInAir == false)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
            _isInAir = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            _isInAir = false;
        }
    }
}
