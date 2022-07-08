using System.Collections.Generic;
using UnityEngine;

namespace Windchime.Runtime
{
    public class Binding
    {
        public delegate void Composite();
        public static readonly Stack<Composite> Context = new();

        public delegate T GetValue<out T>();
        public delegate void SetValue<T>(in T newValue);
        public delegate T UpdateValue<T>(T newValue);
        public delegate void UpdateValueBox<T>(UpdateValue<T> updater);

        public static (bool hasObserver, Composite observer) GetCurrentObserver()
        {
            var has = Context.TryPeek(out var obs);
            return (has, obs);
        }

        public static void UseComposite(Composite fn)
        {
            Context.Push(fn);
            try
            {
                fn();
            }
            finally
            {
                Context.Pop();
            }
        }
    }
    
    public abstract class ReactiveBehaviour : MonoBehaviour
    {
        public virtual void Start()
        {
            Binding.UseComposite(Reactive);
        }

        protected abstract void Reactive();
    }
}