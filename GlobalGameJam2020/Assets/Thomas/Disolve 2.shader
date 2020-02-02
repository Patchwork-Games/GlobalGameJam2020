// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33259,y:32676,varname:node_3138,prsc:2|diff-4604-RGB,spec-9820-OUT,gloss-9820-OUT,emission-7144-RGB,custl-1175-OUT,clip-1668-OUT;n:type:ShaderForge.SFN_Add,id:1668,x:32461,y:33007,varname:node_1668,prsc:2|A-1974-OUT,B-6449-R;n:type:ShaderForge.SFN_Tex2d,id:6449,x:32185,y:33212,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_905,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e182ac5d3b797044fb29f3fa2acc3708,ntxv:0,isnm:False;n:type:ShaderForge.SFN_RemapRange,id:1974,x:32229,y:32973,varname:node_1974,prsc:2,frmn:0,frmx:1,tomn:-0.7,tomx:0.7|IN-7728-OUT;n:type:ShaderForge.SFN_Slider,id:9394,x:31683,y:32994,ptovrint:False,ptlb:Dissolve amount,ptin:_Dissolveamount,varname:node_7226,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.02879007,max:1;n:type:ShaderForge.SFN_OneMinus,id:7728,x:32040,y:32973,varname:node_7728,prsc:2|IN-9394-OUT;n:type:ShaderForge.SFN_RemapRange,id:2965,x:32377,y:32766,varname:node_2965,prsc:2,frmn:0,frmx:1,tomn:-4,tomx:4|IN-1668-OUT;n:type:ShaderForge.SFN_Clamp01,id:7427,x:32545,y:32744,varname:node_7427,prsc:2|IN-2965-OUT;n:type:ShaderForge.SFN_Append,id:219,x:32765,y:32779,varname:node_219,prsc:2|A-723-OUT,B-2557-OUT;n:type:ShaderForge.SFN_Vector1,id:2557,x:32596,y:32901,varname:node_2557,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2dAsset,id:9021,x:32765,y:32988,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_9021,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:181ec605fb3b4314bbee61db18ab41c0,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7144,x:32945,y:32817,varname:node_7144,prsc:2,tex:181ec605fb3b4314bbee61db18ab41c0,ntxv:0,isnm:False|UVIN-219-OUT,TEX-9021-TEX;n:type:ShaderForge.SFN_OneMinus,id:723,x:32616,y:32568,varname:node_723,prsc:2|IN-7427-OUT;n:type:ShaderForge.SFN_Color,id:3698,x:32976,y:32522,ptovrint:False,ptlb:node_3698,ptin:_node_3698,varname:node_3698,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1860093,c2:0.5800024,c3:0.7169812,c4:1;n:type:ShaderForge.SFN_Vector1,id:9820,x:33018,y:32696,varname:node_9820,prsc:2,v1:0;n:type:ShaderForge.SFN_LightAttenuation,id:3763,x:32803,y:33573,varname:node_3763,prsc:2;n:type:ShaderForge.SFN_Dot,id:3437,x:31862,y:33797,varname:node_3437,prsc:2,dt:1|A-3773-OUT,B-8601-OUT;n:type:ShaderForge.SFN_NormalVector,id:8601,x:31653,y:33891,prsc:2,pt:True;n:type:ShaderForge.SFN_LightVector,id:3773,x:31653,y:33770,varname:node_3773,prsc:2;n:type:ShaderForge.SFN_Dot,id:5489,x:31862,y:33970,varname:node_5489,prsc:2,dt:1|A-8601-OUT,B-9112-OUT;n:type:ShaderForge.SFN_Add,id:9866,x:32803,y:33835,varname:node_9866,prsc:2|A-7537-OUT,B-7182-RGB,C-5-OUT;n:type:ShaderForge.SFN_Power,id:854,x:32064,y:34070,cmnt:Specular Light,varname:node_854,prsc:2|VAL-5489-OUT,EXP-8915-OUT;n:type:ShaderForge.SFN_HalfVector,id:9112,x:31653,y:34030,varname:node_9112,prsc:2;n:type:ShaderForge.SFN_LightColor,id:1298,x:32803,y:33702,varname:node_1298,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1175,x:32987,y:33702,varname:node_1175,prsc:2|A-3763-OUT,B-1298-RGB,C-9866-OUT;n:type:ShaderForge.SFN_Color,id:8033,x:32299,y:33725,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6544118,c2:0.8426978,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:1239,x:32299,y:33549,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:_Diffuse,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8993b617f08498f43adcbd90697f1c5d,ntxv:0,isnm:False|UVIN-1368-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:4604,x:32987,y:33513,ptovrint:False,ptlb:Normals,ptin:_Normals,varname:_Normals,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c6dfb00dbee6bc044a8a3bb22e56e064,ntxv:3,isnm:True|UVIN-1368-UVOUT;n:type:ShaderForge.SFN_Multiply,id:7537,x:32504,y:33707,cmnt:Diffuse Light,varname:node_7537,prsc:2|A-1239-RGB,B-8033-RGB,C-4986-OUT;n:type:ShaderForge.SFN_AmbientLight,id:7182,x:32504,y:33827,varname:node_7182,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:816,x:32064,y:33970,ptovrint:False,ptlb:Bands,ptin:_Bands,varname:_Bands,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_Slider,id:9578,x:30915,y:34138,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Add,id:3732,x:31653,y:34187,varname:node_3732,prsc:2|A-4995-OUT,B-900-OUT;n:type:ShaderForge.SFN_Vector1,id:900,x:31485,y:34275,varname:node_900,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:4995,x:31485,y:34125,varname:node_4995,prsc:2|A-9578-OUT,B-1438-OUT;n:type:ShaderForge.SFN_Vector1,id:1438,x:31072,y:34208,varname:node_1438,prsc:2,v1:10;n:type:ShaderForge.SFN_Exp,id:8915,x:31824,y:34187,varname:node_8915,prsc:2,et:1|IN-3732-OUT;n:type:ShaderForge.SFN_Posterize,id:4986,x:32299,y:33891,varname:node_4986,prsc:2|IN-3437-OUT,STPS-816-OUT;n:type:ShaderForge.SFN_Posterize,id:5,x:32299,y:34022,varname:node_5,prsc:2|IN-854-OUT,STPS-816-OUT;n:type:ShaderForge.SFN_TexCoord,id:1368,x:32052,y:33598,varname:node_1368,prsc:2,uv:0,uaff:False;proporder:6449-9394-9021-3698-4604-8033-1239-816-9578;pass:END;sub:END;*/

Shader "Shader Forge/Disolve 2" {
    Properties {
        _Noise ("Noise", 2D) = "white" {}
        _Dissolveamount ("Dissolve amount", Range(0, 1)) = 0.02879007
        _Ramp ("Ramp", 2D) = "white" {}
        _node_3698 ("node_3698", Color) = (0.1860093,0.5800024,0.7169812,1)
        _Normals ("Normals", 2D) = "bump" {}
        _Color ("Color", Color) = (0.6544118,0.8426978,1,1)
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Bands ("Bands", Float ) = 3
        _Gloss ("Gloss", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma target 3.0
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normals; uniform float4 _Normals_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Dissolveamount)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _Bands)
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float _Dissolveamount_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Dissolveamount );
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_1668 = (((1.0 - _Dissolveamount_var)*1.4+-0.7)+_Noise_var.r);
                clip(node_1668 - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float2 node_219 = float2((1.0 - saturate((node_1668*8.0+-4.0))),0.0);
                float4 node_7144 = tex2D(_Ramp,TRANSFORM_TEX(node_219, _Ramp));
                float3 emissive = node_7144.rgb;
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float _Bands_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Bands );
                float _Gloss_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Gloss );
                float3 finalColor = emissive + (attenuation*_LightColor0.rgb*((_Diffuse_var.rgb*_Color_var.rgb*floor(max(0,dot(lightDirection,normalDirection)) * _Bands_var) / (_Bands_var - 1))+UNITY_LIGHTMODEL_AMBIENT.rgb+floor(pow(max(0,dot(normalDirection,halfDirection)),exp2(((_Gloss_var*10.0)+1.0))) * _Bands_var) / (_Bands_var - 1)));
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma target 3.0
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normals; uniform float4 _Normals_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Dissolveamount)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _Bands)
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float _Dissolveamount_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Dissolveamount );
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_1668 = (((1.0 - _Dissolveamount_var)*1.4+-0.7)+_Noise_var.r);
                clip(node_1668 - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float _Bands_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Bands );
                float _Gloss_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Gloss );
                float3 finalColor = (attenuation*_LightColor0.rgb*((_Diffuse_var.rgb*_Color_var.rgb*floor(max(0,dot(lightDirection,normalDirection)) * _Bands_var) / (_Bands_var - 1))+UNITY_LIGHTMODEL_AMBIENT.rgb+floor(pow(max(0,dot(normalDirection,halfDirection)),exp2(((_Gloss_var*10.0)+1.0))) * _Bands_var) / (_Bands_var - 1)));
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma target 3.0
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Dissolveamount)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float _Dissolveamount_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Dissolveamount );
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(i.uv0, _Noise));
                float node_1668 = (((1.0 - _Dissolveamount_var)*1.4+-0.7)+_Noise_var.r);
                clip(node_1668 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
