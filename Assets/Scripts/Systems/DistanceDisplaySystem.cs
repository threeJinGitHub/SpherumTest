using Leopotam.Ecs;
using TestMillionParticles.Components;
using TestMillionParticles.View;

namespace TestMillionParticles.Systems
{
    public class DistanceDisplaySystem : IEcsRunSystem
    {
        private DistanceView _distanceView;
        private EcsFilter<DistanceInfo> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var distanceInfo = ref _filter.Get1(i);
                _distanceView.SetDistanceText(distanceInfo.Distance.ToString("F2"));
            }
        }
    }
}