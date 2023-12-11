using Leopotam.Ecs;
using TestMillionParticles.Components;
using TestMillionParticles.Container;

namespace TestMillionParticles.Systems
{
    public class SpheresInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private RuntimeObjectContainer _objectContainer;

        public void Init()
        {
            foreach (var sphereGo in _objectContainer.Spheres)
            {
                var sphereDataEntity = _world.NewEntity();
                ref var spheres = ref sphereDataEntity.Get<Sphere>();
                spheres.SphereGo = sphereGo;    
            }
            
        }
    }
}