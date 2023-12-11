using Leopotam.Ecs;
using TestMillionParticles.Components;
using TestMillionParticles.Container;
using UnityEngine.SceneManagement;

namespace TestMillionParticles.Systems
{
    public class SceneModeControllerSystem : IEcsRunSystem
    {
        private EcsFilter<DistanceInfo> _filter1;
        private EcsFilter<Sphere> _filter2;
        private GameConfig _cfg;
        private float? _previousDistance;

        private const float DistanceToDisableSpheres = 2;
        private const float DistanceToChangeScene = 1;

        public void Run()
        {
            if (_filter2.GetEntitiesCount() == 0) return;
            foreach (var i in _filter1)
            {
                var distance = _filter1.Get1(i).Distance;
                if (_previousDistance.HasValue)
                {
                    if (_previousDistance > DistanceToDisableSpheres && distance < DistanceToDisableSpheres)
                    {
                        foreach (var j in _filter2)
                        {
                            _filter2.Get1(j).SphereGo.SetActive(true);
                        }
                    }
                    else if (_previousDistance < DistanceToDisableSpheres && distance > DistanceToDisableSpheres)
                    {
                        foreach (var j in _filter2)
                        {
                            _filter2.Get1(j).SphereGo.SetActive(false);
                        }
                    }
                    else if (distance < DistanceToChangeScene)
                    {
                        SceneManager.LoadScene(_cfg.secondSceneName);
                        break;
                    }
                }

                _previousDistance = distance;
            }
        }
    }
}