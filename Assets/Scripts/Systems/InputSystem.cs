using Client.Components;
using Client.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class InputSystem:IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world = null;
        private Camera _camera;
        private Configure _config;
        private float _time;
        public void Init()
        {
            _camera = Object.FindObjectOfType<Camera>();
        }

        public void Run()
        {
            _time -= Time.deltaTime;
            RaycastHit hit;
            if (Input.GetMouseButtonDown(0)&& _time<=0)
            {
                _time = _config.ReachargeTime;
                if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    var arrowEnt = _world.NewEntity();
                    arrowEnt.Get<DestroyTime>().TimeOfDestroy = 4;
                    Vector3 direction = (hit.point - _camera.gameObject.transform.position).normalized;
                    Vector3 angle = new Vector3(-70*direction.y, direction.x*70, direction.z);
                    var arrow = GameObject.Instantiate(_config.ArrowPrefab, _camera.gameObject.transform.position,
                       Quaternion.Euler(angle));
                    arrowEnt.Get<ObjectRef>().RefObject = arrow;
                    arrow.GetComponent<Rigidbody>().AddForce(direction*50, ForceMode.Impulse);
                }
            }
        }
    }
}