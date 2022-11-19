using UnityEngine;

namespace KasherOriginal.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        private const string SpaceButton = "Jump";
        protected const string MouseX = "Mouse X";
        protected const string MouseY = "Mouse Y";

        public abstract Vector2 Axis
        {
            get;
        }

        public abstract Vector2 MouseAxis
        {
            get;
        }
        
        public bool IsSpaceButtonDown()
        {
            return SimpleInput.GetButtonDown(SpaceButton);
        }

        protected Vector2 SimpleInputAxis()
        {
            return new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
        }
        
        protected Vector2 SimpleMouseInputAxis()
        {
            return new Vector2(SimpleInput.GetAxis(MouseX), SimpleInput.GetAxis(MouseY));
        }
    }
}