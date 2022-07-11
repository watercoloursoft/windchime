using System;
using UnityEngine;

namespace Windchime.Runtime
{
    public interface ITween
    {
        public void Update();
    }
    
    public struct Tween<T> : ITween where T : IEquatable<T>
    {
        public delegate T Getter();
        public delegate void Setter(T value);
        
        private readonly TweenInfo _tweenInfo;

        private readonly T _goal;
        private readonly T _startValue;
        private T _currentValue;
        private readonly Setter _setter;
        
        private readonly float _tweenDuration;
        private readonly float _tweenStartTIme;
        private bool _animating;

        public Tween(Getter getter, Setter setter, T goal, TweenInfo tweenInfo)
        {
            _tweenInfo = tweenInfo;

            _goal = goal;
            _startValue = getter();
            _currentValue = _startValue;
            _setter = setter;

            var tweenDuration = _tweenInfo.CycleDuration;
            tweenDuration *= _tweenInfo.RepeatCount + 1;
            _tweenDuration = tweenDuration;
            
            _tweenStartTIme = Time.realtimeSinceStartup;
            _animating = true;
            
            TweenScheduler.Add(this);
        }

        public void Update()
        {
            var elapsedTime = Time.realtimeSinceStartup - _tweenStartTIme;
            if (elapsedTime > _tweenDuration)
            {
                _currentValue = _goal;
                _animating = false;
                TweenScheduler.Remove(this);
            }
            else
            {
                var ratio = (float)_tweenInfo.GetTweenRatio(elapsedTime);
                var currentValue = Lerp.LerpType(_startValue, _goal, ratio);
                _currentValue = currentValue;
                _animating = true;
            }

            _setter(_currentValue);
        }
    }
}