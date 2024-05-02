using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ProjectTest.Module.ShooterGame.Unit.OLD;

namespace ProjectTest.Module.ShooterGame.Player
{
    public class PlayerUnitInput : MonoBehaviour
    {
        [SerializeField] private UnitController _unitController;

        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            _unitController.Move(new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            ));

            _unitController.LookTo(_mainCamera.ScreenToWorldPoint(Input.mousePosition));

            if (Input.GetKeyDown(KeyCode.R))
            {
                _unitController.ReloadInput();
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                _unitController.StartInputAction();
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _unitController.EndInputAction();
            }
        }
    }
}
