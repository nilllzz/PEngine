﻿using PEngine.Common.Data.Maps;
using PEngine.Creator.Components.Projects;
using System.IO;

namespace PEngine.Creator.Components.Game
{
    public partial class MapEditor : ProjectTabComponent, IEventBusComponent
    {
        private readonly ProjectEventBus _eventBus;
        private readonly MapData _data;
        private readonly ProjectItem _item;

        public override string FilePath => _item.FilePath;
        public override string Identifier => _item.Identifier;
        public override int IconIndex => ICON_MAP;

        public MapEditor(ProjectEventBus eventBus, MapData data, ProjectItem item)
        {
            InitializeComponent();

            _item = item;
            _data = data;

            _eventBus = eventBus;
            RegisterEvents();

            InitData();
        }

        #region events

        private void RegisterEvents()
        {

        }

        public void UnregisterEvents()
        {

        }

        #endregion

        private void InitData()
        {
            Title = _data.id;
        }
    }
}
