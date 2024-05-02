using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Agate.MVC.Base;
using Agate.MVC.Core;

namespace ProjectTest.Module.SaveData
{
    public class SaveDataController : DataController<SaveDataController, SaveDataModel, ISaveDataModel>
    {
        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            LoadData();
        }

        private void SaveData()
        {
            PlayerPrefs.SetInt("Coin", _model.Coin);
            PlayerPrefs.Save();

            Debug.Log($"SAVEDATACONTROLLER SAVE: {_model.Coin}");
        }

        private void LoadData()
        {
            int coin = PlayerPrefs.GetInt("Coin");
            _model.SetCoinData(coin);

            Debug.Log($"SAVEDATACONTROLLER LOAD: {_model.Coin}");
        }

        public void OnUpdateCoin(int coin)
        {
            _model.SetCoinData(coin);
            Debug.Log($"COIN UPDATED TO {coin}");
            SaveData();
        }
    }
}
