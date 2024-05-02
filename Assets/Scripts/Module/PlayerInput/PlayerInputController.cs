using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

using Agate.MVC.Base;
using Agate.MVC.Core;

namespace ProjectTest.Module.PlayerInput
{
    public class PlayerInputController : BaseController<PlayerInputController>
    {
        public override IEnumerator Finalize()
        {
            return base.Finalize();
            
        }

        private IEnumerator TIck()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log($"SPACE ENTERED");
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
