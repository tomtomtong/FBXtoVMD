//
//SpringBone.cs for PronamaChan
//
//Original Script is here:
//ricopin / SpringCollider.cs
//Rocket Jump : http://rocketjump.skr.jp/unity3d/109/
//https://twitter.com/ricopin416
//
using UnityEngine;

namespace PronamaChan
{
    public class SpringCollider : MonoBehaviour
    {
        //半径
        public float radius = 0.5f;

        //半径の倍率
        public float radiusVolume = 1f;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, radius * radiusVolume);
        }
    }
}