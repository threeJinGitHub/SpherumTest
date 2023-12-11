using TestMillionParticles.Components;
using UnityEngine;

namespace TestMillionParticles.Systems
{
    public class WasdInputSystem : InputSystem
    {
        protected override bool IsMoveUp() => Input.GetKey(KeyCode.W);
        protected override bool IsMoveDow() => Input.GetKey(KeyCode.S);
        protected override bool IsMoveLeft() => Input.GetKey(KeyCode.A);
        protected override bool IsMoveRight() => Input.GetKey(KeyCode.D);
        protected override bool CheckInput(InputType inputInputType) => inputInputType == InputType.WASD;
    }
}