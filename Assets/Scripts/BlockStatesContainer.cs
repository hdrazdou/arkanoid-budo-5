using UnityEngine;

namespace Arkanoid

{
    [CreateAssetMenu(fileName = nameof(BlockStatesContainer), menuName = "Block/Block states")]
    public class BlockStatesContainer : ScriptableObject
    {
        #region Variables

        public Sprite[] BlockStatesSprites;

        #endregion
    }
}