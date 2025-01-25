using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adsorption : MonoBehaviour
{
 public float attractionSpeed = 5f; // 吸附速度
    public float attractionRadius = 2f; // 吸附范围半径

    private void Update()
    {
        AttractCoinsInRange();
    }
    private void AttractCoinsInRange()
    {
        // 检测吸附范围内的所有金币/带泡泡的垃圾 tag为coin/或者可以自行修改
        Collider[] coins = Physics.OverlapSphere(transform.position, attractionRadius);
        foreach (var coin in coins)
        {
            if (coin.CompareTag("coin"))//需要修改
            {
                StartCoroutine(AttractCoin(coin.transform));
            }
        }
    }

    private System.Collections.IEnumerator AttractCoin(Transform coin)
    {
        while (coin != null && Vector3.Distance(transform.position, coin.position) > 0.1f)
        {
            // 逐渐将金币/带泡泡的垃圾移动到飞船位置 
            coin.position = Vector3.MoveTowards(coin.position, transform.position, attractionSpeed * Time.deltaTime);
            yield return null;
        }

        // 吸附完成后销毁金币/带泡泡的垃圾
        if (coin != null)
        {
            Destroy(coin.gameObject);
        }
    }
}
