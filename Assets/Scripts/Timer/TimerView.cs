using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

using Agate.MVC.Base;
using Agate.MVC.Core;

namespace ProjectTest.Module.Timer
{
    public class TimerView : ObjectView<ITimerModel>
    {
        [SerializeField] private TMP_Text _timeText;
        [SerializeField] private Button _toggleTimeButton;
        [SerializeField] private Button _resetTimeButton;

        protected override void InitRenderModel(ITimerModel model)
        {
            UpdateTimeText(model.Time);
        }

        protected override void UpdateRenderModel(ITimerModel model)
        {
            UpdateTimeText(model.Time);
        }

        private void UpdateTimeText(float timeValue)
        {
            _timeText.text = TimeSpan.FromSeconds(timeValue).ToString("mm:ss");
        }

        public void SetCallback(UnityAction onClickToggleTime, UnityAction onClickResetTime)
        {
            _toggleTimeButton.onClick.RemoveAllListeners();
            _resetTimeButton.onClick.RemoveAllListeners();

            _toggleTimeButton.onClick.AddListener(onClickToggleTime);
            _resetTimeButton.onClick.AddListener(onClickResetTime);
        }
    }
}
