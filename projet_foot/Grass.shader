Shader "Examples/FootballFieldGrass"
{
    Properties
    {
        _BaseColor("Base Color", Color) = (0.1, 0.6, 0.1, 1)
    }

    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
            "Queue" = "Geometry"
            "RenderPipeline" = "UniversalPipeline"
        }

        Pass
        {
            Tags
            {
                "LightMode" = "UniversalForward"
            }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct v2f
            {
                float4 positionCS : SV_Position;
                float2 uv : TEXCOORD0;
            };

            CBUFFER_START(UnityPerMaterial)
                float4 _BaseColor;
            CBUFFER_END

            v2f vert (float4 vertex : POSITION) 
            {
                v2f o;
                o.positionCS = mul(UNITY_MATRIX_MVP, vertex);
                o.uv = vertex.xy * 0.5 + 0.5;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                // Ajout de variations pour simuler les différentes brins d'herbe
                float grassVariation = frac(sin(dot(i.uv.xy, float2(12.9898, 78.233))) * 43758.5453);

                // Ajout de couleur pour simuler la pelouse verte
                float4 grassColor = float4(_BaseColor.rgb * grassVariation, 1.0);

                // Assombrissement de la couleur pour simuler les ombres
                grassColor.rgb *= 0.8;

                return grassColor;
            }
            ENDHLSL
        }
    }
    Fallback Off
}
