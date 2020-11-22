using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelToSceneIndex : MonoBehaviour
{
    /// <summary>
    /// Takes the number of a level and returns the build index
    /// of the scene for that level. For example to get the build
    /// index of level 2:
    ///     <example>
    ///     ConvertToSceneIndex(2);
    ///     </example>
    /// </summary>
    /// <param name="levelNumber">Integer for the number of the level.</param>
    /// <returns></returns>
    public static int ConvertToSceneIndex(int levelNumber)
    {
        return levelNumber + 1;
    }
}
