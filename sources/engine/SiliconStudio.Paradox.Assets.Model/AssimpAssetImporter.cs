﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;

using SiliconStudio.Core.Diagnostics;
using SiliconStudio.Core.IO;
using SiliconStudio.Paradox.Importer.Common;

namespace SiliconStudio.Paradox.Assets.Model
{
    public class AssimpAssetImporter : ModelAssetImporter
    {
        // Supported file extensions for this importer
        private const string FileExtensions = ".dae;.3ds;.obj;.blend;.x;.md2;.md3;.dxf";

        private static readonly Guid uid = new Guid("30243FC0-CEC7-4433-977E-95DCA29D846E");

        public override Guid Id
        {
            get
            {
                return uid;
            }
        }

        public override string Description
        {
            get
            {
                return "Assimp importer used for creating entities, 3D Models or animations assets";
            }
        }

        public override string SupportedFileExtensions
        {
            get
            {
                return FileExtensions;
            }
        }

        /// <inheritdoc/>
        public override EntityInfo GetEntityInfo(UFile localPath, Logger logger)
        {
            var meshConverter = new Importer.AssimpNET.MeshConverter(logger);
            var entityInfo = meshConverter.ExtractEntity(localPath.FullPath, null);
            return entityInfo;
        }
    }
}
