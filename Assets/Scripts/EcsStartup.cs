using Client.Components;
using Client.Services;
using Client.Systems;
using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class EcsStartup : MonoBehaviour
    {
        [SerializeField] private Configure config;
        EcsWorld _world;
        EcsSystems _systems;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            Screen.orientation = ScreenOrientation.Landscape;
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                .Add (new InputSystem())
                .Add (new DestroyObject())
                .Add(new EnemySpawn())
                .Add(new MoveSystem())
                .Add(new HitEnemy())
                .Add(new KillEnemy())
                
                .OneFrame<HitObject>()
                
                .Inject (config)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}