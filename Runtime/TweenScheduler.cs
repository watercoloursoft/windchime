using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Windchime.Runtime
{
    public class TweenScheduler: MonoBehaviour
    {
        private static readonly HashSet<ITween> AllTweens = new();
        
        public static void Add(ITween t)
        {
            AllTweens.Add(t);
        }

        public static void Remove(ITween t)
        {
            AllTweens.Remove(t);
        }
        
        private void Update()
        {
            foreach (var tween in AllTweens.ToArray())
            {
                tween.Update();
            }
        }
    }
}