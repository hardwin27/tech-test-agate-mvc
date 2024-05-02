using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTest.Module.ShooterGame.HitSystem
{
    [RequireComponent(typeof(Collider2D))]
    public class HitBox : MonoBehaviour, IHitArea
    {
        [SerializeField] private LayerMask _layerMask;

        private IHitResponder _hitResponder;

        public event IHitArea.HitAreaEvent OnHitted;

        public IHitResponder HitResponder { get { return _hitResponder; } set { _hitResponder = value; } }

        public Transform HitAreaTransform => transform;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IHurtArea hurtArea))
            {
                CheckHit(hurtArea);
            }
        }

        public void CheckHit(IHurtArea hurtArea)
        {
            HitData hitData = null;

            if (hurtArea.Active)
            {
                hitData = new HitData
                {
                    Damage = (HitResponder == null) ? 0f : HitResponder.Damage,
                    HitPoint = hurtArea.HurtCollider.ClosestPoint(transform.position),
                    HurtArea = hurtArea,
                    HitArea = this,
                };

                if (hitData.Validate())
                {
                    hitData.HitArea.HitResponder?.Response(hitData);
                    hitData.HurtArea.HurtResponder?.Response(hitData);
                    OnHitted?.Invoke();
                }
            }
        }
    }
}
