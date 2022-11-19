using UnityEngine;

namespace KasherOriginal.Factories.EnvironmentFactory
{
    public interface IEnvironmentFactory : IEnvironmentFactoryInfo, IFactory
    {
        public GameObject CreateInstance(GameObject prefab, Vector3 spawnPoint);
    }
}

