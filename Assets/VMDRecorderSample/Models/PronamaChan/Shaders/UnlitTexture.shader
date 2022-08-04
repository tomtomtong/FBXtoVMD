Shader "PronamaChan/Unlit/Texture" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		[Enum(OFF,0,FRONT,1,BACK,2)] _CullMode("Cull Mode", int) = 2 //OFF/FRONT/BACK
	}

		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 100

		Pass{
		Lighting Off
		Cull[_CullMode]
		SetTexture[_MainTex]{ combine texture }
	}
	}
}