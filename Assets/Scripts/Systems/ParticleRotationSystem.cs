using Leopotam.Ecs;
using TestMillionParticles.Components;

namespace TestMillionParticles.Systems
{
    public class ParticleRotationSystem : IEcsRunSystem
    {
        private EcsFilter<Square> _filter;
        
        public void Run()
        {
            if (_filter.GetEntitiesCount() == 2)
            {
                var square1 = _filter.Get1(0);
                var square2 = _filter.Get1(1);
                square1.SquareRayPs.LookAt(square2.SquareTransform);
                square2.SquareRayPs.LookAt(square1.SquareTransform);
            }
        }
    }
}