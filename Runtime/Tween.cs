using UnityEngine;

namespace Windchime.Runtime
{
    public interface ITween
    {
        
        public void Update(float deltaTime);
        public bool IsDone();
    }
    
    public struct Tween<T> : ITween
    {
        public delegate T Getter();
        public delegate void Setter(T value);
        
        private TweenInfo _tweenInfo;

        private T _goal;
        private T _startValue;
        private  Setter _setter;
        
        private float _tweenDuration;
        private float _tweenElapsed;
        private bool _animating;

        public void Play(Getter getter, Setter setter, T goal, TweenInfo tweenInfo)
        {
            if (_animating)
                return;
            _tweenInfo = tweenInfo;

            _goal = goal;
            _startValue = getter();
            _setter = setter;

            var tweenDuration = _tweenInfo.CycleDuration;
            tweenDuration *= _tweenInfo.RepeatCount + 1;
            _tweenDuration = tweenDuration;
            
            _tweenElapsed = 0;
            _animating = true;
        }

        public bool IsDone()
        {
            return !_animating;
        }

        public void Update(float deltaTime)
        {
            var elapsedTime = _tweenElapsed += deltaTime;
            if (elapsedTime > _tweenDuration)
            {
                _setter(_goal);
                _animating = false;
            }
            else
            {
                var ratio = (float)_tweenInfo.GetTweenRatio(elapsedTime);
                var currentValue = Lerp.LerpType(_startValue, _goal, ratio);
                _setter(currentValue);
                _animating = true;
            }
        }
    }
}