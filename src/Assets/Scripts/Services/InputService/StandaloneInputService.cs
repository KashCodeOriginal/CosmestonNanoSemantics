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

        private static Vector2 GetUnityAxis() =>
            new (UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
    }
}
