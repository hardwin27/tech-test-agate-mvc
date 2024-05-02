using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ProjectTest.Module.ShooterGame.HitSystem;

namespace ProjectTest.Module.ShooterGame.Shooter
{
    public class ShooterController : MonoBehaviour, IHitResponder
    {
        protected GameObject _owner;
        protected string _targetTag;

        [SerializeField] protected float _shooterCooldown;
        protected float _cooldownTimer;
        [SerializeField] protected float _damage;

        [SerializeField] protected GameObject _projectilePrefab;
        [SerializeField] protected Transform _projectilePoint;
        [SerializeField] protected float _projectileForce;
        [SerializeField] protected int _ammoCapacity;
        /*[SerializeField] protected int _reservedAmmo;*/
        protected int _loadedAmmo;
        [SerializeField] protected float _reloadDuration;
        protected bool _isReloading;

        public delegate void WeaponEvent();
        public event WeaponEvent WeaponActed;

        public delegate void WeaponBoolEvent(bool param);
        public event WeaponBoolEvent WeaponReloaded;

        public bool IsOnCooldown
        {
            get
            {
                return (_cooldownTimer > 0f);
            }
        }
        public float Damage => _damage;
        public GameObject Owner { set => _owner = value; get => _owner; }
        public string TargetTag { set => _targetTag = value; get => _targetTag; }

        public int AmmoCapacity { get => _ammoCapacity; }
        /*public int ReservedAmmo { get => _reservedAmmo; }*/
        public int LoadedAmmo { get => _loadedAmmo; }
        public bool HasAmmo { get => (LoadedAmmo > 0); }

        protected bool CanReload { get => /*_reservedAmmo > 0 && */_loadedAmmo < _ammoCapacity; }

        protected bool IsReloading
        {
            set
            {
                _isReloading = value;
                WeaponReloaded?.Invoke(_isReloading);
            }
            get
            {
                return _isReloading;
            }
        }

        protected void OnEnable()
        {
            _cooldownTimer = 0f;
            _isReloading = false;
        }

        protected void Start()
        {
            LoadAmmo();
        }

        protected void Update()
        {
            CooldownHandler();
        }

        protected virtual void StartCooldown()
        {
            _cooldownTimer = _shooterCooldown;
        }

        protected void CooldownHandler()
        {
            if (IsOnCooldown)
            {
                _cooldownTimer -= Time.deltaTime;
            }
        }

        public void StartActionInput()
        {
            if (CanDoAction())
            {
                Action();
                WeaponActed?.Invoke();
            }
        }

        public void EndActionInput()
        {

        }

        protected virtual void Action()
        {
            Shoot();
            StartCooldown();
        }

        protected virtual bool CanDoAction()
        {
            return (!IsOnCooldown) && (HasAmmo) && !IsReloading;
        }

        public bool CheckHit(HitData hitData)
        {
            if (hitData.HurtArea.HurtResponder.Owner.tag == TargetTag)
            {
                return (hitData.HurtArea.HurtResponder.Owner != Owner);
            }

            return false;
        }

        public void Response(HitData hitData)
        {
            
        }

        protected void LoadAmmo()
        {
            int ammoNeeded = _ammoCapacity - _loadedAmmo;
            int ammoToLoad = /*(_reservedAmmo < ammoNeeded) ? _reservedAmmo : */ammoNeeded;
            /*_reservedAmmo -= ammoToLoad;*/
            _loadedAmmo += ammoToLoad;
        }

        public void Reload()
        {
            if (!CanReload)
            {
                return;
            }

            if (IsReloading)
            {
                return;
            }

            StartCoroutine(ReloadHandler());
        }

        protected IEnumerator ReloadHandler()
        {
            IsReloading = true;
            yield return new WaitForSeconds(_reloadDuration);
            LoadAmmo();
            IsReloading = false;
        }

        protected void Shoot()
        {
            Debug.Log($"SHOOT");
            GameObject projectileObject = Instantiate(_projectilePrefab, _projectilePoint.position, _projectilePoint.rotation);
            if (projectileObject.TryGetComponent(out Projectile projectile))
            {
                projectile.HitArea.HitResponder = this;
                projectile.Body.AddForce(_projectileForce * transform.right, ForceMode2D.Impulse);
                Debug.Log($"ADDFORCE {_projectileForce * transform.forward}");
            }

            _loadedAmmo--;
        }
    }
}
