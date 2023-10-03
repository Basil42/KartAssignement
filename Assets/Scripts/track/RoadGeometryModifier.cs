using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.U2D;

namespace track
{
    [CreateAssetMenu(fileName = "RoadGeometry", menuName = "Road geometry modifier", order = 0)]
    public class RoadGeometryModifier : SpriteShapeGeometryModifier
    {
        public override JobHandle MakeModifierJob(JobHandle generator, SpriteShapeController spriteShapeController, NativeArray<ushort> indices,
            NativeSlice<Vector3> positions, NativeSlice<Vector2> texCoords, NativeSlice<Vector4> tangents, NativeArray<SpriteShapeSegment> segments, NativeArray<float2> colliderData)
        {
            throw new System.NotImplementedException();
        }
    }
}

public struct CornerHighlightJob : IJob
{
    public NativeArray<Vector2> uvs;//I can actually pack this is the u channel of the uvs
    public NativeArray<Vector4> Tangents;//might use the tangents instead 
    public void Execute()
    {
        for (int i = 0; i < uvs.Length; i++)
        {
            var uv = uvs[i];
            Vector4 tangents = Tangents[i];
            var t1 = new Vector2(tangents.x, tangents.y);
            var t2 = new Vector2(tangents.z, tangents.w);
            
        }
    }
}