using Client.Components;
using Client.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class MoveSystem:IEcsRunSystem
    {
        private Configure _config;
        private EcsFilter<Movable> enemy;
        public void Run()
        {
            foreach (var i in enemy)
            {
                if ((enemy.Get1(i).CurrentPosition.position - enemy.Get1(i).TargetPosition).magnitude > 0.5f)
                {
                    enemy.Get1(i).CurrentPosition.position = Vector3.MoveTowards(enemy.Get1(i).CurrentPosition.position, enemy.Get1(i).TargetPosition, enemy.Get1(i).Speed);
                    
                }
                else
                {
                    enemy.Get1(i).TargetPosition = _config.TargetPoint[Random.Range(0, _config.TargetPoint.Length)];
                    enemy.Get1(i).Speed = Random.Range(0.01f, 0.1f);
                }
            }
        }
    }
}