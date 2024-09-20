using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text stackText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void UpdateStackCount(int count)
    {
        stackText.text = "Blocks: " + count.ToString();
    }
}
