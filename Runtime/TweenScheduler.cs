using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

namespace Windchime.Runtime
{
    public class TweenScheduler: MonoBehaviour
    {
        private static ObjectPool<ITween> _tweenPool;
        private static HashSet<ITween> _activeTweens;

        private void Start()
        {
            _tweenPool = new ObjectPool<ITween>(() => new Tween<object>(), null, null, null, false);
            _activeTweens = new HashSet<ITween>();
        }

        public static Tween<T> Play<T>(Tween<T>.Getter getter, Tween<T>.Setter setter, T goal, TweenInfo tweenInfo)
        {
            var tween = _tweenPool.Get() is Tween<T> ? (Tween<T>) _tweenPool.Get() : default;
            tween.Play(getter, setter, goal, tweenInfo);
            _activeTweens.Add(tween);
            return tween;
        }
        
        public static Tween<Color> PlayAlpha(Tween<Color>.Getter getter, Tween<Color>.Setter setter, float goal, TweenInfo tweenInfo)
        {
            var tween = _tweenPool.Get() is Tween<Color> ? (Tween<Color>) _tweenPool.Get() : default;
            tween.Play(getter, setter, new Color(0, 0, 0, goal), tweenInfo);
            _activeTweens.Add(tween);
            return tween;
        }

        private void Update()
        {
            foreach (var tween in _activeTweens.ToArray())
            {
                tween.Update(Time.deltaTime);
                if (!tween.IsDone()) continue;
                _activeTweens.Remove(tween);
                _tweenPool.Release(tween);
            }
        }
    }
}