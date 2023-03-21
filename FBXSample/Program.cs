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

            Assimp.Scene model_assimp = importer.ImportFile(file.fbx, PostProcessPreset.TargetRealTimeMaximumQuality);
            foreach(var child in model_assimp.RootNode.Children)
            {
                var mesh = child.MeshIndices;
            }

            var model_sharpie = FbxIO.Read(file.fbx);
            var geometryIds = model_sharpie.GetGeometryIds();
            foreach (var geometryId in geometryIds)
            {
                var vertexIndices = model_sharpie.GetVertexIndices(geometryId);
                var positions = model_sharpie.GetPositions(geometryId, vertexIndices);

                var normalLayerIndices = model_sharpie.GetLayerIndices(geometryId, FbxLayerElementType.Normal);
                var tangentLayerIndices = model_sharpie.GetLayerIndices(geometryId, FbxLayerElementType.Tangent);
                var binormalLayerIndices = model_sharpie.GetLayerIndices(geometryId, FbxLayerElementType.Binormal);
                var texCoordLayerIndices = model_sharpie.GetLayerIndices(geometryId, FbxLayerElementType.TexCoord);
                var materialLayerIndices = model_sharpie.GetLayerIndices(geometryId, FbxLayerElementType.Material);

                var normals = model_sharpie.GetNormals(geometryId, vertexIndices, normalLayerIndices[0]);

                var hasNormals = model_sharpie.GetGeometryHasNormals(geometryId);
                var hasTexCoords = model_sharpie.GetGeometryHasTexCoords(geometryId);
                var hasTangents = model_sharpie.GetGeometryHasTangents(geometryId);
                var hasBinormals = model_sharpie.GetGeometryHasBinormals(geometryId);
                var hasMaterials = model_sharpie.GetGeometryHasMaterials(geometryId);
            }
        }
    }
}