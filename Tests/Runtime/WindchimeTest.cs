using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Windchime.Runtime;

namespace Windchime.Tests.Runtime
{
    public class WindchimeTest : ReactiveBehaviour
    {
        private readonly State<int> _amount = new(0);
        private float _elapsed = 0;

        private new void Start()
        {
            base.Start();
        }

        private void Update()
        {
            _elapsed += Time.deltaTime;
            if (!(_elapsed > 1)) return;
            _amount.Update(x => x + 1);
            _elapsed--;
        }

        protected override void Reactive()
        {
            Debug.Log("Elapsed: " + _amount.Get() + "s");
        }
    }
}