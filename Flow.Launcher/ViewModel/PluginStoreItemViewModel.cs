﻿using System;
using System.Diagnostics;
using Flow.Launcher.Core.ExternalPlugins;
using Flow.Launcher.Core.Plugin;
using Flow.Launcher.Plugin;

namespace Flow.Launcher.ViewModel
{
    public class PluginStoreItemViewModel : BaseModel
    {
        public PluginStoreItemViewModel(UserPlugin plugin)
        {
            _plugin = plugin;
        }

        private UserPlugin _plugin;

        public string ID => _plugin.ID;
        public string Name => _plugin.Name;
        public string Description => _plugin.Description;
        public string Author => _plugin.Author;
        public string Version => _plugin.Version;
        public string Language => _plugin.Language;
        public string Website => _plugin.Website;
        public string UrlDownload => _plugin.UrlDownload;
        public string UrlSourceCode => _plugin.UrlSourceCode;
        public string IcoPath => _plugin.IcoPath;

        public bool LabelInstalled => PluginManager.GetPluginForId(_plugin.ID) != null;
        public bool LabelUpdate => LabelInstalled && _plugin.Version != PluginManager.GetPluginForId(_plugin.ID).Metadata.Version;
        public bool LabelNew => DateTime.Now - _plugin.LatestReleaseDate < TimeSpan.FromDays(7) && !LabelUpdate; // Show Update Label show first.
    }
}
