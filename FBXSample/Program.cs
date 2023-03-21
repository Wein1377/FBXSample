/*using Assimp;
*/using Assimp;
using FbxSharp;
using System;
using UkooLabs.FbxSharpie;

namespace FBXSample
{
    class Program
    {
        static void Main(string[] args)
        {
            AssimpContext importer = new AssimpContext();

            Assimp.Scene model_1 = importer.ImportFile(file.fbx, PostProcessPreset.TargetRealTimeMaximumQuality);
            var a = model_1.RootNode.Children;

            var model = FbxIO.Read(file.fbx);
            var geometryIds = model.GetGeometryIds();
            foreach (var geometryId in geometryIds)
            {
                var vertexIndices = model.GetVertexIndices(geometryId);
                var positions = model.GetPositions(geometryId, vertexIndices);

                var normalLayerIndices = model.GetLayerIndices(geometryId, FbxLayerElementType.Normal);
                var tangentLayerIndices = model.GetLayerIndices(geometryId, FbxLayerElementType.Tangent);
                var binormalLayerIndices = model.GetLayerIndices(geometryId, FbxLayerElementType.Binormal);
                var texCoordLayerIndices = model.GetLayerIndices(geometryId, FbxLayerElementType.TexCoord);
                var materialLayerIndices = model.GetLayerIndices(geometryId, FbxLayerElementType.Material);

                var normals = model.GetNormals(geometryId, vertexIndices, normalLayerIndices[0]);

                var hasNormals = model.GetGeometryHasNormals(geometryId);
                var hasTexCoords = model.GetGeometryHasTexCoords(geometryId);
                var hasTangents = model.GetGeometryHasTangents(geometryId);
                var hasBinormals = model.GetGeometryHasBinormals(geometryId);
                var hasMaterials = model.GetGeometryHasMaterials(geometryId);
            }
        }
    }
}