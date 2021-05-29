using System;
using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.UnityComponents
{
    public class EnemyView:MonoBehaviour
    {
        public EcsWorld World=null;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Arrow")) return;
            var hitObject = World.NewEntity();
            hitObject.Get<HitObject>();
            ref var obj1 = ref hitObject.Get<HitObject>().Object1;
            obj1 = gameObject;
        }
    }
}