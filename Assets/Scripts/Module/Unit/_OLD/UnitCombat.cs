using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ProjectTest.Module.ShooterGame.Shooter;

namespace ProjectTest.Module.ShooterGame.Unit.OLD
{
    public class UnitCombat : MonoBehaviour
    {
        [SerializeField] private GameObject _owner;

        [SerializeField] private ShooterController _shooter;
        private bool _canCombat = true;

        [SerializeField] private string _targetTag;

        public delegate void UnitCombatShooterEvent(ShooterController param);
        public event UnitCombatShooterEvent WeaponAssigned;
        public event UnitCombatShooterEvent WeaponUnssigned;

        public bool CanCombat
        {
            get
            {
                _canCombat = _shooter.HasAmmo;

                return _canCombat;
            }
        }

        private void Start()
        {
            AssignWeapon();
        }

        private void AssignWeapon()
        {
            if (_shooter != null)
            {
                _shooter.Owner = _owner;
                _shooter.TargetTag = _targetTag;
                WeaponAssigned?.Invoke(_shooter);
            }
        }

        public void StartInputAction()
        {
            _shooter?.StartActionInput();
        }

        public void EndInputAction()
        {
            _shooter?.EndActionInput();
        }

        public void ReloadInput()
        {
            _shooter?.Reload();
        }
    }
}
