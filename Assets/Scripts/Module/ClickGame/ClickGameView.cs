using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

using Agate.MVC.Base;
using Agate.MVC.Core;

namespace ProjectTest.Module.ClickGame
{
    public class ClickGameView : ObjectView<IClickGameModel>
    {
        [SerializeField] private TMP_Text _coinText;
        [SerializeField] private Button _earnButtonCoinButton;
        [SerializeField] private Button _spendCoinButton;
        [SerializeField] private Button _backButton;

        protected override void InitRenderModel(IClickGameModel model)
        {
            _coinText.text = $"Coin: {model.Coin}";
        }

        protected override void UpdateRenderModel(IClickGameModel model)
        {
            _coinText.text = $"Coin: {model.Coin}";
        }

        public void SetCallbacks(UnityAction onClickEarnCoin, UnityAction onClickSpendCoin, UnityAction onClickBack)
        {
            _earnButtonCoinButton.onClick.RemoveAllListeners();
            _spendCoinButton.onClick.RemoveAllListeners();
            _backButton.onClick.RemoveAllListeners();

            _earnButtonCoinButton.onClick.AddListener(onClickEarnCoin);
            _spendCoinButton.onClick.AddListener(onClickSpendCoin);
            _backButton.onClick.AddListener(onClickBack);
        }
    }
}
