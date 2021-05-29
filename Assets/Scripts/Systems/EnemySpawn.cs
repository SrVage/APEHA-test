using Client.Components;
using Client.Services;
using Client.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class EnemySpawn: IEcsRunSystem, IEcsInitSystem
    {
        private Configure _config;
        private EcsWorld _world = null;
        private float _waitTime;

        public void Run()
        {
            _waitTime -= Time.deltaTime;
            if (_waitTime <= 0)
            {
                _waitTime = Random.Range(6, 10);
                Spawn();
            }
        }

        private void Spawn()
        {
            var enemy = _world.NewEntity();
            enemy.Get<Movable>().TargetPosition = _config.TargetPoint[Random.Range(0, _config.TargetPoint.Length)];
            enemy.Get<Movable>().Speed = Random.Range(0.01f, 0.1f);
            enemy.Get<Health>().HP = 100;
            ref var physics = ref enemy.Get<PhysicsRef>().RB;
            ref var color = ref enemy.Get<Health>().MeshRenderer;
            ref var currentPosition = ref enemy.Get<Movable>().CurrentPosition;
            var enemyObject = GameObject.Instantiate(_config.EnemyPrefab,
                new Vector3(Random.Range(-5, 5), Random.Range(1, 5), Random.Range(2, 8)), Quaternion.identity);
            enemy.Get<Movable>().CurrentPosition=enemyObject.transform;
            currentPosition = enemyObject.transform;
            color = enemyObject.GetComponent<MeshRenderer>();
            enemy.Get<ObjectRef>().RefObject = enemyObject;
            enemyObject.GetComponent<EnemyView>().World = _world;
            physics = enemyObject.GetComponent<Rigidbody>();
        }

        public void Init()
        {
            _waitTime = Random.Range(3, 6);
        }
    }
}