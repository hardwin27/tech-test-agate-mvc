using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Agate.MVC.Base;
using Agate.MVC.Core;

namespace ProjectTest.Module.ShooterGame
{
    public interface IShooterGameModel : IBaseModel
    {
        public int Score { get; }
        public int HighScore { get; }
    }
}
