using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCar : MonoBehaviour
{
    public List<GameObject> _CarModels;
    private int _PickedCarNumber = 0;


    /// <summary>
    /// Вызывается при изменении модели персонажа
    /// Функция нужна для проверка выхода за граница коллекции и последующей
    /// акцитации выбранной модели
    /// </summary>
    private void ChangeCar()
    {   
        if (_PickedCarNumber < 0)
        {
            _PickedCarNumber = _CarModels.Count - 1;
        }
        else if (_PickedCarNumber > _CarModels.Count - 1)
        {
            _PickedCarNumber = 0;
        }
        _CarModels[_PickedCarNumber].SetActive(true);
    }

    /// <summary>
    /// Функция переходит к следующей модели в коллекции, деактивируя последнюю выбранную
    /// </summary>
    public void NextCar()
    {
        _CarModels[_PickedCarNumber].SetActive(false);
        _PickedCarNumber++;
        ChangeCar();
    }

    /// <summary>
    /// Функция меняет модель на предыдущую в коллекции, деактивируя последнюю выбранную
    /// </summary>
    public void PrevCar()
    {
        _CarModels[_PickedCarNumber].SetActive(false);
        _PickedCarNumber--;
        ChangeCar();
    }
}
