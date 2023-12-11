using Leopotam.Ecs;
using TestMillionParticles.Components;
using TestMillionParticles.Container;
using TestMillionParticles.View;
using UnityEngine;

namespace TestMillionParticles.Systems
{
    public class SquareInitSystem : IEcsInitSystem
    {
        private GameConfig _cfg;
        private EcsWorld _world;
        private RuntimeObjectContainer _objectContainer;

        public void Init()
        {
            _cfg.squares.ForEach(InitSquare);

            void InitSquare(SquareInitData squarePrefab)
            {
                var squareEntity = _world.NewEntity();
                ref var input = ref squareEntity.Get<InputData>();
                ref var square = ref squareEntity.Get<Square>();
                var squareGo = Object.Instantiate(squarePrefab.transform, squarePrefab.Position, Quaternion.identity,
                    _objectContainer.CubesHolder);
                square.SquareTransform = squareGo;
                square.SquareRayPs = squareGo.GetChild(0); 
                square.Speed = squarePrefab.Speed;
                input.InputType = squarePrefab.InputType;
            }
        }
    }
}