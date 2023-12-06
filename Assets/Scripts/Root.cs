using System.Collections.Generic;
using UnityEngine;

public sealed class Root : MonoBehaviour
{
        private List<CustomButton> _buttons;

        private void Awake()
        {
                _buttons = new List<CustomButton>(FindObjectsOfType<CustomButton>(true));
                var particleController = new ParticleSystemMediator();
                for (int i = 0; i < _buttons.Count; i++)
                {
                        _buttons[i].Initialize(particleController);
                }
        }
}