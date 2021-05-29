using UnityEngine;

namespace Client.Services
{
    [CreateAssetMenu]
    public class Configure:ScriptableObject
    {
        public GameObject ArrowPrefab;
        public GameObject EnemyPrefab;
        public float ReachargeTime;
        public Vector3[] TargetPoint;
    }
}