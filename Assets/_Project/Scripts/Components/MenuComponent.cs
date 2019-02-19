using System;
using Unity.Entities;

namespace _Project.Scripts {
    [Serializable]
    public struct MenuData : IComponentData {
        public int currentMenuId;
        public int menuId;
    }

    public class MenuComponent : ComponentDataWrapper<MenuData> { }
}