using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTest.Module.ShooterGame.HitSystem
{
    public interface IHitResponder
    {
        public float Damage { get; }

        public GameObject Owner { get; }

        public bool CheckHit(HitData hitData);
        public void Response(HitData hitData);
    }
}
