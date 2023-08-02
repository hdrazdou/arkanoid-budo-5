using UnityEngine;

namespace Arkanoid
{
    [CreateAssetMenu(fileName = nameof(BlockStatesContainer), menuName = "Block/Block states")]
    public class BlockStatesContainer : ScriptableObject
    {
        #region Variables

        [SerializeField] private Sprite[] _blockStatesSprites;

        public Sprite[] BlockStatesSprites => _blockStatesSprites;

        #endregion
    }
}