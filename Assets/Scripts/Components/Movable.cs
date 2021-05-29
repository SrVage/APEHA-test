using UnityEngine;

namespace Client.Components
{
    public struct Movable
    {
        public Transform CurrentPosition;
        public Vector3 TargetPosition;
        public float Speed;
    }
}