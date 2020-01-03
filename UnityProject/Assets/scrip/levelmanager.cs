using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class levelmanager : MonoBehaviour
{
    public GameObject objLight;

    public GameObject randomSkill;

    [Header("是否自動顯示隨機技能")]
    public bool autoShowSkill;
    [Header("是否自動開門")]
    public bool autoOpenDoor;

    private Animator door;
    private Image imgCross;

    private void Start()
    {
        door = GameObject.Find("木頭門").GetComponent<Animator>();
        imgCross = GameObject.Find("轉場效果").GetComponent<Image>();
        if (autoShowSkill) ShowSkill();
        if (autoOpenDoor) Invoke("OpenDoor", 6);

    }

    private void ShowSkill()
    {
        randomSkill.SetActive(true);
    }

    private void OpenDoor()
    {
        objLight.SetActive(true);
        door.SetTrigger("開門觸發");
    }

    public IEnumerable Nextlevel()
    {
        print("仔入下一關");

        imgCross.color += new Color(1, 1, 1, 0.01f);
        yield return new WaitForSeconds(0.01f);
    }

}
