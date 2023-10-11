using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputForwarder : MonoBehaviour//unfortunate hack, next time I won't use an input map
{
        [SerializeField] private PlayerCarManager carManager;

        [UsedImplicitly]
        private void OnAccelerate(InputValue value)
        {
                carManager.ControlledCar?.SendMessage("OnAccelerate",value);
        }

        [UsedImplicitly]
        private void OnBreak(InputValue value)
        {
                carManager.ControlledCar?.SendMessage("OnBreak",value);
        }
        [UsedImplicitly]
        private void OnTurn(InputValue value)
        {
                carManager.ControlledCar?.SendMessage("OnTurn",value);
        }
}