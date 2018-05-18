// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unity Shader Book/Chapter 5/Simple Shader"
{
	Properties
	{
		//声明一个Color 类型的属性
		_Color("Color Tint", Color) = (1.0, 1.0, 1.0, 1.0)
		//_MainTex ("Texture", 2D) = "white" {}
	}
		SubShader
	{
		/*Tags { "RenderType"="Opaque" }
		LOD 100*/

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			fixed4 _Color;

			// 使用一个结构体来定义顶点着色器的输入
			struct a2v{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
			};

			// 使用一个结构体来定义顶点着色器的输出
			struct v2f {
				float4 pos : SV_POSITION;
				fixed3 color : COLOR0;
			};

			v2f vert(a2v v){
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.color = v.normal * 0.5 + fixed3(0.5, 0.5, 0.5);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target {
				fixed3 c = i.color;
				c *= _Color.rgb;
				return fixed4(c, 1.0);
			}
			ENDCG
		}
	}
}
