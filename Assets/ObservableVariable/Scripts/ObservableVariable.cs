// наблюдаемая переменная 
// класс который принимает любые переменные

using System;

namespace ObservableVariable.Scripts
{
    public class ObservableVariable<T> : IObservable
    {
        public event Action<object> OnChanged;

        private T _value;

        public T Value
        {
            get => _value;

            set // когда мы меняем значение value срабатывает OnCnanged
            {
                _value = value;
                OnChanged?.Invoke(value);
            }
        }

        // default - Значение по умолчанию
        // Значение по умолчанию зависит от типа T.
        // Например, для числовых типов данных значение по умолчанию будет 0,
        // для ссылочных типов данных (классов) значение по умолчанию будет null,
        // а для булевого типа данных значение по умолчанию будет false.

        public ObservableVariable()
        {
            Value = default;
        }

        public ObservableVariable(T defaultValue)
        {
            Value = defaultValue;
        }

        // будет преобразовывать значение свойства T _value
        
        public override string ToString() => Value.ToString();
    }
}