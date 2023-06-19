// наблюдаемый (тот за кем наблюдают)

using System;

namespace ObservableVariable.Scripts
{
    public interface IObservable
    {
         event Action<object> OnChanged;
    }
}