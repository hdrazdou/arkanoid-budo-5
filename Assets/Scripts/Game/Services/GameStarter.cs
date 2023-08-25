using System;
using UnityEngine;

namespace Arkanoid.Game.Services
{
    public class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            GameService.Instance.StartGame();
        }
    }
}