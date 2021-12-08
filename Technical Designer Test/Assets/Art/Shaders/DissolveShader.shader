// I found this shader script in a blog, and made some minor adjustments to suit the needs of the project. ORIGINAL SOURCE: https://gist.github.com/benloong/b25066cb140398b402f2ad8295a28d42

Shader "Custom/DissolveSurface" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
 
		//Dissolve properties
		_DissolveTexture("Dissolve Texutre", 2D) = "white" {} 
		_Amount("Amount", Range(0,1)) = 0

		_DissolveColor ("DissolveColor", Color) = (1,1,1)
	}
 
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		Cull Off //Fast way to turn your material double-sided
 
		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows
 
		#pragma target 3.0
 
		sampler2D _MainTex;
 
		struct Input {
			float2 uv_MainTex;
		};
 
		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
 
		//Dissolve properties
		sampler2D _DissolveTexture;
		half _Amount;
		fixed3 _DissolveColor;
 
		void surf (Input IN, inout SurfaceOutputStandard o) {
			
			//Dissolve function
			half dissolve_value = tex2D(_DissolveTexture, IN.uv_MainTex).r;
			clip(dissolve_value - _Amount);

			o.Emission = _DissolveColor * step( dissolve_value - _Amount, 0.07f); //emits white color with 0.05 border size

 
			//Basic shader function
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color; 
 
			o.Albedo = c.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}