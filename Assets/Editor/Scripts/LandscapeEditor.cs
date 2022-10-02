using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace LandscapePrototype {
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Landscape))]
    public class LandscapeEditor : Editor {
        [SerializeField] private VisualTreeAsset landscapeInspectorView;
        [SerializeField] private StyleSheet landscapeInspectorStyle;

        public override VisualElement CreateInspectorGUI() {
            VisualElement customInspectorRoot = new();
            landscapeInspectorView?.CloneTree(customInspectorRoot);
            if (landscapeInspectorStyle != null) {
                customInspectorRoot.styleSheets.Add(landscapeInspectorStyle);
            }
            return customInspectorRoot;
        }
    }
}