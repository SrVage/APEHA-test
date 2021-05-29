using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class HitEnemy:IEcsRunSystem
    {
        private EcsFilter<HitObject> obj;
        private EcsFilter<Movable, Health> enemy;
        public void Run()
        {
            foreach (var i in obj)
            {
                foreach (var j in enemy)
                {
                    if (obj.Get1(i).Object1 == enemy.Get1(j).CurrentPosition.gameObject)
                    {
                        enemy.Get2(j).HP -= Random.Range(20, 50);
                        enemy.Get2(j).MeshRenderer.material.color = Color.Lerp(enemy.Get2(j).MeshRenderer.material.color, Color.red, 1-enemy.Get2(j).HP/100);
                    }
                }
                
                
               
            }
        }
    }
}