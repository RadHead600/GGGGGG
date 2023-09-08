using UnityEngine;

public class UpgradeCanvas : MonoBehaviour
{
    private void LateUpdate()
    {
        gameObject.SetActive(false);
        enabled = false;
    }
}
