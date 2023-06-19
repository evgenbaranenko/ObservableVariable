// класс для примера, что бы показать реализацию в UNITY

using UnityEngine;
using Random = UnityEngine.Random;

namespace ObservableVariable.Scripts
{
    public class ObservableExample : MonoBehaviour
    {
        private ObservableVariable<int> _observableVariableInt;
        private ObservableVariable<float> _observableVariableFloat;
        private ObservableVariable<bool> _observableVariableBool;
        private ObservableLogger _logger;

        private void Start()
        {
            // Тут идет инициализация объектов
            // В данном случае для примера

            _observableVariableInt = new ObservableVariable<int>(10);
            _observableVariableFloat = new ObservableVariable<float>(0.5f);
            _observableVariableBool = new ObservableVariable<bool>(false);

            _logger = new ObservableLogger(_observableVariableInt);
            _logger = new ObservableLogger(_observableVariableBool);
            _logger = new ObservableLogger(_observableVariableFloat);
        }

        private void Update()
        {
            // реализация ввода  с клавиатуры
            // В данном случае для примера

            if (Input.GetKeyDown(KeyCode.Space)) RandomizeInt();
            if (Input.GetKeyDown(KeyCode.E)) RandomizeFloat();
            if (Input.GetKeyDown(KeyCode.Q)) InvertBool();
        }

        private void RandomizeInt()
        {
            var rInt = Random.Range(0, 100);
            _observableVariableInt.Value = rInt;
        }

        private void RandomizeFloat()
        {
            var rInt = Random.Range(0.99f, 9.99f);
            _observableVariableFloat.Value = rInt;
        }

        private void InvertBool() => _observableVariableBool.Value = !_observableVariableBool.Value;
    }
}