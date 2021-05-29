using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class DestroyObject:IEcsRunSystem
    {
        private EcsFilter<DestroyTime, ObjectRef> time;
        public void Run()
        {
            foreach (var i in time)
            {
                time.Get1(i).TimeOfDestroy -= Time.deltaTime;
                if (time.Get1(i).TimeOfDestroy <= 0)
                {
                    GameObject.Destroy(time.Get2(i).RefObject);
                    time.GetEntity(i).Destroy();
                }
            }
        }
    }
}