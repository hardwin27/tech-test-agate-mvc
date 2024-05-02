using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Agate.MVC.Base;
using Agate.MVC.Core;

namespace ProjectTest.Module.ClickGame
{
    public interface IClickGameModel : IBaseModel
    {
        /*public event OnDataModified OnDataModified;*/
        public int Coin { get; }
    }
}
