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
        public Image imageSkill;
        [Header("速度"), Range(0.01f, 1f)]
        public float speed = 0.2f;
        private void Start()
        {
            StartCoroutine(RandomEffect());
        }
        private IEnumerator RandomEffect()
        {

            for (int i = 0; i < spritesBlur.Length; i++)
            {
                imageSkill.sprite = spritesBlur[i];
                yield return new WaitForSeconds(speed);
            }
        }
    }
}
