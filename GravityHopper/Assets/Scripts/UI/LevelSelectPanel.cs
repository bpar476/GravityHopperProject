using System;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LevelSelectPanel : MonoBehaviour
{
    /// <summary>
    /// Prefab of button to instantiate for each level
    /// </summary>
    [SerializeField]
    private Button levelButtonPrefab;

    /// <summary>
    /// Levels to load into the select screen
    /// </summary>
    [SerializeField]
    private Level[] levels;

    [SerializeField]
    private SceneLoader sceneLoader;

    /// <summary>
    /// Position in panel that the first level button should be loaded
    /// </summary>
    [SerializeField]
    private Vector2 start;

    /// <summary>
    /// Offset between each button. Y value will be used when buttons must
    /// wrap the panel.
    /// </summary>
    [SerializeField]
    private Vector2 offset;

    private void Start()
    {
        for (var i = 0; i < LevelProgression.Instance.GetCurrentLevel(); i++)
        {
            Button levelButton = Instantiate(levelButtonPrefab, transform);
            var rectTransform = levelButton.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(start.x + i * offset.x, start.y);

            Level currentLevel = levels[i];
            levelButton.onClick.AddListener(() => sceneLoader.LoadGravityHopperSceneAsync(currentLevel.BuildIndex));
            levelButton.GetComponentInChildren<TMP_Text>().text = currentLevel.DisplayName;
        }
    }

    [Serializable]
    public struct Level
    {
        /// <summary>
        /// Build index of the level. Will be loaded
        /// by scene manager when clicking button
        /// </summary>
        public int BuildIndex;
        /// <summary>
        /// Text to display on level select button
        /// </summary>
        public string DisplayName;
    }
}
