using Leopotam.Ecs;
using TestMillionParticles.Components;
using UnityEngine;

namespace TestMillionParticles.Systems
{
    public class DistanceCalculationSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<DistanceInfo> _filter1;
        private EcsFilter<Square> _filter2;
        private EcsWorld _world;

        public void Run()
        {
            var entitiesCount = _filter2.GetEntitiesCount();
            var distance = 0f;
            if (entitiesCount > 1)
            {
                distance = Vector3.Distance(_filter2.GetEntity(0).Get<Square>().SquareTransform.position,
                    _filter2.GetEntity(1).Get<Square>().SquareTransform.position);
            }

            foreach (var i in _filter1)
            {
                ref var distanceInfo = ref _filter1.Get1(i);
                distanceInfo.Distance = distance;
            }
        }

        public void Init()
        {
            var distanceViewEntity = _world.NewEntity();
            distanceViewEntity.Get<DistanceInfo>();
        }
    }
}