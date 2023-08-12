using UnityEngine;

namespace Arkanoid.Game.Blocks
{
    [CreateAssetMenu(fileName = nameof(BlockStatesContainer), menuName = "Block/Block states")]
    public class BlockStatesContainer : ScriptableObject
    {
        #region Variables

        [SerializeField] private Sprite[] _blockStatesSprites;

        #endregion

        #region Properties

        public Sprite[] BlockStatesSprites => _blockStatesSprites;

        #endregion
    }
}