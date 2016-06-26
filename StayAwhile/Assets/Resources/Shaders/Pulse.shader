Shader "Custom/TilePulse"
{
	Properties
	{
		_mainTexture("Texture", 2D) = "white" {}
		_pulse("Pulse", Float) = 0
		_color("Color", Color) = (1,1,1,1)
		_origin("Origin", Vector) = (1,1,1,1)
		_rampup("RampUp", Float) = 0
		_beat("Beat", Float) = 1
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
		float2 uv : TEXCOORD0;
		float4 position : SV_POSITION;
	};

	sampler2D _mainTexture;
	float4 _mainTexture_ST;

	float _pulse;
	float4 _color;
	float4 _origin;

	float4 _MainTex_ST;
	float _rampup;
	float _beat;
	

	v2f vert(appdata input)
	{
		v2f output;


		float x = input.position.x;// -_origin.x;
		float x2 = x * x;

		float z = input.position.z;// -_origin.z;
		float z2 = z * z;

		float delta = x2 + z2;

		float reduce = delta < 1.0f ? delta  / 1.0f: delta;

		output.position = input.position;
		output.position.y = output.position.y +  sin(delta * _pulse * 0.01) * 1.16f / delta *_rampup;


		output.position = mul(UNITY_MATRIX_MVP, output.position);


		float jump = _beat * 500.0f > 3 ? 3 : _beat * 500.0f;
		output.position.y = output.position.y + jump *_rampup;

		output.uv = TRANSFORM_TEX(input.uv, _mainTexture);
		return output;
	}

	fixed4 frag(v2f i) : SV_Target
	{
		float4 temp = _color;
		temp.a = 0.04f;
		return temp;
	}

		ENDCG
	}
	}
}