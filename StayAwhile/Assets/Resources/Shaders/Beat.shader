Shader "Custom/TileBeat"
{
	Properties
	{
		_mainTexture("Texture", 2D) = "white" {}
	_color("Color", Color) = (1,1,1,1)
		_beat("Beat", Float) = 1
		_rampup("RampUp", Range(0,1)) = 0

	}
		SubShader
	{
		Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 100

		Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

	struct appdata
	{
		float4 position : POSITION;
		float2 uv : TEXCOORD0;
	};

	struct v2f
	{
		float4 position : SV_POSITION;
		float2 uv : TEXCOORD0;
	};

	sampler2D _mainTexture;
	float4 _mainTexture_ST;

	float4 _color;

	float _beat;
	float _rampup;

	float4 _MainTex_ST;

	v2f vert(appdata input)
	{
		v2f output;
		output.position = mul(UNITY_MATRIX_MVP, input.position);

		float jump = _beat * 1000.0f > 2 ? 2 : _beat * 1000.0f;
		output.position.y = output.position.y + jump *_rampup;

		output.uv = TRANSFORM_TEX(input.uv, _MainTex);
		return output;
	}

	fixed4 frag(v2f i) : SV_Target
	{
		float4 temp = _color;
		temp.a = 0.8f;

		return temp;
	}

		ENDCG
	}
	}
}