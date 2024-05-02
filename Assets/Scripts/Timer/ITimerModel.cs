using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Agate.MVC.Base;
using Agate.MVC.Core;

namespace ProjectTest.Module.Timer
{
    public interface ITimerModel : IBaseModel
    {
        public float Time { get; }
    }
}
