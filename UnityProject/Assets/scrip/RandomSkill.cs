using System.Collections;
using UnityEngine.UI;
using UnityEngine;


namespace crow
{
    public class RandomSkill : MonoBehaviour
    {

        [Header("圖片區域")]
        public Sprite[] spritesBlur;
        public Sprite[] spritesSkill;
        private string[] nameskill = { "連續射擊","正向箭","背向箭","側向箭","血量增加","攻擊增加","攻速增加","暴擊增加" };
       
        [Header("速度"), Range(0.01f, 1f)]
        public float speed = 0.04f;
        [Header("模擬圖片執行次數"), Range(1, 30)]
        public float count = 3;

        public AudioClip soundScroll;
        public AudioClip soundSkill;

        private AudioSource aud;
        private Button btn;
        private Image imageSkill;
        private Text textName;
        private GameObject skillPanel;
        private int index;

        private void Start()
        {
            aud = GetComponent<AudioSource>();
            imageSkill = GetComponent<Image>();
            btn = GetComponent<Button>();
            textName = transform.GetChild(0).GetComponent<Text>();
            skillPanel = GameObject.Find("隨機技能");

            btn.onClick.AddListener(ChooseSkill);

            StartCoroutine(RandomEffect());
        }

        private IEnumerator RandomEffect()
        {
            btn.interactable = false;
            for (int j = 0; j < count; j++)
            {
                for (int i = 0; i < spritesBlur.Length; i++)
                {
                    aud.PlayOneShot(soundScroll, 0.5f);
                    imageSkill.sprite = spritesBlur[i];
                    yield return new WaitForSeconds(speed);
                }
            }
            btn.interactable = true;
            index =Random.Range(0, spritesSkill.Length);
            imageSkill.sprite = spritesSkill[index];
            aud.PlayOneShot(soundSkill, 0.5f);
            textName.text = nameskill[index];
        }
        private void ChooseSkill()
        {
            skillPanel.SetActive(false);
            print(nameskill[index]);
        }
    }
}
