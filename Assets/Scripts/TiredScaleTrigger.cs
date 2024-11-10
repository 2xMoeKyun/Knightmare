using UnityEngine;
using UnityEngine.UI;

public class TiredScaleTrigger : MonoBehaviour
{
    public Image scale;
    public float scaleAmount = 100f;


    public void TakeTire(float tirednress)
    {
        scaleAmount -= tirednress;
        scale.fillAmount = scaleAmount / 100f;
    }

    public void GetTire(float tirednress)
    {
        scaleAmount += tirednress;
        scale.fillAmount = scaleAmount / 100f;
    }

}
