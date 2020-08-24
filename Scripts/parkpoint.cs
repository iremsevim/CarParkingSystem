using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parkpoint : MonoBehaviour
{
    public LayerMask carmask;
    public LayerMask parkpointmask;

    public SpriteRenderer spriteRenderer;
    public Color32 parkcolor;
    public Color32 normal;

       void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        parkcontrol();
    }

    private void parkcontrol()
    {
      Collider2D hittedcar=Physics2D.OverlapBox(transform.position,transform.localScale,0,carmask);
      if(hittedcar==null)return;

      CarController hittedcarcontroller=hittedcar.GetComponent<CarController>();
      
      Collider2D[] hittedparkpoints=Physics2D.OverlapBoxAll(transform.position,transform.localScale,0,parkpointmask);


      bool parkisok=true;  

      foreach(var item in hittedcarcontroller.parkobjects)
      {
          bool result=false;
          foreach(var item2 in hittedparkpoints)
          {
              if(item==item2)
              {
                  result=true;
                  break;
              }
          }
          if(result==false)
          {
              parkisok=false;
              break;
          }
      }   
       
       if(parkisok)
       {
           spriteRenderer.color=parkcolor;
       }
       else
       {
           spriteRenderer.color=normal;
       }

    }
}
