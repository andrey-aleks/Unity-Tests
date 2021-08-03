﻿using System;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace Importer
{
    [CreateAssetMenu(fileName = "CustomImportSettings", menuName = "Custom Import Settings", order = 1010)]
    public class ImporterSettings : ScriptableObject
    {
        //[Tooltip(@"Should tool process drag&dropped files or not?")]
        //public bool processDragAndDrop = false;
        
        [Tooltip(@"Existing project folder with '\' at the end. Example: Assets\Models\")]
        public string parentFolder = @"Assets\Models\";

        public string baseColorPostfix = "BC";
        
        [Tooltip(@"Property name for the current texture in the Shader")]
        public string baseColorMapName = "_BaseMap";
        
        public string normalPostfix = "N";
        
        [Tooltip(@"Property name for the current texture in the Shader")]
        public string normalMapName = "_BumpMap";
        
        public string metallicPostfix = "M";
        
        [Tooltip(@"Property name for the current texture in the Shader")]
        public string metallicMapName = "_MetallicGlossMap";
        
        public string occlusionPostfix = "AO";
        
        [Tooltip(@"Property name for the current texture in the Shader")]
        public string occlusionMapName = "_OcclusionMap";

        [Tooltip(@"Texture format with '.' at start. Example: .png")]
        public string textureFormat = ".png";
        
        
        private static ImporterSettings _instance;
        public static ImporterSettings Instance => _instance ?? (_instance = LoadAsset());

        private static ImporterSettings LoadAsset([CallerFilePath] string callerFilepath = null)
        {
            var path = GetAssetPath();
            var asset = AssetDatabase.LoadAssetAtPath<ImporterSettings>(path);

            if (asset == null)
            {
                asset = CreateInstance<ImporterSettings>();
                AssetDatabase.CreateAsset(asset, path);
                AssetDatabase.SaveAssets();
            }

            return asset;
        }
        
        private static string GetAssetPath([CallerFilePath] string callerFilePath = null)
        {
            var folder = Path.GetDirectoryName(callerFilePath);
            folder = folder.Substring(folder.LastIndexOf("\\Assets\\", StringComparison.Ordinal) + 1);
            return Path.Combine(folder, "CustomImportSettings.asset");
        }
        


    }
}