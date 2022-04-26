Shader "Graph/PointSurfaceShader" 
{
    Properties
    {
        _Smoothness("Smoothness", Range(0,1)) = 0.5
    }

        SubShader
        {
            CGPROGRAM
            // Physically based Standard lighting model, and enable shadows on all light types
            // surf 表示接下来调用用于着色的函数
            #pragma surface surf Standard fullforwardshadows

            // Use shader model 3.0 target, to get nicer looking lighting
            #pragma target 3.0

            // 定义输入的数据格式
            struct Input {
            // 我们需要使用世界坐标系中的位置来着色
                float3 worldPos;
            };
            float _Smoothness;

            // 上面定义的 Input 函数
            // 两个参数: 上面定义的输入结构, 标准输出结构
            void surf(Input IN, inout SurfaceOutputStandard o) {
                o.Smoothness = _Smoothness;
                // o.Albedo = IN.worldPos * 0.5 + 0.5;    // 根据位置设置颜色(这样会导致太蓝, 因为z=0)
                o.Albedo.rg = IN.worldPos.xy * 0.5 + 0.5; //  black => yellow(red + green = yellow)
            }
            ENDCG
        }
            FallBack "Diffuse"
}