using Leopotam.Ecs;
using TestMillionParticles.Container;
using TestMillionParticles.Systems;
using TestMillionParticles.View;
using UnityEngine;

namespace TestMillionParticles
{
    public class EcsStartup : MonoBehaviour
    {
        [SerializeField] private DistanceView distanceView;
        [SerializeField] private GameConfig gameConfig;
        [SerializeField] private RuntimeObjectContainer objectContainer;

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
                .Inject(distanceView)
                .Inject(objectContainer)
                .Add(new SquareInitSystem())
                .Add(new ArrowInputSystem())
                .Add(new WasdInputSystem())
                .Add(new SquareMoveSystem())
                .Add(new DistanceCalculationSystem())
                .Add(new DistanceDisplaySystem())
                .Add(new SceneModeControllerSystem())
                .Add(new SpheresInitSystem())
                .Add(new ParticleRotationSystem())
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