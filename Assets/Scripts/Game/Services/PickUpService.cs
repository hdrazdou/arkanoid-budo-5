using System;
using Arkanoid.Game.PickUps;
using Arkanoid.Utility;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Arkanoid.Game.Services
{
    public class PickUpService : SingletonMonoBehaviour<PickUpService>
    {
        #region Variables

        [Range(0, 100)]
        [SerializeField] private int _pickUpDropChance = 50;

        [SerializeField] private PickupSpawnData[] _pickUps;

        #endregion

        #region Public methods

        public void CreatePickUp(Vector3 blockPosition)
        {
            if (_pickUps == null || _pickUps.Length == 0)
            {
                return;
            }

            int chance = Random.Range(0, 101);

            if (_pickUpDropChance >= chance)
            {
                InstantiateRandomPickUp(blockPosition);
            }
        }

        #endregion

        #region Private methods

        private void InstantiateRandomPickUp(Vector3 blockPosition)
        {
            int weightSum = 0;

            foreach (PickupSpawnData spawnData in _pickUps)
            {
                weightSum += spawnData.SpawnWeight;
            }

            int randomWeight = Random.Range(0, weightSum + 1);
            int currentWeight = 0;

            for (int i = 0; i < _pickUps.Length; i++)
            {
                currentWeight += _pickUps[i].SpawnWeight;

                if (currentWeight >= randomWeight)
                {
                    Instantiate(_pickUps[i].PickUpPrefab, blockPosition, Quaternion.identity);

                    return;
                }
            }
        }

        #endregion

        #region Local data

        [Serializable]
        private class PickupSpawnData
        {
            #region Variables

            public PickUp PickUpPrefab;
            public int SpawnWeight;

            #endregion
        }

        #endregion
    }
}