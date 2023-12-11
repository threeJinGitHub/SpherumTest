using TestMillionParticles.Components;
using UnityEngine;

namespace TestMillionParticles.Systems
{
    public class ArrowInputSystem : InputSystem
    {
        protected override bool IsMoveUp() => Input.GetKey(KeyCode.UpArrow);
        protected override bool IsMoveDow() => Input.GetKey(KeyCode.DownArrow);
        protected override bool IsMoveLeft() => Input.GetKey(KeyCode.LeftArrow);
        protected override bool IsMoveRight() => Input.GetKey(KeyCode.RightArrow);
        protected override bool CheckInput(InputType inputInputType) => inputInputType == InputType.Arrow;
    }
}