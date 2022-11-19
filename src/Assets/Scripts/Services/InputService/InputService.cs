using UnityEngine;

namespace KasherOriginal.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        protected const string SpaceButton = "Jump";

        public abstract Vector2 Axis
        {
            get;
        }
        
        public bool IsSpaceButtonDown()
        {
            return SimpleInput.GetButtonDown(SpaceButton);
        }

        public Vector2 SimpleInputAxis()
        {
            return new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
        }
    }
}