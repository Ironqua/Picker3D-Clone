using DG.Tweening;
using TMPro;
using UnityEngine;

public class PlayerMeshController : MonoBehaviour
{
private PlayerMeshData _data;

  [SerializeField] private new Renderer renderer;
  [SerializeField] private TextMeshPro scaleText;
  [SerializeField] private ParticleSystem confeti;




internal void SetData(PlayerMeshData data)
{
    _data = data;
}

internal void ScaleUpPlayer()
{
    renderer.gameObject.transform.DOScaleX(_data.ScaleCounter,1f).SetEase(Ease.Flash);

}

internal void ScaleUpText()
{
   // scaleText.DOFade(1,0).SetEase(Ease.Flash).OnComplete(()=>
    //{
       // scaleText.DOFade(0,0.3f).SetDelay(0.35f);
     //   scaleText.rectTransform.DOAnchorPosY(1f,0.65f).SetEase(Ease.Linear); 
   // });
}


internal void PlayConfeti()
{
   // confeti.Play();
  
}

internal void OnReset()
{
    renderer.gameObject.transform.DOScaleX(1,1).SetEase(Ease.Linear);
}









}











