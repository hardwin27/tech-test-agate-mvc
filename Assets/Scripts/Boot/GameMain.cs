using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Agate.MVC.Base;
using Agate.MVC.Core;

using ProjectTest.Module.SaveData;

namespace ProjectTest.Boot
{
    public class GameMain : BaseMain<GameMain>, IMain
    {
        protected override IConnector[] GetConnectors()
        {
            return null;
        }

        protected override IController[] GetDependencies()
        {
            return new IController[]
            {
                new SaveDataController()
            };
        }

        protected override IEnumerator StartInit()
        {
            yield return null;
        }
    }
}
