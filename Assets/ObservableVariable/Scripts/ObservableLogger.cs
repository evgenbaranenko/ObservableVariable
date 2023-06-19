// реализация паттерна ObservableVariable
// объект который следить и выводит в Log изменения с объектом который изменяется 

using System.Collections.Generic;
using UnityEngine;

namespace ObservableVariable.Scripts
{
    public class ObservableLogger : IObserver
    {
        private List<IObservable> _observables;

        public ObservableLogger()
        {
            _observables = new List<IObservable>();
        }

        public ObservableLogger(IObservable observable)
        {
            // создаем объект
            _observables = new List<IObservable> { observable };
            observable.OnChanged += OnChanged; // сразу подписываемся 
        }

        public ObservableLogger(IObservable[] observables)
        {
            _observables = new List<IObservable>(observables);
            foreach (var observable in _observables)
            {
                observable.OnChanged += OnChanged;
            }
        }

        public void Dispose()
        {
            foreach (var observable in _observables)
            {
                observable.OnChanged -= OnChanged;
            }
        }

        public void AddObservable(IObservable observable)
        {
            if (_observables.Contains(observable)) return; // проверка есть ли такой же объект в листе 
            _observables.Add(observable);
            observable.OnChanged += OnChanged;
        }

        private void OnChanged(object o)
        {
            Debug.Log($"{o.GetType().Namespace} value changed. New Value: {o.ToString()}");
        }
    }
}