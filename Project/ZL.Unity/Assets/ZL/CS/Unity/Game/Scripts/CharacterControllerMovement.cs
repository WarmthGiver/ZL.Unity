using UnityEngine;

namespace ZL.CS.Unity.Game
{
    [RequireComponent(typeof(GravitationalCharacterController))]

    public sealed class CharacterControllerMovement : Movement
    {
        [Space]

        [SerializeField]

        [UsingCustomProperty]

        [ReadOnly(true)]

        [GetComponent]

        private GravitationalCharacterController characterController;

        private void Update()
        {
            characterController.Move(velocity);
        }
    }
}