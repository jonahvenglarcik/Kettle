﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asd : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
       Debug.Log("Release");
       Instantiate(prefab, transform.position, Quaternion.identity);
    }

    private void asdasd()
    {
        Debug.Log("Asd");
    }
}
/*
 * True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160022.601;20180516-160022.000;48.35731967;15.61056602;3.2;195.2;146.0;3.4;True;13;20
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160023.104;20180516-160023.000;48.35730900;15.61056956;3.2;195.2;134.4;3.9;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160023.615;20180516-160023.000;48.35730900;15.61056956;3.2;195.2;145.5;3.9;True;13;20
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160024.117;20180516-160024.000;48.35729953;15.61057591;3.2;195.2;156.5;4.0;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160024.618;20180516-160024.000;48.35729953;15.61057591;3.2;195.2;140.4;4.0;True;13;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160025.121;20180516-160025.000;48.35729119;15.61058150;3.2;152.1;149.7;3.2;True;14;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160025.623;20180516-160025.000;48.35729119;15.61058150;3.2;152.1;145.2;3.2;True;14;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160026.127;20180516-160026.000;48.35728328;15.61058764;3.2;151.9;88.8;4.4;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160026.634;20180516-160026.000;48.35728328;15.61058764;3.2;151.9;145.9;4.4;True;13;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160027.136;20180516-160027.000;48.35727312;15.61059510;3.2;148.8;146.7;5.3;True;12;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160027.638;20180516-160027.000;48.35727312;15.61059510;3.2;148.8;146.4;5.3;True;12;20
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160028.138;20180516-160028.000;48.35726257;15.61060151;3.2;148.8;142.5;3.8;True;12;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160028.641;20180516-160028.000;48.35726257;15.61060151;3.2;148.8;154.7;3.8;True;12;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160029.146;20180516-160029.000;48.35725369;15.61060649;3.2;145.3;153.3;3.3;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160029.653;20180516-160029.000;48.35725369;15.61060649;3.2;145.3;145.2;3.3;True;13;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160030.154;20180516-160030.000;48.35724373;15.61061146;3.2;145.9;165.7;3.9;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160030.656;20180516-160030.000;48.35724373;15.61061146;3.2;145.9;161.0;3.9;True;13;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160031.157;20180516-160031.000;48.35723240;15.61061715;3.2;155.9;164.8;4.2;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160031.660;20180516-160031.000;48.35723240;15.61061715;3.2;155.9;149.3;4.2;True;13;21
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160032.162;20180516-160032.000;48.35722023;15.61062373;3.2;155.9;144.3;4.4;True;12;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160032.666;20180516-160032.000;48.35722023;15.61062373;3.2;155.9;138.2;4.4;True;12;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160033.174;20180516-160033.000;48.35720927;15.61063280;3.2;131.1;131.7;4.6;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160033.676;20180516-160033.000;48.35720927;15.61063280;3.2;131.1;107.9;4.6;True;13;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160034.178;20180516-160034.000;48.35720162;15.61064497;3.2;130.4;121.5;4.1;True;12;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160034.678;20180516-160034.000;48.35720162;15.61064497;3.2;130.4;89.1;4.1;True;12;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160035.182;20180516-160035.000;48.35719726;15.61065921;3.2;130.7;69.6;3.4;True;14;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160035.686;20180516-160035.000;48.35719726;15.61065921;3.2;130.7;95.2;3.4;True;14;21
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160036.192;20180516-160036.000;48.35719697;15.61067309;3.2;130.7;57.4;3.3;True;12;19
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160036.693;20180516-160036.000;48.35719697;15.61067309;3.2;130.7;35.1;3.3;True;12;19
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160037.192;20180516-160037.000;48.35719910;15.61069071;3.2;130.7;66.4;5.1;True;14;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160037.698;20180516-160037.000;48.35719910;15.61069071;3.2;130.7;67.8;5.1;True;14;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160038.200;20180516-160038.000;48.35720178;15.61071041;3.2;88.4;64.3;4.1;True;12;19
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160038.701;20180516-160038.000;48.35720178;15.61071041;3.2;88.4;85.6;4.1;True;12;19
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160039.206;20180516-160039.000;48.35720397;15.61072808;3.2;87.6;95.5;4.2;True;14;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160039.711;20180516-160039.000;48.35720397;15.61072808;3.2;87.6;63.8;4.2;True;14;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160040.215;20180516-160040.000;48.35720968;15.61074571;3.2;59.3;55.5;4.6;True;14;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160040.717;20180516-160040.000;48.35720968;15.61074571;3.2;59.3;55.4;4.6;True;14;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160041.218;20180516-160041.000;48.35721699;15.61076374;3.2;59.4;25.9;4.9;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160041.721;20180516-160041.000;48.35721699;15.61076374;3.2;59.4;36.3;4.9;True;13;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160042.222;20180516-160042.000;48.35722466;15.61077952;3.2;59.3;48.5;3.9;True;12;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160042.728;20180516-160042.000;48.35722466;15.61077952;3.2;59.3;67.4;3.9;True;12;20
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160043.233;20180516-160043.000;48.35723087;15.61079570;3.2;59.3;73.2;4.5;True;12;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160043.735;20180516-160043.000;48.35723087;15.61079570;3.2;59.3;53.1;4.5;True;12;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160044.237;20180516-160044.000;48.35723530;15.61081424;3.2;74.9;35.1;4.2;True;12;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160044.740;20180516-160044.000;48.35723530;15.61081424;3.2;74.9;26.8;4.2;True;12;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160045.247;20180516-160045.000;48.35724023;15.61083424;3.2;73.6;49.8;4.8;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160045.746;20180516-160045.000;48.35724023;15.61083424;3.2;73.6;91.0;4.8;True;13;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160046.251;20180516-160046.000;48.35724687;15.61085436;3.2;74.0;83.7;4.6;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160046.754;20180516-160046.000;48.35724687;15.61085436;3.2;74.0;47.2;4.6;True;13;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160047.256;20180516-160047.000;48.35725462;15.61087391;3.2;61.2;45.5;5.1;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160047.758;20180516-160047.000;48.35725462;15.61087391;3.2;61.2;41.2;5.1;True;13;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160048.260;20180516-160048.000;48.35726346;15.61089336;3.2;60.8;34.7;4.9;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160048.762;20180516-160048.000;48.35726346;15.61089336;3.2;60.8;61.2;4.9;True;13;20
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160049.267;20180516-160049.000;48.35727289;15.61090989;3.2;60.8;51.0;4.9;True;14;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160049.773;20180516-160049.000;48.35727289;15.61090989;3.2;60.8;46.6;4.9;True;14;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160050.275;20180516-160050.000;48.35728156;15.61092367;3.2;52.6;47.6;3.7;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160050.783;20180516-160050.000;48.35728156;15.61092367;3.2;52.6;30.2;3.7;True;13;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160051.277;20180516-160051.000;48.35728585;15.61093233;3.2;52.9;47.0;1.8;True;14;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160051.781;20180516-160051.000;48.35728585;15.61093233;3.2;52.9;32.3;1.8;True;14;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160052.285;20180516-160052.000;48.35729044;15.61094104;3.2;52.8;24.3;2.9;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160052.787;20180516-160052.000;48.35729044;15.61094104;3.2;52.8;50.5;2.9;True;13;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160053.292;20180516-160053.000;48.35729911;15.61094936;3.2;28.9;30.5;4.4;True;14;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160053.796;20180516-160053.000;48.35729911;15.61094936;3.2;28.9;351.5;4.4;True;14;21
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160054.300;20180516-160054.000;48.35730627;15.61095028;3.2;28.9;10.5;0.0;True;12;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160054.799;20180516-160054.000;48.35730627;15.61095028;3.2;28.9;359.7;0.0;True;12;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160055.304;20180516-160055.000;48.35731171;15.61094945;3.2;27.5;339.1;2.8;True;12;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160055.807;20180516-160055.000;48.35731171;15.61094945;3.2;27.5;356.9;2.8;True;12;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160056.312;20180516-160056.000;48.35732097;15.61095083;3.2;26.7;354.8;3.9;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160056.815;20180516-160056.000;48.35732097;15.61095083;3.2;26.7;356.7;3.9;True;13;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160057.317;20180516-160057.000;48.35733145;15.61095196;3.2;11.9;333.9;4.2;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160057.818;20180516-160057.000;48.35733145;15.61095196;3.2;11.9;310.1;4.2;True;13;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160058.325;20180516-160058.000;48.35734171;15.61095108;3.2;12.0;302.8;3.5;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160058.823;20180516-160058.000;48.35734171;15.61095108;3.2;12.0;298.4;3.5;True;13;21
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160059.326;20180516-160059.000;48.35734994;15.61094319;3.2;12.0;294.3;4.7;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160059.828;20180516-160059.000;48.35734994;15.61094319;3.2;12.0;282.9;4.7;True;13;21
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160100.336;20180516-160100.000;48.35735683;15.61093094;3.2;12.0;261.8;3.5;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160100.837;20180516-160100.000;48.35735683;15.61093094;3.2;12.0;264.1;3.5;True;13;21
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160101.340;20180516-160101.000;48.35736042;15.61091608;3.2;12.0;233.4;4.2;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160101.842;20180516-160101.000;48.35736042;15.61091608;3.2;12.0;228.6;4.2;True;13;21
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160102.345;20180516-160102.000;48.35736178;15.61090073;3.2;12.0;235.7;3.6;True;11;19
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160102.852;20180516-160102.000;48.35736178;15.61090073;3.2;12.0;240.3;3.6;True;11;19
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160103.353;20180516-160103.000;48.35736124;15.61088839;4.3;11.9;236.8;2.5;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160103.856;20180516-160103.000;48.35736124;15.61088839;4.3;11.9;244.1;2.5;True;13;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160104.357;20180516-160104.000;48.35735806;15.61088010;3.2;12.1;241.4;3.2;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160104.859;20180516-160104.000;48.35735806;15.61088010;3.2;12.1;224.2;3.2;True;13;21
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160105.363;20180516-160105.000;48.35735479;15.61087438;3.2;12.1;212.9;1.5;True;12;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160105.866;20180516-160105.000;48.35735479;15.61087438;3.2;12.1;236.9;1.5;True;12;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160106.371;20180516-160106.000;48.35735009;15.61086831;4.3;12.2;238.8;2.4;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160106.875;20180516-160106.000;48.35735009;15.61086831;4.3;12.2;239.6;2.4;True;13;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160107.378;20180516-160107.000;48.35734364;15.61085805;4.3;12.3;254.6;3.3;True;12;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160107.879;20180516-160107.000;48.35734364;15.61085805;4.3;12.3;244.4;3.3;True;12;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160108.382;20180516-160108.000;48.35733714;15.61084603;4.3;239.3;242.4;3.6;True;12;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160108.884;20180516-160108.000;48.35733714;15.61084603;4.3;239.3;228.2;3.6;True;12;20
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160109.392;20180516-160109.000;48.35733051;15.61083262;4.3;239.3;240.9;4.5;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160109.894;20180516-160109.000;48.35733051;15.61083262;4.3;239.3;261.5;4.5;True;13;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160110.396;20180516-160110.000;48.35732405;15.61081808;3.2;241.8;228.4;4.5;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160110.897;20180516-160110.000;48.35732405;15.61081808;3.2;241.8;247.4;4.5;True;13;21
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160111.397;20180516-160111.000;48.35731759;15.61080307;3.2;241.8;252.3;4.1;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160111.903;20180516-160111.000;48.35731759;15.61080307;3.2;241.8;229.3;4.1;True;13;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160112.406;20180516-160112.000;48.35731117;15.61078757;3.2;225.3;231.6;4.7;True;12;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160112.912;20180516-160112.000;48.35731117;15.61078757;3.2;225.3;229.6;4.7;True;12;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160113.415;20180516-160113.000;48.35730433;15.61077300;4.3;225.8;219.0;4.0;True;13;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160113.916;20180516-160113.000;48.35730433;15.61077300;4.3;225.8;229.6;4.0;True;13;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160114.418;20180516-160114.000;48.35729859;15.61075818;4.3;226.4;243.0;3.9;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160114.921;20180516-160114.000;48.35729859;15.61075818;4.3;226.4;246.3;3.9;True;13;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160115.424;20180516-160115.000;48.35729371;15.61074372;4.3;226.0;241.2;3.6;True;14;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160115.927;20180516-160115.000;48.35729371;15.61074372;4.3;226.0;241.1;3.6;True;14;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160116.433;20180516-160116.000;48.35729009;15.61073303;4.3;226.1;236.7;2.4;True;14;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160116.932;20180516-160116.000;48.35729009;15.61073303;4.3;226.1;232.0;2.4;True;14;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160117.434;20180516-160117.000;48.35728401;15.61071865;3.2;238.0;247.4;4.3;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160117.939;20180516-160117.000;48.35728401;15.61071865;3.2;238.0;273.2;4.3;True;13;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160118.441;20180516-160118.000;48.35727767;15.61070204;3.2;238.3;285.7;3.8;True;14;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160118.944;20180516-160118.000;48.35727767;15.61070204;3.2;238.3;297.7;3.8;True;14;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160119.451;20180516-160119.000;48.35727551;15.61068616;3.2;286.2;279.3;3.5;True;14;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160119.955;20180516-160119.000;48.35727551;15.61068616;3.2;286.2;297.5;3.5;True;14;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160120.456;20180516-160120.000;48.35727733;15.61067170;3.2;286.8;336.4;3.6;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160120.959;20180516-160120.000;48.35727733;15.61067170;3.2;286.8;306.9;3.6;True;13;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160121.460;20180516-160121.000;48.35728535;15.61065767;3.2;287.3;321.7;4.7;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160121.966;20180516-160121.000;48.35728535;15.61065767;3.2;287.3;317.8;4.7;True;13;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160122.469;20180516-160122.000;48.35729518;15.61064429;3.2;318.5;319.5;4.4;True;12;19
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160122.976;20180516-160122.000;48.35729518;15.61064429;3.2;318.5;331.2;4.4;True;12;19
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160123.474;20180516-160123.000;48.35730169;15.61063340;3.2;317.8;313.9;3.0;True;12;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160123.974;20180516-160123.000;48.35730169;15.61063340;3.2;317.8;325.2;3.0;True;12;20
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160124.483;20180516-160124.000;48.35730966;15.61062234;3.2;333.1;301.0;4.3;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160124.978;20180516-160124.000;48.35730966;15.61062234;3.2;333.1;322.3;4.3;True;14;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160125.483;20180516-160125.000;48.35731803;15.61060957;3.2;332.9;334.3;4.0;True;14;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160125.986;20180516-160126.000;48.35732915;15.61060008;3.2;333.1;316.3;4.8;True;14;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160126.489;20180516-160126.000;48.35732915;15.61060008;3.2;333.1;332.4;4.8;True;14;21
True;False;True;True;gps;DeviceLocationProviderAndroidNative;20180516-160126.990;20180516-160127.000;48.35733850;15.61059320;3.2;333.2;319.6;1.6;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160127.496;20180516-160127.000;48.35733850;15.61059320;3.2;333.2;314.3;1.6;True;13;20
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160127.995;20180516-160128.000;48.35734564;15.61058772;3.2;333.2;316.3;2.5;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160128.501;20180516-160128.000;48.35734564;15.61058772;3.2;333.2;316.3;2.5;True;13;20
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160129.002;20180516-160129.000;48.35735454;15.61058529;3.2;333.2;320.2;0.0;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160129.507;20180516-160129.000;48.35735454;15.61058529;3.2;333.2;316.4;0.0;True;13;20
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160130.008;20180516-160130.000;48.35735500;15.61058407;3.2;333.2;324.3;0.0;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160130.516;20180516-160130.000;48.35735500;15.61058407;3.2;333.2;320.8;0.0;True;13;20
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160131.013;20180516-160131.000;48.35735617;15.61058407;3.2;333.2;318.8;0.0;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160131.519;20180516-160131.000;48.35735617;15.61058407;3.2;333.2;322.8;0.0;True;13;20
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160132.020;20180516-160132.000;48.35735572;15.61058070;3.2;333.2;316.1;0.0;True;12;19
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160132.526;20180516-160132.000;48.35735572;15.61058070;3.2;333.2;323.6;0.0;True;12;19
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160133.030;20180516-160133.000;48.35735554;15.61057794;4.3;333.2;325.3;0.0;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160133.534;20180516-160133.000;48.35735554;15.61057794;4.3;333.2;319.9;0.0;True;13;20
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160134.032;20180516-160134.000;48.35735418;15.61057608;4.3;333.2;320.5;0.0;True;12;19
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160134.538;20180516-160134.000;48.35735418;15.61057608;4.3;333.2;324.1;0.0;True;12;19
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160135.040;20180516-160135.000;48.35734860;15.61057281;4.3;333.2;318.6;0.0;True;14;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160135.544;20180516-160135.000;48.35734860;15.61057281;4.3;333.2;325.2;0.0;True;14;21
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160136.044;20180516-160136.000;48.35734200;15.61056864;4.3;333.2;320.8;0.0;True;14;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160136.551;20180516-160136.000;48.35734200;15.61056864;4.3;333.2;318.6;0.0;True;14;21
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160137.054;20180516-160137.000;48.35733797;15.61056640;4.3;333.2;317.9;0.0;True;11;19
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160137.563;20180516-160137.000;48.35733797;15.61056640;4.3;333.2;322.0;0.0;True;11;19
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160138.057;20180516-160138.000;48.35733722;15.61056578;4.3;333.2;319.1;0.0;True;14;21
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160138.562;20180516-160138.000;48.35733722;15.61056578;4.3;333.2;320.7;0.0;True;14;21
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160139.058;20180516-160139.000;48.35733845;15.61056596;4.3;333.2;321.5;0.0;True;12;19
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160139.570;20180516-160139.000;48.35733845;15.61056596;4.3;333.2;321.1;0.0;True;12;19
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160140.071;20180516-160140.000;48.35733937;15.61056628;4.3;333.2;320.0;0.0;True;13;20
True;False;False;False;gps;DeviceLocationProviderAndroidNative;20180516-160140.575;20180516-160140.000;48.35733937;15.61056628;4.3;333.2;318.0;0.0;True;13;20
True;False;True;False;gps;DeviceLocationProviderAndroidNative;20180516-160141.074;20180516-160141.000;48.35733973;15.61056617;4.3;333.2;315.7;0.0;True;14;21

 */
