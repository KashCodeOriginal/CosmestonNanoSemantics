﻿using UnityEngine;
using System.Collections.Generic;

namespace KasherOriginal.Factories
{
    public interface IFactory
    {
        public void DestroyInstance(GameObject gameObject);
        public void DestroyAllInstances();
        public void DestroyAllInstances<T>(List<T> list) where T : Object;
    }
}