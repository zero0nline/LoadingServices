using Model;
using UniRx;
using UnityEngine;
using Zenject;

public class Main : MonoBehaviour
{
    [Inject] private User _user;
    [Inject] private GameConfig _gameConfig;

    private void Start()
    {
        _user.Load().Subscribe(OnUserLoad);
        _gameConfig.Load().Subscribe(OnGameConfigsLoad);
    }

    private void OnUserLoad(bool result)
    {
        if (result)
        {
            var userData = _user.Model;
        }
        else
        {
        }
    }

    private void OnGameConfigsLoad(bool result)
    {
        if (result)
        {
            var gameData = _gameConfig.Model;
        }
    }
}