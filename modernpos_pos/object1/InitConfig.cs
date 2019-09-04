﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class InitConfig
    {
        public String hostDB = "", userDB = "", passDB = "", nameDB = "", portDB = "";
        public String hostDBEx = "", userDBEx = "", passDBEx = "", nameDBEx = "", portDBEx = "";
        public String hostDBIm = "", userDBIm = "", passDBIm = "", nameDBIm = "", portDBIm = "";
        public String hostFTP = "", userFTP = "", passFTP = "", portFTP = "", pathImageScan = "", folderFTP="", usePassiveFTP = "";

        public String grdViewFontSize = "", grdViewFontName = "", themeApplication = "", txtFocus = "", grfRowColor = "", grfRowGreen = "", grfRowRed = "", grfRowYellow = "";

        public String sticker_donor_takeout_panel1 = "", sticker_donor_height = "", sticker_donor_start_x = "", sticker_donor_start_y = "", sticker_donor_barcode_height = "", sticker_donor_barcode_gap_x = "", sticker_donor_barcode_gap_y = "", sticker_donor_gap="";
        public String statusAppToGo = "", patientaddpanel1weight="", barcode_width_minus="", status_show_border="";
        public String themeDonor = "",themeDonor1 = "", printerBill="";
        public String timerlabreqaccept = "", timerImgScanNew="", ShareFile="", ShareFileSMBFolder="";

        public String TileFoodsPriceColor = "", TileFoodsNameColor = "";
        public String VNEip = "", VNEwebapi = "", statusShowListBox1="", takeouttilhorizontalsize="", takeouttilverticalsize="", pnOrderborderstyle="", TileFoodsOrientation="", TileFoodsBackColor="", statuspaytoclose="";
        public String statushidenavigator = "", statusHide="", statusDrinkHide="", tabFoodsAlign="", tabFoodsAreaSpacing="",tabFoodsIndent="", tabFoodsSpacing="", tabFoodsLook = "", tabFoodsPaddingHeight="", tabFoodsPaddingWidth="", tabFoodsAreaColor="", tabFoodsBackGroundColor = "", tabFoodsForeGroundColor = "", tabFoodsCustom="";
        public String VNEtimer = "", TileFoodsCatOrientation="", TileFoodstakeouttilverticalsize="", TileFoodstakeouttilhorizontalsize="", VNEopName="";
    }
}
