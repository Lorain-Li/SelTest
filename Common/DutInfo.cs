using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DutInfo
    {
        public string SN, TEST_START_TIME, TEST_END_TIME;
        //SF 变量
        public string SF_MB_NUM, SF_MB_BTB, SF_LINE, SF_Station, SF_MAC, SF_STATUS, SF_REGION, SF_COUNTRY, SF_EMMCSIZE, SF_BTMAC, SF_WLMAC;
        public string SF_PN, SF_SKU, SF_WO, SF_REPAIR, SF_DSN, SF_TOP_B, SF_WO_Model, SF_TOP_MIC, SF_TOP_BPN, SF_TOP_COLOR, SF_F_IMAGE, SF_F_OTP;
        public string SF_FSI_V, SF_FCT_V, SF_MLB_RAM, SF_MLB_ROM, SF_COLOR, SF_FCT_VER, SF_FCT_RF_VER, SF_FSI_VER, SF_FSI_FDV, SF_REFH_VER, SF_LANG;
        public string SF_MLB_WIFI, SF_User_code, SF_Group_code, SF_SF_Routing_CHK, SF_SPK_NUM, SF_FailCount, SF_1FixtureID, SF_2FixtureID, SF_BSSID_MAC;
        //DUT 变量
        public string DUT_MB_NUM, DUT_MB_BTB, DUT_LINE, DUT_Station, DUT_MAC, DUT_STATUS, DUT_REGION, DUT_COUNTRY, DUT_EMMCSIZE, DUT_BTMAC, DUT_WLMAC;
        public string DUT_PN, DUT_SKU, DUT_WO, DUT_REPAIR, DUT_DSN, DUT_TOP_B, DUT_WO_Model, DUT_TOP_MIC, DUT_TOP_BPN, DUT_TOP_COLOR, DUT_F_IMAGE, DUT_F_OTP;
        public string DUT_FSI_V, DUT_FCT_V, DUT_MLB_RAM, DUT_MLB_ROM, DUT_COLOR, DUT_FCT_VER, DUT_FCT_RF_VER, DUT_FSI_VER, DUT_FSI_FDV, DUT_REFH_VER, DUT_LANG;
        public string DUT_MLB_WIFI, DUT_User_code, DUT_Group_code, DUT_DUT_Routing_CHK, DUT_SPK_NUM, DUT_FailCount, DUT_1FixtureID, DUT_2FixtureID, DUT_BSSID_MAC;
    }
}
