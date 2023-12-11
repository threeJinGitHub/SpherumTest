using Leopotam.Ecs;
using TestMillionParticles.Components;
using UnityEngine;

namespace TestMillionParticles.Systems
{
    public abstract class InputSystem : IEcsRunSystem
    {
        protected EcsFilter<InputData> _filter;

        protected abstract bool IsMoveUp();
        protected abstract bool IsMoveDow();
        protected abstract bool IsMoveLeft();
        protected abstract bool IsMoveRight();
        protected abstract bool CheckInput(InputType inputInputType);

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var input = ref _filter.Get1(i);
                var moveInput = Vector3.zero;
                if(!CheckInput(input.InputType)) continue;
                if (IsMoveUp())
                {
                    moveInput += Vector3.forward;
                }

                if (IsMoveDow())
                {
                    moveInput -= Vector3.forward;
                }

                if (IsMoveLeft())
                {
                    moveInput += Vector3.left;
                }

                if (IsMoveRight())
                {
                    moveInput += Vector3.right;
                }

                input.MoveInput = moveInput;
            }
        }
    }    
}