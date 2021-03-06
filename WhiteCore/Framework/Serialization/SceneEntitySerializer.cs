﻿using System.IO;
using System.Xml;
using WhiteCore.Framework.Modules;
using WhiteCore.Framework.SceneInfo;
using WhiteCore.Framework.SceneInfo.Entities;
using OpenMetaverse;

namespace WhiteCore.Framework.Serialization
{
    public interface ISceneObjectSerializer
    {
        ISceneEntity FromOriginalXmlFormat(string serialization, IRegistryCore scene);

        ISceneEntity FromOriginalXmlFormat(UUID fromUserInventoryItemID, string xmlData,
                                           IRegistryCore scene);

        string ToOriginalXmlFormat(ISceneEntity sceneObject);
        ISceneEntity FromXml2Format(string xmlData, IScene scene);
        ISceneEntity FromXml2Format(ref MemoryStream ms, IScene scene);
        string ToXml2Format(ISceneEntity sceneObject);
        byte[] ToBinaryXml2Format(ISceneEntity sceneObject);
        void ToXmlFormat(ISceneChildEntity part, XmlTextWriter writer);
        void AddSerializer(string p, ISOPSerializerModule serializer);
    }

    public class SceneEntitySerializer
    {
        public static ISceneObjectSerializer SceneObjectSerializer;
    }
}