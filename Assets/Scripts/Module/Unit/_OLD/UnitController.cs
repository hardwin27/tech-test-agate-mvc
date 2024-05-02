using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTest.Module.ShooterGame.Unit.OLD
{
    public class UnitController : MonoBehaviour
    {
        [SerializeField] private UnitMovement _unitMovement;
        [SerializeField] private UnitVisual _unitVisual;
        [SerializeField] private UnitCombat _unitCombat;

        public void Move(Vector2 moveDirection)
        {
            _unitMovement.SetMove(moveDirection);
        }

        public void LookTo(Vector3 posToLook)
        {
            _unitVisual.LookTo(posToLook);
        }

        public void StartInputAction()
        {
            _unitCombat.StartInputAction();
        }

        public void EndInputAction()
        {
            _unitCombat.StartInputAction();
        }

        public void ReloadInput()
        {
            _unitCombat.ReloadInput();
        }
    }
}
