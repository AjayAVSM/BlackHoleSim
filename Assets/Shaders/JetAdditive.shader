Shader "Custom/JetAdditive"
{
    Properties
    {
        [MainTexture] _MainTex ("Particle Texture", 2D) = "white" {}
        [HDR] _Color ("Tint Color", Color) = (0.2, 0.5, 1, 1)
        _Intensity ("Glow Intensity", Range(0,5)) = 1
    }

    SubShader
    {
        Tags { 
            "RenderType" = "Transparent" 
            "Queue" = "Transparent+100"
            "RenderPipeline" = "UniversalPipeline"
        }

        Blend One One        // Additive blending
        ZWrite Off           // Don’t write to depth
        ZTest Always         // Ignore depth (always visible)
        Cull Off             // Render both sides

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            float4 _MainTex_ST;
            float4 _Color;
            float _Intensity;

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.uv = TRANSFORM_TEX(IN.uv, _MainTex);
                OUT.color = IN.color * _Color;
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                half4 texCol = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv);
                half3 col = texCol.rgb * IN.color.rgb * _Intensity;
                return half4(col, texCol.a * IN.color.a);
            }
            ENDHLSL
        }
    }

    FallBack Off
}

