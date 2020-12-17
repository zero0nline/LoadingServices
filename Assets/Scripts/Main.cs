using UI.Presenters;
using UnityEngine;
using Zenject;

public class Main : MonoBehaviour
{
    [Inject] private UserPresenter _userPresenter;
    [Inject] private GameConfigPresenter _gameConfigPresenter;

    private void Start()
    {
        _userPresenter.Show();
        _gameConfigPresenter.Show();
    }
}