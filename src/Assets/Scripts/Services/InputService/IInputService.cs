using UnityEngine;

namespace KasherOriginal.Services.Input
{
    public interface IInputService : IService
    {
        public Vector2 Axis { get; }

        public bool IsSpaceButtonDown();
    }
}