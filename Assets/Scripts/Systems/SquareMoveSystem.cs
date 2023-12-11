using Leopotam.Ecs;
using TestMillionParticles.Components;
using UnityEngine;

namespace TestMillionParticles.Systems
{
    public class SquareMoveSystem : IEcsRunSystem
    {
        private EcsFilter<InputData, Square> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var input = ref _filter.Get1(i);
                ref var square = ref _filter.Get2(i);

                square.SquareTransform.position += input.MoveInput * Time.deltaTime * square.Speed;
            }
        }
    }
}