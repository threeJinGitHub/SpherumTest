using System.Collections.Generic;
using Leopotam.Ecs;
using TestMillionParticles.Components;
using TestMillionParticles.View;
using UnityEngine;

namespace TestMillionParticles.Container
{
    public class ParticleGeneratorSystem : IEcsInitSystem
    {
        private GameConfig _cfg;
        private EcsWorld _world;
    
        public void Init()
        {
            for (int i = 0; i < _cfg.psCount; i++)
            {
                var entity = _world.NewEntity();
                ref var psModeData = ref entity.Get<ParticleMoveData>();
                psModeData.PsTransform = Object.Instantiate(_cfg.ps2Prefab, Random.insideUnitSphere, Quaternion.identity);
                psModeData.PreviousDirection = Random.insideUnitSphere.normalized;
            }
        }
    }

    [CreateAssetMenu]
    public class GameConfig : ScriptableObject
    {
        [Header("FirstScene")]
        public List<SquareInitData> squares;
        public string secondSceneName;
    
        [Header("SecondScene")]
        public Transform ps2Prefab;
        public int psCount;
        public float psShellRadius;
    }    
}
