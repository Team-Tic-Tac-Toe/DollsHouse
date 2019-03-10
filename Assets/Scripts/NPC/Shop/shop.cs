using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class shop : MonoBehaviour {

    int displayGoods;//진열될 물건의 개수 
    //그리드 레이아웃에 적용됩니다
    int goods ;// 해당 상점에 데이터상 존재하는 물건의 개수
    //이건 내용상으로 존재하는 물건의 개수입니다.
    int availableGoods;//현재 살 수 있는 물건의 개수
    //상점에서 살 수 있는 물건의 개수-구매한 물건의 개수
    MerchantType merchantType;

    public enum MerchantType
    {
        dollMaster,
        coreMaster
    }
    //상인의 타입에 따라 상점 내용이 다름

    public shop(int _displayGoods,int _goods,int _availableGoods,MerchantType _merchantType) {

        displayGoods = _displayGoods;
        goods = _goods;
        availableGoods = _availableGoods;
        merchantType = _merchantType;
       
    }


}
