using System;

namespace AircraftClass
{
    //тип целей
    enum target_type
    {
        TN,//ТН
        AC,//АЦ
        PAP,//ПАП
        PPP,//ППП
        NIAO,//НЯО
        NSNS,//НСНС
        SNS,//СНС
        SR,//СР
        BC,//БЦ
        SB,//СБ
        SKR,//СКР
        BPLA,//БПЛА
        V,//В
        TI,//ТИ
        SBRLO,//СБРЛО
        SRUK//СРУК
    };
    //типы своих самолётов
    enum ally_type
    {
        TN,//ТН
        I,//И
        IB,//ИБ
        FB,//ФБ
        VTS,//ВТС
        SR,//СР
        VR,//ВР
        SRTR,//СРТР
        AK_RLDN,//АК РЛДН
        DB,//ДБ
        DPLA,//ДПЛА
        SS,//СС
        VRD,//ВРД
        SRD,//СРД
        ZS,//ЗС
        KS//КС
    };

    class Aircraft
    {
        private bool nationality;       //гос. принадлежность
        private string aircraft_type;   //тип вздушного судна
        private int level_height;       //эшелон высоты
        private int source_number;      //номер источника информации
        private int target_number;      //номер цели
        private bool command;           //на уничтожение
        private bool ativity;           //признак действия
        public Aircraft();
        public ~Aircraft();
    };

}