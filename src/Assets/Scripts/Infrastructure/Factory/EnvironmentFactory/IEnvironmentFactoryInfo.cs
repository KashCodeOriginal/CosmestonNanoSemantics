using UnityEngine;
using System.Collections.Generic;

namespace KasherOriginal.Factories.EnvironmentFactory
{
    public interface IEnvironmentFactoryInfo
    {
        public List<GameObject> Instances { get; }
    }
}
