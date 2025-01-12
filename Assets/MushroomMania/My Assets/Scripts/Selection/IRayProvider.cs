using UnityEngine;

// File from Niall's repository https://github.com/nmcguinness/2024-25-GD3A-IntroToUnity

namespace SelectionSystem
{
    /// <summary>
    /// Any class that implements this interface can provide a Ray.
    /// </summary>
    public interface IRayProvider
    {
        Ray CreateRay();
    }
}