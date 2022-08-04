using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PronamaChan
{
    public class BlendShapeValueChanger : MonoBehaviour
    {
        public SkinnedMeshRenderer SkinnedMeshRenderer;

        //各スライダーの現在値を保持するリスト
        private List<float> _sliderValues;

        //BlendShape名の表示スタイル
        private GUIStyle _labelTitleStyle;

        //スライダー値の表示スタイル
        private GUIStyle _labelValueStyle;

        private void Start()
        {
            //SkinnedMeshRendererの取得
            if (this.SkinnedMeshRenderer == null) this.SkinnedMeshRenderer = this.GetComponentInChildren<SkinnedMeshRenderer>();

            this._sliderValues = Enumerable.Repeat<float>(0f, this.SkinnedMeshRenderer.sharedMesh.blendShapeCount).ToList();

            this._labelTitleStyle = new GUIStyle { fixedWidth = 80f, alignment = TextAnchor.MiddleRight, normal = new GUIStyleState { textColor = Color.white } };
            this._labelValueStyle = new GUIStyle { fixedWidth = 20f, alignment = TextAnchor.MiddleRight, normal = new GUIStyleState { textColor = Color.white } };
        }

        private void OnGUI()
        {
            GUILayout.Box("", GUILayout.Width(220), GUILayout.Height(15 * (this.SkinnedMeshRenderer.sharedMesh.blendShapeCount + 1)));
            Rect screenRect = new Rect(10, 10, 190, 15 * (this.SkinnedMeshRenderer.sharedMesh.blendShapeCount + 1));
            GUILayout.BeginArea(screenRect);
            for (int index = 0; index < this.SkinnedMeshRenderer.sharedMesh.blendShapeCount; index++)
            {
                //BlendShape名
                var name = this.SkinnedMeshRenderer.sharedMesh.GetBlendShapeName(index);

                GUILayout.BeginHorizontal();
                GUILayout.Label(name, this._labelTitleStyle);

                //スライダー
                this._sliderValues[index] = GUILayout.HorizontalSlider(this._sliderValues[index], 0f, 100f);

                //スライダーの値
                GUILayout.Label(((int)this._sliderValues[index]).ToString("#0"), this._labelValueStyle);

                GUILayout.EndHorizontal();

                //スライダーの値をBlendShapeに反映
                this.SkinnedMeshRenderer.SetBlendShapeWeight(index, this._sliderValues[index]);
            }
            GUILayout.EndArea();
        }

        private void Update()
        {
        }
    }
}