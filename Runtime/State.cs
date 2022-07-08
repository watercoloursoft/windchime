using System.Collections.Generic;

namespace Windchime.Runtime
{
    public class State<T>
    {
        private T _value;
        private readonly HashSet<Binding.Composite> _subscribed;

        public State(T defaultValue)
        {
            _value = defaultValue;
            _subscribed = new HashSet<Binding.Composite>();
        }

        public T Get()
        {
            var current = Binding.GetCurrentObserver();
            if (current.hasObserver) _subscribed.Add(current.observer);
            return _value;
        }
        
        public void Set(in T newValue)
        {
            _value = newValue;
            foreach (var observer in _subscribed)
            {
                observer();
            }
        }
        
        public void Update(Binding.UpdateValue<T> updater)
        {
            Set(updater(Get())); 
        }
    }
}