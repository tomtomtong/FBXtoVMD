Shader "PronamaChan/Toon/Lit Outline" {
	Properties {
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {}
		[Enum(OFF,0,FRONT,1,BACK,2)] _CullMode("Cull Mode", int) = 2 //OFF/FRONT/BACK
		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_Outline("Outline width", Range(.0, 0.03)) = .005
		_OutlineZOffest("Outline Z Offset", float) = .0
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		UsePass "PronamaChan/Toon/Lit/FORWARD"
		UsePass "PronamaChan/Toon/Basic Outline/OUTLINE"
	} 
	
	Fallback "PronamaChan/Toon/Lit"
}
