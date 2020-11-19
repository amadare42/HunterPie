﻿using System;
using HunterPie.Core.Enums;

namespace HunterPie.Core.Jobs
{
    public class SwitchAxeEventArgs : EventArgs
    {
        public float OuterGauge { get; }
        public float SwordChargeTimer { get; }
        public float SwordChargeMaxTimer { get; }
        public float InnerGauge { get; }
        public float SwitchAxeBuffTimer { get; }
        public float SwitchAxeBuffMaxTimer { get; }
        public bool IsBuffActive { get; }

        public SwitchAxeEventArgs(SwitchAxe weapon)
        {
            OuterGauge = weapon.OuterGauge;
            SwordChargeTimer = weapon.SwordChargeTimer;
            SwordChargeMaxTimer = weapon.SwordChargeMaxTimer;
            InnerGauge = weapon.InnerGauge;
            SwitchAxeBuffTimer = weapon.SwitchAxeBuffTimer;
            SwitchAxeBuffMaxTimer = weapon.SwitchAxeBuffMaxTimer;
            IsBuffActive = weapon.IsBuffActive;
        }
    }
    public class SwitchAxe : Job
    {
        private float outerGauge;
        private float swordChargeTimer;
        private float innerGauge;
        private float switchAxeBuffTimer;
        private bool isBuffActive;

        public override int SafijiivaMaxHits => 6;
        public override Classes Type => Classes.SwitchAxe;
        public override bool IsMelee => true;

        public float OuterGauge
        {
            get => outerGauge;
            set
            {
                if (value != outerGauge)
                {
                    outerGauge = value;
                    Dispatch(OnOuterGaugeChange);
                }
            }
        }
        public float SwordChargeTimer
        {
            get => swordChargeTimer;
            set
            {
                if (value != swordChargeTimer)
                {
                    swordChargeTimer = value;
                    Dispatch(OnOuterGaugeChange);
                }
            }
        }
        public float SwordChargeMaxTimer { get; set; }
        public float InnerGauge
        {
            get => innerGauge;
            set
            {
                if (value != innerGauge)
                {
                    innerGauge = value;
                    Dispatch(OnInnerGaugeChange);
                }
            }
        }
        public float SwitchAxeBuffTimer
        {
            get => switchAxeBuffTimer;
            set
            {
                if (value != switchAxeBuffTimer)
                {
                    switchAxeBuffTimer = value;
                    Dispatch(OnSwitchAxeBuffTimerUpdate);
                }
            }
        }
        public float SwitchAxeBuffMaxTimer { get; set; }
        public bool IsBuffActive
        {
            get => isBuffActive;
            set
            {
                if (value != isBuffActive)
                {
                    isBuffActive = value;
                    Dispatch(OnSwitchAxeBuffStateChange);
                }
            }
        }

        public delegate void SwitchAxeEvents(object source, SwitchAxeEventArgs args);
        public event SwitchAxeEvents OnOuterGaugeChange;
        public event SwitchAxeEvents OnInnerGaugeChange;
        public event SwitchAxeEvents OnSwitchAxeBuffTimerUpdate;
        public event SwitchAxeEvents OnSwitchAxeBuffStateChange;

        private void Dispatch(SwitchAxeEvents e) => e?.Invoke(this, new SwitchAxeEventArgs(this));
    }
}
