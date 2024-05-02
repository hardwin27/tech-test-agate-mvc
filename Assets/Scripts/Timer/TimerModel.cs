using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Agate.MVC.Base;
using Agate.MVC.Core;

namespace ProjectTest.Module.Timer
{
    public class TimerModel : BaseModel, ITimerModel
    {
        public float Time { get; private set; }
    }
}
