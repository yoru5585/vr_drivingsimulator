Shader "Custom/ClipSphereBottomFade"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ClipPlane ("Clip Plane Height", Float) = 0.0
        _FadeRange ("Fade Range", Float) = 1.0
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha

        CGPROGRAM
        #pragma surface surf Lambert alpha:fade

        sampler2D _MainTex;
        float _ClipPlane;
        float _FadeRange;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

            // �t�F�[�h�̌v�Z
            float distance = IN.worldPos.y - _ClipPlane;
            float fade = 1.0;

            if (distance < 0)
            {
                fade = 0; // �N���b�v�v���[����艺�̕����͊��S�ɓ���
            }
            else if (distance < _FadeRange)
            {
                fade = distance / _FadeRange; // �t�F�[�h�͈͓��ł̃t�F�[�h�v�Z
            }

            c.a *= fade;

            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Transparent/Cutout/VertexLit"
}
