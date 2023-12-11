using Leopotam.Ecs;
using TestMillionParticles.Container;
using TestMillionParticles.Systems;
using UnityEngine;

namespace TestMillionParticles
{
    public class EcsScene2Startup : MonoBehaviour
    {
        [SerializeField] private GameConfig gameConfig;

        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            _systems
                .Inject(gameConfig)
                .Add(new ParticleGeneratorSystem())
                .Add(new ParticleMoveSystem())
                .Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems == null) return;
            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }
    }
}