using UnityEditor;
using UnityEngine;

namespace LandscapePrototype {
    [ExecuteInEditMode]
    public class Landscape : MonoBehaviour {
        /// <summary>
        /// Initial landscape setting
        /// </summary>
        private void Awake() {
            SerializedObject tagManager = new SerializedObject(
                AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]
            );
            SerializedProperty tagsProperty = tagManager.FindProperty("tags");

            AddTagToManager(tagsProperty,"Terrain");
            AddTagToManager(tagsProperty,"Cloud");
            AddTagToManager(tagsProperty,"Shore");
            tagManager.ApplyModifiedProperties();

            //gameObject.GetComponent<Terrain>().hideFlags = HideFlags.HideInInspector;
            //gameObject.GetComponent<TerrainCollider>().hideFlags = HideFlags.HideInInspector;
            gameObject.tag = "Terrain";
        }

        /// <summary>
        /// Adding a new tag to the tag manager
        /// </summary>
        /// <param name="tagsProperty">A property that stores all existing tags</param>
        /// <param name="tagToAdd">A tag that should be added to already existing tags</param>
        private void AddTagToManager(SerializedProperty tagsProperty, string tagToAdd) {
            for (int i = 0; i < tagsProperty.arraySize; i++) {
                SerializedProperty tagProperty = tagsProperty.GetArrayElementAtIndex(i);
                if (tagProperty.stringValue.Equals(tagToAdd)) {
                    return;
                }
            }

            tagsProperty.InsertArrayElementAtIndex(0);
            SerializedProperty addedTag = tagsProperty.GetArrayElementAtIndex(0);
            addedTag.stringValue = tagToAdd;
        }
    }
}