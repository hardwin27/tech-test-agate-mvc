using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Agate.MVC.Base;
using Agate.MVC.Core;

namespace ProjectTest.Module.ShooterGame
{
    public class ShooterGameModel : BaseModel, IShooterGameModel
    {
        public int Score { get; private set; }
        public int HighScore { get; private set; }

        public void SetHighScore(int highScore)
        {
            HighScore = highScore;
            SetDataAsDirty();
        }

        public void ResetScore()
        {
            Score = 0;
            SetDataAsDirty();
        }

        public void AddScore(int addedScore)
        {
            Score += addedScore;
            SetDataAsDirty();
        }
    }
}
