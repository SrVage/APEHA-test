using Client.Components;
using Leopotam.Ecs;

namespace Client.Systems
{
    public class KillEnemy:IEcsRunSystem
    {
        private EcsFilter<Health, PhysicsRef> kill;
        public void Run()
        {
            foreach (var i in kill)
            {
                if (kill.Get1(i).HP <= 0)
                {
                    kill.Get2(i).RB.isKinematic = false;
                    kill.GetEntity(i).Del<Movable>();
                    kill.GetEntity(i).Get<DestroyTime>().TimeOfDestroy = 5;
                    kill.GetEntity(i).Del<Health>();
                }
            }
        }
    }
}