Shader "ZL/Standard/Skybox/Foggy 6 Sided"
{
    Properties
    {
        _Tint("Tint Color", Color) = (0.5, 0.5, 0.5, 0.5)

        [Gamma] _Exposure("Exposure", Range(0.0, 8.0)) = 1.0

        _Rotation("Rotation", Range(0.0, 360.0)) = 0.0

        [NoScaleOffset] _FrontTex("Front [+Z]   (HDR)", 2D) = "grey" {}

        [NoScaleOffset] _BackTex("Back [-Z]   (HDR)", 2D) = "grey" {}

        [NoScaleOffset] _LeftTex("Left [+X]   (HDR)", 2D) = "grey" {}

        [NoScaleOffset] _RightTex("Right [-X]   (HDR)", 2D) = "grey" {}

        [NoScaleOffset] _UpTex("Up [+Y]   (HDR)", 2D) = "grey" {}

        [NoScaleOffset] _DownTex("Down [-Y]   (HDR)", 2D) = "grey" {}

        _GradientColor("Gradient Color", Color) = (0.0, 0.0, 0.0, 1.0)

        _GradientStartHeight("Gradient Start Height", Float) = 0.0

        _GradientEndHeight("Gradient End Height", Float) = 1.0

        _GradientColor2("Second Gradient Color", Color) = (0.0, 0.0, 0.0, 1.0)

        _GradientStartHeight2("Second Gradient Start Height", Float) = 0.0

        _GradientEndHeight2("Second Gradient End Height", Float) = -1.0
    }

    SubShader
    {
        Tags
        {
            "Queue"="Background"
            
            "RenderType"="Background"
            
            "PreviewType"="Skybox"
        }

        Cull Off ZWrite Off

        CGINCLUDE

        #include "UnityCG.cginc"

        half4 _Tint;

        half _Exposure;

        float _Rotation;

        half4 _GradientColor;

        float _GradientStartHeight;

        float _GradientEndHeight;

        half4 _GradientColor2;

        float _GradientStartHeight2;

        float _GradientEndHeight2;

        float3 RotateAroundYInDegrees(float3 vertex, float degrees)
        {
            float alpha = degrees * UNITY_PI / 180.0;

            float sina, cosa;

            sincos(alpha, sina, cosa);

            float2x2 m = float2x2(cosa, -sina, sina, cosa);

            return float3(mul(m, vertex.xz), vertex.y).xzy;
        }

        struct appdata_t
        {
            float4 vertex : POSITION;

            float2 texcoord : TEXCOORD0;

            UNITY_VERTEX_INPUT_INSTANCE_ID
        };

        struct v2f
        {
            float4 vertex : SV_POSITION;

            float2 texcoord : TEXCOORD0;

            float3 worldPos : TEXCOORD1;

            UNITY_VERTEX_OUTPUT_STEREO
        };

        v2f vert(appdata_t v)
        {
            v2f o;

            UNITY_SETUP_INSTANCE_ID(v);

            UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

            float3 rotated = RotateAroundYInDegrees(v.vertex.xyz, _Rotation);

            o.vertex = UnityObjectToClipPos(rotated);

            o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;

            o.texcoord = v.texcoord;

            return o;
        }

        half4 skybox_frag(v2f i, sampler2D smp, half4 smpDecode)
        {
            half4 tex = tex2D(smp, i.texcoord);

            half3 c = DecodeHDR(tex, smpDecode);

            c = c * _Tint.rgb * unity_ColorSpaceDouble.rgb;

            c *= _Exposure;

            float heightFactor = normalize(i.worldPos).y;

            float t1 = smoothstep(_GradientStartHeight, _GradientEndHeight, heightFactor);

            c = lerp(c, _GradientColor.rgb, t1);

            float t2 = smoothstep(_GradientStartHeight2, _GradientEndHeight2, heightFactor);

            c = lerp(c, _GradientColor2.rgb, t2);

            return half4(c, 1);
        }

        ENDCG

        Pass
        {
            CGPROGRAM

            #pragma vertex vert

            #pragma fragment frag

            #pragma target 2.0

            sampler2D _FrontTex;

            half4 _FrontTex_HDR;

            half4 frag(v2f i) : SV_Target
            {
                return skybox_frag(i, _FrontTex, _FrontTex_HDR);
            }

            ENDCG
        }

        Pass
        {
            CGPROGRAM

            #pragma vertex vert

            #pragma fragment frag

            #pragma target 2.0

            sampler2D _BackTex;

            half4 _BackTex_HDR;

            half4 frag(v2f i) : SV_Target
            {
                return skybox_frag(i, _BackTex, _BackTex_HDR);
            }

            ENDCG
        }

        Pass
        {
            CGPROGRAM

            #pragma vertex vert

            #pragma fragment frag

            #pragma target 2.0

            sampler2D _LeftTex;

            half4 _LeftTex_HDR;

            half4 frag(v2f i) : SV_Target
            {
                return skybox_frag(i, _LeftTex, _LeftTex_HDR);
            }

            ENDCG
        }

        Pass
        {
            CGPROGRAM

            #pragma vertex vert

            #pragma fragment frag

            #pragma target 2.0

            sampler2D _RightTex;

            half4 _RightTex_HDR;

            half4 frag(v2f i) : SV_Target
            {
                return skybox_frag(i, _RightTex, _RightTex_HDR);
            }

            ENDCG
        }

        Pass
        {
            CGPROGRAM

            #pragma vertex vert

            #pragma fragment frag

            #pragma target 2.0

            sampler2D _UpTex;

            half4 _UpTex_HDR;

            half4 frag(v2f i) : SV_Target
            {
                return skybox_frag(i, _UpTex, _UpTex_HDR);
            }

            ENDCG
        }

        Pass
        {
            CGPROGRAM

            #pragma vertex vert

            #pragma fragment frag

            #pragma target 2.0

            sampler2D _DownTex;

            half4 _DownTex_HDR;

            half4 frag(v2f i) : SV_Target
            {
                return skybox_frag(i, _DownTex, _DownTex_HDR);
            }

            ENDCG
        }
    }
}