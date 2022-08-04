using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PronamaChan
{
    public class EquipmentsChanger : MonoBehaviour
    {
        public Material TransparentMaterial;
        public SkinnedMeshRenderer SkinnedMesh;

        public bool ShowSpats = false;
        public bool ShowSocks = true;
        public bool ShowShoes = true;

        [TooltipAttribute("太もも\nすね\nつま先\n靴下すね\n靴下つま先\nパンツ\nスパッツ\n靴\nの順でMaterialのIndexをセット")]
        public int[] MaterialIndexes = new[] { 2, 3, 0, 6, 5, 21, 4, 7 };
        private Dictionary<MaterialIndexesKey, Material> _materialsDic;

        private enum MaterialIndexesKey
        {
            /// <summary>太もも</summary>
            Thigh,

            /// <summary>すね</summary>
            Shin,

            /// <summary>つま先</summary>
            Toe,

            /// <summary>靴下すね</summary>
            SocksShin,

            /// <summary>靴下つま先</summary>
            SocksToe,

            /// <summary>パンツ</summary>
            Pants,

            /// <summary>スパッツ</summary>
            Spats,

            /// <summary>靴</summary>
            Shoes,
        }

        // Use this for initialization
        private void Start()
        {
            this.StoreMaterials();
            this.ChangeEquipments();
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void StoreMaterials()
        {
            this._materialsDic = new Dictionary<MaterialIndexesKey, Material>();
            var materials = this.SkinnedMesh.sharedMaterials;

            foreach (var item in Enum.GetValues(typeof(MaterialIndexesKey)).Cast<MaterialIndexesKey>().Select((x, i) => new {Index = i, Key = x}))
            {
                this._materialsDic[item.Key] = materials[this.MaterialIndexes[item.Index]];
            }

            //スパッツのRenderQuereを太もものそれより大きくしておく
            this._materialsDic[MaterialIndexesKey.Spats].renderQueue = this._materialsDic[MaterialIndexesKey.Thigh].renderQueue + 1;
        }

        private void OnValidate()
        {
            this.ChangeEquipments();
        }

        private void ChangeEquipments()
        {
            if (_materialsDic == null) return;

            var renderer = this.SkinnedMesh.GetComponent<Renderer>();
            var materials = renderer.sharedMaterials;

            if (this.ShowSpats)
            {
                this.ChangeToTransparent(materials, MaterialIndexesKey.Pants);
                this.ChangeToTransparent(materials, MaterialIndexesKey.Thigh);
                this.ChangeToOrigin(materials, MaterialIndexesKey.Spats);
            }
            else
            {
                this.ChangeToOrigin(materials, MaterialIndexesKey.Pants);
                this.ChangeToOrigin(materials, MaterialIndexesKey.Thigh);
                this.ChangeToTransparent(materials, MaterialIndexesKey.Spats);
            }

            if (this.ShowSocks)
            {
                this.ChangeToTransparent(materials, MaterialIndexesKey.Shin);
                this.ChangeToTransparent(materials, MaterialIndexesKey.Toe);
                this.ChangeToOrigin(materials, MaterialIndexesKey.SocksShin);

                if (this.ShowShoes)
                {
                    this.ChangeToTransparent(materials, MaterialIndexesKey.SocksToe);
                    this.ChangeToOrigin(materials, MaterialIndexesKey.Shoes);
                }
                else
                {
                    this.ChangeToOrigin(materials, MaterialIndexesKey.SocksToe);
                    this.ChangeToTransparent(materials, MaterialIndexesKey.Shoes);
                }
            }
            else
            {
                this.ChangeToOrigin(materials, MaterialIndexesKey.Shin);
                this.ChangeToTransparent(materials, MaterialIndexesKey.SocksShin);
                this.ChangeToTransparent(materials, MaterialIndexesKey.SocksToe);
                               
                if (this.ShowShoes)
                {
                    this.ChangeToTransparent(materials, MaterialIndexesKey.Toe);
                    this.ChangeToOrigin(materials, MaterialIndexesKey.Shoes);
                }
                else
                {
                    this.ChangeToOrigin(materials, MaterialIndexesKey.Toe);
                    this.ChangeToTransparent(materials, MaterialIndexesKey.Shoes);
                }
            }

            renderer.sharedMaterials = materials;
        }

        /// <summary>
        /// マテリアルを元に戻す
        /// </summary>
        /// <param name="materials"></param>
        /// <param name="key"></param>
        private void ChangeToOrigin(Material[] materials, MaterialIndexesKey key)
        {
            materials[this.MaterialIndexes[(int)key]] = this._materialsDic[key];
        }

        /// <summary>
        /// マテリアルを透過のものに置き換える
        /// </summary>
        /// <param name="materials"></param>
        /// <param name="key"></param>
        private void ChangeToTransparent(Material[] materials, MaterialIndexesKey key)
        {
            materials[this.MaterialIndexes[(int)key]] = this.TransparentMaterial;
        }
    }
}
