using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Collections.Generic;

namespace Yoolax.Framework
{
	public class GoldManager : SingletonNormal<GoldManager>
	{
		//References
		[Header("UI references")]
		[SerializeField] GoldFly animatedCoinPrefab;

		[Space]
		[Header("Available coins : (coins to pool)")]
		[SerializeField] int maxCoins;
		Queue<GoldFly> coinsQueue = new Queue<GoldFly>();


		[Space]
		[Header("Animation settings")]
		[SerializeField] [Range(0.5f, 0.9f)] float minAnimDuration;
		[SerializeField] [Range(0.9f, 2f)] float maxAnimDuration;

		[SerializeField] Ease easeType;
		[SerializeField] float spread;

        public override void Awake()
        {
            base.Awake();
			//prepare pool
			PrepareCoins();
		}

        void PrepareCoins()
		{
			GoldFly coin = null;
			for (int i = 0; i < maxCoins; i++)
			{
				coin = Instantiate(animatedCoinPrefab);
				coin.Init(this);
				coin.transform.parent = transform;
				coin.gameObject.SetActive(false);
				coinsQueue.Enqueue(coin);
			}
		}

		void Animate(Vector3 collectedCoinPosition, Transform _target, int amount, float scale, Transform parent = null)
		{
			for (int i = 0; i < amount; i++)
			{
				//check if there's coins in the pool
				if (coinsQueue.Count > 0)
				{
					//extract a coin from the pool
					GoldFly coin = coinsQueue.Dequeue();
					coin.gameObject.SetActive(true);

					if (parent != null)
					{
						coin.transform.SetParent(parent);
					}
					//move coin to the collected coin pos
					coin.transform.position = _target.position + new Vector3(Random.Range(-spread, spread), 0f, 0f);
					coin.transform.localScale = new Vector3(scale, scale, scale);

					//animate coin to target position
					float duration = Random.Range(minAnimDuration, maxAnimDuration);
					coin.transform.DOMove(collectedCoinPosition, duration)
					.SetEase(easeType)
					.OnComplete(() => {
					//executes whenever coin reach target position
					coin.Push(); 
				  // coinsQueue.Enqueue(coin);
						//AudioManager.Instance.PlayAudio_GoldCollect();
					});
				}
			}
		}

		public void SpawnGold(Vector3 collectedCoinPosition, Transform _target, float scale, int amount = 7)
		{
			Animate(collectedCoinPosition, _target, amount, scale);
		}
		public void SpawnGoldUI(Vector3 collectedCoinPosition, Transform _target, Transform parent, float scale, int amount = 7)
		{
			Animate(collectedCoinPosition, _target, amount, scale, parent);
		}
		public void HideGold()
        {
			GoldFly coin;

			for (int i = 0; i < coinsQueue.Count; i++)
            {
				coin = coinsQueue.Dequeue();
				coin.gameObject.SetActive(false);
			}
        }
	}
}
