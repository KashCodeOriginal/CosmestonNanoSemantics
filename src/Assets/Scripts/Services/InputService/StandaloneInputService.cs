using UnityEngine;

namespace KasherOriginal.Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                var input = SimpleInputAxis();

                if (input == Vector2.zero)
                {
                    input = GetUnityAxis();
                }

                return input;
            }
        }

        public override Vector2 MouseAxis
        {
            get
            {
                var input = SimpleMouseInputAxis();

                if (input == Vector2.zero)
                {
                    input = GetUnityMouseAxis();
                }

                return input;
            }
        }

        private static Vector2 GetUnityAxis() =>
            new (UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
        
        private static Vector2 GetUnityMouseAxis() =>
            new (UnityEngine.Input.GetAxis(MouseX), UnityEngine.Input.GetAxis(MouseY));
    }
}
