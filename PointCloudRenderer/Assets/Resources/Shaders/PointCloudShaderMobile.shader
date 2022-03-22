Shader "Unlit/PointCloudShaderMobile"
{
    /*
	This shader renders the given vertices as points with the given color
	The point size is adjustable through _PointSize 
    The shader works on iOS devices using Metal.
	*/

    Properties 
    {
        _PointSize("PointSize", Float) = 1
    }

	SubShader
	{

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			struct VertexInput
			{
				float4 vertex : POSITION;
				float4 color : COLOR;
			};
			
			struct VertexOutput
			{
				float4 pos : SV_POSITION;
				fixed4 color : COLOR;
				float psize : PSIZE;
			};
			
			float _PointSize;
			
			VertexOutput vert (VertexInput v)
			{
				VertexOutput o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.color = v.color;
				o.psize = _PointSize;
				return o;
			}
			
			half4 frag(VertexOutput i) : COLOR
			{
				return i.color;
			}
			ENDCG
		}
	}
}