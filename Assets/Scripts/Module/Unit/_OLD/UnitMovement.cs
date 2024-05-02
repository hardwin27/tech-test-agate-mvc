using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTest.Module.ShooterGame.Unit.OLD
{
    public class UnitMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _body;

        private Vector2 _moveInput = Vector2.zero;
        private Vector2 _moveVelocity = Vector2.zero;

        [SerializeField] private float _moveForce;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _minVelocity;
        private float _sqrMoveSpeed;

        private void Start()
        {
            _sqrMoveSpeed = _moveSpeed * _moveSpeed;
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            Vector2 moveDirection = new Vector2(_moveInput.x, _moveInput.y);

            if (_body.velocity.sqrMagnitude < _sqrMoveSpeed)
            {
                _body.AddForce(moveDirection.normalized * _moveForce);
            }

            float xVelocity = _body.velocity.x;
            if (Mathf.Abs(xVelocity) < _minVelocity)
            {
                xVelocity = 0f;
            }

            float yVelocity = _body.velocity.y;
            if (Mathf.Abs(yVelocity) < _minVelocity)
            {
                yVelocity = 0f;
            }

            _moveVelocity = new Vector2(xVelocity, yVelocity);
            _body.velocity = _moveVelocity;
        }

        public void SetMove(Vector2 moveInput)
        {
            _moveInput = moveInput;
        }
    }
}
