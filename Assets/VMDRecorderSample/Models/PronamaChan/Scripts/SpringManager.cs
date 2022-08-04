//
//SpringBone.cs for PronamaChan
//
//Original Script is here:
//ricopin / SpringManager.cs
//Rocket Jump : http://rocketjump.skr.jp/unity3d/109/
//https://twitter.com/ricopin416
//
using UnityEngine;

namespace PronamaChan
{
    public class SpringManager : MonoBehaviour
    {
        public SpringBone[] springBones;

        private void LateUpdate()
        {
            for (int i = 0; i < springBones.Length; i++)
            {
                springBones[i].UpdateSpring();
            }
        }
    }
}