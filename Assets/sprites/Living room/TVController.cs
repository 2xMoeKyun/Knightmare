using System.Collections;
using UnityEngine;

public class TVController : MonoBehaviour
{
    public DialogueTrigger dt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "tv":
                CoroutineTemplate("TVOutput");
                break;
            case "tvshroom":
                CoroutineTemplate("TVShroomOutput");
                break;
        }
    }

    private void CoroutineTemplate(string coroutineName)
    {

        StartCoroutine(coroutineName);

    }

    private IEnumerator TVShroomOutput()
    {
        dt.SetText("ᔑ ʖ ᓵ ↸ ᒷ ⎓ ╎ ⋮ ⊣ ⍑ ╎リ↸", delayClean: 0.5f);
        yield return new WaitForSeconds(2f);
        dt.SetText("!¡ᒷ ||ᔑ∷↸リ∴∴リ ↸⍑ᔑリᒷ", delayClean: 2f);
        yield return new WaitForSeconds(6f);
        dt.SetText("⍑∷ᔑ ᓭ↸ ∴ᒲ╎ℸ リℸリ∷ᔑ ᓭ!", delayClean: 2f);
        yield return new WaitForSeconds(6f);
        dt.SetText("リᔑℸ∷ ╎ᓭ リリᓭリ∷リ ⍑リリ", delayClean: 0.8f);
        yield return new WaitForSeconds(2f);
        dt.SetText("⊣リ⍑ ⊣ᓭ⍑リリ ℸᒷリᔑ⊣", delayClean: 0.5f);
        yield return new WaitForSeconds(2f);
        dt.SetText("⊣リ⍑ ⊣ᓭ⍑リリ ℸᒷリᔑ⊣", delayClean: 0.5f);

    }

    private IEnumerator TVOutput()
    {
        dt.SetText("Bla-bla-bla", delayClean: 0.5f);
        yield return new WaitForSeconds(2f);
        dt.SetText("A suspicious man resembling \n a knight was spotted today", delayClean: 2f);
        yield return new WaitForSeconds(6f);
        dt.SetText("Witnesses claim to have seen \nhim at the pharmacy", delayClean: 2f);
        yield return new WaitForSeconds(6f);
        dt.SetText("further in the news", delayClean: 0.8f);
        yield return new WaitForSeconds(2f);
        dt.SetText("Bla-bla-bla", delayClean: 0.5f);
        yield return new WaitForSeconds(2f);
        dt.SetText("Bla-bla-bla", delayClean: 0.5f);

    }

}
