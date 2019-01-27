﻿Shader "Custom/RainbowShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {			
			fixed3 violet = fixed3(148, 0, 211);
			fixed3 indigo = fixed3(75, 0, 130);
			fixed3 blue = fixed3(0, 0, 255);
			fixed3 green = fixed3(0, 255, 0);
			fixed3 yellow = fixed3(255, 255, 0);
			fixed3 orange = fixed3(255, 127, 0);
			fixed3 red = fixed3(225, 0, 0);
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;		
			if (IN.uv_MainTex.y < 0.14) {
				c.rgb = violet;
			}
			else if (IN.uv_MainTex.y < 0.28) {
				c.rgb = indigo;
			}
			else if (IN.uv_MainTex.y < 0.42) {
				c.rgb = blue;
			}
			else if(IN.uv_MainTex.y < 0.57) {
				c.rgb = green;
			}
			else if (IN.uv_MainTex.y < 0.71) {
				c.rgb = yellow;
			}
			else if (IN.uv_MainTex.y < 0.85) {
				c.rgb = orange;
			}
			else {
				c.rgb = red;
			}

			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}