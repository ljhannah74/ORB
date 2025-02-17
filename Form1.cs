using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ORB_DLL.Orb;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
//using UniversalRateCalc;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {

        private DataTable st_cty;

        private string[] mywebs;

        private DataGridViewLinkColumn links;

        private Online_Resource orb_obj;

        private Statutes_Lookup orbStats;

        private Tax_Lookup1 orbTax;

        private ORB_DLL.Orb.orb_misc orb_misc;

        private int taxoffc_count;

        private string[] TxOffcOutput;

        private object[] picbox;

        private string target;

        private int i;

        private string dsn;

        private string dsn2;

        private StringBuilder sb;

        private StringBuilder sb2;

        private int c;

        private int c2;

        private DataTable dt;

        private DataTable dt2;

        private OleDbDataAdapter da;

        private OleDbDataAdapter da2;

        private OleDbCommandBuilder cmdBuilder;

        private OleDbCommandBuilder cmdBuilder2;

        private OleDbCommand cmd;

        private OleDbCommand cmd2;

        private string Import_File;

        private string sheetNm1;

        private string sheetNm2;

        private string sheetNm3;

        private string sheetNm4;

        private string sheetNm5;

        private string sheetNm7;


        private frmEdit EditForm;
        public Form1()
        {
            base.Load += new EventHandler(this.Form1_Load);
            this.st_cty = new DataTable();
            this.mywebs = new string[31];
            this.taxoffc_count = 1;
            this.TxOffcOutput = new string[6];
            this.picbox = new object[6];
            this.i = 0;
            this.sb = new StringBuilder();
            this.sb2 = new StringBuilder();
            this.c = 0;
            this.c2 = 0;
            this.dt = new DataTable();
            this.dt2 = new DataTable();
            this.da = new OleDbDataAdapter();
            this.da2 = new OleDbDataAdapter();
            this.cmdBuilder = new OleDbCommandBuilder();
            this.cmdBuilder2 = new OleDbCommandBuilder();
            this.cmd = new OleDbCommand();
            this.cmd2 = new OleDbCommand();
            this.Import_File = "Data\\ORB_DATABASE.xls";
            this.sheetNm1 = "orb";
            this.sheetNm2 = "taxes";
            this.sheetNm3 = "state_counsels";
            this.sheetNm4 = "statutes";
            this.sheetNm5 = "other_logins";
            this.sheetNm7 = "misc";
            this.InitializeComponent();
        }

        private void Button_EditORB_Click(object sender, EventArgs e)
        {
            this.SplitContainer1.SendToBack();
            this.SplitContainer1.Panel1Collapsed = true;
            this.SplitContainer1.Height = 480;
            this.Panel2.Visible = true;
            this.Panel2.BringToFront();
            this.TabControl1.Visible = false;
            EditForm.SetStateCounty(this.ComboBoxState.Text, this.ComboBoxCounty.Text, this.ComboBoxTaxAuth.Text, this.ComboBoxTaxType.Text);
        }

        private void Button_PolicyWarehouse_Click(object sender, EventArgs e)
        {
            (new Form4_pw()).Show();
        }

        private void Button_RateCalc_Click(object sender, EventArgs e)
        {
            //(new UniversalRateCalc.Form1()).Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            (new WindowsApplication1.Form3()).Show();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonGetLinks_Click(object sender, EventArgs e)
        {
            string state = this.ComboBoxState.Text;
            string county = this.ComboBoxCounty.Text;
            string tax = this.ComboBoxTaxAuth.Text;
            string taxtype = this.ComboBoxTaxType.Text;
            Resource_Lookup rsLookup = new Resource_Lookup();
            this.orb_obj = rsLookup.GetResources(state, county, tax);
           
                      this.txt_login_landU.Text = this.orb_obj.county_user;
                        this.txt_login_landP.Text = this.orb_obj.county_pwd;
                        this.txt_login_courtU.Text = this.orb_obj.court_user;
                        this.txt_login_courtP.Text = this.orb_obj.court_pwd;
                        this.txt_login_tax1U.Text = this.orb_obj.tax_user;
                        this.txt_login_tax1P.Text = this.orb_obj.tax_pwd;
                        this.txt_login_prothonU.Text = this.orb_obj.pro_user;
                        this.txt_login_prothonP.Text = this.orb_obj.pro_pwd;
                        this.txt_login_tax2U.Text = this.orb_obj.tax2_user;
                        this.txt_login_tax2P.Text = this.orb_obj.tax2_pwd;
                        this.txt_login_muniU.Text = this.orb_obj.muniCourt_user;
                        this.txt_login_muniP.Text = this.orb_obj.muniCourt_pwd;
                        this.txt_login_probateU.Text = this.orb_obj.probate_user;
                        this.txt_login_probateP.Text = this.orb_obj.probate_pwd;
                        this.txt_login_asrU.Text = this.orb_obj.assessor_user;
                        this.txt_login_asrP.Text = this.orb_obj.assessor_pwd;
                        this.txt_login_otherU.Text = this.orb_obj.other_user;
                        this.txt_login_otherP.Text = this.orb_obj.other_pwd;
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.county_user, "", false) != 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.county_pwd, "", false) != 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.court_user, "", false) != 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.court_pwd, "", false) != 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.tax_user, "", false) != 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.tax_pwd, "", false) != 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.pro_user, "", false) != 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.pro_pwd, "", false) != 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.tax2_user, "", false) != 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.tax2_pwd, "", false) != 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.probate_user, "", false) != 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.probate_pwd, "", false) != 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.muniCourt_user, "", false) != 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.muniCourt_pwd, "", false) != 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.assessor_user, "", false) != 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.assessor_pwd, "", false) != 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.other_user, "", false) != 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.other_pwd, "", false) != 0)
                        {
                            this.Label_user.Visible = true;
                            this.Label_pwd.Visible = true;
                        }
                        this.LabelCopy_source.Text = this.orb_obj.copy_source;
                        this.LabelIndex_source.Text = this.orb_obj.index_source;
                        this.LabelImage_date.Text = this.orb_obj.img_date;
                        this.LabelIndex_date.Text = this.orb_obj.index_date;
                        this.LabelCopyPmtType.Text = this.orb_obj.copy_pmt_method;
                        this.lbl_copyFeeAmt.Text = this.orb_obj.copyFeeAmt;
                        this.lbl_courtIndexDate.Text = this.orb_obj.courtIndexDate;
                        this.lbl_courtImgDate.Text = this.orb_obj.courtImageDate;
                        this.LabelSubNeeded.Text = this.orb_obj.sub_need;
                        this.lbl_WeSubscribe.Text = this.orb_obj.subscribed;
                        this.lbl_SubTerm.Text = this.orb_obj.subscr_term;
                        this.lbl_IndexPmtMethod.Text = this.orb_obj.index_pmt_method;
                        this.lbl_IndexFeeAmt.Text = this.orb_obj.subscrFeeAmt;
                        this.LabelUseTap.Text = this.orb_obj.tap;
                        this.LabelUseRV.Text =this.orb_obj.rv;
                        this.LabelUseDtree.Text = this.orb_obj.dtree_desk;
                        this.LabelUseIns.Text = this.orb_obj.ins;
                        this.LabelUseProps.Text = this.orb_obj.props;
                        this.LabelUseCopy.Text = this.orb_obj.doc_retrieval;
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.land_url, "", false) == 0)
                        {
                            this.LinkLabelCounty.Text = "search internet";
                            this.LinkLabelCounty.Enabled = false;
                            this.LinkLabelCounty.Visible = true;
                            this.LabelCountyURL.Visible = true;
                            this.txt_login_landU.Visible = false;
                            this.txt_login_landP.Visible = false;
                        }
                        else if (!(this.orb_obj.land_url.StartsWith("http") | this.orb_obj.land_url.StartsWith("www")))
                        {
                            this.LinkLabelCounty.Text=this.orb_obj.land_url;
                            this.LinkLabelCounty.Visible = true;
                            this.LabelCountyURL.Visible = true;
                            this.txt_login_landU.Visible = false;
                            this.txt_login_landP.Visible = false;
                        }
                        else
                        {
                            this.LinkLabelCounty.Text = "Goto Land Index";
                            this.LinkLabelCounty.Enabled = true;
                            this.LinkLabelCounty.Visible = true;
                            this.LabelCountyURL.Visible = true;
                            this.txt_login_landU.Visible = true;
                            this.txt_login_landP.Visible = true;
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.ComboBoxState.Text, "FL", false) != 0)
                        {
                            this.LinkLabel_MyFlCountiesURL.Visible = false;
                            this.lbl_MyFlaCounties.Visible = false;
                            this.txt_myfl_U.Visible = false;
                            this.txt_myfl_P.Visible = false;
                        }
                        else
                        {
                            this.Label_user.Visible = true;
                            this.Label_pwd.Visible = true;
                            this.LinkLabel_MyFlCountiesURL.Text = "Visit Web";
                            this.LinkLabel_MyFlCountiesURL.Enabled = true;
                            this.LinkLabel_MyFlCountiesURL.Visible = true;
                            this.lbl_MyFlaCounties.Visible = true;
                            this.txt_myfl_U.Visible = true;
                            this.txt_myfl_P.Visible = true;
                            this.txt_myfl_U.Text = "cporto";
                            this.txt_myfl_P.Text = "TFOadAAb";
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.court_url, "", false) == 0)
                        {
                            this.LinkLabelCourt.Text = "search internet";
                            this.LinkLabelCourt.Enabled = false;
                            this.LinkLabelCourt.Visible = true;
                            this.LabelCourt.Visible = true;
                            this.txt_login_courtU.Visible = false;
                            this.txt_login_courtP.Visible = false;
                        }
                        else if (!(this.orb_obj.court_url.StartsWith("http") | this.orb_obj.court_url.StartsWith("www")))
						{
							this.LinkLabelCourt.Text = this.orb_obj.court_url;
							this.LinkLabelCourt.Visible = true;
                            this.LabelCourt.Visible = true;
                            this.txt_login_courtU.Visible = false;
                            this.txt_login_courtP.Visible = false;
                        }
                        else
                        {
                            this.LinkLabelCourt.Text = "Goto Court Index";
                            this.LinkLabelCourt.Enabled = true;
                            this.LinkLabelCourt.Visible = true;
                            this.LabelCourt.Visible = true;
                            this.txt_login_courtU.Visible = true;
                            this.txt_login_courtP.Visible = true;
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.tax_url, "", false) == 0)
                        {
                            this.LinkLabelTax.Text = "search internet";
                            this.LinkLabelTax.Enabled = false;
                            this.LinkLabelTax.Visible = true;
                            this.LabelCountyTax.Visible = true;
                            this.txt_login_tax1U.Visible = false;
                            this.txt_login_tax1P.Visible = false;
                        }
                        else if (!(this.orb_obj.tax_url.StartsWith("http") | this.orb_obj.tax_url.StartsWith("www")))
                        {
                            this.LinkLabelTax.Text = this.orb_obj.tax_url;
                            this.LinkLabelTax.Visible = true;
                            this.LabelCountyTax.Visible = true;
                            this.txt_login_tax1U.Visible = false;
                            this.txt_login_tax1P.Visible = false;
                        }
                        else
                        {
                            this.LinkLabelTax.Text = "Goto Tax Web";
                            this.LinkLabelTax.Enabled = true;
                            this.LinkLabelTax.Visible = true;
                            this.LabelCountyTax.Visible = true;
                            this.txt_login_tax1U.Visible = true;
                            this.txt_login_tax1P.Visible = true;
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.prothon_url, "", false) == 0)
                        {
                            this.txt_login_prothonU.Visible = false;
                            this.txt_login_prothonP.Visible = false;
                        }
                        else if (this.orb_obj.prothon_url.StartsWith("http") | this.orb_obj.prothon_url.StartsWith("www"))
                        {
                            this.LinkLabelProthon.Text = "Goto Prothon";
                            this.LinkLabelProthon.Visible = true;
                            this.LabelProthon.Visible = true;
                            this.LinkLabelProthon.Enabled = true;
                            this.txt_login_prothonU.Visible = true;
                            this.txt_login_prothonP.Visible = true;
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.assessor_url, "", false) == 0)
                        {
                            this.LinkLabelAssessor.Text = "search internet";
                            this.LinkLabelAssessor.Enabled = false;
                            this.LinkLabelAssessor.Visible = true;
                            this.LabelAssessor.Visible = true;
                            this.txt_login_asrU.Visible = false;
                            this.txt_login_asrP.Visible = false;
                        }
                        else if (!(this.orb_obj.assessor_url.StartsWith("http") | this.orb_obj.assessor_url.StartsWith("www")))
                        {
                            this.LinkLabelAssessor.Text = this.orb_obj.assessor_url;
                            this.LinkLabelAssessor.Visible = true;
                            this.LabelAssessor.Visible = true;
                            this.txt_login_asrU.Visible = false;
                            this.txt_login_asrP.Visible = false;
                        }
                        else
                        {
                            this.LinkLabelAssessor.Text = "Goto Assessor";
                            this.LinkLabelAssessor.Enabled = true;
                            this.LinkLabelAssessor.Visible = true;
                            this.LabelAssessor.Visible = true;
                            this.txt_login_asrU.Visible = true;
                            this.txt_login_asrP.Visible = true;
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.map_url, "", false) != 0)
                        {
                            if (this.orb_obj.map_url.StartsWith("http") | this.orb_obj.map_url.StartsWith("www"))
                            {
                                this.LinkLabelMaps.Text = "Goto Maps";
                                this.LinkLabelMaps.Enabled = true;
                                this.LinkLabelMaps.Visible = true;
                                this.LabelMapsGIS.Visible = true;
                            }
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.probate_url, "", false) == 0)
                        {
                            this.txt_login_probateU.Visible = false;
                            this.txt_login_probateP.Visible = false;
                        }
                        else if (this.orb_obj.probate_url.StartsWith("http") | this.orb_obj.probate_url.StartsWith("www"))
                        {
                            this.LinkLabelProbate.Text = "Probate Web";
                            this.LinkLabelProbate.Enabled = true;
                            this.LinkLabelProbate.Visible = true;
                            this.LabelProbate.Visible = true;
                            this.txt_login_probateU.Visible = true;
                            this.txt_login_probateP.Visible = true;
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.ucc_url, "", false) != 0)
                        {
                            if (this.orb_obj.ucc_url.StartsWith("http") | this.orb_obj.ucc_url.StartsWith("www"))
                            {
                                this.LinkLabel_UCC.Text = "UCC Search";
                                this.LinkLabel_UCC.Enabled = true;
                                this.LinkLabel_UCC.Visible = true;
                                this.LabelUCC.Visible = true;
                            }
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.county_homepage, "", false) == 0)
                        {
                            this.LinkLabelCoHome.Text = "search internet";
                            this.LinkLabelCoHome.Enabled = false;
                            this.LinkLabelCoHome.Visible = true;
                            this.LabelCountyHome.Visible = true;
                        }
                        else if (!(this.orb_obj.county_homepage.StartsWith("http") | this.orb_obj.county_homepage.StartsWith("www")))
                        {
                            this.LinkLabelCoHome.Text = this.orb_obj.county_homepage;
                            this.LinkLabelCoHome.Visible = true;
                            this.LabelCountyHome.Visible = true;
                        }
                        else
                        {
                            this.LinkLabelCoHome.Text = "Homepage";
                            this.LinkLabelCoHome.Enabled = true;
                            this.LinkLabelCoHome.Visible = true;
                            this.LabelCountyHome.Visible = true;
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.foreclosure_url, "", false) != 0)
                        {
                            if (this.orb_obj.foreclosure_url.StartsWith("http") | this.orb_obj.foreclosure_url.StartsWith("www"))
                            {
                                this.LinkLabelForeclosure.Text = "Foreclosures";
                                this.LinkLabelForeclosure.Enabled = true;
                                this.LinkLabelForeclosure.Visible = true;
                                this.LabelForeclosures.Visible = true;
                            }
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.plat_url, "", false) != 0)
                        {
                            if (this.orb_obj.plat_url.StartsWith("http") | this.orb_obj.plat_url.StartsWith("www"))
                            {
                                this.LinkLabelPlats.Text = "Search Plats";
                                this.LinkLabelPlats.Enabled = true;
                                this.LinkLabelPlats.Visible = true;
                                this.LabelMapsGIS.Visible = true;
                            }
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.muniCourt_url, "", false) == 0)
                        {
                            this.LinkLabelMuniCourt.Text = "search internet";
                            this.LinkLabelMuniCourt.Enabled = false;
                            this.LinkLabelMuniCourt.Visible = true;
                            this.LabelMuniCourt.Visible = true;
                            this.txt_login_muniU.Visible = false;
                            this.txt_login_muniP.Visible = false;
                        }
                        else if (!(this.orb_obj.muniCourt_url.StartsWith("http") | this.orb_obj.muniCourt_url.StartsWith("www")))
                        {
                            this.LinkLabelMuniCourt.Text = this.orb_obj.muniCourt_url;
                            this.LinkLabelMuniCourt.Visible = true;
                            this.LabelMuniCourt.Visible = true;
                            this.txt_login_muniU.Visible = false;
                            this.txt_login_muniP.Visible = false;
                        }
                        else
                        {
                            this.LinkLabelMuniCourt.Text = "Goto Court";
                            this.LinkLabelMuniCourt.Enabled = true;
                            this.LinkLabelMuniCourt.Visible = true;
                            this.LabelMuniCourt.Visible = true;
                            this.txt_login_muniU.Visible = true;
                            this.txt_login_muniP.Visible = true;
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.other_url, "", false) == 0)
                        {
                            this.txt_login_otherU.Visible = false;
                            this.txt_login_otherP.Visible = false;
                        }
                        else if (this.orb_obj.other_url.StartsWith("http") | this.orb_obj.other_url.StartsWith("www"))
                        {
                            this.LinkLabel_OtherURL.Text = "Goto Web";
                            this.LinkLabel_OtherURL.Enabled = true;
                            this.LinkLabel_OtherURL.Visible = true;
                            this.LabelOtherURL.Visible = true;
                            this.txt_login_otherU.Visible = true;
                            this.txt_login_otherP.Visible = true;
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.tax2_url, "", false) == 0)
                        {
                            this.txt_login_tax2U.Visible = false;
                            this.txt_login_tax2P.Visible = false;
                        }
                        else if (this.orb_obj.tax2_url.StartsWith("http") | this.orb_obj.tax2_url.StartsWith("www"))
                        {
                            this.LinkLabelOtherTax.Text = "Goto Taxes";
                            this.LinkLabelOtherTax.Enabled = true;
                            this.LinkLabelOtherTax.Visible = true;
                            this.LabelOtherTax.Visible = true;
                            this.txt_login_tax2U.Visible = true;
                            this.txt_login_tax2P.Visible = true;
                        }
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.sheriff_url, "", false) != 0)
                        {
                            if (this.orb_obj.sheriff_url.StartsWith("http") | this.orb_obj.sheriff_url.StartsWith("www"))
                            {
                                this.LinkLabelSheriff.Text = "SHERIFF";
                                this.LinkLabelSheriff.Enabled = true;
                                this.LinkLabelSheriff.Visible = true;
                                this.LabelSheriff.Visible = true;
                            }
                        }
                        this.txtComments.Text = this.orb_obj.comments;
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_obj.comments, "", false) != 0)
                        {
                            this.txtComments.Visible = true;
                        }
     
            
            this.dt2.Clear();
            this.cmd2.CommandType = CommandType.TableDirect;
            this.cmd2.CommandText = string.Concat("Select * From [", this.sheetNm2, "$]");
            this.cmd2.Connection = new OleDbConnection(this.dsn);
            this.da2.SelectCommand = this.cmd2;
            this.cmdBuilder2.DataAdapter = this.da2;
            this.da2.Fill(this.dt2);
            this.da2.Dispose();
            string[] strArrays = new string[6];
            string[] strArrays1 = new string[6];
            bool[] flagArray = new bool[6];
            this.c2 = 0;
            while (this.c2 < 6)
            {
                strArrays[this.c2] = "";
                strArrays1[this.c2] = "";
                flagArray[this.c2] = false;
                this.TxOffcOutput[this.c2] = "";
                this.c2 = checked(this.c2 + 1);
            }
            this.taxoffc_count = 1;
            this.c2 = 0;
            while (this.c2 <= checked(this.dt2.Rows.Count - 1))
            {
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["st"].ToString(), this.ComboBoxState.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["county"].ToString(), this.ComboBoxCounty.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["tax_auth"].ToString(), "", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["state"].ToString(), this.ComboBoxState.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["county"].ToString(), this.ComboBoxCounty.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["tax_auth"].ToString(), null, false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["state"].ToString(), this.ComboBoxState.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["county"].ToString(), this.ComboBoxCounty.Text, false) == 0 & (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["tax_auth"].ToString(), this.ComboBoxTaxAuth.Text, false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.ComboBoxTaxAuth.Text, "choose", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.ComboBoxTaxAuth.Text, "RESEARCH NEEDED", false) == 0) | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["state"].ToString(), this.ComboBoxState.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["county"].ToString(), this.ComboBoxCounty.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["tax_auth"].ToString(), this.ComboBoxTaxAuth.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["tax_auth_type"].ToString(), this.ComboBoxTaxType.Text, false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["state"].ToString(), this.ComboBoxState.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["county"].ToString(), this.ComboBoxCounty.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["tax_auth"].ToString(), this.ComboBoxTaxAuth.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["tax_auth_type"].ToString(), this.ComboBoxTaxType.Text, false) == 0)
                {
                    strArrays[this.taxoffc_count] = this.dt2.Rows[this.c2]["locTx_url"].ToString();
                    strArrays1[this.taxoffc_count] = string.Concat("TaxType: ", this.dt2.Rows[this.c2]["tax_auth_type"].ToString(), " TaxingAuth: ", this.dt2.Rows[this.c2]["tax_auth"].ToString());
                    string[] txOffcOutput = this.TxOffcOutput;
                    int taxoffcCount = this.taxoffc_count;
                    string[] str2 = new string[] { "Phone: ", this.dt2.Rows[this.c2]["phone"].ToString(), "  Fax: ", this.dt2.Rows[this.c2]["fax"].ToString(), "\r\nPayee: ", this.dt2.Rows[this.c2]["payee"].ToString(), "\r\n", this.dt2.Rows[this.c2]["street1"].ToString(), ", ", this.dt2.Rows[this.c2]["street2"].ToString(), "\r\n", this.dt2.Rows[this.c2]["city"].ToString(), ", ", this.dt2.Rows[this.c2]["tx_st"].ToString(), "  ", this.dt2.Rows[this.c2]["zip"].ToString(), "\r\nHours: ", this.dt2.Rows[this.c2]["hours"].ToString(), "\r\nCert Needed? ", this.dt2.Rows[this.c2]["cert_req"].ToString(), "    Fee: ", this.dt2.Rows[this.c2]["cert_fee"].ToString(), "\r\nBill Cycle: ", this.dt2.Rows[this.c2]["cycle"].ToString(), "   DueDates: ", this.dt2.Rows[this.c2]["due_dates"].ToString(), "\r\nNOTES: ", this.dt2.Rows[this.c2]["notes"].ToString() };
                    txOffcOutput[taxoffcCount] = string.Concat(str2);
                    if (!(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["street1"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["locTx_url"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["street2"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["city"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["tx_st"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["zip"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["phone"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["fax"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["hours"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["cert_req"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["cert_fee"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["cycle"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["due_dates"].ToString(), "", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt2.Rows[this.c2]["notes"].ToString(), "", false) == 0))
                    {
                        flagArray[this.taxoffc_count] = true;
                    }
                    else
                    {
                        flagArray[this.taxoffc_count] = false;
                    }
                    if (this.taxoffc_count != 5)
                    {
                        this.taxoffc_count = checked(this.taxoffc_count + 1);
                    }
                }
                this.c2 = checked(this.c2 + 1);
            }
            this.ComboBoxTaxAuth.Visible = true;
            this.txtTaxOffice1.Text = this.TxOffcOutput[1];
            this.txtTaxOffice2.Text = this.TxOffcOutput[2];
            this.txtTaxOffice3.Text = this.TxOffcOutput[3];
            this.txtTaxOffice4.Text = this.TxOffcOutput[4];
            this.txtTaxOffice5.Text = this.TxOffcOutput[5];
            this.lblTxAuth1.Text = strArrays1[1];
            this.lblTxAuth2.Text = strArrays1[2];
            this.lblTxAuth3.Text = strArrays1[3];
            this.lblTxAuth4.Text = strArrays1[4];
            this.lblTxAuth5.Text = strArrays1[5];
            if (flagArray[1])
            {
                this.txtTaxOffice1.Visible = true;
                this.lblTxAuth1.Visible = true;
                this.linkLocTax1.Visible = true;
                this.pbxCopy1.Visible = true;
            }
            if (flagArray[2])
            {
                this.txtTaxOffice2.Visible = true;
                this.lblTxAuth2.Visible = true;
                this.linkLocTax2.Visible = true;
                this.pbxCopy2.Visible = true;
            }
            if (flagArray[3])
            {
                this.txtTaxOffice3.Visible = true;
                this.lblTxAuth3.Visible = true;
                this.linkLocTax3.Visible = true;
                this.pbxCopy3.Visible = true;
            }
            if (flagArray[4])
            {
                this.txtTaxOffice4.Visible = true;
                this.lblTxAuth4.Visible = true;
                this.linkLocTax4.Visible = true;
                this.pbxCopy4.Visible = true;
            }
            if (flagArray[5])
            {
                this.txtTaxOffice5.Visible = true;
                this.lblTxAuth5.Visible = true;
                this.linkLocTax5.Visible = true;
                this.pbxCopy5.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(strArrays[1], "", false) == 0)
            {
                this.linkLocTax1.Text = "none";
                this.linkLocTax1.Enabled = false;
            }
            else if (!(strArrays[1].StartsWith("http") | strArrays[1].StartsWith("www")))
            {
                this.linkLocTax1.Text = strArrays[1];
            }
            else
            {
                this.linkLocTax1.Text = "Visit Web";
                this.mywebs[11] = strArrays[1];
                this.linkLocTax1.Enabled = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(strArrays[2], "", false) == 0)
            {
                this.linkLocTax2.Text = "";
                this.linkLocTax2.Enabled = false;
            }
            else if (!(strArrays[2].StartsWith("http") | strArrays[2].StartsWith("www")))
            {
                this.linkLocTax2.Text = strArrays[2];
            }
            else
            {
                this.linkLocTax2.Text = "Visit Web";
                this.mywebs[12] = strArrays[2];
                this.linkLocTax2.Enabled = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(strArrays[3], "", false) == 0)
            {
                this.linkLocTax3.Text = "";
                this.linkLocTax3.Enabled = false;
            }
            else if (!(strArrays[3].StartsWith("http") | strArrays[3].StartsWith("www")))
            {
                this.linkLocTax3.Text = strArrays[3];
            }
            else
            {
                this.linkLocTax3.Text = "Visit Web";
                this.mywebs[13] = strArrays[3];
                this.linkLocTax3.Enabled = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(strArrays[4], "", false) == 0)
            {
                this.linkLocTax4.Text = "";
                this.linkLocTax4.Enabled = false;
            }
            else if (!(strArrays[4].StartsWith("http") | strArrays[4].StartsWith("www")))
            {
                this.linkLocTax4.Text = strArrays[4];
            }
            else
            {
                this.linkLocTax4.Text = "Visit Web";
                this.mywebs[14] = strArrays[4];
                this.linkLocTax4.Enabled = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(strArrays[5], "", false) == 0)
            {
                this.linkLocTax5.Text = "";
                this.linkLocTax5.Enabled = false;
            }
            else if (!(strArrays[5].StartsWith("http") | strArrays[5].StartsWith("www")))
            {
                this.linkLocTax5.Text = strArrays[5];
            }
            else
            {
                this.linkLocTax5.Text = "Visit Web";
                this.mywebs[15] = strArrays[5];
                this.linkLocTax5.Enabled = true;
            }
            this.LabelCopy_source.Visible = true;
            this.LabelIndex_source.Visible = true;
            this.LabelImage_date.Visible = true;
            this.LabelIndex_date.Visible = true;
            this.LabelCopyPmtType.Visible = true;
            this.LabelSubNeeded.Visible = true;
            this.lbl_copyFeeAmt.Visible = true;
            this.lbl_IndexFeeAmt.Visible = true;
            this.LabelUseTap.Visible = true;
            this.LabelUseRV.Visible = true;
            this.LabelUseDtree.Visible = true;
            this.orbStats = new Statutes_Lookup(state);
            this.c = 0;
            if (this.orbStats.SOL_MtgRD != null & this.orbStats.SOL_MtgAM != null)
            {
                this.lblSOL_Mtg.Text = string.Concat(this.orbStats.SOL_MtgAM, " Yrs After Maturity, ", this.orbStats.SOL_MtgRD, " Yrs After Record Date");
            }
            else if (this.orbStats.SOL_MtgRD == null & this.orbStats.SOL_MtgAM == null)
            {
                this.lblSOL_Mtg.Text = "limits not known";
            }
            else if (this.orbStats.SOL_MtgAM != null)
            {
                this.lblSOL_Mtg.Text = string.Concat(this.orbStats.SOL_MtgAM, " Yrs After Maturity");
            }
            else if (this.orbStats.SOL_MtgRD != null)
            {
                this.lblSOL_Mtg.Text = string.Concat(this.orbStats.SOL_MtgRD, " Yrs After Record Date");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orbStats.SOL_MtgAM, "no limit", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orbStats.SOL_MtgRD, "no limit", false) == 0)
            {
                this.lblSOL_Mtg.Text = "no statutory limit";
            }
            if (this.orbStats.SOL_HelocRD != null & this.orbStats.SOL_HelocAM != null)
            {
                this.lblSOL_Heloc.Text = string.Concat(this.orbStats.SOL_HelocAM, " Yrs After Maturity, ", this.orbStats.SOL_HelocRD, " Yrs After Record Date");
            }
            else if (this.orbStats.SOL_HelocRD == null & this.orbStats.SOL_HelocAM == null)
            {
                this.lblSOL_Heloc.Text = "limits not known";
            }
            else if (this.orbStats.SOL_HelocAM != null)
            {
                this.lblSOL_Heloc.Text = string.Concat(this.orbStats.SOL_HelocAM, " Yrs After Maturity");
            }
            else if (this.orbStats.SOL_HelocRD != null)
            {
                this.lblSOL_Heloc.Text = string.Concat(this.orbStats.SOL_HelocRD, " Yrs After Record Date");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orbStats.SOL_HelocAM, "no limit", false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orbStats.SOL_HelocRD, "no limit", false) == 0)
            {
                this.lblSOL_Heloc.Text = "no statutory limit";
            }
            this.lblSOL_Mech.Text = this.orbStats.SOL_Mech;
            this.lblSOL_Notice.Text = this.orbStats.SOL_Notice;
            this.lblSOL_lispen.Text = this.orbStats.SOL_lispen;
            this.lblSOL_HOA.Text = this.orbStats.SOL_HOA;
            this.lblSOL_Hosp.Text = this.orbStats.SOL_Hosp;
            this.lblSOL_ClaimLien.Text = this.orbStats.SOL_ClaimLien;
            this.lblSOL_Jgmt.Text = this.orbStats.SOL_Jgmt;
            this.lblSOL_Support.Text = this.orbStats.SOL_Support;
            this.lblSOL_StateJgmt.Text = this.orbStats.SOL_StateJgmt;
            this.lblSOL_AftAcq.Text = this.orbStats.SOL_AftAcq;
            this.lblSOL_TERule.Text = this.orbStats.SOL_TERule;
            this.lblSOL_Creditor_Claims.Text = this.orbStats.SOL_Creditor_Claims;
            this.lblSOL_PersTax.Text = this.orbStats.SOL_PersTax;
            this.lblSOL_Tax_RedemPer.Text = this.orbStats.SOL_Tax_RedemPer;
            this.lblSOL_forecl_redem_per.Text = this.orbStats.SOL_Foreclosure_RedemPer;
            this.lblSOL_Spousal.Text = this.orbStats.SOL_Spousal;
            this.txtSOL_notes.Text = this.orbStats.SOL_notes;
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_Mtg.Text.ToString(), "", false) != 0)
            {
                this.lblSOL_Mtg.Visible = true;
                this.Label_mtg.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_Heloc.Text, "", false) != 0)
            {
                this.lblSOL_Heloc.Visible = true;
                this.Label_heloc.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_TERule.Text, "", false) != 0)
            {
                this.lblSOL_TERule.Visible = true;
                this.Label_teRule.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_Mech.Text, "", false) != 0)
            {
                this.lblSOL_Mech.Visible = true;
                this.Label_mechLien.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_Notice.Text, "", false) != 0)
            {
                this.lblSOL_Notice.Visible = true;
                this.Label_NOC.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_lispen.Text, "", false) != 0)
            {
                this.lblSOL_lispen.Visible = true;
                this.Label_lisPendens.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_HOA.Text, "", false) != 0)
            {
                this.lblSOL_HOA.Visible = true;
                this.Label_HOA.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_Hosp.Text, "", false) != 0)
            {
                this.lblSOL_Hosp.Visible = true;
                this.Label_hospLien.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_ClaimLien.Text, "", false) != 0)
            {
                this.lblSOL_ClaimLien.Visible = true;
                this.Label_claimLien.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_Jgmt.Text, "", false) != 0)
            {
                this.lblSOL_Jgmt.Visible = true;
                this.Label_jgmt.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_Support.Text, "", false) != 0)
            {
                this.lblSOL_Support.Visible = true;
                this.Label_support.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_StateJgmt.Text, "", false) != 0)
            {
                this.lblSOL_StateJgmt.Visible = true;
                this.Label_stateJgmt.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_AftAcq.Text, "", false) != 0)
            {
                this.lblSOL_AftAcq.Visible = true;
                this.Label_aftacq.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_Creditor_Claims.Text, "", false) != 0)
            {
                this.lblSOL_Creditor_Claims.Visible = true;
                this.Label_credclaim.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_PersTax.Text, "", false) != 0)
            {
                this.lblSOL_PersTax.Visible = true;
                this.Label_persTax.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_Tax_RedemPer.Text, "", false) != 0)
            {
                this.lblSOL_Tax_RedemPer.Visible = true;
                this.Label_taxTakRedem.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_forecl_redem_per.Text, "", false) != 0)
            {
                this.lblSOL_forecl_redem_per.Visible = true;
                this.Label_forclRedem.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lblSOL_Spousal.Text, "", false) != 0)
            {
                this.lblSOL_Spousal.Visible = true;
                this.Label_spousal.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txtSOL_notes.Text, "", false) != 0)
            {
                this.txtSOL_notes.Visible = true;
                this.Label_statutecomments.Visible = true;
            }
            this.TableLayoutPanel2.AutoSize = true;
            this.c = checked(this.dt.Rows.Count + this.c);
            this.c = checked(this.c + 1);
            this.orb_misc = new ORB_DLL.Orb.orb_misc(state);
            this.c = 0;
            this.txt_foreclosure_notes.Text = this.orb_misc.Foreclosure_Notes;
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txt_foreclosure_notes.Text, "", false) != 0)
            {
                this.txt_foreclosure_notes.Visible = true;
                this.Label_fc.Visible = true;
            }
            this.txt_ProbateInfo.Text = this.orb_misc.Probate_Notes;
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.txt_ProbateInfo.Text, "", false) != 0)
            {
                this.txt_ProbateInfo.Visible = true;
                this.Label_probate.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_misc.Being_Clause, "Yes", false) != 0)
            {
                this.lblSOL_being_Clause.Visible = false;
            }
            else
            {
                this.lblSOL_being_Clause.Visible = true;
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_misc.SecretaryState_url, "", false) != 0)
            {
                if (this.orb_misc.SecretaryState_url.StartsWith("http") | this.orb_misc.SecretaryState_url.StartsWith("www"))
                {
                    this.LinkLabel_SecState.Text = "Secretary of State";
                    this.LinkLabel_SecState.Enabled = true;
                    this.LinkLabel_SecState.Visible = true;
                    this.Label_secState.Visible = true;
                }
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_misc.DOI_url, "", false) != 0)
            {
                if (this.orb_misc.DOI_url.StartsWith("http") | this.orb_misc.DOI_url.StartsWith("www"))
                {
                    this.LinkLabel_DeptIns.Text = "Dept of Insurance";
                    this.LinkLabel_DeptIns.Enabled = true;
                    this.LinkLabel_DeptIns.Visible = true;
                    this.Label_DOI.Visible = true;
                }
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.orb_misc.State_Code_url, "", false) != 0)
            {
                if (this.orb_misc.State_Code_url.StartsWith("http") | this.orb_misc.State_Code_url.StartsWith("www"))
                {
                    this.LinkLabel_State_Code.Text = "State Admin Code";
                    this.LinkLabel_State_Code.Enabled = true;
                    this.LinkLabel_State_Code.Visible = true;
                    this.Label_stCode.Visible = true;
                }
            }
            this.lbl_attyState.Text = this.orb_misc.Attorney_Search;
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.lbl_attyState.Text, "NO", false) != 0)
            {
                this.lbl_attyState.Text = "Attorney Opinion of Title Required";
                this.lbl_attyState.Visible = true;
            }
            else
            {
                this.lbl_attyState.Visible = false;
            }
            this.lbl_attyClose.Text = string.Concat("Attorney Closer Needed? ", this.orb_misc.Attorney_Close);
            this.txt_AttyNotes.Text = this.orb_misc.Attorney_Notes;
            this.lbl_homestead.Text = string.Concat("Homestead State? ", this.orb_misc.Homestead);
            this.txt_homestead_notes.Text = this.orb_misc.Homestead_Notes;
            this.lbl_deed_prep.Text = string.Concat("Deed Prep: ", this.orb_misc.Deed_Prep);
            this.txt_DeedNotes.Text = this.orb_misc.Deed_Notes;
            this.txt_PolicyNotes.Text = this.orb_misc.Policy_Notes;
            int num = 0;
            StringBuilder stringBuilder = new StringBuilder();
            DataTable dataTable = new DataTable();
            DataTable dataTable1 = new DataTable();
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
            OleDbCommandBuilder oleDbCommandBuilder = new OleDbCommandBuilder();
            OleDbCommand oleDbCommand = new OleDbCommand();
            OleDbCommand oleDbConnection = new OleDbCommand();
            oleDbConnection.CommandText = string.Concat("Select * From [", this.sheetNm5, "$]");
            oleDbConnection.Connection = new OleDbConnection(this.dsn);
            oleDbDataAdapter.SelectCommand = oleDbConnection;
            oleDbCommandBuilder.DataAdapter = oleDbDataAdapter;
            oleDbDataAdapter.Fill(dataTable1);
            oleDbDataAdapter.Dispose();
            this.DataGridView2.DataSource = dataTable1;
        }

        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            //Process.Start("T:\\ONLINE ABSTRACTING\\_ORB\\ORB_files-dontmoveordelete\\HELP.doc");
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            this.ComboBoxState.ResetText();
            this.ComboBoxCounty.ResetText();
            this.ComboBoxTaxAuth.ResetText();
            this.ComboBoxTaxType.ResetText();
            this.resetVis();
            this.lblDefault_UW_Name.ResetText();
        }

        private void cbox_StatsStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.madStat(this.cbox_StatsStates.Text);
            this.cbox_StatsTaxCounties.ResetText();
            this.txt_StatsTaxOffices.ResetText();
            this.lbl_TaxOnlineStats.ResetText();
            this.cbox_StatsTaxCounties.Items.Clear();
            this.i = 0;
            while (this.i < this.st_cty.Rows.Count)
            {
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.st_cty.Rows[this.i]["state"].ToString(), this.cbox_StatsStates.Text, false) == 0)
                {
                    this.cbox_StatsTaxCounties.Items.Add(this.st_cty.Rows[this.i]["county"].ToString());
                }
                this.i = checked(this.i + 1);
            }
        }

        private void cbox_StatsTaxCounties_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            this.cmd.CommandType = CommandType.TableDirect;
	        this.cmd.CommandText = string.Concat("Select * From [", this.sheetNm2, "$]");
            this.cmd.Connection = new OleDbConnection(this.dsn);
            this.da.SelectCommand = this.cmd;
            this.cmdBuilder.DataAdapter = this.da;
            this.da.Fill(dataTable);
            this.da.Dispose();
            this.txt_StatsTaxOffices.ResetText();
            long num = (long)0;
            this.i = 0;
            while (this.i < dataTable.Rows.Count)
            {
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[this.i]["state"].ToString(), this.cbox_StatsStates.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[this.i]["county"].ToString(), this.cbox_StatsTaxCounties.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[this.i]["payee"].ToString(), "", false) != 0)
                {
                    num = checked(num + (long)1);
                    string[] text = new string[] { this.txt_StatsTaxOffices.Text, dataTable.Rows[this.i]["state"].ToString(), " - ", dataTable.Rows[this.i]["county"].ToString(), " - ", dataTable.Rows[this.i]["tax_auth"].ToString(), "\r\n" };
                    this.txt_StatsTaxOffices.Text = string.Concat(text);
                }
                this.i = checked(this.i + 1);
            }
            this.lbl_TaxOnlineStats.Text = string.Concat("#Tax Offices: ", Conversions.ToString(num));
        }

        private void cbxAddtlLinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = Conversions.ToString(this.cbxAddtlLinks.SelectedItem);
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "PACER", false) == 0)
            {
                Process.Start("https://pacer.login.uscourts.gov/cgi-bin/login.pl?court_id=00idx");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Justia (Courts)", false) == 0)
            {
                Process.Start("http://dockets.justia.com/");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Ernst Publishing", false) == 0)
            {
                Process.Start("www.ernstpublishing.com/subscribers/login.asp");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "USPS.com", false) == 0)
            {
                Process.Start("www.usps.com");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "US Courts Map", false) == 0)
            {
                Process.Start("http://www.uscourts.gov/courtlinks/#other");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Real Quest", false) == 0)
            {
                Process.Start("www.realquest.com");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "NetrOnline", false) == 0)
            {
                Process.Start("http://publicrecords.netronline.com");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "ZipCode Lookup", false) == 0)
            {
                Process.Start("http://www.zipinfo.com/cgi-local/zipsrch.exe?cnty=cnty&zip=48383");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Stewart Title Guaranty", false) == 0)
            {
                Process.Start("http://www.stewart.com");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Stewart VirtUW", false) == 0)
            {
                Process.Start("http://www.vuwriter.com/");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "MERS-Releases", false) == 0)
            {
                Process.Start("https://www.mers-servicerid.org/sis/");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Stewart New York", false) == 0)
            {
                Process.Start("http://www.stewartnewyork.com/");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "Ticor NTI Web", false) == 0)
            {
                Process.Start("http://www.ticorntiweb.com/login.aspx");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "CPL-Stewart", false) == 0)
            {
                Process.Start("https://www.stewarticl.com/ICL.asp?/default_stg.asp");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "CPL-Ticor", false) == 0)
            {
                Process.Start("http://www.ticorntiweb.com/login.aspx");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "CPL-Old Republic", false) == 0)
            {
                Process.Start("http://www.oldrepublictitle.com/asp3/icl/xmlicl10.asp");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "FDIC.gov", false) == 0)
            {
                Process.Start("http://www.fdic.gov/");
            }
            else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, "IRS.gov", false) == 0)
            {
                Process.Start("www.irs.gov");
            }
        }

        private void ComboBoxCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
        /*    this.cmd.CommandType = CommandType.TableDirect;
            this.dsn = string.Concat("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", this.Import_File, ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"");
            this.cmd.CommandText = string.Concat("Select * From [", this.sheetNm2, "$]");
            this.cmd.Connection = new OleDbConnection(this.dsn);
            this.da.SelectCommand = this.cmd;
            this.cmdBuilder.DataAdapter = this.da;
            this.da.Fill(this.dt);
            this.da.Dispose();
            this.ComboBoxTaxAuth.Items.Clear();
            this.ComboBoxTaxAuth.Text = "choose";
            this.ComboBoxTaxType.Items.Clear();
            this.ComboBoxTaxType.Text = "choose";
            short num = 0;
            bool flag = false;
            while (this.i < this.dt.Rows.Count)
            {
                if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.AndObject(Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ComboBoxState.SelectedItem, this.dt.Rows[this.i]["state"].ToString(), false), Microsoft.VisualBasic.CompilerServices.Operators.CompareObjectEqual(this.ComboBoxCounty.SelectedItem, this.dt.Rows[this.i]["county"].ToString(), false))))
                {
                    num = 0;
                    flag = false;
                    while (num < this.ComboBoxTaxAuth.Items.Count)
                    {
                        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.ComboBoxTaxAuth.Items[num].ToString(), this.dt.Rows[this.i]["tax_auth"].ToString(), false) == 0)
                        {
                            flag = true;
                        }
                        num = checked((short)(checked(num + 1)));
                    }
                    if (!flag)
                    {
                        this.ComboBoxTaxAuth.Items.Add(this.dt.Rows[this.i]["tax_auth"].ToString());
                    }
                }
                this.i = checked(this.i + 1);
            }
            this.resetVis();
            this.lbl_NotFound.Visible = false;
            this.linkUS_Legal_Forms.Visible = false;*/
        }

        private void comboboxState_TextChanged(object sender, EventArgs e)
        {
            this.TopMost = false;
            string text = this.ComboBoxState.Text;
            switch (text)
            {
                case "AK":
                case "AR":
                case "CT":
                case "AZ":
                case "CA":
                case "HI":
                case "ID":
                case "NM":
                case "NV":
                case "OR":
                case "OK":
                case "SD":
                case "TX":
                case "UT":
                case "WA":
                case "WY":
                    {
                        this.lblDefault_UW_Name.Text = "Not Licensed";
                        break;
                    }
                case "AL":
                case "CO":
                case "FL":
                case "IA":
                case "IN":
                case "KS":
                case "KY":
                case "MD":
                case "ME":
                case "MN":
                case "MO":
                case "MS":
                case "NC":
                case "NJ":
                case "NY":
                case "OH":
                case "SC":
                case "TN":
                case "VT":
                case "WI":
                    {
                        this.lblDefault_UW_Name.Text = "Licensed - Stewart";
                        break;
                    }
                case "DC":
                case "DE":
                case "GA":
                case "IL":
                case "LA":
                case "MA":
                case "MI":
                case "MT":
                case "ND":
                case "NE":
                case "NH":
                case "PA":
                case "RI":
                case "VA":
                case "WV":
                    {
                        this.lblDefault_UW_Name.Text = "Licensed - Old Republic";
                        break;
                    }

            }
            if (text.Length >= 2)
            {
                
              
                this.ComboBoxTaxAuth.Items.Clear();
                this.ComboBoxTaxAuth.Text = "choose";
                this.ComboBoxTaxType.Items.Clear();
                this.ComboBoxTaxType.Text = "choose";
                this.resetVis();

                Resource_Lookup rLookup = new Resource_Lookup();
                DataTable st_cty = rLookup.GetCountiesByState(ComboBoxState.Text);
                this.ComboBoxCounty.DataSource = st_cty;
                this.ComboBoxCounty.DisplayMember = "county";
                this.ComboBoxCounty.ValueMember = "county";
            }
        }

        private void ComboBoxTaxAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
        /*    this.cmd.CommandType = CommandType.TableDirect;
            this.dsn = string.Concat("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", this.Import_File, ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"");
            this.cmd.CommandText = string.Concat("Select * From [", this.sheetNm2, "$]");
            this.cmd.Connection = new OleDbConnection(this.dsn);
            this.da.SelectCommand = this.cmd;
            this.cmdBuilder.DataAdapter = this.da;
            this.da.Fill(this.dt);
            this.da.Dispose();
            this.ComboBoxTaxType.Items.Clear();
            this.ComboBoxTaxType.Text = "choose";
            while (this.i < this.dt.Rows.Count)
            {
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt.Rows[this.i]["state"].ToString().ToUpper(), this.ComboBoxState.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt.Rows[this.i]["county"].ToString().ToUpper(), this.ComboBoxCounty.Text, false) == 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.dt.Rows[this.i]["tax_auth"].ToString().ToUpper(), this.ComboBoxTaxAuth.Text, false) == 0)
                {
                    this.ComboBoxTaxType.Items.Add(this.dt.Rows[this.i]["tax_auth_type"].ToString().ToUpper());
                }
                this.i = checked(this.i + 1);
            }
            this.resetVis();*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Label32.Text = string.Concat("Today is ", Strings.FormatDateTime(DateAndTime.Now, DateFormat.LongDate));
            this.EditForm = new frmEdit();
            this.ButtonReset.PerformClick();
			string dataFileName = @"Data\ORB_DATABASE.xlsx";
			this.dsn = string.Concat("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=", dataFileName, ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"");

			this.Refresh();
            //this.xlLoad1();
            UpdateCheckInfo updateCheckInfo = null;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment currentDeployment = ApplicationDeployment.CurrentDeployment;
                try
                {
                    updateCheckInfo = currentDeployment.CheckForDetailedUpdate();
                }
                catch (DeploymentDownloadException deploymentDownloadException1)
                {
                    ProjectData.SetProjectError(deploymentDownloadException1);
                    DeploymentDownloadException deploymentDownloadException = deploymentDownloadException1;
                    MessageBox.Show(string.Concat("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: ", deploymentDownloadException.Message));
                    ProjectData.ClearProjectError();
                    return;
                }
                catch (InvalidOperationException invalidOperationException1)
                {
                    ProjectData.SetProjectError(invalidOperationException1);
                    InvalidOperationException invalidOperationException = invalidOperationException1;
                    MessageBox.Show(string.Concat("This application cannot be updated. It is likely not a ClickOnce application. Error: ", invalidOperationException.Message));
                    ProjectData.ClearProjectError();
                    return;
                }
                if (!updateCheckInfo.UpdateAvailable)
                {
                    MessageBox.Show("This is the most current update.");
                    return;
                }
                bool flag = true;
                if (updateCheckInfo.IsUpdateRequired)
                {
                    MessageBox.Show(string.Concat("This application has detected a mandatory update from your current version to version ", updateCheckInfo.MinimumRequiredVersion.ToString(), ". The application will now install the update and restart."), "Update Available", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("An update is available.", "Update Available", MessageBoxButtons.OK);
                    this.TopMost = false;
                }
                if (flag)
                {
                    try
                    {
                        currentDeployment.Update();
                        MessageBox.Show("Update complete. The application will restart.");
                        Application.Restart();
                    }
                    catch (DeploymentDownloadException deploymentDownloadException2)
                    {
                        ProjectData.SetProjectError(deploymentDownloadException2);
                        MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later.");
                        ProjectData.ClearProjectError();
                        return;
                    }
                }
            }
            this.resetVis();
            this.TopMost = false;
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.Label32 = new System.Windows.Forms.Label();
			this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lbl_attyState = new System.Windows.Forms.Label();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblDefault_UW_Name = new System.Windows.Forms.Label();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.ButtonExit = new System.Windows.Forms.Button();
			this.Label36 = new System.Windows.Forms.Label();
			this.Button_PolicyWarehouse = new System.Windows.Forms.Button();
			this.ComboBoxTaxType = new System.Windows.Forms.ComboBox();
			this.GroupBox6 = new System.Windows.Forms.GroupBox();
			this.cbxAddtlLinks = new System.Windows.Forms.ComboBox();
			this.Button_EditORB = new System.Windows.Forms.Button();
			this.Button_Search = new System.Windows.Forms.Button();
			this.ButtonHelp = new System.Windows.Forms.Button();
			this.Button_RateCalc = new System.Windows.Forms.Button();
			this.ComboBoxState = new System.Windows.Forms.ComboBox();
			this.ComboBoxCounty = new System.Windows.Forms.ComboBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.ComboBoxTaxAuth = new System.Windows.Forms.ComboBox();
			this.ButtonReset = new System.Windows.Forms.Button();
			this.GroupBox10 = new System.Windows.Forms.GroupBox();
			this.lbl_SubTerm = new System.Windows.Forms.Label();
			this.Label135 = new System.Windows.Forms.Label();
			this.lbl_IndexFeeAmt = new System.Windows.Forms.Label();
			this.Label19 = new System.Windows.Forms.Label();
			this.Label13 = new System.Windows.Forms.Label();
			this.lbl_WeSubscribe = new System.Windows.Forms.Label();
			this.lbl_IndexPmtMethod = new System.Windows.Forms.Label();
			this.Label11 = new System.Windows.Forms.Label();
			this.Label128 = new System.Windows.Forms.Label();
			this.lbl_Free = new System.Windows.Forms.Label();
			this.Label30 = new System.Windows.Forms.Label();
			this.LabelSubNeeded = new System.Windows.Forms.Label();
			this.GroupBox8 = new System.Windows.Forms.GroupBox();
			this.TextBox4 = new System.Windows.Forms.TextBox();
			this.ComboBox1 = new System.Windows.Forms.ComboBox();
			this.Label40 = new System.Windows.Forms.Label();
			this.Button1 = new System.Windows.Forms.Button();
			this.TextBox3 = new System.Windows.Forms.TextBox();
			this.TextBox2 = new System.Windows.Forms.TextBox();
			this.Label41 = new System.Windows.Forms.Label();
			this.Label50 = new System.Windows.Forms.Label();
			this.Label51 = new System.Windows.Forms.Label();
			this.GroupBox7 = new System.Windows.Forms.GroupBox();
			this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.txt_myfl_P = new System.Windows.Forms.TextBox();
			this.LinkLabel_MyFlCountiesURL = new System.Windows.Forms.LinkLabel();
			this.txt_myfl_U = new System.Windows.Forms.TextBox();
			this.txt_login_tax2P = new System.Windows.Forms.TextBox();
			this.lbl_MyFlaCounties = new System.Windows.Forms.Label();
			this.Label_DOI = new System.Windows.Forms.Label();
			this.txt_login_tax2U = new System.Windows.Forms.TextBox();
			this.Label_stCode = new System.Windows.Forms.Label();
			this.txt_login_otherP = new System.Windows.Forms.TextBox();
			this.txt_login_courtP = new System.Windows.Forms.TextBox();
			this.txt_login_otherU = new System.Windows.Forms.TextBox();
			this.Label_secState = new System.Windows.Forms.Label();
			this.txt_login_asrP = new System.Windows.Forms.TextBox();
			this.txt_login_probateP = new System.Windows.Forms.TextBox();
			this.txt_login_asrU = new System.Windows.Forms.TextBox();
			this.txt_login_courtU = new System.Windows.Forms.TextBox();
			this.txt_login_tax1P = new System.Windows.Forms.TextBox();
			this.txt_login_muniP = new System.Windows.Forms.TextBox();
			this.txt_login_tax1U = new System.Windows.Forms.TextBox();
			this.txt_login_probateU = new System.Windows.Forms.TextBox();
			this.txt_login_muniU = new System.Windows.Forms.TextBox();
			this.txt_login_prothonP = new System.Windows.Forms.TextBox();
			this.txt_login_landP = new System.Windows.Forms.TextBox();
			this.txt_login_prothonU = new System.Windows.Forms.TextBox();
			this.LabelOtherURL = new System.Windows.Forms.Label();
			this.txt_login_landU = new System.Windows.Forms.TextBox();
			this.LabelCountyURL = new System.Windows.Forms.Label();
			this.LinkLabelOtherTax = new System.Windows.Forms.LinkLabel();
			this.LinkLabelSheriff = new System.Windows.Forms.LinkLabel();
			this.LabelUCC = new System.Windows.Forms.Label();
			this.txtComments = new System.Windows.Forms.TextBox();
			this.LinkLabelCounty = new System.Windows.Forms.LinkLabel();
			this.LabelOtherTax = new System.Windows.Forms.Label();
			this.LinkLabelForeclosure = new System.Windows.Forms.LinkLabel();
			this.LabelCourt = new System.Windows.Forms.Label();
			this.LinkLabelMuniCourt = new System.Windows.Forms.LinkLabel();
			this.LabelForeclosures = new System.Windows.Forms.Label();
			this.LinkLabelMaps = new System.Windows.Forms.LinkLabel();
			this.LabelSheriff = new System.Windows.Forms.Label();
			this.LinkLabelAssessor = new System.Windows.Forms.LinkLabel();
			this.LinkLabelTax = new System.Windows.Forms.LinkLabel();
			this.LabelMapsGIS = new System.Windows.Forms.Label();
			this.LinkLabelCoHome = new System.Windows.Forms.LinkLabel();
			this.LinkLabelCourt = new System.Windows.Forms.LinkLabel();
			this.LabelProthon = new System.Windows.Forms.Label();
			this.LabelAssessor = new System.Windows.Forms.Label();
			this.LinkLabelProthon = new System.Windows.Forms.LinkLabel();
			this.LabelCountyTax = new System.Windows.Forms.Label();
			this.LinkLabelProbate = new System.Windows.Forms.LinkLabel();
			this.LabelCountyHome = new System.Windows.Forms.Label();
			this.LabelMuniCourt = new System.Windows.Forms.Label();
			this.LabelProbate = new System.Windows.Forms.Label();
			this.Label_user = new System.Windows.Forms.Label();
			this.Label_pwd = new System.Windows.Forms.Label();
			this.LinkLabelPlats = new System.Windows.Forms.LinkLabel();
			this.LinkLabel_OtherURL = new System.Windows.Forms.LinkLabel();
			this.LinkLabel_UCC = new System.Windows.Forms.LinkLabel();
			this.LinkLabel_SecState = new System.Windows.Forms.LinkLabel();
			this.LinkLabel_State_Code = new System.Windows.Forms.LinkLabel();
			this.LinkLabel_DeptIns = new System.Windows.Forms.LinkLabel();
			this.GroupBox4 = new System.Windows.Forms.GroupBox();
			this.LabelUseIns = new System.Windows.Forms.Label();
			this.LabelUseProps = new System.Windows.Forms.Label();
			this.LabelUseCopy = new System.Windows.Forms.Label();
			this.Label20 = new System.Windows.Forms.Label();
			this.Label15 = new System.Windows.Forms.Label();
			this.Label28 = new System.Windows.Forms.Label();
			this.GroupBox3 = new System.Windows.Forms.GroupBox();
			this.Label4Tap = new System.Windows.Forms.Label();
			this.Label5dtree = new System.Windows.Forms.Label();
			this.Label6RV = new System.Windows.Forms.Label();
			this.LinkLabel10 = new System.Windows.Forms.LinkLabel();
			this.LinkLabel9 = new System.Windows.Forms.LinkLabel();
			this.LinkLabel16 = new System.Windows.Forms.LinkLabel();
			this.LabelUseTap = new System.Windows.Forms.Label();
			this.LabelUseDtree = new System.Windows.Forms.Label();
			this.LabelUseRV = new System.Windows.Forms.Label();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.lbl_courtImgDate = new System.Windows.Forms.Label();
			this.lbl_courtIndexDate = new System.Windows.Forms.Label();
			this.Label34 = new System.Windows.Forms.Label();
			this.Label35 = new System.Windows.Forms.Label();
			this.lbl_copyFeeAmt = new System.Windows.Forms.Label();
			this.Label16 = new System.Windows.Forms.Label();
			this.Label27 = new System.Windows.Forms.Label();
			this.LabelIndex_source = new System.Windows.Forms.Label();
			this.LabelCopyPmtType = new System.Windows.Forms.Label();
			this.Label26 = new System.Windows.Forms.Label();
			this.LabelImage_date = new System.Windows.Forms.Label();
			this.LabelIndex_date = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this.Label10 = new System.Windows.Forms.Label();
			this.Label29 = new System.Windows.Forms.Label();
			this.LabelCopy_source = new System.Windows.Forms.Label();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPg4Clearing = new System.Windows.Forms.TabPage();
			this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.txtSOL_notes = new System.Windows.Forms.TextBox();
			this.Label_statutecomments = new System.Windows.Forms.Label();
			this.lblSOL_Tax_RedemPer = new System.Windows.Forms.Label();
			this.Label_forclRedem = new System.Windows.Forms.Label();
			this.Label_taxTakRedem = new System.Windows.Forms.Label();
			this.Label_mtg = new System.Windows.Forms.Label();
			this.lblSOL_forecl_redem_per = new System.Windows.Forms.Label();
			this.Label73 = new System.Windows.Forms.Label();
			this.Label46 = new System.Windows.Forms.Label();
			this.Label74 = new System.Windows.Forms.Label();
			this.Label54 = new System.Windows.Forms.Label();
			this.Label52 = new System.Windows.Forms.Label();
			this.lblSOL_Mtg = new System.Windows.Forms.Label();
			this.Label58 = new System.Windows.Forms.Label();
			this.Label_heloc = new System.Windows.Forms.Label();
			this.lblSOL_Heloc = new System.Windows.Forms.Label();
			this.Label_teRule = new System.Windows.Forms.Label();
			this.lblSOL_TERule = new System.Windows.Forms.Label();
			this.Label_spousal = new System.Windows.Forms.Label();
			this.lblSOL_PersTax = new System.Windows.Forms.Label();
			this.Label_persTax = new System.Windows.Forms.Label();
			this.lblSOL_ClaimLien = new System.Windows.Forms.Label();
			this.lblSOL_HOA = new System.Windows.Forms.Label();
			this.lblSOL_Support = new System.Windows.Forms.Label();
			this.Label_support = new System.Windows.Forms.Label();
			this.Label_claimLien = new System.Windows.Forms.Label();
			this.lblSOL_Notice = new System.Windows.Forms.Label();
			this.lblSOL_Hosp = new System.Windows.Forms.Label();
			this.Label_HOA = new System.Windows.Forms.Label();
			this.Label_hospLien = new System.Windows.Forms.Label();
			this.lblSOL_Mech = new System.Windows.Forms.Label();
			this.Label_NOC = new System.Windows.Forms.Label();
			this.lblSOL_lispen = new System.Windows.Forms.Label();
			this.Label_mechLien = new System.Windows.Forms.Label();
			this.Label_lisPendens = new System.Windows.Forms.Label();
			this.lblSOL_Jgmt = new System.Windows.Forms.Label();
			this.Label_jgmt = new System.Windows.Forms.Label();
			this.lblSOL_Spousal = new System.Windows.Forms.Label();
			this.Label_stateJgmt = new System.Windows.Forms.Label();
			this.lblSOL_StateJgmt = new System.Windows.Forms.Label();
			this.Label_fc = new System.Windows.Forms.Label();
			this.txt_foreclosure_notes = new System.Windows.Forms.TextBox();
			this.Label_credclaim = new System.Windows.Forms.Label();
			this.Label_aftacq = new System.Windows.Forms.Label();
			this.lblSOL_Creditor_Claims = new System.Windows.Forms.Label();
			this.lblSOL_AftAcq = new System.Windows.Forms.Label();
			this.txt_ProbateInfo = new System.Windows.Forms.TextBox();
			this.Label_probate = new System.Windows.Forms.Label();
			this.TabPg6OtherLogins = new System.Windows.Forms.TabPage();
			this.DataGridView2 = new System.Windows.Forms.DataGridView();
			this.TabPg7Taxes = new System.Windows.Forms.TabPage();
			this.lbl_verifDate5 = new System.Windows.Forms.Label();
			this.lbl_verified_taxoff5 = new System.Windows.Forms.Label();
			this.lbl_verifDate4 = new System.Windows.Forms.Label();
			this.lbl_verified_taxoff4 = new System.Windows.Forms.Label();
			this.lbl_verifDate3 = new System.Windows.Forms.Label();
			this.lbl_verified_taxoff3 = new System.Windows.Forms.Label();
			this.lbl_verifDate2 = new System.Windows.Forms.Label();
			this.lbl_verified_taxoff2 = new System.Windows.Forms.Label();
			this.lbl_verifDate1 = new System.Windows.Forms.Label();
			this.lbl_verified_taxoff1 = new System.Windows.Forms.Label();
			this.Label39 = new System.Windows.Forms.Label();
			this.txtTaxOffice1 = new System.Windows.Forms.TextBox();
			this.txtTaxOffice2 = new System.Windows.Forms.TextBox();
			this.txtTaxOffice3 = new System.Windows.Forms.TextBox();
			this.txtTaxOffice4 = new System.Windows.Forms.TextBox();
			this.txtTaxOffice5 = new System.Windows.Forms.TextBox();
			this.lblTxAuth1 = new System.Windows.Forms.Label();
			this.linkLocTax1 = new System.Windows.Forms.LinkLabel();
			this.linkLocTax5 = new System.Windows.Forms.LinkLabel();
			this.lblTxAuth5 = new System.Windows.Forms.Label();
			this.lblTxAuth2 = new System.Windows.Forms.Label();
			this.linkLocTax2 = new System.Windows.Forms.LinkLabel();
			this.linkLocTax4 = new System.Windows.Forms.LinkLabel();
			this.lblTxAuth4 = new System.Windows.Forms.Label();
			this.lblTxAuth3 = new System.Windows.Forms.Label();
			this.linkLocTax3 = new System.Windows.Forms.LinkLabel();
			this.pbxExport = new System.Windows.Forms.PictureBox();
			this.pbxCopy5 = new System.Windows.Forms.PictureBox();
			this.pbxCopy4 = new System.Windows.Forms.PictureBox();
			this.pbxCopy3 = new System.Windows.Forms.PictureBox();
			this.pbxCopy2 = new System.Windows.Forms.PictureBox();
			this.pbxCopy1 = new System.Windows.Forms.PictureBox();
			this.TabPg1Statistics = new System.Windows.Forms.TabPage();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.lbl_vstats_YTD = new System.Windows.Forms.Label();
			this.lbl_vstats_Jan = new System.Windows.Forms.Label();
			this.lbl_vstats_Dec = new System.Windows.Forms.Label();
			this.lbl_vstats_Feb = new System.Windows.Forms.Label();
			this.lbl_vstats_Nov = new System.Windows.Forms.Label();
			this.lbl_vstats_Mar = new System.Windows.Forms.Label();
			this.lbl_vstats_Oct = new System.Windows.Forms.Label();
			this.lbl_vstats_Apr = new System.Windows.Forms.Label();
			this.lbl_vstats_Sep = new System.Windows.Forms.Label();
			this.lbl_vstats_May = new System.Windows.Forms.Label();
			this.lbl_vstats_Aug = new System.Windows.Forms.Label();
			this.lbl_vstats_Jun = new System.Windows.Forms.Label();
			this.lbl_vstats_Jul = new System.Windows.Forms.Label();
			this.Label121 = new System.Windows.Forms.Label();
			this.Label118 = new System.Windows.Forms.Label();
			this.Label21 = new System.Windows.Forms.Label();
			this.cbox_StatsTaxCounties = new System.Windows.Forms.ComboBox();
			this.txt_StatsTaxOffices = new System.Windows.Forms.TextBox();
			this.lbl_TaxOnlineStats = new System.Windows.Forms.Label();
			this.Label14 = new System.Windows.Forms.Label();
			this.lbl_OrbStat6 = new System.Windows.Forms.Label();
			this.Label37 = new System.Windows.Forms.Label();
			this.cbox_StatsStates = new System.Windows.Forms.ComboBox();
			this.Label25 = new System.Windows.Forms.Label();
			this.Label23 = new System.Windows.Forms.Label();
			this.lbl_OrbStats = new System.Windows.Forms.Label();
			this.lbl_OrbStat5 = new System.Windows.Forms.Label();
			this.txt_StatsCounties = new System.Windows.Forms.TextBox();
			this.lbl_OrbStat4 = new System.Windows.Forms.Label();
			this.lbl_OrbStat3 = new System.Windows.Forms.Label();
			this.lbl_OrbStat2 = new System.Windows.Forms.Label();
			this.lbl_OrbStat1 = new System.Windows.Forms.Label();
			this.lbl_CoOnlineStats = new System.Windows.Forms.Label();
			this.Label120 = new System.Windows.Forms.Label();
			this.Label119 = new System.Windows.Forms.Label();
			this.Label116 = new System.Windows.Forms.Label();
			this.Label115 = new System.Windows.Forms.Label();
			this.TabPg2Misc = new System.Windows.Forms.TabPage();
			this.lblSOL_being_Clause = new System.Windows.Forms.Label();
			this.lbl_homestead = new System.Windows.Forms.Label();
			this.txt_homestead_notes = new System.Windows.Forms.TextBox();
			this.lbl_deed_prep = new System.Windows.Forms.Label();
			this.lbl_attyClose = new System.Windows.Forms.Label();
			this.txt_AttyNotes = new System.Windows.Forms.TextBox();
			this.txt_DeedNotes = new System.Windows.Forms.TextBox();
			this.CheckBox1 = new System.Windows.Forms.CheckBox();
			this.Label123 = new System.Windows.Forms.Label();
			this.txt_PolicyNotes = new System.Windows.Forms.TextBox();
			this.LinkLabel4 = new System.Windows.Forms.LinkLabel();
			this.Label56 = new System.Windows.Forms.Label();
			this.ToolTip2 = new System.Windows.Forms.ToolTip(this.components);
			this.Label55 = new System.Windows.Forms.Label();
			this.Label62 = new System.Windows.Forms.Label();
			this.Label64 = new System.Windows.Forms.Label();
			this.Label66 = new System.Windows.Forms.Label();
			this.Label70 = new System.Windows.Forms.Label();
			this.Label75 = new System.Windows.Forms.Label();
			this.Label76 = new System.Windows.Forms.Label();
			this.Label77 = new System.Windows.Forms.Label();
			this.Label78 = new System.Windows.Forms.Label();
			this.Label80 = new System.Windows.Forms.Label();
			this.Label82 = new System.Windows.Forms.Label();
			this.Label84 = new System.Windows.Forms.Label();
			this.Label85 = new System.Windows.Forms.Label();
			this.Label86 = new System.Windows.Forms.Label();
			this.Label87 = new System.Windows.Forms.Label();
			this.Label88 = new System.Windows.Forms.Label();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.Label89 = new System.Windows.Forms.Label();
			this.Label90 = new System.Windows.Forms.Label();
			this.Label91 = new System.Windows.Forms.Label();
			this.Label92 = new System.Windows.Forms.Label();
			this.Label93 = new System.Windows.Forms.Label();
			this.Label94 = new System.Windows.Forms.Label();
			this.Label95 = new System.Windows.Forms.Label();
			this.Label96 = new System.Windows.Forms.Label();
			this.Label97 = new System.Windows.Forms.Label();
			this.Label98 = new System.Windows.Forms.Label();
			this.Label99 = new System.Windows.Forms.Label();
			this.Label100 = new System.Windows.Forms.Label();
			this.Label101 = new System.Windows.Forms.Label();
			this.Label102 = new System.Windows.Forms.Label();
			this.Label103 = new System.Windows.Forms.Label();
			this.Label104 = new System.Windows.Forms.Label();
			this.Label105 = new System.Windows.Forms.Label();
			this.Label106 = new System.Windows.Forms.Label();
			this.Label107 = new System.Windows.Forms.Label();
			this.Label108 = new System.Windows.Forms.Label();
			this.Label109 = new System.Windows.Forms.Label();
			this.Label110 = new System.Windows.Forms.Label();
			this.Label111 = new System.Windows.Forms.Label();
			this.Label112 = new System.Windows.Forms.Label();
			this.Panel2 = new System.Windows.Forms.Panel();
			this.SplitContainer1.Panel1.SuspendLayout();
			this.SplitContainer1.Panel2.SuspendLayout();
			this.SplitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.Panel1.SuspendLayout();
			this.GroupBox6.SuspendLayout();
			this.GroupBox10.SuspendLayout();
			this.GroupBox8.SuspendLayout();
			this.GroupBox7.SuspendLayout();
			this.TableLayoutPanel2.SuspendLayout();
			this.GroupBox4.SuspendLayout();
			this.GroupBox3.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			this.TabControl1.SuspendLayout();
			this.TabPg4Clearing.SuspendLayout();
			this.TableLayoutPanel1.SuspendLayout();
			this.TabPg6OtherLogins.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).BeginInit();
			this.TabPg7Taxes.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxExport)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxCopy5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxCopy4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxCopy3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxCopy2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxCopy1)).BeginInit();
			this.TabPg1Statistics.SuspendLayout();
			this.GroupBox1.SuspendLayout();
			this.TabPg2Misc.SuspendLayout();
			this.SuspendLayout();
			// 
			// Label32
			// 
			this.Label32.AutoSize = true;
			this.Label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label32.ForeColor = System.Drawing.Color.Black;
			this.Label32.ImageAlign = System.Drawing.ContentAlignment.TopRight;
			this.Label32.Location = new System.Drawing.Point(514, 26);
			this.Label32.Name = "Label32";
			this.Label32.Size = new System.Drawing.Size(80, 15);
			this.Label32.TabIndex = 54;
			this.Label32.Text = "todays date";
			this.Label32.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// SplitContainer1
			// 
			this.SplitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.SplitContainer1.Location = new System.Drawing.Point(0, 6);
			this.SplitContainer1.Name = "SplitContainer1";
			this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// SplitContainer1.Panel1
			// 
			this.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Honeydew;
			this.SplitContainer1.Panel1.Controls.Add(this.lbl_attyState);
			this.SplitContainer1.Panel1.Controls.Add(this.PictureBox1);
			this.SplitContainer1.Panel1.Controls.Add(this.lblDefault_UW_Name);
			this.SplitContainer1.Panel1.Controls.Add(this.Label32);
			this.SplitContainer1.Panel1.Controls.Add(this.Panel1);
			// 
			// SplitContainer1.Panel2
			// 
			this.SplitContainer1.Panel2.AutoScroll = true;
			this.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Honeydew;
			this.SplitContainer1.Panel2.Controls.Add(this.GroupBox10);
			this.SplitContainer1.Panel2.Controls.Add(this.GroupBox8);
			this.SplitContainer1.Panel2.Controls.Add(this.GroupBox7);
			this.SplitContainer1.Panel2.Controls.Add(this.GroupBox4);
			this.SplitContainer1.Panel2.Controls.Add(this.GroupBox3);
			this.SplitContainer1.Panel2.Controls.Add(this.GroupBox2);
			this.SplitContainer1.Size = new System.Drawing.Size(874, 385);
			this.SplitContainer1.SplitterDistance = 109;
			this.SplitContainer1.TabIndex = 179;
			// 
			// lbl_attyState
			// 
			this.lbl_attyState.AutoSize = true;
			this.lbl_attyState.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_attyState.ForeColor = System.Drawing.Color.Red;
			this.lbl_attyState.Location = new System.Drawing.Point(262, 4);
			this.lbl_attyState.Name = "lbl_attyState";
			this.lbl_attyState.Size = new System.Drawing.Size(10, 15);
			this.lbl_attyState.TabIndex = 84;
			this.lbl_attyState.Text = ".";
			// 
			// PictureBox1
			// 
			this.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.PictureBox1.Image = global::WindowsApplication1.Resources.ims_ORB_logo;
			this.PictureBox1.Location = new System.Drawing.Point(3, 4);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(238, 35);
			this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.PictureBox1.TabIndex = 48;
			this.PictureBox1.TabStop = false;
			this.PictureBox1.Tag = "ORB";
			// 
			// lblDefault_UW_Name
			// 
			this.lblDefault_UW_Name.AutoSize = true;
			this.lblDefault_UW_Name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDefault_UW_Name.ForeColor = System.Drawing.Color.Red;
			this.lblDefault_UW_Name.Location = new System.Drawing.Point(262, 26);
			this.lblDefault_UW_Name.Name = "lblDefault_UW_Name";
			this.lblDefault_UW_Name.Size = new System.Drawing.Size(10, 15);
			this.lblDefault_UW_Name.TabIndex = 66;
			this.lblDefault_UW_Name.Text = ".";
			// 
			// Panel1
			// 
			this.Panel1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.Panel1.Controls.Add(this.ButtonExit);
			this.Panel1.Controls.Add(this.Label36);
			this.Panel1.Controls.Add(this.Button_PolicyWarehouse);
			this.Panel1.Controls.Add(this.ComboBoxTaxType);
			this.Panel1.Controls.Add(this.GroupBox6);
			this.Panel1.Controls.Add(this.Button_EditORB);
			this.Panel1.Controls.Add(this.Button_Search);
			this.Panel1.Controls.Add(this.ButtonHelp);
			this.Panel1.Controls.Add(this.Button_RateCalc);
			this.Panel1.Controls.Add(this.ComboBoxState);
			this.Panel1.Controls.Add(this.ComboBoxCounty);
			this.Panel1.Controls.Add(this.Label2);
			this.Panel1.Controls.Add(this.Label1);
			this.Panel1.Controls.Add(this.Label3);
			this.Panel1.Controls.Add(this.ComboBoxTaxAuth);
			this.Panel1.Controls.Add(this.ButtonReset);
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Panel1.Location = new System.Drawing.Point(0, 44);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(874, 65);
			this.Panel1.TabIndex = 83;
			// 
			// ButtonExit
			// 
			this.ButtonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
			this.ButtonExit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonExit.FlatAppearance.BorderColor = System.Drawing.Color.Purple;
			this.ButtonExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Magenta;
			this.ButtonExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
			this.ButtonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.ButtonExit.ForeColor = System.Drawing.Color.Indigo;
			this.ButtonExit.Location = new System.Drawing.Point(811, 25);
			this.ButtonExit.Name = "ButtonExit";
			this.ButtonExit.Size = new System.Drawing.Size(59, 35);
			this.ButtonExit.TabIndex = 84;
			this.ButtonExit.Text = "EXIT";
			this.ButtonExit.UseVisualStyleBackColor = false;
			this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
			// 
			// Label36
			// 
			this.Label36.AutoSize = true;
			this.Label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label36.Location = new System.Drawing.Point(305, 18);
			this.Label36.Name = "Label36";
			this.Label36.Size = new System.Drawing.Size(53, 16);
			this.Label36.TabIndex = 93;
			this.Label36.Text = "tax type";
			// 
			// Button_PolicyWarehouse
			// 
			this.Button_PolicyWarehouse.BackColor = System.Drawing.Color.Turquoise;
			this.Button_PolicyWarehouse.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Button_PolicyWarehouse.FlatAppearance.BorderColor = System.Drawing.Color.MediumSlateBlue;
			this.Button_PolicyWarehouse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Magenta;
			this.Button_PolicyWarehouse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
			this.Button_PolicyWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Button_PolicyWarehouse.Font = new System.Drawing.Font("Arial", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Button_PolicyWarehouse.ForeColor = System.Drawing.Color.Indigo;
			this.Button_PolicyWarehouse.Location = new System.Drawing.Point(717, 2);
			this.Button_PolicyWarehouse.Name = "Button_PolicyWarehouse";
			this.Button_PolicyWarehouse.Size = new System.Drawing.Size(70, 20);
			this.Button_PolicyWarehouse.TabIndex = 202;
			this.Button_PolicyWarehouse.Text = "POLICIES";
			this.Button_PolicyWarehouse.UseVisualStyleBackColor = false;
			this.Button_PolicyWarehouse.Click += new System.EventHandler(this.Button_PolicyWarehouse_Click);
			// 
			// ComboBoxTaxType
			// 
			this.ComboBoxTaxType.DropDownHeight = 50;
			this.ComboBoxTaxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ComboBoxTaxType.ForeColor = System.Drawing.Color.Indigo;
			this.ComboBoxTaxType.FormattingEnabled = true;
			this.ComboBoxTaxType.IntegralHeight = false;
			this.ComboBoxTaxType.ItemHeight = 12;
			this.ComboBoxTaxType.Location = new System.Drawing.Point(305, 37);
			this.ComboBoxTaxType.MaxDropDownItems = 10;
			this.ComboBoxTaxType.Name = "ComboBoxTaxType";
			this.ComboBoxTaxType.Size = new System.Drawing.Size(120, 20);
			this.ComboBoxTaxType.TabIndex = 92;
			// 
			// GroupBox6
			// 
			this.GroupBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
			this.GroupBox6.Controls.Add(this.cbxAddtlLinks);
			this.GroupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.GroupBox6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GroupBox6.Location = new System.Drawing.Point(660, 25);
			this.GroupBox6.Name = "GroupBox6";
			this.GroupBox6.Size = new System.Drawing.Size(145, 38);
			this.GroupBox6.TabIndex = 90;
			this.GroupBox6.TabStop = false;
			this.GroupBox6.Text = "Additional Links";
			// 
			// cbxAddtlLinks
			// 
			this.cbxAddtlLinks.DropDownHeight = 150;
			this.cbxAddtlLinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbxAddtlLinks.ForeColor = System.Drawing.Color.Indigo;
			this.cbxAddtlLinks.FormattingEnabled = true;
			this.cbxAddtlLinks.IntegralHeight = false;
			this.cbxAddtlLinks.ItemHeight = 12;
			this.cbxAddtlLinks.Items.AddRange(new object[] {
            "CPL-Ticor",
            "CPL-Stewart",
            "Ernst Publishing",
            "FDIC.gov",
            "IRS.gov",
            "Justia (Courts)",
            "MERS-Releases",
            "NetrOnline",
            "Old Republic",
            "PACER",
            "Real Quest",
            "Stewart New York",
            "Stewart Title Guaranty",
            "Stewart VirtUW",
            "Ticor NTI Web",
            "US Courts Map",
            "USPS.com",
            "ZipCode Lookup"});
			this.cbxAddtlLinks.Location = new System.Drawing.Point(6, 13);
			this.cbxAddtlLinks.Name = "cbxAddtlLinks";
			this.cbxAddtlLinks.Size = new System.Drawing.Size(133, 20);
			this.cbxAddtlLinks.TabIndex = 69;
			this.cbxAddtlLinks.SelectedIndexChanged += new System.EventHandler(this.cbxAddtlLinks_SelectedIndexChanged);
			// 
			// Button_EditORB
			// 
			this.Button_EditORB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
			this.Button_EditORB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Button_EditORB.FlatAppearance.BorderColor = System.Drawing.Color.Purple;
			this.Button_EditORB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Magenta;
			this.Button_EditORB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
			this.Button_EditORB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Button_EditORB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Button_EditORB.ForeColor = System.Drawing.Color.Indigo;
			this.Button_EditORB.Location = new System.Drawing.Point(585, 25);
			this.Button_EditORB.Name = "Button_EditORB";
			this.Button_EditORB.Size = new System.Drawing.Size(72, 35);
			this.Button_EditORB.TabIndex = 91;
			this.Button_EditORB.Text = "EDIT";
			this.Button_EditORB.UseVisualStyleBackColor = false;
			this.Button_EditORB.Click += new System.EventHandler(this.Button_EditORB_Click);
			// 
			// Button_Search
			// 
			this.Button_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
			this.Button_Search.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Button_Search.FlatAppearance.BorderColor = System.Drawing.Color.Purple;
			this.Button_Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Magenta;
			this.Button_Search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
			this.Button_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Button_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Button_Search.ForeColor = System.Drawing.Color.Indigo;
			this.Button_Search.Location = new System.Drawing.Point(433, 25);
			this.Button_Search.Name = "Button_Search";
			this.Button_Search.Size = new System.Drawing.Size(72, 35);
			this.Button_Search.TabIndex = 87;
			this.Button_Search.Text = "SEARCH";
			this.Button_Search.UseVisualStyleBackColor = false;
			this.Button_Search.Click += new System.EventHandler(this.ButtonGetLinks_Click);
			// 
			// ButtonHelp
			// 
			this.ButtonHelp.BackColor = System.Drawing.Color.Turquoise;
			this.ButtonHelp.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonHelp.FlatAppearance.BorderColor = System.Drawing.Color.MediumSlateBlue;
			this.ButtonHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Magenta;
			this.ButtonHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
			this.ButtonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonHelp.Font = new System.Drawing.Font("Arial", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ButtonHelp.ForeColor = System.Drawing.Color.Indigo;
			this.ButtonHelp.Location = new System.Drawing.Point(647, 2);
			this.ButtonHelp.Margin = new System.Windows.Forms.Padding(0);
			this.ButtonHelp.Name = "ButtonHelp";
			this.ButtonHelp.Size = new System.Drawing.Size(70, 20);
			this.ButtonHelp.TabIndex = 195;
			this.ButtonHelp.Text = "ORB HELP";
			this.ButtonHelp.UseVisualStyleBackColor = false;
			this.ButtonHelp.Click += new System.EventHandler(this.ButtonHelp_Click);
			// 
			// Button_RateCalc
			// 
			this.Button_RateCalc.BackColor = System.Drawing.Color.Turquoise;
			this.Button_RateCalc.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Button_RateCalc.FlatAppearance.BorderColor = System.Drawing.Color.MediumSlateBlue;
			this.Button_RateCalc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Magenta;
			this.Button_RateCalc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
			this.Button_RateCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Button_RateCalc.Font = new System.Drawing.Font("Arial", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Button_RateCalc.ForeColor = System.Drawing.Color.Indigo;
			this.Button_RateCalc.Location = new System.Drawing.Point(787, 2);
			this.Button_RateCalc.Margin = new System.Windows.Forms.Padding(0);
			this.Button_RateCalc.Name = "Button_RateCalc";
			this.Button_RateCalc.Size = new System.Drawing.Size(83, 20);
			this.Button_RateCalc.TabIndex = 194;
			this.Button_RateCalc.Text = "RATE CALC";
			this.Button_RateCalc.UseVisualStyleBackColor = false;
			this.Button_RateCalc.Click += new System.EventHandler(this.Button_RateCalc_Click);
			// 
			// ComboBoxState
			// 
			this.ComboBoxState.DropDownHeight = 100;
			this.ComboBoxState.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ComboBoxState.ForeColor = System.Drawing.Color.Indigo;
			this.ComboBoxState.FormattingEnabled = true;
			this.ComboBoxState.IntegralHeight = false;
			this.ComboBoxState.ItemHeight = 12;
			this.ComboBoxState.Items.AddRange(new object[] {
            "AK",
            "AL",
            "AR",
            "AZ",
            "CA",
            "CO",
            "CT",
            "DC",
            "DE",
            "FL",
            "GA",
            "HI",
            "IA",
            "ID",
            "IL",
            "IN",
            "KS",
            "KY",
            "LA",
            "MA",
            "MD",
            "ME",
            "MI",
            "MN",
            "MO",
            "MS",
            "MT",
            "NC",
            "ND",
            "NE",
            "NH",
            "NJ",
            "NM",
            "NV",
            "NY",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VA",
            "VT",
            "WA",
            "WI",
            "WV",
            "WY"});
			this.ComboBoxState.Location = new System.Drawing.Point(3, 37);
			this.ComboBoxState.MaxDropDownItems = 10;
			this.ComboBoxState.Name = "ComboBoxState";
			this.ComboBoxState.Size = new System.Drawing.Size(44, 20);
			this.ComboBoxState.Sorted = true;
			this.ComboBoxState.TabIndex = 82;
			this.ComboBoxState.TextChanged += new System.EventHandler(this.comboboxState_TextChanged);
			// 
			// ComboBoxCounty
			// 
			this.ComboBoxCounty.DropDownHeight = 50;
			this.ComboBoxCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ComboBoxCounty.ForeColor = System.Drawing.Color.Indigo;
			this.ComboBoxCounty.FormattingEnabled = true;
			this.ComboBoxCounty.IntegralHeight = false;
			this.ComboBoxCounty.ItemHeight = 12;
			this.ComboBoxCounty.Location = new System.Drawing.Point(53, 37);
			this.ComboBoxCounty.MaxDropDownItems = 10;
			this.ComboBoxCounty.Name = "ComboBoxCounty";
			this.ComboBoxCounty.Size = new System.Drawing.Size(120, 20);
			this.ComboBoxCounty.TabIndex = 83;
			this.ComboBoxCounty.TextChanged += new System.EventHandler(this.ComboBoxCounty_SelectedIndexChanged);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.Location = new System.Drawing.Point(53, 18);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(46, 16);
			this.Label2.TabIndex = 86;
			this.Label2.Text = "county";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.Location = new System.Drawing.Point(3, 18);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(36, 16);
			this.Label1.TabIndex = 84;
			this.Label1.Text = "state";
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.Location = new System.Drawing.Point(179, 18);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(77, 16);
			this.Label3.TabIndex = 89;
			this.Label3.Text = "tax authority";
			// 
			// ComboBoxTaxAuth
			// 
			this.ComboBoxTaxAuth.DropDownHeight = 50;
			this.ComboBoxTaxAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ComboBoxTaxAuth.ForeColor = System.Drawing.Color.Indigo;
			this.ComboBoxTaxAuth.FormattingEnabled = true;
			this.ComboBoxTaxAuth.IntegralHeight = false;
			this.ComboBoxTaxAuth.ItemHeight = 12;
			this.ComboBoxTaxAuth.Location = new System.Drawing.Point(179, 37);
			this.ComboBoxTaxAuth.MaxDropDownItems = 10;
			this.ComboBoxTaxAuth.Name = "ComboBoxTaxAuth";
			this.ComboBoxTaxAuth.Size = new System.Drawing.Size(120, 20);
			this.ComboBoxTaxAuth.TabIndex = 85;
			this.ComboBoxTaxAuth.TextChanged += new System.EventHandler(this.ComboBoxTaxAuth_SelectedIndexChanged);
			// 
			// ButtonReset
			// 
			this.ButtonReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
			this.ButtonReset.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonReset.FlatAppearance.BorderColor = System.Drawing.Color.Purple;
			this.ButtonReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Magenta;
			this.ButtonReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
			this.ButtonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.ButtonReset.ForeColor = System.Drawing.Color.Indigo;
			this.ButtonReset.Location = new System.Drawing.Point(509, 25);
			this.ButtonReset.Name = "ButtonReset";
			this.ButtonReset.Size = new System.Drawing.Size(72, 35);
			this.ButtonReset.TabIndex = 88;
			this.ButtonReset.Text = "RESET";
			this.ButtonReset.UseVisualStyleBackColor = false;
			this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
			// 
			// GroupBox10
			// 
			this.GroupBox10.BackColor = System.Drawing.Color.GhostWhite;
			this.GroupBox10.Controls.Add(this.lbl_SubTerm);
			this.GroupBox10.Controls.Add(this.Label135);
			this.GroupBox10.Controls.Add(this.lbl_IndexFeeAmt);
			this.GroupBox10.Controls.Add(this.Label19);
			this.GroupBox10.Controls.Add(this.Label13);
			this.GroupBox10.Controls.Add(this.lbl_WeSubscribe);
			this.GroupBox10.Controls.Add(this.lbl_IndexPmtMethod);
			this.GroupBox10.Controls.Add(this.Label11);
			this.GroupBox10.Controls.Add(this.Label128);
			this.GroupBox10.Controls.Add(this.lbl_Free);
			this.GroupBox10.Controls.Add(this.Label30);
			this.GroupBox10.Controls.Add(this.LabelSubNeeded);
			this.GroupBox10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GroupBox10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.GroupBox10.Location = new System.Drawing.Point(666, 88);
			this.GroupBox10.Name = "GroupBox10";
			this.GroupBox10.Size = new System.Drawing.Size(152, 149);
			this.GroupBox10.TabIndex = 189;
			this.GroupBox10.TabStop = false;
			this.GroupBox10.Text = "INDEX SUBSCRIP\'S";
			// 
			// lbl_SubTerm
			// 
			this.lbl_SubTerm.AutoSize = true;
			this.lbl_SubTerm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbl_SubTerm.ForeColor = System.Drawing.Color.Black;
			this.lbl_SubTerm.Location = new System.Drawing.Point(86, 72);
			this.lbl_SubTerm.Name = "lbl_SubTerm";
			this.lbl_SubTerm.Size = new System.Drawing.Size(9, 12);
			this.lbl_SubTerm.TabIndex = 74;
			this.lbl_SubTerm.Text = "*";
			// 
			// Label135
			// 
			this.Label135.AutoSize = true;
			this.Label135.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label135.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label135.Location = new System.Drawing.Point(6, 72);
			this.Label135.Name = "Label135";
			this.Label135.Size = new System.Drawing.Size(73, 12);
			this.Label135.TabIndex = 72;
			this.Label135.Text = "Subscrip. Term: ";
			// 
			// lbl_IndexFeeAmt
			// 
			this.lbl_IndexFeeAmt.AutoSize = true;
			this.lbl_IndexFeeAmt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbl_IndexFeeAmt.ForeColor = System.Drawing.Color.Black;
			this.lbl_IndexFeeAmt.Location = new System.Drawing.Point(73, 89);
			this.lbl_IndexFeeAmt.Name = "lbl_IndexFeeAmt";
			this.lbl_IndexFeeAmt.Size = new System.Drawing.Size(9, 12);
			this.lbl_IndexFeeAmt.TabIndex = 71;
			this.lbl_IndexFeeAmt.Text = "*";
			// 
			// Label19
			// 
			this.Label19.AutoSize = true;
			this.Label19.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label19.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label19.Location = new System.Drawing.Point(6, 54);
			this.Label19.Name = "Label19";
			this.Label19.Size = new System.Drawing.Size(81, 12);
			this.Label19.TabIndex = 68;
			this.Label19.Text = "Do we subscribe?";
			// 
			// Label13
			// 
			this.Label13.AutoSize = true;
			this.Label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label13.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label13.Location = new System.Drawing.Point(6, 89);
			this.Label13.Name = "Label13";
			this.Label13.Size = new System.Drawing.Size(67, 12);
			this.Label13.TabIndex = 70;
			this.Label13.Text = "Subscrip. Fee: ";
			// 
			// lbl_WeSubscribe
			// 
			this.lbl_WeSubscribe.AutoSize = true;
			this.lbl_WeSubscribe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbl_WeSubscribe.ForeColor = System.Drawing.Color.Black;
			this.lbl_WeSubscribe.Location = new System.Drawing.Point(93, 54);
			this.lbl_WeSubscribe.Name = "lbl_WeSubscribe";
			this.lbl_WeSubscribe.Size = new System.Drawing.Size(9, 12);
			this.lbl_WeSubscribe.TabIndex = 69;
			this.lbl_WeSubscribe.Text = "*";
			// 
			// lbl_IndexPmtMethod
			// 
			this.lbl_IndexPmtMethod.AutoSize = true;
			this.lbl_IndexPmtMethod.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbl_IndexPmtMethod.ForeColor = System.Drawing.Color.Black;
			this.lbl_IndexPmtMethod.Location = new System.Drawing.Point(74, 107);
			this.lbl_IndexPmtMethod.Name = "lbl_IndexPmtMethod";
			this.lbl_IndexPmtMethod.Size = new System.Drawing.Size(9, 12);
			this.lbl_IndexPmtMethod.TabIndex = 67;
			this.lbl_IndexPmtMethod.Text = "*";
			// 
			// Label11
			// 
			this.Label11.AutoSize = true;
			this.Label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label11.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label11.Location = new System.Drawing.Point(6, 36);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(67, 12);
			this.Label11.TabIndex = 66;
			this.Label11.Text = "Free Subscrip?";
			// 
			// Label128
			// 
			this.Label128.AutoSize = true;
			this.Label128.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label128.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label128.Location = new System.Drawing.Point(6, 107);
			this.Label128.Name = "Label128";
			this.Label128.Size = new System.Drawing.Size(66, 12);
			this.Label128.TabIndex = 66;
			this.Label128.Text = "Pmt Method: ";
			// 
			// lbl_Free
			// 
			this.lbl_Free.AutoSize = true;
			this.lbl_Free.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbl_Free.ForeColor = System.Drawing.Color.Black;
			this.lbl_Free.Location = new System.Drawing.Point(86, 36);
			this.lbl_Free.Name = "lbl_Free";
			this.lbl_Free.Size = new System.Drawing.Size(9, 12);
			this.lbl_Free.TabIndex = 67;
			this.lbl_Free.Text = "*";
			// 
			// Label30
			// 
			this.Label30.AutoSize = true;
			this.Label30.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label30.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label30.Location = new System.Drawing.Point(6, 20);
			this.Label30.Name = "Label30";
			this.Label30.Size = new System.Drawing.Size(78, 12);
			this.Label30.TabIndex = 64;
			this.Label30.Text = "Subscr. Needed: ";
			// 
			// LabelSubNeeded
			// 
			this.LabelSubNeeded.AutoSize = true;
			this.LabelSubNeeded.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.LabelSubNeeded.ForeColor = System.Drawing.Color.Black;
			this.LabelSubNeeded.Location = new System.Drawing.Point(86, 20);
			this.LabelSubNeeded.Name = "LabelSubNeeded";
			this.LabelSubNeeded.Size = new System.Drawing.Size(9, 12);
			this.LabelSubNeeded.TabIndex = 65;
			this.LabelSubNeeded.Text = "*";
			// 
			// GroupBox8
			// 
			this.GroupBox8.BackColor = System.Drawing.Color.GhostWhite;
			this.GroupBox8.Controls.Add(this.TextBox4);
			this.GroupBox8.Controls.Add(this.ComboBox1);
			this.GroupBox8.Controls.Add(this.Label40);
			this.GroupBox8.Controls.Add(this.Button1);
			this.GroupBox8.Controls.Add(this.TextBox3);
			this.GroupBox8.Controls.Add(this.TextBox2);
			this.GroupBox8.Controls.Add(this.Label41);
			this.GroupBox8.Controls.Add(this.Label50);
			this.GroupBox8.Controls.Add(this.Label51);
			this.GroupBox8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GroupBox8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.GroupBox8.Location = new System.Drawing.Point(675, 245);
			this.GroupBox8.Name = "GroupBox8";
			this.GroupBox8.Size = new System.Drawing.Size(142, 238);
			this.GroupBox8.TabIndex = 187;
			this.GroupBox8.TabStop = false;
			this.GroupBox8.Text = "DO NOT INSURE";
			this.GroupBox8.Visible = false;
			// 
			// TextBox4
			// 
			this.TextBox4.BackColor = System.Drawing.Color.Snow;
			this.TextBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextBox4.ForeColor = System.Drawing.Color.Purple;
			this.TextBox4.Location = new System.Drawing.Point(6, 155);
			this.TextBox4.MaxLength = 100000;
			this.TextBox4.Multiline = true;
			this.TextBox4.Name = "TextBox4";
			this.TextBox4.ReadOnly = true;
			this.TextBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TextBox4.Size = new System.Drawing.Size(123, 72);
			this.TextBox4.TabIndex = 72;
			// 
			// ComboBox1
			// 
			this.ComboBox1.DropDownHeight = 100;
			this.ComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ComboBox1.ForeColor = System.Drawing.Color.Indigo;
			this.ComboBox1.FormattingEnabled = true;
			this.ComboBox1.IntegralHeight = false;
			this.ComboBox1.ItemHeight = 12;
			this.ComboBox1.Items.AddRange(new object[] {
            "AK",
            "AL",
            "AR",
            "AZ",
            "CA",
            "CO",
            "CT",
            "DC",
            "DE",
            "FL",
            "GA",
            "HI",
            "IA",
            "ID",
            "IL",
            "IN",
            "KS",
            "KY",
            "LA",
            "MA",
            "MD",
            "ME",
            "MI",
            "MN",
            "MO",
            "MS",
            "MT",
            "NC",
            "ND",
            "NE",
            "NH",
            "NJ",
            "NM",
            "NV",
            "NY",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VA",
            "VT",
            "WA",
            "WI",
            "WV",
            "WY"});
			this.ComboBox1.Location = new System.Drawing.Point(39, 110);
			this.ComboBox1.MaxDropDownItems = 10;
			this.ComboBox1.Name = "ComboBox1";
			this.ComboBox1.Size = new System.Drawing.Size(44, 20);
			this.ComboBox1.Sorted = true;
			this.ComboBox1.TabIndex = 71;
			// 
			// Label40
			// 
			this.Label40.AutoSize = true;
			this.Label40.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label40.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label40.Location = new System.Drawing.Point(6, 112);
			this.Label40.Name = "Label40";
			this.Label40.Size = new System.Drawing.Size(33, 13);
			this.Label40.TabIndex = 70;
			this.Label40.Text = "State";
			// 
			// Button1
			// 
			this.Button1.Location = new System.Drawing.Point(89, 110);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(40, 23);
			this.Button1.TabIndex = 69;
			this.Button1.Text = "GO";
			this.Button1.UseVisualStyleBackColor = true;
			// 
			// TextBox3
			// 
			this.TextBox3.Location = new System.Drawing.Point(6, 81);
			this.TextBox3.Name = "TextBox3";
			this.TextBox3.Size = new System.Drawing.Size(124, 23);
			this.TextBox3.TabIndex = 68;
			// 
			// TextBox2
			// 
			this.TextBox2.Location = new System.Drawing.Point(6, 37);
			this.TextBox2.Name = "TextBox2";
			this.TextBox2.Size = new System.Drawing.Size(124, 23);
			this.TextBox2.TabIndex = 67;
			// 
			// Label41
			// 
			this.Label41.AutoSize = true;
			this.Label41.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label41.ForeColor = System.Drawing.Color.Black;
			this.Label41.Location = new System.Drawing.Point(6, 137);
			this.Label41.Name = "Label41";
			this.Label41.Size = new System.Drawing.Size(36, 15);
			this.Label41.TabIndex = 66;
			this.Label41.Text = "result";
			// 
			// Label50
			// 
			this.Label50.AutoSize = true;
			this.Label50.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label50.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label50.Location = new System.Drawing.Point(6, 63);
			this.Label50.Name = "Label50";
			this.Label50.Size = new System.Drawing.Size(64, 13);
			this.Label50.TabIndex = 64;
			this.Label50.Text = "FIrst  Name";
			// 
			// Label51
			// 
			this.Label51.AutoSize = true;
			this.Label51.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label51.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label51.Location = new System.Drawing.Point(6, 22);
			this.Label51.Name = "Label51";
			this.Label51.Size = new System.Drawing.Size(124, 13);
			this.Label51.TabIndex = 63;
			this.Label51.Text = "Last Name or Company";
			// 
			// GroupBox7
			// 
			this.GroupBox7.AutoSize = true;
			this.GroupBox7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.GroupBox7.BackColor = System.Drawing.Color.GhostWhite;
			this.GroupBox7.Controls.Add(this.TableLayoutPanel2);
			this.GroupBox7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GroupBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.GroupBox7.Location = new System.Drawing.Point(7, 3);
			this.GroupBox7.Name = "GroupBox7";
			this.GroupBox7.Size = new System.Drawing.Size(418, 452);
			this.GroupBox7.TabIndex = 184;
			this.GroupBox7.TabStop = false;
			this.GroupBox7.Text = "SEARCHABLE INDEXES";
			// 
			// TableLayoutPanel2
			// 
			this.TableLayoutPanel2.AutoSize = true;
			this.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TableLayoutPanel2.ColumnCount = 4;
			this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TableLayoutPanel2.Controls.Add(this.txt_myfl_P, 3, 2);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabel_MyFlCountiesURL, 1, 2);
			this.TableLayoutPanel2.Controls.Add(this.txt_myfl_U, 2, 2);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_tax2P, 3, 14);
			this.TableLayoutPanel2.Controls.Add(this.lbl_MyFlaCounties, 0, 2);
			this.TableLayoutPanel2.Controls.Add(this.Label_DOI, 0, 18);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_tax2U, 2, 14);
			this.TableLayoutPanel2.Controls.Add(this.Label_stCode, 0, 17);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_otherP, 3, 13);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_courtP, 3, 3);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_otherU, 2, 13);
			this.TableLayoutPanel2.Controls.Add(this.Label_secState, 0, 16);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_asrP, 3, 9);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_probateP, 3, 5);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_asrU, 2, 9);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_courtU, 2, 3);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_tax1P, 3, 8);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_muniP, 3, 6);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_tax1U, 2, 8);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_probateU, 2, 5);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_muniU, 2, 6);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_prothonP, 3, 4);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_landP, 3, 1);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_prothonU, 2, 4);
			this.TableLayoutPanel2.Controls.Add(this.LabelOtherURL, 0, 13);
			this.TableLayoutPanel2.Controls.Add(this.txt_login_landU, 2, 1);
			this.TableLayoutPanel2.Controls.Add(this.LabelCountyURL, 0, 1);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabelOtherTax, 1, 14);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabelSheriff, 1, 11);
			this.TableLayoutPanel2.Controls.Add(this.LabelUCC, 0, 15);
			this.TableLayoutPanel2.Controls.Add(this.txtComments, 0, 19);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabelCounty, 1, 1);
			this.TableLayoutPanel2.Controls.Add(this.LabelOtherTax, 0, 14);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabelForeclosure, 1, 12);
			this.TableLayoutPanel2.Controls.Add(this.LabelCourt, 0, 3);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabelMuniCourt, 1, 6);
			this.TableLayoutPanel2.Controls.Add(this.LabelForeclosures, 0, 12);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabelMaps, 1, 10);
			this.TableLayoutPanel2.Controls.Add(this.LabelSheriff, 0, 11);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabelAssessor, 1, 9);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabelTax, 1, 8);
			this.TableLayoutPanel2.Controls.Add(this.LabelMapsGIS, 0, 10);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabelCoHome, 1, 7);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabelCourt, 1, 3);
			this.TableLayoutPanel2.Controls.Add(this.LabelProthon, 0, 4);
			this.TableLayoutPanel2.Controls.Add(this.LabelAssessor, 0, 9);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabelProthon, 1, 4);
			this.TableLayoutPanel2.Controls.Add(this.LabelCountyTax, 0, 8);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabelProbate, 1, 5);
			this.TableLayoutPanel2.Controls.Add(this.LabelCountyHome, 0, 7);
			this.TableLayoutPanel2.Controls.Add(this.LabelMuniCourt, 0, 6);
			this.TableLayoutPanel2.Controls.Add(this.LabelProbate, 0, 5);
			this.TableLayoutPanel2.Controls.Add(this.Label_user, 2, 0);
			this.TableLayoutPanel2.Controls.Add(this.Label_pwd, 3, 0);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabelPlats, 2, 10);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabel_OtherURL, 1, 13);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabel_UCC, 1, 15);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabel_SecState, 1, 16);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabel_State_Code, 1, 17);
			this.TableLayoutPanel2.Controls.Add(this.LinkLabel_DeptIns, 1, 18);
			this.TableLayoutPanel2.Location = new System.Drawing.Point(12, 22);
			this.TableLayoutPanel2.Name = "TableLayoutPanel2";
			this.TableLayoutPanel2.Padding = new System.Windows.Forms.Padding(1);
			this.TableLayoutPanel2.RowCount = 20;
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.Size = new System.Drawing.Size(400, 408);
			this.TableLayoutPanel2.TabIndex = 57;
			// 
			// txt_myfl_P
			// 
			this.txt_myfl_P.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_myfl_P.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_myfl_P.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_myfl_P.Location = new System.Drawing.Point(313, 38);
			this.txt_myfl_P.Name = "txt_myfl_P";
			this.txt_myfl_P.ReadOnly = true;
			this.txt_myfl_P.Size = new System.Drawing.Size(77, 13);
			this.txt_myfl_P.TabIndex = 201;
			this.txt_myfl_P.WordWrap = false;
			// 
			// LinkLabel_MyFlCountiesURL
			// 
			this.LinkLabel_MyFlCountiesURL.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabel_MyFlCountiesURL.AutoSize = true;
			this.LinkLabel_MyFlCountiesURL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabel_MyFlCountiesURL.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabel_MyFlCountiesURL.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabel_MyFlCountiesURL.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabel_MyFlCountiesURL.Location = new System.Drawing.Point(125, 35);
			this.LinkLabel_MyFlCountiesURL.Name = "LinkLabel_MyFlCountiesURL";
			this.LinkLabel_MyFlCountiesURL.Size = new System.Drawing.Size(103, 15);
			this.LinkLabel_MyFlCountiesURL.TabIndex = 214;
			this.LinkLabel_MyFlCountiesURL.TabStop = true;
			this.LinkLabel_MyFlCountiesURL.Text = "MYFLORIDA.COM";
			this.LinkLabel_MyFlCountiesURL.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabel_MyFlCountiesURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_MyFla_LinkClicked);
			// 
			// txt_myfl_U
			// 
			this.txt_myfl_U.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_myfl_U.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_myfl_U.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_myfl_U.Location = new System.Drawing.Point(240, 38);
			this.txt_myfl_U.Name = "txt_myfl_U";
			this.txt_myfl_U.ReadOnly = true;
			this.txt_myfl_U.Size = new System.Drawing.Size(67, 13);
			this.txt_myfl_U.TabIndex = 198;
			this.txt_myfl_U.WordWrap = false;
			// 
			// txt_login_tax2P
			// 
			this.txt_login_tax2P.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_tax2P.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_tax2P.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_tax2P.Location = new System.Drawing.Point(313, 250);
			this.txt_login_tax2P.Name = "txt_login_tax2P";
			this.txt_login_tax2P.ReadOnly = true;
			this.txt_login_tax2P.Size = new System.Drawing.Size(77, 13);
			this.txt_login_tax2P.TabIndex = 212;
			this.txt_login_tax2P.WordWrap = false;
			// 
			// lbl_MyFlaCounties
			// 
			this.lbl_MyFlaCounties.AutoSize = true;
			this.lbl_MyFlaCounties.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_MyFlaCounties.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.lbl_MyFlaCounties.Location = new System.Drawing.Point(4, 35);
			this.lbl_MyFlaCounties.Name = "lbl_MyFlaCounties";
			this.lbl_MyFlaCounties.Size = new System.Drawing.Size(87, 15);
			this.lbl_MyFlaCounties.TabIndex = 213;
			this.lbl_MyFlaCounties.Text = "MyFlorida.com";
			// 
			// Label_DOI
			// 
			this.Label_DOI.AutoSize = true;
			this.Label_DOI.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_DOI.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label_DOI.Location = new System.Drawing.Point(4, 311);
			this.Label_DOI.Name = "Label_DOI";
			this.Label_DOI.Size = new System.Drawing.Size(92, 15);
			this.Label_DOI.TabIndex = 190;
			this.Label_DOI.Text = "Agent Licensing";
			// 
			// txt_login_tax2U
			// 
			this.txt_login_tax2U.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_tax2U.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_tax2U.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_tax2U.Location = new System.Drawing.Point(240, 250);
			this.txt_login_tax2U.Name = "txt_login_tax2U";
			this.txt_login_tax2U.ReadOnly = true;
			this.txt_login_tax2U.Size = new System.Drawing.Size(67, 13);
			this.txt_login_tax2U.TabIndex = 211;
			this.txt_login_tax2U.WordWrap = false;
			// 
			// Label_stCode
			// 
			this.Label_stCode.AutoSize = true;
			this.Label_stCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_stCode.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label_stCode.Location = new System.Drawing.Point(4, 296);
			this.Label_stCode.Name = "Label_stCode";
			this.Label_stCode.Size = new System.Drawing.Size(115, 15);
			this.Label_stCode.TabIndex = 190;
			this.Label_stCode.Text = "Administrative Code";
			// 
			// txt_login_otherP
			// 
			this.txt_login_otherP.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_otherP.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_otherP.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_otherP.Location = new System.Drawing.Point(313, 231);
			this.txt_login_otherP.Name = "txt_login_otherP";
			this.txt_login_otherP.ReadOnly = true;
			this.txt_login_otherP.Size = new System.Drawing.Size(77, 13);
			this.txt_login_otherP.TabIndex = 210;
			this.txt_login_otherP.WordWrap = false;
			// 
			// txt_login_courtP
			// 
			this.txt_login_courtP.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_courtP.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_courtP.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_courtP.Location = new System.Drawing.Point(313, 57);
			this.txt_login_courtP.Name = "txt_login_courtP";
			this.txt_login_courtP.ReadOnly = true;
			this.txt_login_courtP.Size = new System.Drawing.Size(77, 13);
			this.txt_login_courtP.TabIndex = 198;
			this.txt_login_courtP.WordWrap = false;
			// 
			// txt_login_otherU
			// 
			this.txt_login_otherU.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_otherU.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_otherU.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_otherU.Location = new System.Drawing.Point(240, 231);
			this.txt_login_otherU.Name = "txt_login_otherU";
			this.txt_login_otherU.ReadOnly = true;
			this.txt_login_otherU.Size = new System.Drawing.Size(67, 13);
			this.txt_login_otherU.TabIndex = 209;
			this.txt_login_otherU.WordWrap = false;
			// 
			// Label_secState
			// 
			this.Label_secState.AutoSize = true;
			this.Label_secState.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_secState.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label_secState.Location = new System.Drawing.Point(4, 281);
			this.Label_secState.Name = "Label_secState";
			this.Label_secState.Size = new System.Drawing.Size(96, 15);
			this.Label_secState.TabIndex = 190;
			this.Label_secState.Text = "LLC/Corp Search";
			// 
			// txt_login_asrP
			// 
			this.txt_login_asrP.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_asrP.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_asrP.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_asrP.Location = new System.Drawing.Point(313, 167);
			this.txt_login_asrP.Name = "txt_login_asrP";
			this.txt_login_asrP.ReadOnly = true;
			this.txt_login_asrP.Size = new System.Drawing.Size(77, 13);
			this.txt_login_asrP.TabIndex = 208;
			this.txt_login_asrP.WordWrap = false;
			// 
			// txt_login_probateP
			// 
			this.txt_login_probateP.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_probateP.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_probateP.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_probateP.Location = new System.Drawing.Point(313, 95);
			this.txt_login_probateP.Name = "txt_login_probateP";
			this.txt_login_probateP.ReadOnly = true;
			this.txt_login_probateP.Size = new System.Drawing.Size(77, 13);
			this.txt_login_probateP.TabIndex = 202;
			this.txt_login_probateP.WordWrap = false;
			// 
			// txt_login_asrU
			// 
			this.txt_login_asrU.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_asrU.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_asrU.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_asrU.Location = new System.Drawing.Point(240, 167);
			this.txt_login_asrU.Name = "txt_login_asrU";
			this.txt_login_asrU.ReadOnly = true;
			this.txt_login_asrU.Size = new System.Drawing.Size(67, 13);
			this.txt_login_asrU.TabIndex = 207;
			this.txt_login_asrU.WordWrap = false;
			// 
			// txt_login_courtU
			// 
			this.txt_login_courtU.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_courtU.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_courtU.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_courtU.Location = new System.Drawing.Point(240, 57);
			this.txt_login_courtU.Name = "txt_login_courtU";
			this.txt_login_courtU.ReadOnly = true;
			this.txt_login_courtU.Size = new System.Drawing.Size(67, 13);
			this.txt_login_courtU.TabIndex = 197;
			this.txt_login_courtU.WordWrap = false;
			// 
			// txt_login_tax1P
			// 
			this.txt_login_tax1P.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_tax1P.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_tax1P.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_tax1P.Location = new System.Drawing.Point(313, 148);
			this.txt_login_tax1P.Name = "txt_login_tax1P";
			this.txt_login_tax1P.ReadOnly = true;
			this.txt_login_tax1P.Size = new System.Drawing.Size(77, 13);
			this.txt_login_tax1P.TabIndex = 206;
			this.txt_login_tax1P.WordWrap = false;
			// 
			// txt_login_muniP
			// 
			this.txt_login_muniP.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_muniP.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_muniP.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_muniP.Location = new System.Drawing.Point(313, 114);
			this.txt_login_muniP.Name = "txt_login_muniP";
			this.txt_login_muniP.ReadOnly = true;
			this.txt_login_muniP.Size = new System.Drawing.Size(77, 13);
			this.txt_login_muniP.TabIndex = 204;
			this.txt_login_muniP.WordWrap = false;
			// 
			// txt_login_tax1U
			// 
			this.txt_login_tax1U.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_tax1U.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_tax1U.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_tax1U.Location = new System.Drawing.Point(240, 148);
			this.txt_login_tax1U.Name = "txt_login_tax1U";
			this.txt_login_tax1U.ReadOnly = true;
			this.txt_login_tax1U.Size = new System.Drawing.Size(67, 13);
			this.txt_login_tax1U.TabIndex = 205;
			this.txt_login_tax1U.WordWrap = false;
			// 
			// txt_login_probateU
			// 
			this.txt_login_probateU.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_probateU.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_probateU.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_probateU.Location = new System.Drawing.Point(240, 95);
			this.txt_login_probateU.Name = "txt_login_probateU";
			this.txt_login_probateU.ReadOnly = true;
			this.txt_login_probateU.Size = new System.Drawing.Size(67, 13);
			this.txt_login_probateU.TabIndex = 201;
			this.txt_login_probateU.WordWrap = false;
			// 
			// txt_login_muniU
			// 
			this.txt_login_muniU.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_muniU.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_muniU.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_muniU.Location = new System.Drawing.Point(240, 114);
			this.txt_login_muniU.Name = "txt_login_muniU";
			this.txt_login_muniU.ReadOnly = true;
			this.txt_login_muniU.Size = new System.Drawing.Size(67, 13);
			this.txt_login_muniU.TabIndex = 203;
			this.txt_login_muniU.WordWrap = false;
			// 
			// txt_login_prothonP
			// 
			this.txt_login_prothonP.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_prothonP.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_prothonP.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_prothonP.Location = new System.Drawing.Point(313, 76);
			this.txt_login_prothonP.Name = "txt_login_prothonP";
			this.txt_login_prothonP.ReadOnly = true;
			this.txt_login_prothonP.Size = new System.Drawing.Size(77, 13);
			this.txt_login_prothonP.TabIndex = 200;
			this.txt_login_prothonP.WordWrap = false;
			// 
			// txt_login_landP
			// 
			this.txt_login_landP.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_landP.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_landP.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_landP.Location = new System.Drawing.Point(313, 19);
			this.txt_login_landP.Name = "txt_login_landP";
			this.txt_login_landP.ReadOnly = true;
			this.txt_login_landP.Size = new System.Drawing.Size(77, 13);
			this.txt_login_landP.TabIndex = 196;
			this.txt_login_landP.WordWrap = false;
			// 
			// txt_login_prothonU
			// 
			this.txt_login_prothonU.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_prothonU.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_prothonU.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_prothonU.Location = new System.Drawing.Point(240, 76);
			this.txt_login_prothonU.Name = "txt_login_prothonU";
			this.txt_login_prothonU.ReadOnly = true;
			this.txt_login_prothonU.Size = new System.Drawing.Size(67, 13);
			this.txt_login_prothonU.TabIndex = 199;
			this.txt_login_prothonU.WordWrap = false;
			// 
			// LabelOtherURL
			// 
			this.LabelOtherURL.AutoSize = true;
			this.LabelOtherURL.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelOtherURL.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.LabelOtherURL.Location = new System.Drawing.Point(4, 228);
			this.LabelOtherURL.Name = "LabelOtherURL";
			this.LabelOtherURL.Size = new System.Drawing.Size(82, 13);
			this.LabelOtherURL.TabIndex = 61;
			this.LabelOtherURL.Text = "Other Website";
			// 
			// txt_login_landU
			// 
			this.txt_login_landU.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_login_landU.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txt_login_landU.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_login_landU.Location = new System.Drawing.Point(240, 19);
			this.txt_login_landU.Name = "txt_login_landU";
			this.txt_login_landU.ReadOnly = true;
			this.txt_login_landU.Size = new System.Drawing.Size(67, 13);
			this.txt_login_landU.TabIndex = 195;
			this.txt_login_landU.WordWrap = false;
			// 
			// LabelCountyURL
			// 
			this.LabelCountyURL.AutoSize = true;
			this.LabelCountyURL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelCountyURL.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.LabelCountyURL.Location = new System.Drawing.Point(4, 16);
			this.LabelCountyURL.Name = "LabelCountyURL";
			this.LabelCountyURL.Size = new System.Drawing.Size(65, 15);
			this.LabelCountyURL.TabIndex = 11;
			this.LabelCountyURL.Text = "Land Index";
			// 
			// LinkLabelOtherTax
			// 
			this.LinkLabelOtherTax.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabelOtherTax.AutoSize = true;
			this.LinkLabelOtherTax.DisabledLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelOtherTax.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabelOtherTax.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabelOtherTax.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabelOtherTax.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabelOtherTax.Location = new System.Drawing.Point(125, 247);
			this.LinkLabelOtherTax.Name = "LinkLabelOtherTax";
			this.LinkLabelOtherTax.Size = new System.Drawing.Size(39, 15);
			this.LinkLabelOtherTax.TabIndex = 54;
			this.LinkLabelOtherTax.TabStop = true;
			this.LinkLabelOtherTax.Text = "TAXES";
			this.LinkLabelOtherTax.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelOtherTax.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelOtherTax_LinkClicked);
			// 
			// LinkLabelSheriff
			// 
			this.LinkLabelSheriff.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabelSheriff.AutoSize = true;
			this.LinkLabelSheriff.DisabledLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelSheriff.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabelSheriff.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabelSheriff.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabelSheriff.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabelSheriff.Location = new System.Drawing.Point(125, 198);
			this.LinkLabelSheriff.Name = "LinkLabelSheriff";
			this.LinkLabelSheriff.Size = new System.Drawing.Size(50, 15);
			this.LinkLabelSheriff.TabIndex = 56;
			this.LinkLabelSheriff.TabStop = true;
			this.LinkLabelSheriff.Text = "SHERIFF";
			this.LinkLabelSheriff.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelSheriff.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelSheriff_LinkClicked);
			// 
			// LabelUCC
			// 
			this.LabelUCC.AutoSize = true;
			this.LabelUCC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelUCC.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.LabelUCC.Location = new System.Drawing.Point(4, 266);
			this.LabelUCC.Name = "LabelUCC";
			this.LabelUCC.Size = new System.Drawing.Size(68, 15);
			this.LabelUCC.TabIndex = 194;
			this.LabelUCC.Text = "UCC Filings";
			// 
			// txtComments
			// 
			this.txtComments.BackColor = System.Drawing.Color.GhostWhite;
			this.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TableLayoutPanel2.SetColumnSpan(this.txtComments, 4);
			this.txtComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtComments.ForeColor = System.Drawing.Color.Purple;
			this.txtComments.Location = new System.Drawing.Point(4, 329);
			this.txtComments.MaxLength = 100000;
			this.txtComments.Multiline = true;
			this.txtComments.Name = "txtComments";
			this.txtComments.ReadOnly = true;
			this.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtComments.Size = new System.Drawing.Size(392, 75);
			this.txtComments.TabIndex = 47;
			this.txtComments.Text = "Comments";
			// 
			// LinkLabelCounty
			// 
			this.LinkLabelCounty.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabelCounty.AutoSize = true;
			this.LinkLabelCounty.BackColor = System.Drawing.Color.Transparent;
			this.LinkLabelCounty.DisabledLinkColor = System.Drawing.Color.Navy;
			this.LinkLabelCounty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabelCounty.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabelCounty.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabelCounty.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabelCounty.Location = new System.Drawing.Point(125, 16);
			this.LinkLabelCounty.Name = "LinkLabelCounty";
			this.LinkLabelCounty.Size = new System.Drawing.Size(38, 15);
			this.LinkLabelCounty.TabIndex = 5;
			this.LinkLabelCounty.TabStop = true;
			this.LinkLabelCounty.Text = "LAND";
			this.LinkLabelCounty.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelCounty.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelCounty_LinkClicked);
			// 
			// LabelOtherTax
			// 
			this.LabelOtherTax.AutoSize = true;
			this.LabelOtherTax.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelOtherTax.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.LabelOtherTax.Location = new System.Drawing.Point(4, 247);
			this.LabelOtherTax.Name = "LabelOtherTax";
			this.LabelOtherTax.Size = new System.Drawing.Size(84, 15);
			this.LabelOtherTax.TabIndex = 55;
			this.LabelOtherTax.Text = "Other Tax Web";
			// 
			// LinkLabelForeclosure
			// 
			this.LinkLabelForeclosure.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabelForeclosure.AutoSize = true;
			this.LinkLabelForeclosure.BackColor = System.Drawing.Color.Transparent;
			this.LinkLabelForeclosure.DisabledLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelForeclosure.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabelForeclosure.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabelForeclosure.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabelForeclosure.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabelForeclosure.Location = new System.Drawing.Point(125, 213);
			this.LinkLabelForeclosure.Name = "LinkLabelForeclosure";
			this.LinkLabelForeclosure.Size = new System.Drawing.Size(85, 15);
			this.LinkLabelForeclosure.TabIndex = 48;
			this.LinkLabelForeclosure.TabStop = true;
			this.LinkLabelForeclosure.Text = "FORECLOSURE";
			this.LinkLabelForeclosure.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelForeclosure.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelForeclosure_LinkClicked);
			// 
			// LabelCourt
			// 
			this.LabelCourt.AutoSize = true;
			this.LabelCourt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelCourt.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.LabelCourt.Location = new System.Drawing.Point(4, 54);
			this.LabelCourt.Name = "LabelCourt";
			this.LabelCourt.Size = new System.Drawing.Size(69, 15);
			this.LabelCourt.TabIndex = 12;
			this.LabelCourt.Text = "Court Index";
			// 
			// LinkLabelMuniCourt
			// 
			this.LinkLabelMuniCourt.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabelMuniCourt.AutoSize = true;
			this.LinkLabelMuniCourt.DisabledLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelMuniCourt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabelMuniCourt.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabelMuniCourt.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabelMuniCourt.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabelMuniCourt.Location = new System.Drawing.Point(125, 111);
			this.LinkLabelMuniCourt.Name = "LinkLabelMuniCourt";
			this.LinkLabelMuniCourt.Size = new System.Drawing.Size(109, 15);
			this.LinkLabelMuniCourt.TabIndex = 52;
			this.LinkLabelMuniCourt.TabStop = true;
			this.LinkLabelMuniCourt.Text = "MUNICIPAL COURT";
			this.LinkLabelMuniCourt.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelMuniCourt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelTax2_LinkClicked);
			// 
			// LabelForeclosures
			// 
			this.LabelForeclosures.AutoSize = true;
			this.LabelForeclosures.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelForeclosures.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.LabelForeclosures.Location = new System.Drawing.Point(4, 213);
			this.LabelForeclosures.Name = "LabelForeclosures";
			this.LabelForeclosures.Size = new System.Drawing.Size(73, 15);
			this.LabelForeclosures.TabIndex = 49;
			this.LabelForeclosures.Text = "Foreclosures";
			// 
			// LinkLabelMaps
			// 
			this.LinkLabelMaps.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabelMaps.AutoSize = true;
			this.LinkLabelMaps.DisabledLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelMaps.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabelMaps.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabelMaps.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabelMaps.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabelMaps.Location = new System.Drawing.Point(125, 183);
			this.LinkLabelMaps.Name = "LinkLabelMaps";
			this.LinkLabelMaps.Size = new System.Drawing.Size(39, 15);
			this.LinkLabelMaps.TabIndex = 9;
			this.LinkLabelMaps.TabStop = true;
			this.LinkLabelMaps.Text = "MAPS";
			this.LinkLabelMaps.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelMaps.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelMaps_LinkClicked);
			// 
			// LabelSheriff
			// 
			this.LabelSheriff.AutoSize = true;
			this.LabelSheriff.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelSheriff.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.LabelSheriff.Location = new System.Drawing.Point(4, 198);
			this.LabelSheriff.Name = "LabelSheriff";
			this.LabelSheriff.Size = new System.Drawing.Size(76, 15);
			this.LabelSheriff.TabIndex = 51;
			this.LabelSheriff.Text = "Sheriff\'s Web";
			// 
			// LinkLabelAssessor
			// 
			this.LinkLabelAssessor.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabelAssessor.AutoSize = true;
			this.LinkLabelAssessor.DisabledLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelAssessor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabelAssessor.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabelAssessor.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabelAssessor.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabelAssessor.Location = new System.Drawing.Point(125, 164);
			this.LinkLabelAssessor.Name = "LinkLabelAssessor";
			this.LinkLabelAssessor.Size = new System.Drawing.Size(61, 15);
			this.LinkLabelAssessor.TabIndex = 7;
			this.LinkLabelAssessor.TabStop = true;
			this.LinkLabelAssessor.Text = "ASSESSOR";
			this.LinkLabelAssessor.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			// 
			// LinkLabelTax
			// 
			this.LinkLabelTax.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabelTax.AutoSize = true;
			this.LinkLabelTax.DisabledLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelTax.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabelTax.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabelTax.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabelTax.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabelTax.Location = new System.Drawing.Point(125, 145);
			this.LinkLabelTax.Name = "LinkLabelTax";
			this.LinkLabelTax.Size = new System.Drawing.Size(39, 15);
			this.LinkLabelTax.TabIndex = 6;
			this.LinkLabelTax.TabStop = true;
			this.LinkLabelTax.Text = "TAXES";
			this.LinkLabelTax.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelTax.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelTax_LinkClicked);
			// 
			// LabelMapsGIS
			// 
			this.LabelMapsGIS.AutoSize = true;
			this.LabelMapsGIS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelMapsGIS.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.LabelMapsGIS.Location = new System.Drawing.Point(4, 183);
			this.LabelMapsGIS.Name = "LabelMapsGIS";
			this.LabelMapsGIS.Size = new System.Drawing.Size(58, 15);
			this.LabelMapsGIS.TabIndex = 22;
			this.LabelMapsGIS.Text = "Maps/GIS";
			// 
			// LinkLabelCoHome
			// 
			this.LinkLabelCoHome.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabelCoHome.AutoSize = true;
			this.LinkLabelCoHome.BackColor = System.Drawing.Color.Transparent;
			this.LinkLabelCoHome.DisabledLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelCoHome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabelCoHome.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabelCoHome.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabelCoHome.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabelCoHome.Location = new System.Drawing.Point(125, 130);
			this.LinkLabelCoHome.Name = "LinkLabelCoHome";
			this.LinkLabelCoHome.Size = new System.Drawing.Size(92, 15);
			this.LinkLabelCoHome.TabIndex = 25;
			this.LinkLabelCoHome.TabStop = true;
			this.LinkLabelCoHome.Text = "COUNTY HOME";
			this.LinkLabelCoHome.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelCoHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelCoHome_LinkClicked);
			// 
			// LinkLabelCourt
			// 
			this.LinkLabelCourt.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabelCourt.AutoSize = true;
			this.LinkLabelCourt.BackColor = System.Drawing.Color.Transparent;
			this.LinkLabelCourt.DisabledLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelCourt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabelCourt.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabelCourt.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabelCourt.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabelCourt.Location = new System.Drawing.Point(125, 54);
			this.LinkLabelCourt.Name = "LinkLabelCourt";
			this.LinkLabelCourt.Size = new System.Drawing.Size(44, 15);
			this.LinkLabelCourt.TabIndex = 10;
			this.LinkLabelCourt.TabStop = true;
			this.LinkLabelCourt.Text = "COURT";
			this.LinkLabelCourt.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelCourt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelCourt_LinkClicked);
			// 
			// LabelProthon
			// 
			this.LabelProthon.AutoSize = true;
			this.LabelProthon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelProthon.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.LabelProthon.Location = new System.Drawing.Point(4, 73);
			this.LabelProthon.Name = "LabelProthon";
			this.LabelProthon.Size = new System.Drawing.Size(50, 15);
			this.LabelProthon.TabIndex = 15;
			this.LabelProthon.Text = "Prothon";
			// 
			// LabelAssessor
			// 
			this.LabelAssessor.AutoSize = true;
			this.LabelAssessor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelAssessor.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.LabelAssessor.Location = new System.Drawing.Point(4, 164);
			this.LabelAssessor.Name = "LabelAssessor";
			this.LabelAssessor.Size = new System.Drawing.Size(52, 15);
			this.LabelAssessor.TabIndex = 14;
			this.LabelAssessor.Text = "Assessor";
			// 
			// LinkLabelProthon
			// 
			this.LinkLabelProthon.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabelProthon.AutoSize = true;
			this.LinkLabelProthon.BackColor = System.Drawing.Color.Transparent;
			this.LinkLabelProthon.DisabledLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelProthon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabelProthon.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabelProthon.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabelProthon.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabelProthon.Location = new System.Drawing.Point(125, 73);
			this.LinkLabelProthon.Name = "LinkLabelProthon";
			this.LinkLabelProthon.Size = new System.Drawing.Size(97, 15);
			this.LinkLabelProthon.TabIndex = 8;
			this.LinkLabelProthon.TabStop = true;
			this.LinkLabelProthon.Text = "PROTHONOTARY";
			this.LinkLabelProthon.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelProthon.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelPro_LinkClicked);
			// 
			// LabelCountyTax
			// 
			this.LabelCountyTax.AutoSize = true;
			this.LabelCountyTax.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelCountyTax.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.LabelCountyTax.Location = new System.Drawing.Point(4, 145);
			this.LabelCountyTax.Name = "LabelCountyTax";
			this.LabelCountyTax.Size = new System.Drawing.Size(77, 15);
			this.LabelCountyTax.TabIndex = 13;
			this.LabelCountyTax.Text = "County Taxes";
			// 
			// LinkLabelProbate
			// 
			this.LinkLabelProbate.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabelProbate.AutoSize = true;
			this.LinkLabelProbate.BackColor = System.Drawing.Color.Transparent;
			this.LinkLabelProbate.DisabledLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelProbate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabelProbate.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabelProbate.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabelProbate.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabelProbate.Location = new System.Drawing.Point(125, 92);
			this.LinkLabelProbate.Name = "LinkLabelProbate";
			this.LinkLabelProbate.Size = new System.Drawing.Size(56, 15);
			this.LinkLabelProbate.TabIndex = 23;
			this.LinkLabelProbate.TabStop = true;
			this.LinkLabelProbate.Text = "PROBATE";
			this.LinkLabelProbate.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabelProbate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelProbate_LinkClicked);
			// 
			// LabelCountyHome
			// 
			this.LabelCountyHome.AutoSize = true;
			this.LabelCountyHome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelCountyHome.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.LabelCountyHome.Location = new System.Drawing.Point(4, 130);
			this.LabelCountyHome.Name = "LabelCountyHome";
			this.LabelCountyHome.Size = new System.Drawing.Size(111, 15);
			this.LabelCountyHome.TabIndex = 26;
			this.LabelCountyHome.Text = "County Home Page";
			// 
			// LabelMuniCourt
			// 
			this.LabelMuniCourt.AutoSize = true;
			this.LabelMuniCourt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelMuniCourt.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.LabelMuniCourt.Location = new System.Drawing.Point(4, 111);
			this.LabelMuniCourt.Name = "LabelMuniCourt";
			this.LabelMuniCourt.Size = new System.Drawing.Size(93, 15);
			this.LabelMuniCourt.TabIndex = 53;
			this.LabelMuniCourt.Text = "Municipal Court";
			// 
			// LabelProbate
			// 
			this.LabelProbate.AutoSize = true;
			this.LabelProbate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelProbate.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.LabelProbate.Location = new System.Drawing.Point(4, 92);
			this.LabelProbate.Name = "LabelProbate";
			this.LabelProbate.Size = new System.Drawing.Size(81, 15);
			this.LabelProbate.TabIndex = 24;
			this.LabelProbate.Text = "Probate Court";
			// 
			// Label_user
			// 
			this.Label_user.AutoSize = true;
			this.Label_user.Location = new System.Drawing.Point(240, 1);
			this.Label_user.Name = "Label_user";
			this.Label_user.Size = new System.Drawing.Size(64, 15);
			this.Label_user.TabIndex = 58;
			this.Label_user.Text = "Username";
			// 
			// Label_pwd
			// 
			this.Label_pwd.AutoSize = true;
			this.Label_pwd.Location = new System.Drawing.Point(313, 1);
			this.Label_pwd.Name = "Label_pwd";
			this.Label_pwd.Size = new System.Drawing.Size(59, 15);
			this.Label_pwd.TabIndex = 59;
			this.Label_pwd.Text = "Password";
			// 
			// LinkLabelPlats
			// 
			this.LinkLabelPlats.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabelPlats.AutoSize = true;
			this.LinkLabelPlats.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabelPlats.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabelPlats.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabelPlats.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabelPlats.Location = new System.Drawing.Point(240, 183);
			this.LinkLabelPlats.Name = "LinkLabelPlats";
			this.LinkLabelPlats.Size = new System.Drawing.Size(39, 15);
			this.LinkLabelPlats.TabIndex = 60;
			this.LinkLabelPlats.TabStop = true;
			this.LinkLabelPlats.Text = "PLATS";
			this.LinkLabelPlats.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			// 
			// LinkLabel_OtherURL
			// 
			this.LinkLabel_OtherURL.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabel_OtherURL.AutoSize = true;
			this.LinkLabel_OtherURL.BackColor = System.Drawing.Color.Transparent;
			this.LinkLabel_OtherURL.DisabledLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabel_OtherURL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabel_OtherURL.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabel_OtherURL.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabel_OtherURL.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabel_OtherURL.Location = new System.Drawing.Point(125, 228);
			this.LinkLabel_OtherURL.Name = "LinkLabel_OtherURL";
			this.LinkLabel_OtherURL.Size = new System.Drawing.Size(67, 15);
			this.LinkLabel_OtherURL.TabIndex = 62;
			this.LinkLabel_OtherURL.TabStop = true;
			this.LinkLabel_OtherURL.Text = "OTHER URL";
			this.LinkLabel_OtherURL.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			// 
			// LinkLabel_UCC
			// 
			this.LinkLabel_UCC.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabel_UCC.AutoSize = true;
			this.LinkLabel_UCC.BackColor = System.Drawing.Color.Transparent;
			this.LinkLabel_UCC.DisabledLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabel_UCC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabel_UCC.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabel_UCC.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabel_UCC.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabel_UCC.Location = new System.Drawing.Point(125, 266);
			this.LinkLabel_UCC.Name = "LinkLabel_UCC";
			this.LinkLabel_UCC.Size = new System.Drawing.Size(78, 15);
			this.LinkLabel_UCC.TabIndex = 190;
			this.LinkLabel_UCC.TabStop = true;
			this.LinkLabel_UCC.Text = "UCC SEARCH";
			this.LinkLabel_UCC.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			// 
			// LinkLabel_SecState
			// 
			this.LinkLabel_SecState.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabel_SecState.AutoSize = true;
			this.LinkLabel_SecState.BackColor = System.Drawing.Color.Transparent;
			this.LinkLabel_SecState.DisabledLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabel_SecState.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabel_SecState.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabel_SecState.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabel_SecState.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabel_SecState.Location = new System.Drawing.Point(125, 281);
			this.LinkLabel_SecState.Name = "LinkLabel_SecState";
			this.LinkLabel_SecState.Size = new System.Drawing.Size(94, 15);
			this.LinkLabel_SecState.TabIndex = 191;
			this.LinkLabel_SecState.TabStop = true;
			this.LinkLabel_SecState.Text = "SECT\'Y OF STATE";
			this.LinkLabel_SecState.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			// 
			// LinkLabel_State_Code
			// 
			this.LinkLabel_State_Code.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabel_State_Code.AutoSize = true;
			this.LinkLabel_State_Code.BackColor = System.Drawing.Color.Transparent;
			this.LinkLabel_State_Code.DisabledLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabel_State_Code.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabel_State_Code.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabel_State_Code.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabel_State_Code.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabel_State_Code.Location = new System.Drawing.Point(125, 296);
			this.LinkLabel_State_Code.Name = "LinkLabel_State_Code";
			this.LinkLabel_State_Code.Size = new System.Drawing.Size(71, 15);
			this.LinkLabel_State_Code.TabIndex = 192;
			this.LinkLabel_State_Code.TabStop = true;
			this.LinkLabel_State_Code.Text = "STATE CODE";
			this.LinkLabel_State_Code.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			// 
			// LinkLabel_DeptIns
			// 
			this.LinkLabel_DeptIns.ActiveLinkColor = System.Drawing.Color.GhostWhite;
			this.LinkLabel_DeptIns.AutoSize = true;
			this.LinkLabel_DeptIns.BackColor = System.Drawing.Color.Transparent;
			this.LinkLabel_DeptIns.DisabledLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.LinkLabel_DeptIns.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabel_DeptIns.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabel_DeptIns.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.LinkLabel_DeptIns.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabel_DeptIns.Location = new System.Drawing.Point(125, 311);
			this.LinkLabel_DeptIns.Name = "LinkLabel_DeptIns";
			this.LinkLabel_DeptIns.Size = new System.Drawing.Size(73, 15);
			this.LinkLabel_DeptIns.TabIndex = 193;
			this.LinkLabel_DeptIns.TabStop = true;
			this.LinkLabel_DeptIns.Text = "DEPT OF INS";
			this.LinkLabel_DeptIns.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			// 
			// GroupBox4
			// 
			this.GroupBox4.BackColor = System.Drawing.Color.GhostWhite;
			this.GroupBox4.Controls.Add(this.LabelUseIns);
			this.GroupBox4.Controls.Add(this.LabelUseProps);
			this.GroupBox4.Controls.Add(this.LabelUseCopy);
			this.GroupBox4.Controls.Add(this.Label20);
			this.GroupBox4.Controls.Add(this.Label15);
			this.GroupBox4.Controls.Add(this.Label28);
			this.GroupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.GroupBox4.Location = new System.Drawing.Point(438, 3);
			this.GroupBox4.Name = "GroupBox4";
			this.GroupBox4.Size = new System.Drawing.Size(143, 77);
			this.GroupBox4.TabIndex = 182;
			this.GroupBox4.TabStop = false;
			this.GroupBox4.Text = "PRODUCTS ONLINE";
			// 
			// LabelUseIns
			// 
			this.LabelUseIns.AutoSize = true;
			this.LabelUseIns.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelUseIns.ForeColor = System.Drawing.Color.Black;
			this.LabelUseIns.Location = new System.Drawing.Point(76, 22);
			this.LabelUseIns.Name = "LabelUseIns";
			this.LabelUseIns.Size = new System.Drawing.Size(12, 15);
			this.LabelUseIns.TabIndex = 67;
			this.LabelUseIns.Text = "*";
			// 
			// LabelUseProps
			// 
			this.LabelUseProps.AutoSize = true;
			this.LabelUseProps.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelUseProps.ForeColor = System.Drawing.Color.Black;
			this.LabelUseProps.Location = new System.Drawing.Point(76, 37);
			this.LabelUseProps.Name = "LabelUseProps";
			this.LabelUseProps.Size = new System.Drawing.Size(12, 15);
			this.LabelUseProps.TabIndex = 66;
			this.LabelUseProps.Text = "*";
			// 
			// LabelUseCopy
			// 
			this.LabelUseCopy.AutoSize = true;
			this.LabelUseCopy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelUseCopy.ForeColor = System.Drawing.Color.Black;
			this.LabelUseCopy.Location = new System.Drawing.Point(76, 52);
			this.LabelUseCopy.Name = "LabelUseCopy";
			this.LabelUseCopy.Size = new System.Drawing.Size(12, 15);
			this.LabelUseCopy.TabIndex = 65;
			this.LabelUseCopy.Text = "*";
			// 
			// Label20
			// 
			this.Label20.AutoSize = true;
			this.Label20.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label20.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label20.Location = new System.Drawing.Point(6, 37);
			this.Label20.Name = "Label20";
			this.Label20.Size = new System.Drawing.Size(64, 15);
			this.Label20.TabIndex = 64;
			this.Label20.Text = "Prop Repts";
			// 
			// Label15
			// 
			this.Label15.AutoSize = true;
			this.Label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label15.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label15.Location = new System.Drawing.Point(6, 22);
			this.Label15.Name = "Label15";
			this.Label15.Size = new System.Drawing.Size(58, 15);
			this.Label15.TabIndex = 63;
			this.Label15.Text = "Insurance";
			// 
			// Label28
			// 
			this.Label28.AutoSize = true;
			this.Label28.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label28.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label28.Location = new System.Drawing.Point(6, 52);
			this.Label28.Name = "Label28";
			this.Label28.Size = new System.Drawing.Size(67, 15);
			this.Label28.TabIndex = 62;
			this.Label28.Text = "Doc Copies";
			// 
			// GroupBox3
			// 
			this.GroupBox3.BackColor = System.Drawing.Color.GhostWhite;
			this.GroupBox3.Controls.Add(this.Label4Tap);
			this.GroupBox3.Controls.Add(this.Label5dtree);
			this.GroupBox3.Controls.Add(this.Label6RV);
			this.GroupBox3.Controls.Add(this.LinkLabel10);
			this.GroupBox3.Controls.Add(this.LinkLabel9);
			this.GroupBox3.Controls.Add(this.LinkLabel16);
			this.GroupBox3.Controls.Add(this.LabelUseTap);
			this.GroupBox3.Controls.Add(this.LabelUseDtree);
			this.GroupBox3.Controls.Add(this.LabelUseRV);
			this.GroupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.GroupBox3.Location = new System.Drawing.Point(592, 3);
			this.GroupBox3.Name = "GroupBox3";
			this.GroupBox3.Size = new System.Drawing.Size(225, 77);
			this.GroupBox3.TabIndex = 181;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "3rd PARTY VENDORS";
			// 
			// Label4Tap
			// 
			this.Label4Tap.AutoSize = true;
			this.Label4Tap.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label4Tap.ForeColor = System.Drawing.Color.Black;
			this.Label4Tap.Location = new System.Drawing.Point(138, 25);
			this.Label4Tap.Name = "Label4Tap";
			this.Label4Tap.Size = new System.Drawing.Size(59, 12);
			this.Label4Tap.TabIndex = 65;
			this.Label4Tap.Text = "MORE INFO";
			this.Label4Tap.Click += new System.EventHandler(this.Label4Tap_Click);
			this.Label4Tap.MouseLeave += new System.EventHandler(this.Label4Tap_Leave);
			this.Label4Tap.MouseHover += new System.EventHandler(this.Label4Tap_Hover);
			// 
			// Label5dtree
			// 
			this.Label5dtree.AutoSize = true;
			this.Label5dtree.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label5dtree.ForeColor = System.Drawing.Color.Black;
			this.Label5dtree.Location = new System.Drawing.Point(138, 55);
			this.Label5dtree.Name = "Label5dtree";
			this.Label5dtree.Size = new System.Drawing.Size(59, 12);
			this.Label5dtree.TabIndex = 66;
			this.Label5dtree.Text = "MORE INFO";
			this.Label5dtree.Click += new System.EventHandler(this.Label5dtree_Click);
			this.Label5dtree.MouseLeave += new System.EventHandler(this.Label5dtree_Leave);
			this.Label5dtree.MouseHover += new System.EventHandler(this.Label5dtree_Hover);
			// 
			// Label6RV
			// 
			this.Label6RV.AutoSize = true;
			this.Label6RV.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label6RV.ForeColor = System.Drawing.Color.Black;
			this.Label6RV.Location = new System.Drawing.Point(138, 40);
			this.Label6RV.Name = "Label6RV";
			this.Label6RV.Size = new System.Drawing.Size(59, 12);
			this.Label6RV.TabIndex = 64;
			this.Label6RV.Text = "MORE INFO";
			this.Label6RV.Click += new System.EventHandler(this.Label6RV_Click);
			this.Label6RV.MouseLeave += new System.EventHandler(this.Label6RV_Leave);
			this.Label6RV.MouseHover += new System.EventHandler(this.Label6RV_Hover);
			// 
			// LinkLabel10
			// 
			this.LinkLabel10.ActiveLinkColor = System.Drawing.Color.Plum;
			this.LinkLabel10.AutoSize = true;
			this.LinkLabel10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabel10.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabel10.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabel10.Location = new System.Drawing.Point(6, 54);
			this.LinkLabel10.Name = "LinkLabel10";
			this.LinkLabel10.Size = new System.Drawing.Size(54, 15);
			this.LinkLabel10.TabIndex = 25;
			this.LinkLabel10.TabStop = true;
			this.LinkLabel10.Text = "DocEdge";
			this.LinkLabel10.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel10_LinkClicked);
			// 
			// LinkLabel9
			// 
			this.LinkLabel9.ActiveLinkColor = System.Drawing.Color.Plum;
			this.LinkLabel9.AutoSize = true;
			this.LinkLabel9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabel9.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabel9.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabel9.Location = new System.Drawing.Point(6, 38);
			this.LinkLabel9.Name = "LinkLabel9";
			this.LinkLabel9.Size = new System.Drawing.Size(59, 15);
			this.LinkLabel9.TabIndex = 26;
			this.LinkLabel9.TabStop = true;
			this.LinkLabel9.Text = "RedVision";
			this.LinkLabel9.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel9_LinkClicked);
			// 
			// LinkLabel16
			// 
			this.LinkLabel16.ActiveLinkColor = System.Drawing.Color.Plum;
			this.LinkLabel16.AutoSize = true;
			this.LinkLabel16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabel16.ForeColor = System.Drawing.Color.DarkViolet;
			this.LinkLabel16.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(77)))));
			this.LinkLabel16.Location = new System.Drawing.Point(6, 22);
			this.LinkLabel16.Name = "LinkLabel16";
			this.LinkLabel16.Size = new System.Drawing.Size(50, 15);
			this.LinkLabel16.TabIndex = 27;
			this.LinkLabel16.TabStop = true;
			this.LinkLabel16.Text = "Tapestry";
			this.LinkLabel16.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel16_LinkClicked);
			// 
			// LabelUseTap
			// 
			this.LabelUseTap.AutoSize = true;
			this.LabelUseTap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelUseTap.ForeColor = System.Drawing.Color.Black;
			this.LabelUseTap.Location = new System.Drawing.Point(71, 22);
			this.LabelUseTap.Name = "LabelUseTap";
			this.LabelUseTap.Size = new System.Drawing.Size(12, 15);
			this.LabelUseTap.TabIndex = 61;
			this.LabelUseTap.Text = "*";
			// 
			// LabelUseDtree
			// 
			this.LabelUseDtree.AutoSize = true;
			this.LabelUseDtree.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelUseDtree.ForeColor = System.Drawing.Color.Black;
			this.LabelUseDtree.Location = new System.Drawing.Point(71, 52);
			this.LabelUseDtree.Name = "LabelUseDtree";
			this.LabelUseDtree.Size = new System.Drawing.Size(12, 15);
			this.LabelUseDtree.TabIndex = 63;
			this.LabelUseDtree.Text = "*";
			// 
			// LabelUseRV
			// 
			this.LabelUseRV.AutoSize = true;
			this.LabelUseRV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LabelUseRV.ForeColor = System.Drawing.Color.Black;
			this.LabelUseRV.Location = new System.Drawing.Point(71, 37);
			this.LabelUseRV.Name = "LabelUseRV";
			this.LabelUseRV.Size = new System.Drawing.Size(12, 15);
			this.LabelUseRV.TabIndex = 60;
			this.LabelUseRV.Text = "*";
			// 
			// GroupBox2
			// 
			this.GroupBox2.BackColor = System.Drawing.Color.GhostWhite;
			this.GroupBox2.Controls.Add(this.lbl_courtImgDate);
			this.GroupBox2.Controls.Add(this.lbl_courtIndexDate);
			this.GroupBox2.Controls.Add(this.Label34);
			this.GroupBox2.Controls.Add(this.Label35);
			this.GroupBox2.Controls.Add(this.lbl_copyFeeAmt);
			this.GroupBox2.Controls.Add(this.Label16);
			this.GroupBox2.Controls.Add(this.Label27);
			this.GroupBox2.Controls.Add(this.LabelIndex_source);
			this.GroupBox2.Controls.Add(this.LabelCopyPmtType);
			this.GroupBox2.Controls.Add(this.Label26);
			this.GroupBox2.Controls.Add(this.LabelImage_date);
			this.GroupBox2.Controls.Add(this.LabelIndex_date);
			this.GroupBox2.Controls.Add(this.Label12);
			this.GroupBox2.Controls.Add(this.Label10);
			this.GroupBox2.Controls.Add(this.Label29);
			this.GroupBox2.Controls.Add(this.LabelCopy_source);
			this.GroupBox2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.GroupBox2.Location = new System.Drawing.Point(438, 86);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(219, 151);
			this.GroupBox2.TabIndex = 180;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "RESOURCE INFORMATION";
			// 
			// lbl_courtImgDate
			// 
			this.lbl_courtImgDate.AutoSize = true;
			this.lbl_courtImgDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbl_courtImgDate.ForeColor = System.Drawing.Color.Black;
			this.lbl_courtImgDate.Location = new System.Drawing.Point(112, 84);
			this.lbl_courtImgDate.Name = "lbl_courtImgDate";
			this.lbl_courtImgDate.Size = new System.Drawing.Size(9, 12);
			this.lbl_courtImgDate.TabIndex = 73;
			this.lbl_courtImgDate.Text = "*";
			// 
			// lbl_courtIndexDate
			// 
			this.lbl_courtIndexDate.AutoSize = true;
			this.lbl_courtIndexDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbl_courtIndexDate.ForeColor = System.Drawing.Color.Black;
			this.lbl_courtIndexDate.Location = new System.Drawing.Point(112, 68);
			this.lbl_courtIndexDate.Name = "lbl_courtIndexDate";
			this.lbl_courtIndexDate.Size = new System.Drawing.Size(9, 12);
			this.lbl_courtIndexDate.TabIndex = 72;
			this.lbl_courtIndexDate.Text = "*";
			// 
			// Label34
			// 
			this.Label34.AutoSize = true;
			this.Label34.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label34.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label34.Location = new System.Drawing.Point(7, 84);
			this.Label34.Name = "Label34";
			this.Label34.Size = new System.Drawing.Size(88, 12);
			this.Label34.TabIndex = 71;
			this.Label34.Text = "Court Image Date: ";
			// 
			// Label35
			// 
			this.Label35.AutoSize = true;
			this.Label35.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label35.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label35.Location = new System.Drawing.Point(7, 68);
			this.Label35.Name = "Label35";
			this.Label35.Size = new System.Drawing.Size(85, 12);
			this.Label35.TabIndex = 70;
			this.Label35.Text = "Court Index Date: ";
			// 
			// lbl_copyFeeAmt
			// 
			this.lbl_copyFeeAmt.AutoSize = true;
			this.lbl_copyFeeAmt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbl_copyFeeAmt.ForeColor = System.Drawing.Color.Black;
			this.lbl_copyFeeAmt.Location = new System.Drawing.Point(112, 132);
			this.lbl_copyFeeAmt.Name = "lbl_copyFeeAmt";
			this.lbl_copyFeeAmt.Size = new System.Drawing.Size(9, 12);
			this.lbl_copyFeeAmt.TabIndex = 69;
			this.lbl_copyFeeAmt.Text = "*";
			// 
			// Label16
			// 
			this.Label16.AutoSize = true;
			this.Label16.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label16.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label16.Location = new System.Drawing.Point(7, 132);
			this.Label16.Name = "Label16";
			this.Label16.Size = new System.Drawing.Size(90, 12);
			this.Label16.TabIndex = 68;
			this.Label16.Text = "Copy Fee Amount: ";
			// 
			// Label27
			// 
			this.Label27.AutoSize = true;
			this.Label27.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label27.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label27.Location = new System.Drawing.Point(7, 20);
			this.Label27.Name = "Label27";
			this.Label27.Size = new System.Drawing.Size(78, 12);
			this.Label27.TabIndex = 62;
			this.Label27.Text = "INDEX SOURCE: ";
			// 
			// LabelIndex_source
			// 
			this.LabelIndex_source.AutoSize = true;
			this.LabelIndex_source.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.LabelIndex_source.ForeColor = System.Drawing.Color.Black;
			this.LabelIndex_source.Location = new System.Drawing.Point(112, 20);
			this.LabelIndex_source.Name = "LabelIndex_source";
			this.LabelIndex_source.Size = new System.Drawing.Size(9, 12);
			this.LabelIndex_source.TabIndex = 63;
			this.LabelIndex_source.Text = "*";
			// 
			// LabelCopyPmtType
			// 
			this.LabelCopyPmtType.AutoSize = true;
			this.LabelCopyPmtType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.LabelCopyPmtType.ForeColor = System.Drawing.Color.Black;
			this.LabelCopyPmtType.Location = new System.Drawing.Point(112, 116);
			this.LabelCopyPmtType.Name = "LabelCopyPmtType";
			this.LabelCopyPmtType.Size = new System.Drawing.Size(9, 12);
			this.LabelCopyPmtType.TabIndex = 61;
			this.LabelCopyPmtType.Text = "*";
			// 
			// Label26
			// 
			this.Label26.AutoSize = true;
			this.Label26.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label26.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label26.Location = new System.Drawing.Point(7, 116);
			this.Label26.Name = "Label26";
			this.Label26.Size = new System.Drawing.Size(66, 12);
			this.Label26.TabIndex = 60;
			this.Label26.Text = "Copy Pay By: ";
			// 
			// LabelImage_date
			// 
			this.LabelImage_date.AutoSize = true;
			this.LabelImage_date.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.LabelImage_date.ForeColor = System.Drawing.Color.Black;
			this.LabelImage_date.Location = new System.Drawing.Point(112, 52);
			this.LabelImage_date.Name = "LabelImage_date";
			this.LabelImage_date.Size = new System.Drawing.Size(9, 12);
			this.LabelImage_date.TabIndex = 59;
			this.LabelImage_date.Text = "*";
			// 
			// LabelIndex_date
			// 
			this.LabelIndex_date.AutoSize = true;
			this.LabelIndex_date.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.LabelIndex_date.ForeColor = System.Drawing.Color.Black;
			this.LabelIndex_date.Location = new System.Drawing.Point(112, 36);
			this.LabelIndex_date.Name = "LabelIndex_date";
			this.LabelIndex_date.Size = new System.Drawing.Size(9, 12);
			this.LabelIndex_date.TabIndex = 58;
			this.LabelIndex_date.Text = "*";
			// 
			// Label12
			// 
			this.Label12.AutoSize = true;
			this.Label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label12.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label12.Location = new System.Drawing.Point(7, 52);
			this.Label12.Name = "Label12";
			this.Label12.Size = new System.Drawing.Size(61, 12);
			this.Label12.TabIndex = 57;
			this.Label12.Text = "Image Date: ";
			// 
			// Label10
			// 
			this.Label10.AutoSize = true;
			this.Label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label10.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label10.Location = new System.Drawing.Point(7, 36);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(83, 12);
			this.Label10.TabIndex = 56;
			this.Label10.Text = "Land Index Date: ";
			// 
			// Label29
			// 
			this.Label29.AutoSize = true;
			this.Label29.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.Label29.ForeColor = System.Drawing.Color.DarkSlateBlue;
			this.Label29.Location = new System.Drawing.Point(7, 100);
			this.Label29.Name = "Label29";
			this.Label29.Size = new System.Drawing.Size(76, 12);
			this.Label29.TabIndex = 54;
			this.Label29.Text = "COPY SOURCE: ";
			// 
			// LabelCopy_source
			// 
			this.LabelCopy_source.AutoSize = true;
			this.LabelCopy_source.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.LabelCopy_source.ForeColor = System.Drawing.Color.Black;
			this.LabelCopy_source.Location = new System.Drawing.Point(112, 100);
			this.LabelCopy_source.Name = "LabelCopy_source";
			this.LabelCopy_source.Size = new System.Drawing.Size(9, 12);
			this.LabelCopy_source.TabIndex = 55;
			this.LabelCopy_source.Text = "*";
			// 
			// TabControl1
			// 
			this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TabControl1.Controls.Add(this.TabPg4Clearing);
			this.TabControl1.Controls.Add(this.TabPg6OtherLogins);
			this.TabControl1.Controls.Add(this.TabPg7Taxes);
			this.TabControl1.Controls.Add(this.TabPg1Statistics);
			this.TabControl1.Controls.Add(this.TabPg2Misc);
			this.TabControl1.Location = new System.Drawing.Point(0, 387);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(874, 227);
			this.TabControl1.TabIndex = 190;
			this.TabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TabPage1_Click);
			// 
			// TabPg4Clearing
			// 
			this.TabPg4Clearing.AutoScroll = true;
			this.TabPg4Clearing.BackColor = System.Drawing.Color.Linen;
			this.TabPg4Clearing.Controls.Add(this.TableLayoutPanel1);
			this.TabPg4Clearing.Location = new System.Drawing.Point(4, 22);
			this.TabPg4Clearing.Name = "TabPg4Clearing";
			this.TabPg4Clearing.Padding = new System.Windows.Forms.Padding(3);
			this.TabPg4Clearing.Size = new System.Drawing.Size(866, 201);
			this.TabPg4Clearing.TabIndex = 4;
			this.TabPg4Clearing.Text = "State Guidelines";
			// 
			// TableLayoutPanel1
			// 
			this.TableLayoutPanel1.AutoSize = true;
			this.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TableLayoutPanel1.ColumnCount = 3;
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TableLayoutPanel1.Controls.Add(this.txtSOL_notes, 0, 32);
			this.TableLayoutPanel1.Controls.Add(this.Label_statutecomments, 0, 31);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_Tax_RedemPer, 1, 21);
			this.TableLayoutPanel1.Controls.Add(this.Label_forclRedem, 0, 20);
			this.TableLayoutPanel1.Controls.Add(this.Label_taxTakRedem, 0, 21);
			this.TableLayoutPanel1.Controls.Add(this.Label_mtg, 0, 0);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_forecl_redem_per, 1, 20);
			this.TableLayoutPanel1.Controls.Add(this.Label73, 1, 16);
			this.TableLayoutPanel1.Controls.Add(this.Label46, 1, 15);
			this.TableLayoutPanel1.Controls.Add(this.Label74, 0, 16);
			this.TableLayoutPanel1.Controls.Add(this.Label54, 1, 14);
			this.TableLayoutPanel1.Controls.Add(this.Label52, 0, 15);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_Mtg, 1, 0);
			this.TableLayoutPanel1.Controls.Add(this.Label58, 0, 14);
			this.TableLayoutPanel1.Controls.Add(this.Label_heloc, 0, 1);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_Heloc, 1, 1);
			this.TableLayoutPanel1.Controls.Add(this.Label_teRule, 0, 2);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_TERule, 1, 2);
			this.TableLayoutPanel1.Controls.Add(this.Label_spousal, 0, 3);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_PersTax, 1, 13);
			this.TableLayoutPanel1.Controls.Add(this.Label_persTax, 0, 13);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_ClaimLien, 1, 11);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_HOA, 1, 9);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_Support, 1, 12);
			this.TableLayoutPanel1.Controls.Add(this.Label_support, 0, 12);
			this.TableLayoutPanel1.Controls.Add(this.Label_claimLien, 0, 11);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_Notice, 1, 8);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_Hosp, 1, 10);
			this.TableLayoutPanel1.Controls.Add(this.Label_HOA, 0, 9);
			this.TableLayoutPanel1.Controls.Add(this.Label_hospLien, 0, 10);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_Mech, 1, 7);
			this.TableLayoutPanel1.Controls.Add(this.Label_NOC, 0, 8);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_lispen, 1, 6);
			this.TableLayoutPanel1.Controls.Add(this.Label_mechLien, 0, 7);
			this.TableLayoutPanel1.Controls.Add(this.Label_lisPendens, 0, 6);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_Jgmt, 1, 4);
			this.TableLayoutPanel1.Controls.Add(this.Label_jgmt, 0, 4);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_Spousal, 1, 3);
			this.TableLayoutPanel1.Controls.Add(this.Label_stateJgmt, 0, 5);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_StateJgmt, 1, 5);
			this.TableLayoutPanel1.Controls.Add(this.Label_fc, 0, 23);
			this.TableLayoutPanel1.Controls.Add(this.txt_foreclosure_notes, 0, 24);
			this.TableLayoutPanel1.Controls.Add(this.Label_credclaim, 0, 25);
			this.TableLayoutPanel1.Controls.Add(this.Label_aftacq, 0, 26);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_Creditor_Claims, 1, 25);
			this.TableLayoutPanel1.Controls.Add(this.lblSOL_AftAcq, 1, 26);
			this.TableLayoutPanel1.Controls.Add(this.txt_ProbateInfo, 0, 29);
			this.TableLayoutPanel1.Controls.Add(this.Label_probate, 0, 28);
			this.TableLayoutPanel1.Location = new System.Drawing.Point(12, 6);
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
			this.TableLayoutPanel1.RowCount = 33;
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.Size = new System.Drawing.Size(453, 568);
			this.TableLayoutPanel1.TabIndex = 98;
			// 
			// txtSOL_notes
			// 
			this.txtSOL_notes.BackColor = System.Drawing.Color.Snow;
			this.TableLayoutPanel1.SetColumnSpan(this.txtSOL_notes, 2);
			this.txtSOL_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSOL_notes.ForeColor = System.Drawing.Color.Purple;
			this.txtSOL_notes.Location = new System.Drawing.Point(3, 505);
			this.txtSOL_notes.Multiline = true;
			this.txtSOL_notes.Name = "txtSOL_notes";
			this.txtSOL_notes.ReadOnly = true;
			this.txtSOL_notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtSOL_notes.Size = new System.Drawing.Size(447, 59);
			this.txtSOL_notes.TabIndex = 97;
			// 
			// Label_statutecomments
			// 
			this.Label_statutecomments.AutoSize = true;
			this.Label_statutecomments.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_statutecomments.ForeColor = System.Drawing.Color.Black;
			this.Label_statutecomments.Location = new System.Drawing.Point(3, 489);
			this.Label_statutecomments.Name = "Label_statutecomments";
			this.Label_statutecomments.Size = new System.Drawing.Size(114, 13);
			this.Label_statutecomments.TabIndex = 107;
			this.Label_statutecomments.Text = "Statutes Comments::";
			// 
			// lblSOL_Tax_RedemPer
			// 
			this.lblSOL_Tax_RedemPer.AutoSize = true;
			this.lblSOL_Tax_RedemPer.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_Tax_RedemPer.ForeColor = System.Drawing.Color.Black;
			this.lblSOL_Tax_RedemPer.Location = new System.Drawing.Point(152, 235);
			this.lblSOL_Tax_RedemPer.Name = "lblSOL_Tax_RedemPer";
			this.lblSOL_Tax_RedemPer.Size = new System.Drawing.Size(46, 13);
			this.lblSOL_Tax_RedemPer.TabIndex = 61;
			this.lblSOL_Tax_RedemPer.Text = "Label58";
			// 
			// Label_forclRedem
			// 
			this.Label_forclRedem.AutoSize = true;
			this.Label_forclRedem.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_forclRedem.ForeColor = System.Drawing.Color.Black;
			this.Label_forclRedem.Location = new System.Drawing.Point(3, 222);
			this.Label_forclRedem.Name = "Label_forclRedem";
			this.Label_forclRedem.Size = new System.Drawing.Size(143, 13);
			this.Label_forclRedem.TabIndex = 68;
			this.Label_forclRedem.Text = "Forclosure Redem. Period:";
			// 
			// Label_taxTakRedem
			// 
			this.Label_taxTakRedem.AutoSize = true;
			this.Label_taxTakRedem.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_taxTakRedem.ForeColor = System.Drawing.Color.Black;
			this.Label_taxTakRedem.Location = new System.Drawing.Point(3, 235);
			this.Label_taxTakRedem.Name = "Label_taxTakRedem";
			this.Label_taxTakRedem.Size = new System.Drawing.Size(143, 13);
			this.Label_taxTakRedem.TabIndex = 62;
			this.Label_taxTakRedem.Text = "Tax Taking Redem. Period:";
			// 
			// Label_mtg
			// 
			this.Label_mtg.AutoSize = true;
			this.Label_mtg.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_mtg.Location = new System.Drawing.Point(3, 1);
			this.Label_mtg.Name = "Label_mtg";
			this.Label_mtg.Size = new System.Drawing.Size(59, 13);
			this.Label_mtg.TabIndex = 0;
			this.Label_mtg.Text = "Mtg/DOT:";
			// 
			// lblSOL_forecl_redem_per
			// 
			this.lblSOL_forecl_redem_per.AutoSize = true;
			this.lblSOL_forecl_redem_per.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_forecl_redem_per.ForeColor = System.Drawing.Color.Black;
			this.lblSOL_forecl_redem_per.Location = new System.Drawing.Point(152, 222);
			this.lblSOL_forecl_redem_per.Name = "lblSOL_forecl_redem_per";
			this.lblSOL_forecl_redem_per.Size = new System.Drawing.Size(20, 13);
			this.lblSOL_forecl_redem_per.TabIndex = 67;
			this.lblSOL_forecl_redem_per.Text = "lbl";
			// 
			// Label73
			// 
			this.Label73.AutoSize = true;
			this.Label73.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label73.ForeColor = System.Drawing.Color.Black;
			this.Label73.Location = new System.Drawing.Point(152, 209);
			this.Label73.Name = "Label73";
			this.Label73.Size = new System.Drawing.Size(36, 13);
			this.Label73.TabIndex = 101;
			this.Label73.Text = "20 yrs";
			// 
			// Label46
			// 
			this.Label46.AutoSize = true;
			this.Label46.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label46.ForeColor = System.Drawing.Color.Black;
			this.Label46.Location = new System.Drawing.Point(152, 196);
			this.Label46.Name = "Label46";
			this.Label46.Size = new System.Drawing.Size(30, 13);
			this.Label46.TabIndex = 103;
			this.Label46.Text = "5 yrs";
			// 
			// Label74
			// 
			this.Label74.AutoSize = true;
			this.Label74.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label74.ForeColor = System.Drawing.Color.Black;
			this.Label74.Location = new System.Drawing.Point(3, 209);
			this.Label74.Name = "Label74";
			this.Label74.Size = new System.Drawing.Size(66, 13);
			this.Label74.TabIndex = 100;
			this.Label74.Text = "USA Jgmts:";
			// 
			// Label54
			// 
			this.Label54.AutoSize = true;
			this.Label54.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label54.ForeColor = System.Drawing.Color.Black;
			this.Label54.Location = new System.Drawing.Point(152, 183);
			this.Label54.Name = "Label54";
			this.Label54.Size = new System.Drawing.Size(82, 13);
			this.Label54.TabIndex = 105;
			this.Label54.Text = "10 yrs+30 days";
			// 
			// Label52
			// 
			this.Label52.AutoSize = true;
			this.Label52.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label52.ForeColor = System.Drawing.Color.Black;
			this.Label52.Location = new System.Drawing.Point(3, 196);
			this.Label52.Name = "Label52";
			this.Label52.Size = new System.Drawing.Size(37, 13);
			this.Label52.TabIndex = 102;
			this.Label52.Text = "UCCs:";
			// 
			// lblSOL_Mtg
			// 
			this.lblSOL_Mtg.AutoSize = true;
			this.lblSOL_Mtg.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_Mtg.Location = new System.Drawing.Point(152, 1);
			this.lblSOL_Mtg.Name = "lblSOL_Mtg";
			this.lblSOL_Mtg.Size = new System.Drawing.Size(46, 13);
			this.lblSOL_Mtg.TabIndex = 1;
			this.lblSOL_Mtg.Text = "Label46";
			this.lblSOL_Mtg.MouseLeave += new System.EventHandler(this.lblSOL_Mtg_mouseLeave);
			this.lblSOL_Mtg.MouseHover += new System.EventHandler(this.lblSOL_Mtg_mouseHover);
			// 
			// Label58
			// 
			this.Label58.AutoSize = true;
			this.Label58.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label58.ForeColor = System.Drawing.Color.Black;
			this.Label58.Location = new System.Drawing.Point(3, 183);
			this.Label58.Name = "Label58";
			this.Label58.Size = new System.Drawing.Size(74, 13);
			this.Label58.TabIndex = 104;
			this.Label58.Text = "Fed Tax Lien:";
			// 
			// Label_heloc
			// 
			this.Label_heloc.AutoSize = true;
			this.Label_heloc.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_heloc.Location = new System.Drawing.Point(3, 14);
			this.Label_heloc.Name = "Label_heloc";
			this.Label_heloc.Size = new System.Drawing.Size(45, 13);
			this.Label_heloc.TabIndex = 2;
			this.Label_heloc.Text = "HELOC:";
			// 
			// lblSOL_Heloc
			// 
			this.lblSOL_Heloc.AutoSize = true;
			this.lblSOL_Heloc.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_Heloc.Location = new System.Drawing.Point(152, 14);
			this.lblSOL_Heloc.Name = "lblSOL_Heloc";
			this.lblSOL_Heloc.Size = new System.Drawing.Size(46, 13);
			this.lblSOL_Heloc.TabIndex = 3;
			this.lblSOL_Heloc.Text = "Label52";
			this.lblSOL_Heloc.MouseLeave += new System.EventHandler(this.lblSOL_heloc_mouseLeave);
			this.lblSOL_Heloc.MouseHover += new System.EventHandler(this.lblSOL_heloc_mouseHover);
			// 
			// Label_teRule
			// 
			this.Label_teRule.AutoSize = true;
			this.Label_teRule.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_teRule.Location = new System.Drawing.Point(3, 27);
			this.Label_teRule.Name = "Label_teRule";
			this.Label_teRule.Size = new System.Drawing.Size(48, 13);
			this.Label_teRule.TabIndex = 55;
			this.Label_teRule.Text = "TE Rule:";
			// 
			// lblSOL_TERule
			// 
			this.lblSOL_TERule.AutoSize = true;
			this.lblSOL_TERule.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_TERule.Location = new System.Drawing.Point(152, 27);
			this.lblSOL_TERule.Name = "lblSOL_TERule";
			this.lblSOL_TERule.Size = new System.Drawing.Size(46, 13);
			this.lblSOL_TERule.TabIndex = 56;
			this.lblSOL_TERule.Text = "Label52";
			// 
			// Label_spousal
			// 
			this.Label_spousal.AutoSize = true;
			this.Label_spousal.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_spousal.Location = new System.Drawing.Point(3, 40);
			this.Label_spousal.Name = "Label_spousal";
			this.Label_spousal.Size = new System.Drawing.Size(80, 13);
			this.Label_spousal.TabIndex = 66;
			this.Label_spousal.Text = "Spousal State:";
			// 
			// lblSOL_PersTax
			// 
			this.lblSOL_PersTax.AutoSize = true;
			this.lblSOL_PersTax.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_PersTax.ForeColor = System.Drawing.Color.Black;
			this.lblSOL_PersTax.Location = new System.Drawing.Point(152, 170);
			this.lblSOL_PersTax.Name = "lblSOL_PersTax";
			this.lblSOL_PersTax.Size = new System.Drawing.Size(46, 13);
			this.lblSOL_PersTax.TabIndex = 98;
			this.lblSOL_PersTax.Text = "Label60";
			// 
			// Label_persTax
			// 
			this.Label_persTax.AutoSize = true;
			this.Label_persTax.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_persTax.ForeColor = System.Drawing.Color.Black;
			this.Label_persTax.Location = new System.Drawing.Point(3, 170);
			this.Label_persTax.Name = "Label_persTax";
			this.Label_persTax.Size = new System.Drawing.Size(75, 13);
			this.Label_persTax.TabIndex = 99;
			this.Label_persTax.Text = "Personal Tax:";
			// 
			// lblSOL_ClaimLien
			// 
			this.lblSOL_ClaimLien.AutoSize = true;
			this.lblSOL_ClaimLien.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_ClaimLien.ForeColor = System.Drawing.Color.Black;
			this.lblSOL_ClaimLien.Location = new System.Drawing.Point(152, 144);
			this.lblSOL_ClaimLien.Name = "lblSOL_ClaimLien";
			this.lblSOL_ClaimLien.Size = new System.Drawing.Size(46, 13);
			this.lblSOL_ClaimLien.TabIndex = 91;
			this.lblSOL_ClaimLien.Text = "Label68";
			// 
			// lblSOL_HOA
			// 
			this.lblSOL_HOA.AutoSize = true;
			this.lblSOL_HOA.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_HOA.ForeColor = System.Drawing.Color.Black;
			this.lblSOL_HOA.Location = new System.Drawing.Point(152, 118);
			this.lblSOL_HOA.Name = "lblSOL_HOA";
			this.lblSOL_HOA.Size = new System.Drawing.Size(46, 13);
			this.lblSOL_HOA.TabIndex = 89;
			this.lblSOL_HOA.Text = "Label66";
			// 
			// lblSOL_Support
			// 
			this.lblSOL_Support.AutoSize = true;
			this.lblSOL_Support.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_Support.ForeColor = System.Drawing.Color.Black;
			this.lblSOL_Support.Location = new System.Drawing.Point(152, 157);
			this.lblSOL_Support.Name = "lblSOL_Support";
			this.lblSOL_Support.Size = new System.Drawing.Size(46, 13);
			this.lblSOL_Support.TabIndex = 81;
			this.lblSOL_Support.Text = "Label64";
			// 
			// Label_support
			// 
			this.Label_support.AutoSize = true;
			this.Label_support.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_support.ForeColor = System.Drawing.Color.Black;
			this.Label_support.Location = new System.Drawing.Point(3, 157);
			this.Label_support.Name = "Label_support";
			this.Label_support.Size = new System.Drawing.Size(73, 13);
			this.Label_support.TabIndex = 82;
			this.Label_support.Text = "Support Obl:";
			// 
			// Label_claimLien
			// 
			this.Label_claimLien.AutoSize = true;
			this.Label_claimLien.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_claimLien.ForeColor = System.Drawing.Color.Black;
			this.Label_claimLien.Location = new System.Drawing.Point(3, 144);
			this.Label_claimLien.Name = "Label_claimLien";
			this.Label_claimLien.Size = new System.Drawing.Size(78, 13);
			this.Label_claimLien.TabIndex = 92;
			this.Label_claimLien.Text = "Claim of Lien:";
			// 
			// lblSOL_Notice
			// 
			this.lblSOL_Notice.AutoSize = true;
			this.lblSOL_Notice.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_Notice.ForeColor = System.Drawing.Color.Black;
			this.lblSOL_Notice.Location = new System.Drawing.Point(152, 105);
			this.lblSOL_Notice.Name = "lblSOL_Notice";
			this.lblSOL_Notice.Size = new System.Drawing.Size(46, 13);
			this.lblSOL_Notice.TabIndex = 87;
			this.lblSOL_Notice.Text = "Label58";
			// 
			// lblSOL_Hosp
			// 
			this.lblSOL_Hosp.AutoSize = true;
			this.lblSOL_Hosp.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_Hosp.ForeColor = System.Drawing.Color.Black;
			this.lblSOL_Hosp.Location = new System.Drawing.Point(152, 131);
			this.lblSOL_Hosp.Name = "lblSOL_Hosp";
			this.lblSOL_Hosp.Size = new System.Drawing.Size(46, 13);
			this.lblSOL_Hosp.TabIndex = 95;
			this.lblSOL_Hosp.Text = "Label72";
			// 
			// Label_HOA
			// 
			this.Label_HOA.AutoSize = true;
			this.Label_HOA.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_HOA.ForeColor = System.Drawing.Color.Black;
			this.Label_HOA.Location = new System.Drawing.Point(3, 118);
			this.Label_HOA.Name = "Label_HOA";
			this.Label_HOA.Size = new System.Drawing.Size(59, 13);
			this.Label_HOA.TabIndex = 90;
			this.Label_HOA.Text = "HOA Lien:";
			// 
			// Label_hospLien
			// 
			this.Label_hospLien.AutoSize = true;
			this.Label_hospLien.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_hospLien.ForeColor = System.Drawing.Color.Black;
			this.Label_hospLien.Location = new System.Drawing.Point(3, 131);
			this.Label_hospLien.Name = "Label_hospLien";
			this.Label_hospLien.Size = new System.Drawing.Size(65, 13);
			this.Label_hospLien.TabIndex = 96;
			this.Label_hospLien.Text = "Hosp. Lien:";
			// 
			// lblSOL_Mech
			// 
			this.lblSOL_Mech.AutoSize = true;
			this.lblSOL_Mech.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_Mech.ForeColor = System.Drawing.Color.Black;
			this.lblSOL_Mech.Location = new System.Drawing.Point(152, 92);
			this.lblSOL_Mech.Name = "lblSOL_Mech";
			this.lblSOL_Mech.Size = new System.Drawing.Size(46, 13);
			this.lblSOL_Mech.TabIndex = 85;
			this.lblSOL_Mech.Text = "Label60";
			// 
			// Label_NOC
			// 
			this.Label_NOC.AutoSize = true;
			this.Label_NOC.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_NOC.ForeColor = System.Drawing.Color.Black;
			this.Label_NOC.Location = new System.Drawing.Point(3, 105);
			this.Label_NOC.Name = "Label_NOC";
			this.Label_NOC.Size = new System.Drawing.Size(107, 13);
			this.Label_NOC.TabIndex = 88;
			this.Label_NOC.Text = "Notice/Commence:";
			// 
			// lblSOL_lispen
			// 
			this.lblSOL_lispen.AutoSize = true;
			this.lblSOL_lispen.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_lispen.ForeColor = System.Drawing.Color.Black;
			this.lblSOL_lispen.Location = new System.Drawing.Point(152, 79);
			this.lblSOL_lispen.Name = "lblSOL_lispen";
			this.lblSOL_lispen.Size = new System.Drawing.Size(46, 13);
			this.lblSOL_lispen.TabIndex = 80;
			this.lblSOL_lispen.Text = "Label54";
			// 
			// Label_mechLien
			// 
			this.Label_mechLien.AutoSize = true;
			this.Label_mechLien.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_mechLien.ForeColor = System.Drawing.Color.Black;
			this.Label_mechLien.Location = new System.Drawing.Point(3, 92);
			this.Label_mechLien.Name = "Label_mechLien";
			this.Label_mechLien.Size = new System.Drawing.Size(64, 13);
			this.Label_mechLien.TabIndex = 86;
			this.Label_mechLien.Text = "Mech.Lien:";
			// 
			// Label_lisPendens
			// 
			this.Label_lisPendens.AutoSize = true;
			this.Label_lisPendens.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_lisPendens.ForeColor = System.Drawing.Color.Black;
			this.Label_lisPendens.Location = new System.Drawing.Point(3, 79);
			this.Label_lisPendens.Name = "Label_lisPendens";
			this.Label_lisPendens.Size = new System.Drawing.Size(69, 13);
			this.Label_lisPendens.TabIndex = 79;
			this.Label_lisPendens.Text = "LisPendens:";
			// 
			// lblSOL_Jgmt
			// 
			this.lblSOL_Jgmt.AutoSize = true;
			this.lblSOL_Jgmt.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_Jgmt.ForeColor = System.Drawing.Color.Black;
			this.lblSOL_Jgmt.Location = new System.Drawing.Point(152, 53);
			this.lblSOL_Jgmt.Name = "lblSOL_Jgmt";
			this.lblSOL_Jgmt.Size = new System.Drawing.Size(46, 13);
			this.lblSOL_Jgmt.TabIndex = 93;
			this.lblSOL_Jgmt.Text = "Label70";
			// 
			// Label_jgmt
			// 
			this.Label_jgmt.AutoSize = true;
			this.Label_jgmt.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_jgmt.ForeColor = System.Drawing.Color.Black;
			this.Label_jgmt.Location = new System.Drawing.Point(3, 53);
			this.Label_jgmt.Name = "Label_jgmt";
			this.Label_jgmt.Size = new System.Drawing.Size(63, 13);
			this.Label_jgmt.TabIndex = 94;
			this.Label_jgmt.Text = "Judgment:";
			// 
			// lblSOL_Spousal
			// 
			this.lblSOL_Spousal.AutoSize = true;
			this.lblSOL_Spousal.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_Spousal.Location = new System.Drawing.Point(152, 40);
			this.lblSOL_Spousal.Name = "lblSOL_Spousal";
			this.lblSOL_Spousal.Size = new System.Drawing.Size(46, 13);
			this.lblSOL_Spousal.TabIndex = 65;
			this.lblSOL_Spousal.Text = "Label72";
			// 
			// Label_stateJgmt
			// 
			this.Label_stateJgmt.AutoSize = true;
			this.Label_stateJgmt.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_stateJgmt.ForeColor = System.Drawing.Color.Black;
			this.Label_stateJgmt.Location = new System.Drawing.Point(3, 66);
			this.Label_stateJgmt.Name = "Label_stateJgmt";
			this.Label_stateJgmt.Size = new System.Drawing.Size(65, 13);
			this.Label_stateJgmt.TabIndex = 84;
			this.Label_stateJgmt.Text = "State Jgmt:";
			// 
			// lblSOL_StateJgmt
			// 
			this.lblSOL_StateJgmt.AutoSize = true;
			this.lblSOL_StateJgmt.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_StateJgmt.ForeColor = System.Drawing.Color.Black;
			this.lblSOL_StateJgmt.Location = new System.Drawing.Point(152, 66);
			this.lblSOL_StateJgmt.Name = "lblSOL_StateJgmt";
			this.lblSOL_StateJgmt.Size = new System.Drawing.Size(46, 13);
			this.lblSOL_StateJgmt.TabIndex = 83;
			this.lblSOL_StateJgmt.Text = "Label62";
			// 
			// Label_fc
			// 
			this.Label_fc.AutoSize = true;
			this.Label_fc.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_fc.ForeColor = System.Drawing.Color.Black;
			this.Label_fc.Location = new System.Drawing.Point(3, 268);
			this.Label_fc.Name = "Label_fc";
			this.Label_fc.Size = new System.Drawing.Size(94, 13);
			this.Label_fc.TabIndex = 106;
			this.Label_fc.Text = "Foreclosure Info:";
			// 
			// txt_foreclosure_notes
			// 
			this.txt_foreclosure_notes.BackColor = System.Drawing.Color.Snow;
			this.TableLayoutPanel1.SetColumnSpan(this.txt_foreclosure_notes, 2);
			this.txt_foreclosure_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_foreclosure_notes.ForeColor = System.Drawing.Color.Purple;
			this.txt_foreclosure_notes.Location = new System.Drawing.Point(3, 284);
			this.txt_foreclosure_notes.Multiline = true;
			this.txt_foreclosure_notes.Name = "txt_foreclosure_notes";
			this.txt_foreclosure_notes.ReadOnly = true;
			this.txt_foreclosure_notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txt_foreclosure_notes.Size = new System.Drawing.Size(447, 58);
			this.txt_foreclosure_notes.TabIndex = 69;
			// 
			// Label_credclaim
			// 
			this.Label_credclaim.AutoSize = true;
			this.Label_credclaim.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_credclaim.ForeColor = System.Drawing.Color.Black;
			this.Label_credclaim.Location = new System.Drawing.Point(3, 345);
			this.Label_credclaim.Name = "Label_credclaim";
			this.Label_credclaim.Size = new System.Drawing.Size(89, 13);
			this.Label_credclaim.TabIndex = 57;
			this.Label_credclaim.Text = "Creditor Claims:";
			// 
			// Label_aftacq
			// 
			this.Label_aftacq.AutoSize = true;
			this.Label_aftacq.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_aftacq.ForeColor = System.Drawing.Color.Black;
			this.Label_aftacq.Location = new System.Drawing.Point(3, 358);
			this.Label_aftacq.Name = "Label_aftacq";
			this.Label_aftacq.Size = new System.Drawing.Size(111, 13);
			this.Label_aftacq.TabIndex = 53;
			this.Label_aftacq.Text = "After Acquired Lien:";
			// 
			// lblSOL_Creditor_Claims
			// 
			this.lblSOL_Creditor_Claims.AutoSize = true;
			this.lblSOL_Creditor_Claims.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_Creditor_Claims.ForeColor = System.Drawing.Color.Black;
			this.lblSOL_Creditor_Claims.Location = new System.Drawing.Point(152, 345);
			this.lblSOL_Creditor_Claims.Name = "lblSOL_Creditor_Claims";
			this.lblSOL_Creditor_Claims.Size = new System.Drawing.Size(46, 13);
			this.lblSOL_Creditor_Claims.TabIndex = 58;
			this.lblSOL_Creditor_Claims.Text = "Label54";
			// 
			// lblSOL_AftAcq
			// 
			this.lblSOL_AftAcq.AutoSize = true;
			this.lblSOL_AftAcq.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_AftAcq.ForeColor = System.Drawing.Color.Black;
			this.lblSOL_AftAcq.Location = new System.Drawing.Point(152, 358);
			this.lblSOL_AftAcq.Name = "lblSOL_AftAcq";
			this.lblSOL_AftAcq.Size = new System.Drawing.Size(46, 13);
			this.lblSOL_AftAcq.TabIndex = 54;
			this.lblSOL_AftAcq.Text = "Label46";
			// 
			// txt_ProbateInfo
			// 
			this.txt_ProbateInfo.BackColor = System.Drawing.Color.Snow;
			this.TableLayoutPanel1.SetColumnSpan(this.txt_ProbateInfo, 2);
			this.txt_ProbateInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_ProbateInfo.ForeColor = System.Drawing.Color.Purple;
			this.txt_ProbateInfo.Location = new System.Drawing.Point(3, 407);
			this.txt_ProbateInfo.Multiline = true;
			this.txt_ProbateInfo.Name = "txt_ProbateInfo";
			this.txt_ProbateInfo.ReadOnly = true;
			this.txt_ProbateInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txt_ProbateInfo.Size = new System.Drawing.Size(447, 59);
			this.txt_ProbateInfo.TabIndex = 74;
			// 
			// Label_probate
			// 
			this.Label_probate.AutoSize = true;
			this.Label_probate.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label_probate.ForeColor = System.Drawing.Color.Black;
			this.Label_probate.Location = new System.Drawing.Point(3, 391);
			this.Label_probate.Name = "Label_probate";
			this.Label_probate.Size = new System.Drawing.Size(75, 13);
			this.Label_probate.TabIndex = 107;
			this.Label_probate.Text = "Probate Info:";
			// 
			// TabPg6OtherLogins
			// 
			this.TabPg6OtherLogins.BackColor = System.Drawing.Color.GhostWhite;
			this.TabPg6OtherLogins.Controls.Add(this.DataGridView2);
			this.TabPg6OtherLogins.Location = new System.Drawing.Point(4, 22);
			this.TabPg6OtherLogins.Name = "TabPg6OtherLogins";
			this.TabPg6OtherLogins.Padding = new System.Windows.Forms.Padding(3);
			this.TabPg6OtherLogins.Size = new System.Drawing.Size(866, 201);
			this.TabPg6OtherLogins.TabIndex = 6;
			this.TabPg6OtherLogins.Text = "Other Login Info";
			// 
			// DataGridView2
			// 
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.Thistle;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Indigo;
			this.DataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
			this.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.DataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.DataGridView2.BackgroundColor = System.Drawing.Color.Linen;
			this.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Aquamarine;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.DataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.DataGridView2.Cursor = System.Windows.Forms.Cursors.Default;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.DataGridView2.DefaultCellStyle = dataGridViewCellStyle7;
			this.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DataGridView2.GridColor = System.Drawing.Color.MediumOrchid;
			this.DataGridView2.Location = new System.Drawing.Point(3, 3);
			this.DataGridView2.Name = "DataGridView2";
			this.DataGridView2.RowHeadersWidth = 20;
			dataGridViewCellStyle8.BackColor = System.Drawing.Color.LavenderBlush;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Indigo;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.MediumPurple;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.DataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle8;
			this.DataGridView2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.DataGridView2.Size = new System.Drawing.Size(860, 195);
			this.DataGridView2.TabIndex = 74;
			// 
			// TabPg7Taxes
			// 
			this.TabPg7Taxes.AutoScroll = true;
			this.TabPg7Taxes.BackColor = System.Drawing.Color.GhostWhite;
			this.TabPg7Taxes.Controls.Add(this.lbl_verifDate5);
			this.TabPg7Taxes.Controls.Add(this.lbl_verified_taxoff5);
			this.TabPg7Taxes.Controls.Add(this.lbl_verifDate4);
			this.TabPg7Taxes.Controls.Add(this.lbl_verified_taxoff4);
			this.TabPg7Taxes.Controls.Add(this.lbl_verifDate3);
			this.TabPg7Taxes.Controls.Add(this.lbl_verified_taxoff3);
			this.TabPg7Taxes.Controls.Add(this.lbl_verifDate2);
			this.TabPg7Taxes.Controls.Add(this.lbl_verified_taxoff2);
			this.TabPg7Taxes.Controls.Add(this.lbl_verifDate1);
			this.TabPg7Taxes.Controls.Add(this.lbl_verified_taxoff1);
			this.TabPg7Taxes.Controls.Add(this.Label39);
			this.TabPg7Taxes.Controls.Add(this.txtTaxOffice1);
			this.TabPg7Taxes.Controls.Add(this.txtTaxOffice2);
			this.TabPg7Taxes.Controls.Add(this.txtTaxOffice3);
			this.TabPg7Taxes.Controls.Add(this.txtTaxOffice4);
			this.TabPg7Taxes.Controls.Add(this.txtTaxOffice5);
			this.TabPg7Taxes.Controls.Add(this.lblTxAuth1);
			this.TabPg7Taxes.Controls.Add(this.linkLocTax1);
			this.TabPg7Taxes.Controls.Add(this.linkLocTax5);
			this.TabPg7Taxes.Controls.Add(this.lblTxAuth5);
			this.TabPg7Taxes.Controls.Add(this.lblTxAuth2);
			this.TabPg7Taxes.Controls.Add(this.linkLocTax2);
			this.TabPg7Taxes.Controls.Add(this.linkLocTax4);
			this.TabPg7Taxes.Controls.Add(this.lblTxAuth4);
			this.TabPg7Taxes.Controls.Add(this.lblTxAuth3);
			this.TabPg7Taxes.Controls.Add(this.linkLocTax3);
			this.TabPg7Taxes.Controls.Add(this.pbxExport);
			this.TabPg7Taxes.Controls.Add(this.pbxCopy5);
			this.TabPg7Taxes.Controls.Add(this.pbxCopy4);
			this.TabPg7Taxes.Controls.Add(this.pbxCopy3);
			this.TabPg7Taxes.Controls.Add(this.pbxCopy2);
			this.TabPg7Taxes.Controls.Add(this.pbxCopy1);
			this.TabPg7Taxes.Location = new System.Drawing.Point(4, 22);
			this.TabPg7Taxes.Name = "TabPg7Taxes";
			this.TabPg7Taxes.Padding = new System.Windows.Forms.Padding(3);
			this.TabPg7Taxes.Size = new System.Drawing.Size(866, 201);
			this.TabPg7Taxes.TabIndex = 7;
			this.TabPg7Taxes.Text = "Taxes";
			// 
			// lbl_verifDate5
			// 
			this.lbl_verifDate5.AutoSize = true;
			this.lbl_verifDate5.Location = new System.Drawing.Point(438, 383);
			this.lbl_verifDate5.Name = "lbl_verifDate5";
			this.lbl_verifDate5.Size = new System.Drawing.Size(30, 13);
			this.lbl_verifDate5.TabIndex = 209;
			this.lbl_verifDate5.Text = "Date";
			// 
			// lbl_verified_taxoff5
			// 
			this.lbl_verified_taxoff5.AutoSize = true;
			this.lbl_verified_taxoff5.Location = new System.Drawing.Point(438, 357);
			this.lbl_verified_taxoff5.Name = "lbl_verified_taxoff5";
			this.lbl_verified_taxoff5.Size = new System.Drawing.Size(48, 13);
			this.lbl_verified_taxoff5.TabIndex = 208;
			this.lbl_verified_taxoff5.Text = "Verified?";
			// 
			// lbl_verifDate4
			// 
			this.lbl_verifDate4.AutoSize = true;
			this.lbl_verifDate4.Location = new System.Drawing.Point(438, 304);
			this.lbl_verifDate4.Name = "lbl_verifDate4";
			this.lbl_verifDate4.Size = new System.Drawing.Size(30, 13);
			this.lbl_verifDate4.TabIndex = 207;
			this.lbl_verifDate4.Text = "Date";
			// 
			// lbl_verified_taxoff4
			// 
			this.lbl_verified_taxoff4.AutoSize = true;
			this.lbl_verified_taxoff4.Location = new System.Drawing.Point(438, 278);
			this.lbl_verified_taxoff4.Name = "lbl_verified_taxoff4";
			this.lbl_verified_taxoff4.Size = new System.Drawing.Size(48, 13);
			this.lbl_verified_taxoff4.TabIndex = 206;
			this.lbl_verified_taxoff4.Text = "Verified?";
			// 
			// lbl_verifDate3
			// 
			this.lbl_verifDate3.AutoSize = true;
			this.lbl_verifDate3.Location = new System.Drawing.Point(438, 229);
			this.lbl_verifDate3.Name = "lbl_verifDate3";
			this.lbl_verifDate3.Size = new System.Drawing.Size(30, 13);
			this.lbl_verifDate3.TabIndex = 205;
			this.lbl_verifDate3.Text = "Date";
			// 
			// lbl_verified_taxoff3
			// 
			this.lbl_verified_taxoff3.AutoSize = true;
			this.lbl_verified_taxoff3.Location = new System.Drawing.Point(438, 203);
			this.lbl_verified_taxoff3.Name = "lbl_verified_taxoff3";
			this.lbl_verified_taxoff3.Size = new System.Drawing.Size(48, 13);
			this.lbl_verified_taxoff3.TabIndex = 204;
			this.lbl_verified_taxoff3.Text = "Verified?";
			// 
			// lbl_verifDate2
			// 
			this.lbl_verifDate2.AutoSize = true;
			this.lbl_verifDate2.Location = new System.Drawing.Point(438, 146);
			this.lbl_verifDate2.Name = "lbl_verifDate2";
			this.lbl_verifDate2.Size = new System.Drawing.Size(30, 13);
			this.lbl_verifDate2.TabIndex = 203;
			this.lbl_verifDate2.Text = "Date";
			// 
			// lbl_verified_taxoff2
			// 
			this.lbl_verified_taxoff2.AutoSize = true;
			this.lbl_verified_taxoff2.Location = new System.Drawing.Point(438, 120);
			this.lbl_verified_taxoff2.Name = "lbl_verified_taxoff2";
			this.lbl_verified_taxoff2.Size = new System.Drawing.Size(48, 13);
			this.lbl_verified_taxoff2.TabIndex = 202;
			this.lbl_verified_taxoff2.Text = "Verified?";
			// 
			// lbl_verifDate1
			// 
			this.lbl_verifDate1.AutoSize = true;
			this.lbl_verifDate1.Location = new System.Drawing.Point(438, 64);
			this.lbl_verifDate1.Name = "lbl_verifDate1";
			this.lbl_verifDate1.Size = new System.Drawing.Size(30, 13);
			this.lbl_verifDate1.TabIndex = 201;
			this.lbl_verifDate1.Text = "Date";
			// 
			// lbl_verified_taxoff1
			// 
			this.lbl_verified_taxoff1.AutoSize = true;
			this.lbl_verified_taxoff1.Location = new System.Drawing.Point(438, 38);
			this.lbl_verified_taxoff1.Name = "lbl_verified_taxoff1";
			this.lbl_verified_taxoff1.Size = new System.Drawing.Size(48, 13);
			this.lbl_verified_taxoff1.TabIndex = 200;
			this.lbl_verified_taxoff1.Text = "Verified?";
			// 
			// Label39
			// 
			this.Label39.AutoSize = true;
			this.Label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label39.Location = new System.Drawing.Point(573, 27);
			this.Label39.Name = "Label39";
			this.Label39.Size = new System.Drawing.Size(158, 18);
			this.Label39.TabIndex = 199;
			this.Label39.Text = "Export Taxes To Word";
			// 
			// txtTaxOffice1
			// 
			this.txtTaxOffice1.BackColor = System.Drawing.Color.MintCream;
			this.txtTaxOffice1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTaxOffice1.ForeColor = System.Drawing.Color.Purple;
			this.txtTaxOffice1.Location = new System.Drawing.Point(49, 28);
			this.txtTaxOffice1.Multiline = true;
			this.txtTaxOffice1.Name = "txtTaxOffice1";
			this.txtTaxOffice1.ReadOnly = true;
			this.txtTaxOffice1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtTaxOffice1.Size = new System.Drawing.Size(373, 60);
			this.txtTaxOffice1.TabIndex = 178;
			this.txtTaxOffice1.Text = "no data";
			// 
			// txtTaxOffice2
			// 
			this.txtTaxOffice2.BackColor = System.Drawing.Color.MintCream;
			this.txtTaxOffice2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTaxOffice2.ForeColor = System.Drawing.Color.Purple;
			this.txtTaxOffice2.Location = new System.Drawing.Point(49, 107);
			this.txtTaxOffice2.Multiline = true;
			this.txtTaxOffice2.Name = "txtTaxOffice2";
			this.txtTaxOffice2.ReadOnly = true;
			this.txtTaxOffice2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtTaxOffice2.Size = new System.Drawing.Size(373, 60);
			this.txtTaxOffice2.TabIndex = 179;
			this.txtTaxOffice2.Text = "no data";
			// 
			// txtTaxOffice3
			// 
			this.txtTaxOffice3.BackColor = System.Drawing.Color.MintCream;
			this.txtTaxOffice3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTaxOffice3.ForeColor = System.Drawing.Color.Purple;
			this.txtTaxOffice3.Location = new System.Drawing.Point(49, 190);
			this.txtTaxOffice3.Multiline = true;
			this.txtTaxOffice3.Name = "txtTaxOffice3";
			this.txtTaxOffice3.ReadOnly = true;
			this.txtTaxOffice3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtTaxOffice3.Size = new System.Drawing.Size(373, 60);
			this.txtTaxOffice3.TabIndex = 180;
			this.txtTaxOffice3.Text = "no data";
			// 
			// txtTaxOffice4
			// 
			this.txtTaxOffice4.BackColor = System.Drawing.Color.MintCream;
			this.txtTaxOffice4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTaxOffice4.ForeColor = System.Drawing.Color.Purple;
			this.txtTaxOffice4.Location = new System.Drawing.Point(49, 268);
			this.txtTaxOffice4.Multiline = true;
			this.txtTaxOffice4.Name = "txtTaxOffice4";
			this.txtTaxOffice4.ReadOnly = true;
			this.txtTaxOffice4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtTaxOffice4.Size = new System.Drawing.Size(373, 60);
			this.txtTaxOffice4.TabIndex = 181;
			this.txtTaxOffice4.Text = "no data";
			// 
			// txtTaxOffice5
			// 
			this.txtTaxOffice5.BackColor = System.Drawing.Color.MintCream;
			this.txtTaxOffice5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTaxOffice5.ForeColor = System.Drawing.Color.Purple;
			this.txtTaxOffice5.Location = new System.Drawing.Point(48, 347);
			this.txtTaxOffice5.Multiline = true;
			this.txtTaxOffice5.Name = "txtTaxOffice5";
			this.txtTaxOffice5.ReadOnly = true;
			this.txtTaxOffice5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtTaxOffice5.Size = new System.Drawing.Size(373, 60);
			this.txtTaxOffice5.TabIndex = 182;
			this.txtTaxOffice5.Text = "no data";
			// 
			// lblTxAuth1
			// 
			this.lblTxAuth1.AutoSize = true;
			this.lblTxAuth1.Location = new System.Drawing.Point(51, 12);
			this.lblTxAuth1.Name = "lblTxAuth1";
			this.lblTxAuth1.Size = new System.Drawing.Size(62, 13);
			this.lblTxAuth1.TabIndex = 183;
			this.lblTxAuth1.Text = "Tax Office1";
			// 
			// linkLocTax1
			// 
			this.linkLocTax1.ActiveLinkColor = System.Drawing.Color.MediumOrchid;
			this.linkLocTax1.AutoSize = true;
			this.linkLocTax1.LinkColor = System.Drawing.Color.Purple;
			this.linkLocTax1.Location = new System.Drawing.Point(345, 12);
			this.linkLocTax1.Name = "linkLocTax1";
			this.linkLocTax1.Size = new System.Drawing.Size(57, 13);
			this.linkLocTax1.TabIndex = 188;
			this.linkLocTax1.TabStop = true;
			this.linkLocTax1.Text = "Tax Web1";
			this.linkLocTax1.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.linkLocTax1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelLocTx1_LinkClicked);
			// 
			// linkLocTax5
			// 
			this.linkLocTax5.ActiveLinkColor = System.Drawing.Color.MediumOrchid;
			this.linkLocTax5.AutoSize = true;
			this.linkLocTax5.LinkColor = System.Drawing.Color.Purple;
			this.linkLocTax5.Location = new System.Drawing.Point(344, 331);
			this.linkLocTax5.Name = "linkLocTax5";
			this.linkLocTax5.Size = new System.Drawing.Size(57, 13);
			this.linkLocTax5.TabIndex = 192;
			this.linkLocTax5.TabStop = true;
			this.linkLocTax5.Text = "Tax Web5";
			this.linkLocTax5.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.linkLocTax5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelLocTx5_LinkClicked);
			// 
			// lblTxAuth5
			// 
			this.lblTxAuth5.AutoSize = true;
			this.lblTxAuth5.Location = new System.Drawing.Point(50, 331);
			this.lblTxAuth5.Name = "lblTxAuth5";
			this.lblTxAuth5.Size = new System.Drawing.Size(62, 13);
			this.lblTxAuth5.TabIndex = 187;
			this.lblTxAuth5.Text = "Tax Office5";
			// 
			// lblTxAuth2
			// 
			this.lblTxAuth2.AutoSize = true;
			this.lblTxAuth2.Location = new System.Drawing.Point(51, 91);
			this.lblTxAuth2.Name = "lblTxAuth2";
			this.lblTxAuth2.Size = new System.Drawing.Size(62, 13);
			this.lblTxAuth2.TabIndex = 184;
			this.lblTxAuth2.Text = "Tax Office2";
			// 
			// linkLocTax2
			// 
			this.linkLocTax2.ActiveLinkColor = System.Drawing.Color.MediumOrchid;
			this.linkLocTax2.AutoSize = true;
			this.linkLocTax2.LinkColor = System.Drawing.Color.Purple;
			this.linkLocTax2.Location = new System.Drawing.Point(345, 91);
			this.linkLocTax2.Name = "linkLocTax2";
			this.linkLocTax2.Size = new System.Drawing.Size(57, 13);
			this.linkLocTax2.TabIndex = 189;
			this.linkLocTax2.TabStop = true;
			this.linkLocTax2.Text = "Tax Web2";
			this.linkLocTax2.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.linkLocTax2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelLocTx2_LinkClicked);
			// 
			// linkLocTax4
			// 
			this.linkLocTax4.ActiveLinkColor = System.Drawing.Color.MediumOrchid;
			this.linkLocTax4.AutoSize = true;
			this.linkLocTax4.LinkColor = System.Drawing.Color.Purple;
			this.linkLocTax4.Location = new System.Drawing.Point(345, 252);
			this.linkLocTax4.Name = "linkLocTax4";
			this.linkLocTax4.Size = new System.Drawing.Size(57, 13);
			this.linkLocTax4.TabIndex = 191;
			this.linkLocTax4.TabStop = true;
			this.linkLocTax4.Text = "Tax Web4";
			this.linkLocTax4.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.linkLocTax4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelLocTx4_LinkClicked);
			// 
			// lblTxAuth4
			// 
			this.lblTxAuth4.AutoSize = true;
			this.lblTxAuth4.Location = new System.Drawing.Point(51, 252);
			this.lblTxAuth4.Name = "lblTxAuth4";
			this.lblTxAuth4.Size = new System.Drawing.Size(62, 13);
			this.lblTxAuth4.TabIndex = 186;
			this.lblTxAuth4.Text = "Tax Office4";
			// 
			// lblTxAuth3
			// 
			this.lblTxAuth3.AutoSize = true;
			this.lblTxAuth3.Location = new System.Drawing.Point(51, 174);
			this.lblTxAuth3.Name = "lblTxAuth3";
			this.lblTxAuth3.Size = new System.Drawing.Size(62, 13);
			this.lblTxAuth3.TabIndex = 185;
			this.lblTxAuth3.Text = "Tax Office3";
			// 
			// linkLocTax3
			// 
			this.linkLocTax3.ActiveLinkColor = System.Drawing.Color.MediumOrchid;
			this.linkLocTax3.AutoSize = true;
			this.linkLocTax3.LinkColor = System.Drawing.Color.Purple;
			this.linkLocTax3.Location = new System.Drawing.Point(345, 174);
			this.linkLocTax3.Name = "linkLocTax3";
			this.linkLocTax3.Size = new System.Drawing.Size(57, 13);
			this.linkLocTax3.TabIndex = 190;
			this.linkLocTax3.TabStop = true;
			this.linkLocTax3.Text = "Tax Web3";
			this.linkLocTax3.VisitedLinkColor = System.Drawing.Color.DarkSlateBlue;
			this.linkLocTax3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelLocTx3_LinkClicked);
			// 
			// pbxExport
			// 
			this.pbxExport.Image = global::WindowsApplication1.Resources.doc_icon;
			this.pbxExport.Location = new System.Drawing.Point(542, 22);
			this.pbxExport.Name = "pbxExport";
			this.pbxExport.Size = new System.Drawing.Size(23, 25);
			this.pbxExport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxExport.TabIndex = 198;
			this.pbxExport.TabStop = false;
			this.pbxExport.Tag = "clipboard";
			this.pbxExport.Click += new System.EventHandler(this.pbxExport_Click);
			// 
			// pbxCopy5
			// 
			this.pbxCopy5.Image = global::WindowsApplication1.Resources.clipboard;
			this.pbxCopy5.Location = new System.Drawing.Point(21, 347);
			this.pbxCopy5.Name = "pbxCopy5";
			this.pbxCopy5.Size = new System.Drawing.Size(21, 23);
			this.pbxCopy5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxCopy5.TabIndex = 197;
			this.pbxCopy5.TabStop = false;
			this.pbxCopy5.Tag = "clipboard";
			this.pbxCopy5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pboxCopy5_MouseClick);
			// 
			// pbxCopy4
			// 
			this.pbxCopy4.Image = global::WindowsApplication1.Resources.clipboard;
			this.pbxCopy4.Location = new System.Drawing.Point(22, 268);
			this.pbxCopy4.Name = "pbxCopy4";
			this.pbxCopy4.Size = new System.Drawing.Size(21, 23);
			this.pbxCopy4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxCopy4.TabIndex = 196;
			this.pbxCopy4.TabStop = false;
			this.pbxCopy4.Tag = "clipboard";
			this.pbxCopy4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pboxCopy4_MouseClick);
			// 
			// pbxCopy3
			// 
			this.pbxCopy3.Image = global::WindowsApplication1.Resources.clipboard;
			this.pbxCopy3.Location = new System.Drawing.Point(22, 190);
			this.pbxCopy3.Name = "pbxCopy3";
			this.pbxCopy3.Size = new System.Drawing.Size(21, 23);
			this.pbxCopy3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxCopy3.TabIndex = 195;
			this.pbxCopy3.TabStop = false;
			this.pbxCopy3.Tag = "clipboard";
			this.pbxCopy3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pboxCopy3_MouseClick);
			// 
			// pbxCopy2
			// 
			this.pbxCopy2.Image = global::WindowsApplication1.Resources.clipboard;
			this.pbxCopy2.Location = new System.Drawing.Point(22, 107);
			this.pbxCopy2.Name = "pbxCopy2";
			this.pbxCopy2.Size = new System.Drawing.Size(21, 23);
			this.pbxCopy2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxCopy2.TabIndex = 194;
			this.pbxCopy2.TabStop = false;
			this.pbxCopy2.Tag = "clipboard";
			this.pbxCopy2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbxCopy2_Mouseclick);
			// 
			// pbxCopy1
			// 
			this.pbxCopy1.Image = global::WindowsApplication1.Resources.clipboard;
			this.pbxCopy1.Location = new System.Drawing.Point(22, 28);
			this.pbxCopy1.Name = "pbxCopy1";
			this.pbxCopy1.Size = new System.Drawing.Size(21, 23);
			this.pbxCopy1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxCopy1.TabIndex = 193;
			this.pbxCopy1.TabStop = false;
			this.pbxCopy1.Tag = "clipboard";
			this.pbxCopy1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pboxCopy1_MouseClick);
			// 
			// TabPg1Statistics
			// 
			this.TabPg1Statistics.AutoScroll = true;
			this.TabPg1Statistics.BackColor = System.Drawing.Color.AliceBlue;
			this.TabPg1Statistics.Controls.Add(this.GroupBox1);
			this.TabPg1Statistics.Controls.Add(this.Label121);
			this.TabPg1Statistics.Controls.Add(this.Label118);
			this.TabPg1Statistics.Controls.Add(this.Label21);
			this.TabPg1Statistics.Controls.Add(this.cbox_StatsTaxCounties);
			this.TabPg1Statistics.Controls.Add(this.txt_StatsTaxOffices);
			this.TabPg1Statistics.Controls.Add(this.lbl_TaxOnlineStats);
			this.TabPg1Statistics.Controls.Add(this.Label14);
			this.TabPg1Statistics.Controls.Add(this.lbl_OrbStat6);
			this.TabPg1Statistics.Controls.Add(this.Label37);
			this.TabPg1Statistics.Controls.Add(this.cbox_StatsStates);
			this.TabPg1Statistics.Controls.Add(this.Label25);
			this.TabPg1Statistics.Controls.Add(this.Label23);
			this.TabPg1Statistics.Controls.Add(this.lbl_OrbStats);
			this.TabPg1Statistics.Controls.Add(this.lbl_OrbStat5);
			this.TabPg1Statistics.Controls.Add(this.txt_StatsCounties);
			this.TabPg1Statistics.Controls.Add(this.lbl_OrbStat4);
			this.TabPg1Statistics.Controls.Add(this.lbl_OrbStat3);
			this.TabPg1Statistics.Controls.Add(this.lbl_OrbStat2);
			this.TabPg1Statistics.Controls.Add(this.lbl_OrbStat1);
			this.TabPg1Statistics.Controls.Add(this.lbl_CoOnlineStats);
			this.TabPg1Statistics.Controls.Add(this.Label120);
			this.TabPg1Statistics.Controls.Add(this.Label119);
			this.TabPg1Statistics.Controls.Add(this.Label116);
			this.TabPg1Statistics.Controls.Add(this.Label115);
			this.TabPg1Statistics.Location = new System.Drawing.Point(4, 22);
			this.TabPg1Statistics.Name = "TabPg1Statistics";
			this.TabPg1Statistics.Padding = new System.Windows.Forms.Padding(3);
			this.TabPg1Statistics.Size = new System.Drawing.Size(866, 201);
			this.TabPg1Statistics.TabIndex = 9;
			this.TabPg1Statistics.Text = "Statistics";
			// 
			// GroupBox1
			// 
			this.GroupBox1.Controls.Add(this.lbl_vstats_YTD);
			this.GroupBox1.Controls.Add(this.lbl_vstats_Jan);
			this.GroupBox1.Controls.Add(this.lbl_vstats_Dec);
			this.GroupBox1.Controls.Add(this.lbl_vstats_Feb);
			this.GroupBox1.Controls.Add(this.lbl_vstats_Nov);
			this.GroupBox1.Controls.Add(this.lbl_vstats_Mar);
			this.GroupBox1.Controls.Add(this.lbl_vstats_Oct);
			this.GroupBox1.Controls.Add(this.lbl_vstats_Apr);
			this.GroupBox1.Controls.Add(this.lbl_vstats_Sep);
			this.GroupBox1.Controls.Add(this.lbl_vstats_May);
			this.GroupBox1.Controls.Add(this.lbl_vstats_Aug);
			this.GroupBox1.Controls.Add(this.lbl_vstats_Jun);
			this.GroupBox1.Controls.Add(this.lbl_vstats_Jul);
			this.GroupBox1.Location = new System.Drawing.Point(15, 19);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(237, 161);
			this.GroupBox1.TabIndex = 36;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Online Searches Completed - 2008";
			// 
			// lbl_vstats_YTD
			// 
			this.lbl_vstats_YTD.AutoSize = true;
			this.lbl_vstats_YTD.Location = new System.Drawing.Point(23, 22);
			this.lbl_vstats_YTD.Name = "lbl_vstats_YTD";
			this.lbl_vstats_YTD.Size = new System.Drawing.Size(83, 13);
			this.lbl_vstats_YTD.TabIndex = 36;
			this.lbl_vstats_YTD.Text = "YTD #Inhouse: ";
			// 
			// lbl_vstats_Jan
			// 
			this.lbl_vstats_Jan.AutoSize = true;
			this.lbl_vstats_Jan.Location = new System.Drawing.Point(24, 46);
			this.lbl_vstats_Jan.Name = "lbl_vstats_Jan";
			this.lbl_vstats_Jan.Size = new System.Drawing.Size(30, 13);
			this.lbl_vstats_Jan.TabIndex = 24;
			this.lbl_vstats_Jan.Text = "Jan: ";
			// 
			// lbl_vstats_Dec
			// 
			this.lbl_vstats_Dec.AutoSize = true;
			this.lbl_vstats_Dec.Location = new System.Drawing.Point(125, 136);
			this.lbl_vstats_Dec.Name = "lbl_vstats_Dec";
			this.lbl_vstats_Dec.Size = new System.Drawing.Size(33, 13);
			this.lbl_vstats_Dec.TabIndex = 35;
			this.lbl_vstats_Dec.Text = "Dec: ";
			// 
			// lbl_vstats_Feb
			// 
			this.lbl_vstats_Feb.AutoSize = true;
			this.lbl_vstats_Feb.Location = new System.Drawing.Point(24, 64);
			this.lbl_vstats_Feb.Name = "lbl_vstats_Feb";
			this.lbl_vstats_Feb.Size = new System.Drawing.Size(31, 13);
			this.lbl_vstats_Feb.TabIndex = 25;
			this.lbl_vstats_Feb.Text = "Feb: ";
			// 
			// lbl_vstats_Nov
			// 
			this.lbl_vstats_Nov.AutoSize = true;
			this.lbl_vstats_Nov.Location = new System.Drawing.Point(125, 118);
			this.lbl_vstats_Nov.Name = "lbl_vstats_Nov";
			this.lbl_vstats_Nov.Size = new System.Drawing.Size(33, 13);
			this.lbl_vstats_Nov.TabIndex = 34;
			this.lbl_vstats_Nov.Text = "Nov: ";
			// 
			// lbl_vstats_Mar
			// 
			this.lbl_vstats_Mar.AutoSize = true;
			this.lbl_vstats_Mar.Location = new System.Drawing.Point(24, 82);
			this.lbl_vstats_Mar.Name = "lbl_vstats_Mar";
			this.lbl_vstats_Mar.Size = new System.Drawing.Size(31, 13);
			this.lbl_vstats_Mar.TabIndex = 26;
			this.lbl_vstats_Mar.Text = "Mar: ";
			// 
			// lbl_vstats_Oct
			// 
			this.lbl_vstats_Oct.AutoSize = true;
			this.lbl_vstats_Oct.Location = new System.Drawing.Point(125, 100);
			this.lbl_vstats_Oct.Name = "lbl_vstats_Oct";
			this.lbl_vstats_Oct.Size = new System.Drawing.Size(30, 13);
			this.lbl_vstats_Oct.TabIndex = 33;
			this.lbl_vstats_Oct.Text = "Oct: ";
			// 
			// lbl_vstats_Apr
			// 
			this.lbl_vstats_Apr.AutoSize = true;
			this.lbl_vstats_Apr.Location = new System.Drawing.Point(24, 100);
			this.lbl_vstats_Apr.Name = "lbl_vstats_Apr";
			this.lbl_vstats_Apr.Size = new System.Drawing.Size(29, 13);
			this.lbl_vstats_Apr.TabIndex = 27;
			this.lbl_vstats_Apr.Text = "Apr: ";
			// 
			// lbl_vstats_Sep
			// 
			this.lbl_vstats_Sep.AutoSize = true;
			this.lbl_vstats_Sep.Location = new System.Drawing.Point(125, 82);
			this.lbl_vstats_Sep.Name = "lbl_vstats_Sep";
			this.lbl_vstats_Sep.Size = new System.Drawing.Size(32, 13);
			this.lbl_vstats_Sep.TabIndex = 32;
			this.lbl_vstats_Sep.Text = "Sep: ";
			// 
			// lbl_vstats_May
			// 
			this.lbl_vstats_May.AutoSize = true;
			this.lbl_vstats_May.Location = new System.Drawing.Point(24, 118);
			this.lbl_vstats_May.Name = "lbl_vstats_May";
			this.lbl_vstats_May.Size = new System.Drawing.Size(33, 13);
			this.lbl_vstats_May.TabIndex = 28;
			this.lbl_vstats_May.Text = "May: ";
			// 
			// lbl_vstats_Aug
			// 
			this.lbl_vstats_Aug.AutoSize = true;
			this.lbl_vstats_Aug.Location = new System.Drawing.Point(125, 64);
			this.lbl_vstats_Aug.Name = "lbl_vstats_Aug";
			this.lbl_vstats_Aug.Size = new System.Drawing.Size(32, 13);
			this.lbl_vstats_Aug.TabIndex = 31;
			this.lbl_vstats_Aug.Text = "Aug: ";
			// 
			// lbl_vstats_Jun
			// 
			this.lbl_vstats_Jun.AutoSize = true;
			this.lbl_vstats_Jun.Location = new System.Drawing.Point(24, 136);
			this.lbl_vstats_Jun.Name = "lbl_vstats_Jun";
			this.lbl_vstats_Jun.Size = new System.Drawing.Size(30, 13);
			this.lbl_vstats_Jun.TabIndex = 29;
			this.lbl_vstats_Jun.Text = "Jun: ";
			// 
			// lbl_vstats_Jul
			// 
			this.lbl_vstats_Jul.AutoSize = true;
			this.lbl_vstats_Jul.Location = new System.Drawing.Point(125, 46);
			this.lbl_vstats_Jul.Name = "lbl_vstats_Jul";
			this.lbl_vstats_Jul.Size = new System.Drawing.Size(26, 13);
			this.lbl_vstats_Jul.TabIndex = 30;
			this.lbl_vstats_Jul.Text = "Jul: ";
			// 
			// Label121
			// 
			this.Label121.AutoSize = true;
			this.Label121.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label121.Location = new System.Drawing.Point(578, 183);
			this.Label121.Name = "Label121";
			this.Label121.Size = new System.Drawing.Size(122, 17);
			this.Label121.TabIndex = 23;
			this.Label121.Text = "Tax Offices By State";
			// 
			// Label118
			// 
			this.Label118.AutoSize = true;
			this.Label118.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label118.Location = new System.Drawing.Point(578, 8);
			this.Label118.Name = "Label118";
			this.Label118.Size = new System.Drawing.Size(198, 17);
			this.Label118.TabIndex = 22;
			this.Label118.Text = "InHouse Coverage Area By State";
			// 
			// Label21
			// 
			this.Label21.AutoSize = true;
			this.Label21.Location = new System.Drawing.Point(576, 200);
			this.Label21.Name = "Label21";
			this.Label21.Size = new System.Drawing.Size(43, 13);
			this.Label21.TabIndex = 21;
			this.Label21.Text = "County:";
			// 
			// cbox_StatsTaxCounties
			// 
			this.cbox_StatsTaxCounties.FormattingEnabled = true;
			this.cbox_StatsTaxCounties.Location = new System.Drawing.Point(579, 216);
			this.cbox_StatsTaxCounties.Name = "cbox_StatsTaxCounties";
			this.cbox_StatsTaxCounties.Size = new System.Drawing.Size(60, 21);
			this.cbox_StatsTaxCounties.TabIndex = 20;
			this.cbox_StatsTaxCounties.SelectedIndexChanged += new System.EventHandler(this.cbox_StatsTaxCounties_SelectedIndexChanged);
			// 
			// txt_StatsTaxOffices
			// 
			this.txt_StatsTaxOffices.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_StatsTaxOffices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_StatsTaxOffices.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_StatsTaxOffices.ForeColor = System.Drawing.Color.DarkBlue;
			this.txt_StatsTaxOffices.Location = new System.Drawing.Point(581, 256);
			this.txt_StatsTaxOffices.Multiline = true;
			this.txt_StatsTaxOffices.Name = "txt_StatsTaxOffices";
			this.txt_StatsTaxOffices.ReadOnly = true;
			this.txt_StatsTaxOffices.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txt_StatsTaxOffices.Size = new System.Drawing.Size(259, 92);
			this.txt_StatsTaxOffices.TabIndex = 19;
			// 
			// lbl_TaxOnlineStats
			// 
			this.lbl_TaxOnlineStats.AutoSize = true;
			this.lbl_TaxOnlineStats.Location = new System.Drawing.Point(578, 240);
			this.lbl_TaxOnlineStats.Name = "lbl_TaxOnlineStats";
			this.lbl_TaxOnlineStats.Size = new System.Drawing.Size(64, 13);
			this.lbl_TaxOnlineStats.TabIndex = 18;
			this.lbl_TaxOnlineStats.Text = "Tax Offices:";
			// 
			// Label14
			// 
			this.Label14.AutoSize = true;
			this.Label14.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label14.Location = new System.Drawing.Point(298, 113);
			this.Label14.Name = "Label14";
			this.Label14.Size = new System.Drawing.Size(179, 14);
			this.Label14.TabIndex = 17;
			this.Label14.Text = "Total# Records in Tax Database:";
			// 
			// lbl_OrbStat6
			// 
			this.lbl_OrbStat6.AutoSize = true;
			this.lbl_OrbStat6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_OrbStat6.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbl_OrbStat6.Location = new System.Drawing.Point(505, 113);
			this.lbl_OrbStat6.Name = "lbl_OrbStat6";
			this.lbl_OrbStat6.Size = new System.Drawing.Size(13, 14);
			this.lbl_OrbStat6.TabIndex = 16;
			this.lbl_OrbStat6.Text = "#";
			// 
			// Label37
			// 
			this.Label37.AutoSize = true;
			this.Label37.Location = new System.Drawing.Point(578, 25);
			this.Label37.Name = "Label37";
			this.Label37.Size = new System.Drawing.Size(35, 13);
			this.Label37.TabIndex = 15;
			this.Label37.Text = "State:";
			// 
			// cbox_StatsStates
			// 
			this.cbox_StatsStates.FormattingEnabled = true;
			this.cbox_StatsStates.Items.AddRange(new object[] {
            "ALL",
            "",
            "AK",
            "AL",
            "AR",
            "AZ",
            "CA",
            "CO",
            "CT",
            "DC",
            "DE",
            "FL",
            "GA",
            "HI",
            "IA",
            "ID",
            "IL",
            "IN",
            "KS",
            "KY",
            "LA",
            "MA",
            "MD",
            "ME",
            "MI",
            "MN",
            "MO",
            "MS",
            "MT",
            "NC",
            "ND",
            "NE",
            "NH",
            "NJ",
            "NM",
            "NV",
            "NY",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VA",
            "VT",
            "WA",
            "WI",
            "WV",
            "WY"});
			this.cbox_StatsStates.Location = new System.Drawing.Point(581, 41);
			this.cbox_StatsStates.Name = "cbox_StatsStates";
			this.cbox_StatsStates.Size = new System.Drawing.Size(60, 21);
			this.cbox_StatsStates.TabIndex = 14;
			this.cbox_StatsStates.TextChanged += new System.EventHandler(this.cbox_StatsStates_SelectedIndexChanged);
			// 
			// Label25
			// 
			this.Label25.AutoSize = true;
			this.Label25.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label25.Location = new System.Drawing.Point(298, 157);
			this.Label25.Name = "Label25";
			this.Label25.Size = new System.Drawing.Size(169, 14);
			this.Label25.TabIndex = 13;
			this.Label25.Text = "Total# Tax Offices Researched:";
			// 
			// Label23
			// 
			this.Label23.AutoSize = true;
			this.Label23.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label23.Location = new System.Drawing.Point(298, 25);
			this.Label23.Name = "Label23";
			this.Label23.Size = new System.Drawing.Size(181, 14);
			this.Label23.TabIndex = 12;
			this.Label23.Text = "Total# Records in Orb Database:";
			// 
			// lbl_OrbStats
			// 
			this.lbl_OrbStats.AutoSize = true;
			this.lbl_OrbStats.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_OrbStats.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbl_OrbStats.Location = new System.Drawing.Point(505, 25);
			this.lbl_OrbStats.Name = "lbl_OrbStats";
			this.lbl_OrbStats.Size = new System.Drawing.Size(13, 14);
			this.lbl_OrbStats.TabIndex = 11;
			this.lbl_OrbStats.Text = "#";
			// 
			// lbl_OrbStat5
			// 
			this.lbl_OrbStat5.AutoSize = true;
			this.lbl_OrbStat5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_OrbStat5.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbl_OrbStat5.Location = new System.Drawing.Point(505, 157);
			this.lbl_OrbStat5.Name = "lbl_OrbStat5";
			this.lbl_OrbStat5.Size = new System.Drawing.Size(13, 14);
			this.lbl_OrbStat5.TabIndex = 10;
			this.lbl_OrbStat5.Text = "#";
			// 
			// txt_StatsCounties
			// 
			this.txt_StatsCounties.BackColor = System.Drawing.Color.GhostWhite;
			this.txt_StatsCounties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_StatsCounties.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_StatsCounties.ForeColor = System.Drawing.Color.DarkBlue;
			this.txt_StatsCounties.Location = new System.Drawing.Point(581, 81);
			this.txt_StatsCounties.Multiline = true;
			this.txt_StatsCounties.Name = "txt_StatsCounties";
			this.txt_StatsCounties.ReadOnly = true;
			this.txt_StatsCounties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txt_StatsCounties.Size = new System.Drawing.Size(182, 92);
			this.txt_StatsCounties.TabIndex = 9;
			// 
			// lbl_OrbStat4
			// 
			this.lbl_OrbStat4.AutoSize = true;
			this.lbl_OrbStat4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_OrbStat4.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbl_OrbStat4.Location = new System.Drawing.Point(505, 135);
			this.lbl_OrbStat4.Name = "lbl_OrbStat4";
			this.lbl_OrbStat4.Size = new System.Drawing.Size(13, 14);
			this.lbl_OrbStat4.TabIndex = 8;
			this.lbl_OrbStat4.Text = "#";
			// 
			// lbl_OrbStat3
			// 
			this.lbl_OrbStat3.AutoSize = true;
			this.lbl_OrbStat3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_OrbStat3.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbl_OrbStat3.Location = new System.Drawing.Point(505, 91);
			this.lbl_OrbStat3.Name = "lbl_OrbStat3";
			this.lbl_OrbStat3.Size = new System.Drawing.Size(13, 14);
			this.lbl_OrbStat3.TabIndex = 7;
			this.lbl_OrbStat3.Text = "#";
			// 
			// lbl_OrbStat2
			// 
			this.lbl_OrbStat2.AutoSize = true;
			this.lbl_OrbStat2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_OrbStat2.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbl_OrbStat2.Location = new System.Drawing.Point(505, 69);
			this.lbl_OrbStat2.Name = "lbl_OrbStat2";
			this.lbl_OrbStat2.Size = new System.Drawing.Size(13, 14);
			this.lbl_OrbStat2.TabIndex = 6;
			this.lbl_OrbStat2.Text = "#";
			// 
			// lbl_OrbStat1
			// 
			this.lbl_OrbStat1.AutoSize = true;
			this.lbl_OrbStat1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_OrbStat1.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbl_OrbStat1.Location = new System.Drawing.Point(505, 47);
			this.lbl_OrbStat1.Name = "lbl_OrbStat1";
			this.lbl_OrbStat1.Size = new System.Drawing.Size(13, 14);
			this.lbl_OrbStat1.TabIndex = 5;
			this.lbl_OrbStat1.Text = "#";
			// 
			// lbl_CoOnlineStats
			// 
			this.lbl_CoOnlineStats.AutoSize = true;
			this.lbl_CoOnlineStats.Location = new System.Drawing.Point(578, 65);
			this.lbl_CoOnlineStats.Name = "lbl_CoOnlineStats";
			this.lbl_CoOnlineStats.Size = new System.Drawing.Size(84, 13);
			this.lbl_CoOnlineStats.TabIndex = 4;
			this.lbl_CoOnlineStats.Text = "Online Counties:";
			// 
			// Label120
			// 
			this.Label120.AutoSize = true;
			this.Label120.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label120.Location = new System.Drawing.Point(298, 91);
			this.Label120.Name = "Label120";
			this.Label120.Size = new System.Drawing.Size(120, 14);
			this.Label120.TabIndex = 3;
			this.Label120.Text = "Total# Courts Online:";
			// 
			// Label119
			// 
			this.Label119.AutoSize = true;
			this.Label119.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label119.Location = new System.Drawing.Point(298, 69);
			this.Label119.Name = "Label119";
			this.Label119.Size = new System.Drawing.Size(194, 14);
			this.Label119.TabIndex = 2;
			this.Label119.Text = "Total# InHouse Coverage Counties:";
			// 
			// Label116
			// 
			this.Label116.AutoSize = true;
			this.Label116.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label116.Location = new System.Drawing.Point(298, 135);
			this.Label116.Name = "Label116";
			this.Label116.Size = new System.Drawing.Size(142, 14);
			this.Label116.TabIndex = 1;
			this.Label116.Text = "Total# Tax Offices Online:";
			// 
			// Label115
			// 
			this.Label115.AutoSize = true;
			this.Label115.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label115.Location = new System.Drawing.Point(298, 47);
			this.Label115.Name = "Label115";
			this.Label115.Size = new System.Drawing.Size(165, 14);
			this.Label115.TabIndex = 0;
			this.Label115.Text = "Total# of Land Indexs Online:";
			// 
			// TabPg2Misc
			// 
			this.TabPg2Misc.AutoScroll = true;
			this.TabPg2Misc.BackColor = System.Drawing.Color.GhostWhite;
			this.TabPg2Misc.Controls.Add(this.lblSOL_being_Clause);
			this.TabPg2Misc.Controls.Add(this.lbl_homestead);
			this.TabPg2Misc.Controls.Add(this.txt_homestead_notes);
			this.TabPg2Misc.Controls.Add(this.lbl_deed_prep);
			this.TabPg2Misc.Controls.Add(this.lbl_attyClose);
			this.TabPg2Misc.Controls.Add(this.txt_AttyNotes);
			this.TabPg2Misc.Controls.Add(this.txt_DeedNotes);
			this.TabPg2Misc.Controls.Add(this.CheckBox1);
			this.TabPg2Misc.Controls.Add(this.Label123);
			this.TabPg2Misc.Controls.Add(this.txt_PolicyNotes);
			this.TabPg2Misc.Location = new System.Drawing.Point(4, 22);
			this.TabPg2Misc.Name = "TabPg2Misc";
			this.TabPg2Misc.Padding = new System.Windows.Forms.Padding(3);
			this.TabPg2Misc.Size = new System.Drawing.Size(866, 201);
			this.TabPg2Misc.TabIndex = 10;
			this.TabPg2Misc.Text = "Misc";
			// 
			// lblSOL_being_Clause
			// 
			this.lblSOL_being_Clause.AutoSize = true;
			this.lblSOL_being_Clause.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSOL_being_Clause.Location = new System.Drawing.Point(8, 157);
			this.lblSOL_being_Clause.Name = "lblSOL_being_Clause";
			this.lblSOL_being_Clause.Size = new System.Drawing.Size(124, 13);
			this.lblSOL_being_Clause.TabIndex = 89;
			this.lblSOL_being_Clause.Text = "Being Clause Required";
			// 
			// lbl_homestead
			// 
			this.lbl_homestead.AutoSize = true;
			this.lbl_homestead.Location = new System.Drawing.Point(4, 12);
			this.lbl_homestead.Name = "lbl_homestead";
			this.lbl_homestead.Size = new System.Drawing.Size(64, 13);
			this.lbl_homestead.TabIndex = 88;
			this.lbl_homestead.Text = "Homestead:";
			// 
			// txt_homestead_notes
			// 
			this.txt_homestead_notes.BackColor = System.Drawing.Color.Snow;
			this.txt_homestead_notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_homestead_notes.ForeColor = System.Drawing.Color.Purple;
			this.txt_homestead_notes.Location = new System.Drawing.Point(4, 28);
			this.txt_homestead_notes.Multiline = true;
			this.txt_homestead_notes.Name = "txt_homestead_notes";
			this.txt_homestead_notes.ReadOnly = true;
			this.txt_homestead_notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txt_homestead_notes.Size = new System.Drawing.Size(262, 48);
			this.txt_homestead_notes.TabIndex = 87;
			// 
			// lbl_deed_prep
			// 
			this.lbl_deed_prep.AutoSize = true;
			this.lbl_deed_prep.Location = new System.Drawing.Point(8, 90);
			this.lbl_deed_prep.Name = "lbl_deed_prep";
			this.lbl_deed_prep.Size = new System.Drawing.Size(64, 13);
			this.lbl_deed_prep.TabIndex = 86;
			this.lbl_deed_prep.Text = "Deed Prep: ";
			this.lbl_deed_prep.Click += new System.EventHandler(this.lblDeedPrep_Click);
			this.lbl_deed_prep.MouseLeave += new System.EventHandler(this.lblDeedPrep_mouseLeave);
			this.lbl_deed_prep.MouseHover += new System.EventHandler(this.lblDeedPrep_mouseHover);
			// 
			// lbl_attyClose
			// 
			this.lbl_attyClose.AutoSize = true;
			this.lbl_attyClose.Location = new System.Drawing.Point(287, 12);
			this.lbl_attyClose.Name = "lbl_attyClose";
			this.lbl_attyClose.Size = new System.Drawing.Size(108, 13);
			this.lbl_attyClose.TabIndex = 77;
			this.lbl_attyClose.Text = "Attorney State Notes:";
			// 
			// txt_AttyNotes
			// 
			this.txt_AttyNotes.BackColor = System.Drawing.Color.Snow;
			this.txt_AttyNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_AttyNotes.ForeColor = System.Drawing.Color.Purple;
			this.txt_AttyNotes.Location = new System.Drawing.Point(287, 28);
			this.txt_AttyNotes.Multiline = true;
			this.txt_AttyNotes.Name = "txt_AttyNotes";
			this.txt_AttyNotes.ReadOnly = true;
			this.txt_AttyNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txt_AttyNotes.Size = new System.Drawing.Size(262, 48);
			this.txt_AttyNotes.TabIndex = 76;
			// 
			// txt_DeedNotes
			// 
			this.txt_DeedNotes.BackColor = System.Drawing.Color.Snow;
			this.txt_DeedNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_DeedNotes.ForeColor = System.Drawing.Color.Purple;
			this.txt_DeedNotes.Location = new System.Drawing.Point(6, 106);
			this.txt_DeedNotes.Multiline = true;
			this.txt_DeedNotes.Name = "txt_DeedNotes";
			this.txt_DeedNotes.ReadOnly = true;
			this.txt_DeedNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txt_DeedNotes.Size = new System.Drawing.Size(262, 48);
			this.txt_DeedNotes.TabIndex = 74;
			// 
			// CheckBox1
			// 
			this.CheckBox1.AutoSize = true;
			this.CheckBox1.Location = new System.Drawing.Point(207, 355);
			this.CheckBox1.Name = "CheckBox1";
			this.CheckBox1.Size = new System.Drawing.Size(141, 17);
			this.CheckBox1.TabIndex = 257;
			this.CheckBox1.Text = "Attorney must close loan";
			this.CheckBox1.UseVisualStyleBackColor = true;
			// 
			// Label123
			// 
			this.Label123.AutoSize = true;
			this.Label123.Location = new System.Drawing.Point(577, 12);
			this.Label123.Name = "Label123";
			this.Label123.Size = new System.Drawing.Size(69, 13);
			this.Label123.TabIndex = 73;
			this.Label123.Text = "Policy Notes:";
			// 
			// txt_PolicyNotes
			// 
			this.txt_PolicyNotes.BackColor = System.Drawing.Color.Snow;
			this.txt_PolicyNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_PolicyNotes.ForeColor = System.Drawing.Color.Purple;
			this.txt_PolicyNotes.Location = new System.Drawing.Point(577, 28);
			this.txt_PolicyNotes.Multiline = true;
			this.txt_PolicyNotes.Name = "txt_PolicyNotes";
			this.txt_PolicyNotes.ReadOnly = true;
			this.txt_PolicyNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txt_PolicyNotes.Size = new System.Drawing.Size(262, 48);
			this.txt_PolicyNotes.TabIndex = 72;
			// 
			// LinkLabel4
			// 
			this.LinkLabel4.AutoSize = true;
			this.LinkLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LinkLabel4.Location = new System.Drawing.Point(492, 617);
			this.LinkLabel4.Name = "LinkLabel4";
			this.LinkLabel4.Size = new System.Drawing.Size(236, 15);
			this.LinkLabel4.TabIndex = 191;
			this.LinkLabel4.TabStop = true;
			this.LinkLabel4.Text = "Report suggestions or problems with ORB";
			this.LinkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel4_LinkClicked);
			// 
			// Label56
			// 
			this.Label56.AutoSize = true;
			this.Label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label56.ForeColor = System.Drawing.Color.SteelBlue;
			this.Label56.Location = new System.Drawing.Point(18, 617);
			this.Label56.Name = "Label56";
			this.Label56.Size = new System.Drawing.Size(396, 15);
			this.Label56.TabIndex = 193;
			this.Label56.Text = "iMortgage Services Online Resource Bank  Updated through 9-29-2008";
			// 
			// Label55
			// 
			this.Label55.AutoSize = true;
			this.Label55.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label55.Location = new System.Drawing.Point(324, 60);
			this.Label55.Name = "Label55";
			this.Label55.Size = new System.Drawing.Size(80, 13);
			this.Label55.TabIndex = 66;
			this.Label55.Text = "Spousal State:";
			// 
			// Label62
			// 
			this.Label62.AutoSize = true;
			this.Label62.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label62.Location = new System.Drawing.Point(408, 60);
			this.Label62.Name = "Label62";
			this.Label62.Size = new System.Drawing.Size(46, 13);
			this.Label62.TabIndex = 65;
			this.Label62.Text = "Label72";
			// 
			// Label64
			// 
			this.Label64.AutoSize = true;
			this.Label64.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label64.Location = new System.Drawing.Point(12, 267);
			this.Label64.Name = "Label64";
			this.Label64.Size = new System.Drawing.Size(86, 13);
			this.Label64.TabIndex = 62;
			this.Label64.Text = "Redem. Period:";
			// 
			// Label66
			// 
			this.Label66.AutoSize = true;
			this.Label66.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label66.Location = new System.Drawing.Point(132, 267);
			this.Label66.Name = "Label66";
			this.Label66.Size = new System.Drawing.Size(46, 13);
			this.Label66.TabIndex = 61;
			this.Label66.Text = "Label58";
			// 
			// Label70
			// 
			this.Label70.AutoSize = true;
			this.Label70.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label70.Location = new System.Drawing.Point(12, 233);
			this.Label70.Name = "Label70";
			this.Label70.Size = new System.Drawing.Size(76, 13);
			this.Label70.TabIndex = 60;
			this.Label70.Text = "Personal Tax:";
			// 
			// Label75
			// 
			this.Label75.AutoSize = true;
			this.Label75.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label75.Location = new System.Drawing.Point(132, 233);
			this.Label75.Name = "Label75";
			this.Label75.Size = new System.Drawing.Size(46, 13);
			this.Label75.TabIndex = 59;
			this.Label75.Text = "Label60";
			// 
			// Label76
			// 
			this.Label76.AutoSize = true;
			this.Label76.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label76.Location = new System.Drawing.Point(132, 196);
			this.Label76.Name = "Label76";
			this.Label76.Size = new System.Drawing.Size(46, 13);
			this.Label76.TabIndex = 58;
			this.Label76.Text = "Label54";
			// 
			// Label77
			// 
			this.Label77.AutoSize = true;
			this.Label77.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label77.Location = new System.Drawing.Point(12, 216);
			this.Label77.Name = "Label77";
			this.Label77.Size = new System.Drawing.Size(89, 13);
			this.Label77.TabIndex = 57;
			this.Label77.Text = "Creditor Claims:";
			// 
			// Label78
			// 
			this.Label78.AutoSize = true;
			this.Label78.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label78.Location = new System.Drawing.Point(408, 77);
			this.Label78.Name = "Label78";
			this.Label78.Size = new System.Drawing.Size(46, 13);
			this.Label78.TabIndex = 56;
			this.Label78.Text = "Label52";
			// 
			// Label80
			// 
			this.Label80.AutoSize = true;
			this.Label80.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label80.Location = new System.Drawing.Point(324, 77);
			this.Label80.Name = "Label80";
			this.Label80.Size = new System.Drawing.Size(48, 13);
			this.Label80.TabIndex = 55;
			this.Label80.Text = "TE Rule:";
			// 
			// Label82
			// 
			this.Label82.AutoSize = true;
			this.Label82.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label82.Location = new System.Drawing.Point(132, 301);
			this.Label82.Name = "Label82";
			this.Label82.Size = new System.Drawing.Size(46, 13);
			this.Label82.TabIndex = 54;
			this.Label82.Text = "Label46";
			// 
			// Label84
			// 
			this.Label84.AutoSize = true;
			this.Label84.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label84.Location = new System.Drawing.Point(12, 301);
			this.Label84.Name = "Label84";
			this.Label84.Size = new System.Drawing.Size(111, 13);
			this.Label84.TabIndex = 53;
			this.Label84.Text = "After Acquired Lien:";
			// 
			// Label85
			// 
			this.Label85.AutoSize = true;
			this.Label85.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label85.Location = new System.Drawing.Point(132, 43);
			this.Label85.Name = "Label85";
			this.Label85.Size = new System.Drawing.Size(82, 13);
			this.Label85.TabIndex = 52;
			this.Label85.Text = "10 yrs+30 days";
			// 
			// Label86
			// 
			this.Label86.AutoSize = true;
			this.Label86.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label86.Location = new System.Drawing.Point(12, 43);
			this.Label86.Name = "Label86";
			this.Label86.Size = new System.Drawing.Size(75, 13);
			this.Label86.TabIndex = 51;
			this.Label86.Text = "Fed Tax Lien:";
			// 
			// Label87
			// 
			this.Label87.AutoSize = true;
			this.Label87.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label87.Location = new System.Drawing.Point(132, 60);
			this.Label87.Name = "Label87";
			this.Label87.Size = new System.Drawing.Size(30, 13);
			this.Label87.TabIndex = 50;
			this.Label87.Text = "5 yrs";
			// 
			// Label88
			// 
			this.Label88.AutoSize = true;
			this.Label88.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label88.Location = new System.Drawing.Point(12, 60);
			this.Label88.Name = "Label88";
			this.Label88.Size = new System.Drawing.Size(37, 13);
			this.Label88.TabIndex = 49;
			this.Label88.Text = "UCCs:";
			// 
			// TextBox1
			// 
			this.TextBox1.BackColor = System.Drawing.Color.Snow;
			this.TextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextBox1.ForeColor = System.Drawing.Color.Purple;
			this.TextBox1.Location = new System.Drawing.Point(327, 9);
			this.TextBox1.Multiline = true;
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.ReadOnly = true;
			this.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TextBox1.Size = new System.Drawing.Size(395, 47);
			this.TextBox1.TabIndex = 48;
			this.TextBox1.Text = "Comments";
			// 
			// Label89
			// 
			this.Label89.AutoSize = true;
			this.Label89.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label89.Location = new System.Drawing.Point(12, 162);
			this.Label89.Name = "Label89";
			this.Label89.Size = new System.Drawing.Size(65, 13);
			this.Label89.TabIndex = 23;
			this.Label89.Text = "Hosp. Lien:";
			// 
			// Label90
			// 
			this.Label90.AutoSize = true;
			this.Label90.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label90.Location = new System.Drawing.Point(132, 162);
			this.Label90.Name = "Label90";
			this.Label90.Size = new System.Drawing.Size(46, 13);
			this.Label90.TabIndex = 22;
			this.Label90.Text = "Label72";
			// 
			// Label91
			// 
			this.Label91.AutoSize = true;
			this.Label91.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label91.Location = new System.Drawing.Point(12, 196);
			this.Label91.Name = "Label91";
			this.Label91.Size = new System.Drawing.Size(63, 13);
			this.Label91.TabIndex = 21;
			this.Label91.Text = "Judgment:";
			// 
			// Label92
			// 
			this.Label92.AutoSize = true;
			this.Label92.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label92.Location = new System.Drawing.Point(132, 216);
			this.Label92.Name = "Label92";
			this.Label92.Size = new System.Drawing.Size(46, 13);
			this.Label92.TabIndex = 20;
			this.Label92.Text = "Label70";
			// 
			// Label93
			// 
			this.Label93.AutoSize = true;
			this.Label93.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label93.Location = new System.Drawing.Point(132, 77);
			this.Label93.Name = "Label93";
			this.Label93.Size = new System.Drawing.Size(36, 13);
			this.Label93.TabIndex = 25;
			this.Label93.Text = "20 yrs";
			// 
			// Label94
			// 
			this.Label94.AutoSize = true;
			this.Label94.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label94.Location = new System.Drawing.Point(12, 179);
			this.Label94.Name = "Label94";
			this.Label94.Size = new System.Drawing.Size(78, 13);
			this.Label94.TabIndex = 19;
			this.Label94.Text = "Claim of Lien:";
			// 
			// Label95
			// 
			this.Label95.AutoSize = true;
			this.Label95.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label95.Location = new System.Drawing.Point(12, 77);
			this.Label95.Name = "Label95";
			this.Label95.Size = new System.Drawing.Size(66, 13);
			this.Label95.TabIndex = 24;
			this.Label95.Text = "USA Jgmts:";
			// 
			// Label96
			// 
			this.Label96.AutoSize = true;
			this.Label96.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label96.Location = new System.Drawing.Point(132, 179);
			this.Label96.Name = "Label96";
			this.Label96.Size = new System.Drawing.Size(46, 13);
			this.Label96.TabIndex = 18;
			this.Label96.Text = "Label68";
			// 
			// Label97
			// 
			this.Label97.AutoSize = true;
			this.Label97.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label97.Location = new System.Drawing.Point(12, 145);
			this.Label97.Name = "Label97";
			this.Label97.Size = new System.Drawing.Size(59, 13);
			this.Label97.TabIndex = 17;
			this.Label97.Text = "HOA Lien:";
			// 
			// Label98
			// 
			this.Label98.AutoSize = true;
			this.Label98.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label98.Location = new System.Drawing.Point(132, 145);
			this.Label98.Name = "Label98";
			this.Label98.Size = new System.Drawing.Size(46, 13);
			this.Label98.TabIndex = 16;
			this.Label98.Text = "Label66";
			// 
			// Label99
			// 
			this.Label99.AutoSize = true;
			this.Label99.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label99.Location = new System.Drawing.Point(12, 128);
			this.Label99.Name = "Label99";
			this.Label99.Size = new System.Drawing.Size(107, 13);
			this.Label99.TabIndex = 15;
			this.Label99.Text = "Notice/Commence:";
			// 
			// Label100
			// 
			this.Label100.AutoSize = true;
			this.Label100.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label100.Location = new System.Drawing.Point(132, 128);
			this.Label100.Name = "Label100";
			this.Label100.Size = new System.Drawing.Size(46, 13);
			this.Label100.TabIndex = 14;
			this.Label100.Text = "Label58";
			// 
			// Label101
			// 
			this.Label101.AutoSize = true;
			this.Label101.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label101.Location = new System.Drawing.Point(12, 111);
			this.Label101.Name = "Label101";
			this.Label101.Size = new System.Drawing.Size(64, 13);
			this.Label101.TabIndex = 13;
			this.Label101.Text = "Mech.Lien:";
			// 
			// Label102
			// 
			this.Label102.AutoSize = true;
			this.Label102.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label102.Location = new System.Drawing.Point(132, 111);
			this.Label102.Name = "Label102";
			this.Label102.Size = new System.Drawing.Size(46, 13);
			this.Label102.TabIndex = 12;
			this.Label102.Text = "Label60";
			// 
			// Label103
			// 
			this.Label103.AutoSize = true;
			this.Label103.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label103.Location = new System.Drawing.Point(12, 284);
			this.Label103.Name = "Label103";
			this.Label103.Size = new System.Drawing.Size(65, 13);
			this.Label103.TabIndex = 11;
			this.Label103.Text = "State Jgmt:";
			// 
			// Label104
			// 
			this.Label104.AutoSize = true;
			this.Label104.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label104.Location = new System.Drawing.Point(132, 284);
			this.Label104.Name = "Label104";
			this.Label104.Size = new System.Drawing.Size(46, 13);
			this.Label104.TabIndex = 10;
			this.Label104.Text = "Label62";
			// 
			// Label105
			// 
			this.Label105.AutoSize = true;
			this.Label105.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label105.Location = new System.Drawing.Point(12, 250);
			this.Label105.Name = "Label105";
			this.Label105.Size = new System.Drawing.Size(73, 13);
			this.Label105.TabIndex = 9;
			this.Label105.Text = "Support Obl:";
			// 
			// Label106
			// 
			this.Label106.AutoSize = true;
			this.Label106.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label106.Location = new System.Drawing.Point(132, 250);
			this.Label106.Name = "Label106";
			this.Label106.Size = new System.Drawing.Size(46, 13);
			this.Label106.TabIndex = 8;
			this.Label106.Text = "Label64";
			// 
			// Label107
			// 
			this.Label107.AutoSize = true;
			this.Label107.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label107.Location = new System.Drawing.Point(132, 94);
			this.Label107.Name = "Label107";
			this.Label107.Size = new System.Drawing.Size(46, 13);
			this.Label107.TabIndex = 5;
			this.Label107.Text = "Label54";
			// 
			// Label108
			// 
			this.Label108.AutoSize = true;
			this.Label108.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label108.Location = new System.Drawing.Point(12, 94);
			this.Label108.Name = "Label108";
			this.Label108.Size = new System.Drawing.Size(69, 13);
			this.Label108.TabIndex = 4;
			this.Label108.Text = "LisPendens:";
			// 
			// Label109
			// 
			this.Label109.AutoSize = true;
			this.Label109.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label109.Location = new System.Drawing.Point(132, 26);
			this.Label109.Name = "Label109";
			this.Label109.Size = new System.Drawing.Size(46, 13);
			this.Label109.TabIndex = 3;
			this.Label109.Text = "Label52";
			// 
			// Label110
			// 
			this.Label110.AutoSize = true;
			this.Label110.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label110.Location = new System.Drawing.Point(12, 26);
			this.Label110.Name = "Label110";
			this.Label110.Size = new System.Drawing.Size(45, 13);
			this.Label110.TabIndex = 2;
			this.Label110.Text = "HELOC:";
			// 
			// Label111
			// 
			this.Label111.AutoSize = true;
			this.Label111.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label111.Location = new System.Drawing.Point(132, 9);
			this.Label111.Name = "Label111";
			this.Label111.Size = new System.Drawing.Size(46, 13);
			this.Label111.TabIndex = 1;
			this.Label111.Text = "Label46";
			// 
			// Label112
			// 
			this.Label112.AutoSize = true;
			this.Label112.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label112.Location = new System.Drawing.Point(12, 9);
			this.Label112.Name = "Label112";
			this.Label112.Size = new System.Drawing.Size(59, 13);
			this.Label112.TabIndex = 0;
			this.Label112.Text = "Mtg/DOT:";
			// 
			// Panel2
			// 
			this.Panel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.Panel2.BackColor = System.Drawing.Color.Gainsboro;
			this.Panel2.Location = new System.Drawing.Point(0, 3);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(860, 520);
			this.Panel2.TabIndex = 198;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Honeydew;
			this.ClientSize = new System.Drawing.Size(858, 600);
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.SplitContainer1);
			this.Controls.Add(this.Label56);
			this.Controls.Add(this.LinkLabel4);
			this.Controls.Add(this.Panel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ORB - iMS Online Resource Bank";
			this.SplitContainer1.Panel1.ResumeLayout(false);
			this.SplitContainer1.Panel1.PerformLayout();
			this.SplitContainer1.Panel2.ResumeLayout(false);
			this.SplitContainer1.Panel2.PerformLayout();
			this.SplitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.Panel1.ResumeLayout(false);
			this.Panel1.PerformLayout();
			this.GroupBox6.ResumeLayout(false);
			this.GroupBox10.ResumeLayout(false);
			this.GroupBox10.PerformLayout();
			this.GroupBox8.ResumeLayout(false);
			this.GroupBox8.PerformLayout();
			this.GroupBox7.ResumeLayout(false);
			this.GroupBox7.PerformLayout();
			this.TableLayoutPanel2.ResumeLayout(false);
			this.TableLayoutPanel2.PerformLayout();
			this.GroupBox4.ResumeLayout(false);
			this.GroupBox4.PerformLayout();
			this.GroupBox3.ResumeLayout(false);
			this.GroupBox3.PerformLayout();
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox2.PerformLayout();
			this.TabControl1.ResumeLayout(false);
			this.TabPg4Clearing.ResumeLayout(false);
			this.TabPg4Clearing.PerformLayout();
			this.TableLayoutPanel1.ResumeLayout(false);
			this.TableLayoutPanel1.PerformLayout();
			this.TabPg6OtherLogins.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).EndInit();
			this.TabPg7Taxes.ResumeLayout(false);
			this.TabPg7Taxes.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxExport)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxCopy5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxCopy4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxCopy3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxCopy2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbxCopy1)).EndInit();
			this.TabPg1Statistics.ResumeLayout(false);
			this.TabPg1Statistics.PerformLayout();
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.TabPg2Misc.ResumeLayout(false);
			this.TabPg2Misc.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        private void Label4Tap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chris's credit card is stored in the online draw acct. We add $100 as needed. Searches are $5.95/name, free unlimited page views of images, 50 cents per page printed/saved. Print screen confirmation for Chris's expense report and add the credit card use to spreadsheet on T:\\Drive when renewing draw balance.");
        }

        private void Label4Tap_Hover(object sender, EventArgs e)
        {
            this.Label4Tap.ForeColor = Color.LimeGreen;
            this.Label4Tap.Cursor = Cursors.Hand;
        }

        private void Label4Tap_Leave(object sender, EventArgs e)
        {
            this.Label4Tap.ForeColor = Color.Black;
            this.Label4Tap.Cursor = Cursors.Default;
        }

        private void Label5dtree_Click(object sender, EventArgs e)
        {
            MessageBox.Show("iMS has a contract for use of this account. We pay this by monthly invoices. DocEdge and Datatree are billed on 2 seperate accounts. DocEdge property reports fees vary. Images from either source are $4.95/document.");
        }

        private void Label5dtree_Hover(object sender, EventArgs e)
        {
            this.Label5dtree.ForeColor = Color.LimeGreen;
            this.Label5dtree.Cursor = Cursors.Hand;
        }

        private void Label5dtree_Leave(object sender, EventArgs e)
        {
            this.Label5dtree.ForeColor = Color.Black;
            this.Label5dtree.Cursor = Cursors.Default;
        }

        private void Label6RV_Click(object sender, EventArgs e)
        {
            MessageBox.Show("We pay this account monthly by invoice. Searches are $10/property searched (includes all doc copies).");
        }

        private void Label6RV_Hover(object sender, EventArgs e)
        {
            this.Label6RV.ForeColor = Color.LimeGreen;
            this.Label6RV.Cursor = Cursors.Hand;
        }

        private void Label6RV_Leave(object sender, EventArgs e)
        {
            this.Label6RV.ForeColor = Color.Black;
            this.Label6RV.Cursor = Cursors.Default;
        }

        private void lbl_AbstrSOP_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\Education\\Online Abstracting\\ONLINE ABSTRACTING PROCEDURES.doc");
        }

        private void lbl_BusnPhones_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\Business & Vendor Phone List.xls");
        }

        private void lbl_creditCard_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\Credit Card Usage tracking.xls");
        }

        private void lbl_endorsInfo_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\Education\\ALTA Title Insurance Endorsements.doc");
        }

        private void lblAltaClta_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\ONLINE ABSTRACTING\\_ORB\\ORB_files-dontmoveordelete\\ALTA-CLTA Conversion 2006.doc");
        }

        private void lblDeedPrep_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\Education\\Vesting & Deeds\\Vesting Changes and New Deed Prep.doc");
        }

        private void lblDeedPrep_mouseHover(object sender, EventArgs e)
        {
            this.ToolTip2.SetToolTip(this.lbl_deed_prep, "CLICK TO OPEN");
            this.lbl_deed_prep.ForeColor = Color.MediumPurple;
            this.lbl_deed_prep.Cursor = Cursors.Hand;
        }

        private void lblDeedPrep_mouseLeave(object sender, EventArgs e)
        {
            this.ToolTip2.RemoveAll();
            this.lbl_deed_prep.ForeColor = Color.Black;
            this.lbl_deed_prep.Cursor = Cursors.Default;
        }

        private void lblDeedPrepSOP_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\Education\\Vesting & Deeds\\Vesting Changes and New Deed Prep.doc");
        }

 
        private void lblDocDeeds_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\Education\\Vesting & Deeds\\About Deeds.doc");
        }

         private void lblLeaseFee_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\Education\\Clearance\\Land Contract - Leasehold Property.doc");
        }

         private void lblOpenClearance_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\Title Customers\\TITLE CLEARANCE CUSTOMER SPECIFICS .xls");
        }

        private void lblOpenEtitleWkshare_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\ONLINE ABSTRACTING\\_ORB\\ORB_files-dontmoveordelete\\iMS Title Insurance Workshare Procedures.doc");
        }

         private void lblOpenORT_Wkshare_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\ONLINE ABSTRACTING\\_ORB\\ORB_files-dontmoveordelete\\ortic_workshare_faq.doc");
        }

         private void lblOpenRunSheet_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\ONLINE ABSTRACTING\\_ORB\\ORB_files-dontmoveordelete\\IMS ONLINE ABSTRACT RUN SHEET.doc");
        }

         private void lblOpenTitleProdCustSpecs_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\Title Research & Review\\Typing-Review\\Typing-Review Customer Specifics 7-2008.doc");
        }

        private void lblPOA_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\Education\\Vesting & Deeds\\STEPS TO APPROVE A POWER OF ATTORNEY.doc");
        }

        private void lblSOL_heloc_mouseHover(object sender, EventArgs e)
        {
            this.ToolTip2.SetToolTip(this.lblSOL_Heloc, "Statutes are measured After Maturity Date if stated or after the instrument Recorded Date");
        }

        private void lblSOL_heloc_mouseLeave(object sender, EventArgs e)
        {
            this.ToolTip2.RemoveAll();
        }

        private void lblSOL_Mtg_mouseHover(object sender, EventArgs e)
        {
            this.ToolTip2.SetToolTip(this.lblSOL_Mtg, "Statutes are measured After Maturity Date if stated or after the instrument Recorded Date");
        }

        private void lblSOL_Mtg_mouseLeave(object sender, EventArgs e)
        {
            this.ToolTip2.RemoveAll();
        }

        private void lblVesting_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\Education\\Clearance\\Title Vesting Explained.doc");
        }

        private void LinkLabel_DOI_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.orb_misc.DOI_url.StartsWith("http") | this.orb_misc.DOI_url.StartsWith("www"))
            {
                Process.Start(this.orb_misc.DOI_url);
            }
        }

        private void LinkLabel_MyFla_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.target = "http://myfloridacounties.com/";
            Process.Start(this.target);
        }

        private void LinkLabel_SecState_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.orb_misc.SecretaryState_url.StartsWith("http") | this.orb_misc.SecretaryState_url.StartsWith("www"))
            {
                Process.Start(this.orb_misc.SecretaryState_url);
            }
        }

        private void LinkLabel_StateCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.orb_misc.State_Code_url.StartsWith("http") | this.orb_misc.State_Code_url.StartsWith("www"))
            {
                Process.Start(this.orb_misc.State_Code_url);
            }
        }

        private void LinkLabel_UCC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.orb_obj.ucc_url.StartsWith("http") | this.orb_obj.ucc_url.StartsWith("www"))
            {
                Process.Start(this.orb_obj.ucc_url);
            }
        }

        private void LinkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("www.docedge.com");
        }

        private void LinkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://tapestry.fidlar.com/Splash/Default.aspx");
        }

        private void LinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto://tbaer@imortgageservices.com");
        }

        private void LinkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("www.redvision.com");
        }

        private void LinkLabelAssessor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.orb_obj.assessor_url.StartsWith("http") | this.orb_obj.assessor_url.StartsWith("www"))
            {
                Process.Start(this.orb_obj.assessor_url);
            }
        }

        private void LinkLabelCoHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.orb_obj.county_homepage.StartsWith("http") | this.orb_obj.county_homepage.StartsWith("www"))
            {
                Process.Start(this.orb_obj.county_homepage);
            }
        }

        private void LinkLabelCounty_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.orb_obj.land_url.StartsWith("http") | this.orb_obj.land_url.StartsWith("www"))
            {
                Process.Start(this.orb_obj.land_url);
            }
        }

        private void LinkLabelCourt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.orb_obj.court_url.StartsWith("http") | this.orb_obj.court_url.StartsWith("www"))
            {
                Process.Start(this.orb_obj.court_url);
            }
        }

        private void LinkLabelForeclosure_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.orb_obj.foreclosure_url.StartsWith("http") | this.orb_obj.foreclosure_url.StartsWith("www"))
            {
                Process.Start(this.orb_obj.foreclosure_url);
            }
        }

        private void LinkLabelLocTx1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.mywebs[11].StartsWith("http") | this.mywebs[11].StartsWith("www"))
            {
                Process.Start(this.mywebs[11]);
            }
        }

        private void LinkLabelLocTx2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.mywebs[12].StartsWith("http") | this.mywebs[12].StartsWith("www"))
            {
                Process.Start(this.mywebs[12]);
            }
        }

        private void LinkLabelLocTx3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.mywebs[13].StartsWith("http") | this.mywebs[13].StartsWith("www"))
            {
                Process.Start(this.mywebs[13]);
            }
        }

        private void LinkLabelLocTx4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.mywebs[14].StartsWith("http") | this.mywebs[14].StartsWith("www"))
            {
                Process.Start(this.mywebs[14]);
            }
        }

        private void LinkLabelLocTx5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.mywebs[15].StartsWith("http") | this.mywebs[15].StartsWith("www"))
            {
                Process.Start(this.mywebs[15]);
            }
        }

        private void LinkLabelMaps_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.orb_obj.map_url.StartsWith("http") | this.orb_obj.map_url.StartsWith("www"))
            {
                Process.Start(this.orb_obj.map_url);
            }
        }

        private void LinkLabelOtherTax_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.orb_obj.tax2_url.StartsWith("http") | this.orb_obj.tax2_url.StartsWith("www"))
            {
                Process.Start(this.orb_obj.tax2_url);
            }
        }

        private void LinkLabelPlat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.orb_obj.plat_url.StartsWith("http") | this.orb_obj.plat_url.StartsWith("www"))
            {
                Process.Start(this.orb_obj.plat_url);
            }
        }

        private void LinkLabelPro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.orb_obj.prothon_url.StartsWith("http") | this.orb_obj.prothon_url.StartsWith("www"))
            {
                Process.Start(this.orb_obj.prothon_url);
            }
        }

        private void LinkLabelProbate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.orb_obj.probate_url.StartsWith("http") | this.orb_obj.probate_url.StartsWith("www"))
            {
                Process.Start(this.orb_obj.probate_url);
            }
        }

        private void LinkLabelSheriff_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.orb_obj.sheriff_url.StartsWith("http") | this.orb_obj.sheriff_url.StartsWith("www"))
            {
                Process.Start(this.orb_obj.sheriff_url);
            }
        }

        private void LinkLabelTax_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.orb_obj.tax_url.StartsWith("http") | this.orb_obj.tax_url.StartsWith("www"))
            {
                Process.Start(this.orb_obj.tax_url);
            }
        }

        private void LinkLabelTax2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.orb_obj.muniCourt_url.StartsWith("http") | this.orb_obj.muniCourt_url.StartsWith("www"))
            {
                Process.Start(this.orb_obj.muniCourt_url);
            }
        }

        private void linkUS_Legal_Forms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.target = "http://www.uslegalforms.com/realestate/";
            Process.Start(this.target);
        }

        private void madStat(string st)
        {
			// Get Number of Online Counties
            //int i;
            //string[] text;
            //DataTable dataTable = new DataTable();
            //DataTable dataTable1 = new DataTable();
            //this.cmd.CommandType = CommandType.TableDirect;
            //this.cmd.CommandText = string.Concat("Select * From [", this.sheetNm1, "$] Where st = '", st, "'");
            //this.cmd.Connection = new OleDbConnection(this.dsn);
            //this.da.SelectCommand = this.cmd;
            //this.cmdBuilder.DataAdapter = this.da;
            //this.da.Fill(dataTable);
            //this.da.Dispose();
            //decimal[] numArray = new decimal[11];
            //string[] strArrays = new string[] { null, null, null, null, null, "inhouseCounties", "countyCount", null, null, null, null };
            //int j = 1;
            //for (i = 0; i < 11; i = i + 1)
            //{
            //    numArray[i] = new decimal();
            //}
            //i = 0;
            //j = 1;
            //this.txt_StatsCounties.Text = "";
            //this.txt_StatsTaxOffices.Text = "";
            //while (j < (long)dataTable.Rows.Count)
            //{
            //    if (this.cbox_StatsStates.Text == "ALL" && dataTable.Rows[j]["ins"].ToString() == "Yes" || dataTable.Rows[j]["props"].ToString() == "Yes")
            //    {
            //        numArray[5] = decimal.Add(numArray[5], decimal.One);
            //        text = new string[] { this.txt_StatsCounties.Text, dataTable.Rows[j]["state"].ToString(), " - ", dataTable.Rows[checked((int)j)]["county"].ToString(), "\r\n" };
            //        txt_StatsCounties.Text = string.Concat(text);
            //    }
            //    if (this.cbox_StatsStates.Text == "ALL")
            //    {
            //        numArray[6] = decimal.Add(numArray[6], decimal.One);
            //    }
            //    j = j + 1;
            //}

			Resource_Lookup rsLookup = new Resource_Lookup();
			txt_StatsCounties.Text = rsLookup.GetOnlineResources(st);

    //        this.cmd.CommandType = CommandType.TableDirect;
    //        this.cmd.CommandText = string.Concat("Select * From [", this.sheetNm2, "$] Where st = '", st, "' and payee<>''");
    //        this.cmd.Connection = new OleDbConnection(this.dsn);
    //        this.da.SelectCommand = this.cmd;
    //        this.cmdBuilder.DataAdapter = this.da;
    //        this.da.Fill(dataTable1);
    //        this.da.Dispose();
    //        for (j = 2; j < dataTable1.Rows.Count; j = j + 1)
    //        {
				//numArray[7] = numArray[7] + 1;
				//text = new string[] { this.txt_StatsTaxOffices.Text, dataTable1.Rows[j]["state"].ToString(), " - ", dataTable1.Rows[j]["county"].ToString(), " - ", dataTable1.Rows[j]["tax_auth"].ToString(), "\r\n" };
    //            txt_StatsTaxOffices.Text = string.Concat(text);
    //        }
    //        if (numArray[6] != 0)
    //        {
    //            text = new string[] { "Of ", Conversions.ToString(numArray[6]), " Counties, ", Conversions.ToString(Math.Round(decimal.Multiply(decimal.Divide(numArray[5], numArray[6]), new decimal((long)100)))), " % Online" };
    //            lbl_CoOnlineStats.Text = string.Concat(text);
    //        }
    //        if (this.cbox_StatsStates.Text == "")
    //        {
    //            this.lbl_CoOnlineStats.ResetText();
    //        }
        }

        private void onlineStats()
        {
  /*          int i = 0;
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
            OleDbCommandBuilder oleDbCommandBuilder = new OleDbCommandBuilder();
            OleDbCommand oleDbCommand = new OleDbCommand();
            string str = "T:\\Monthly & Daily Reports\\2008 Vendor Fee Analysis  Subscriptions.xls";
            string str1 = "data_YTD";
            DataTable dataTable = new DataTable();
            string[] strArrays = new string[14];
            oleDbCommand.CommandType = CommandType.TableDirect;
            string str2 = string.Concat("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=", str, ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"");
            oleDbCommand.CommandText = string.Concat("Select * From [", str1, "$]");
            oleDbCommand.Connection = new OleDbConnection(str2);
            oleDbDataAdapter.SelectCommand = oleDbCommand;
            oleDbCommandBuilder.DataAdapter = oleDbDataAdapter;
            dataTable.Clear();
            oleDbDataAdapter.Fill(dataTable);
            oleDbDataAdapter.Dispose();
            while (i < 14)
            {
                strArrays[i] = Conversions.ToString(0);
                i = checked(i + 1);
            }
            for (i = 0; i < dataTable.Rows.Count; i = checked(i + 1))
            {
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[i]["Vendor ID"].ToString(), "134392", false) == 0)
                {
                    strArrays[13] = Conversions.ToString(Conversions.ToDouble(strArrays[13]) + 1);
                    if (Convert.ToDateTime(dataTable.Rows[i]["Date Billed"].ToString()).Month == 1)
                    {
                        strArrays[1] = Conversions.ToString(Conversions.ToDouble(strArrays[1]) + 1);
                    }
                    if (Convert.ToDateTime(dataTable.Rows[i]["Date Billed"].ToString()).Month == 2)
                    {
                        strArrays[2] = Conversions.ToString(Conversions.ToDouble(strArrays[2]) + 1);
                    }
                    if (Convert.ToDateTime(dataTable.Rows[i]["Date Billed"].ToString()).Month == 3)
                    {
                        strArrays[3] = Conversions.ToString(Conversions.ToDouble(strArrays[3]) + 1);
                    }
                    if (Convert.ToDateTime(dataTable.Rows[i]["Date Billed"].ToString()).Month == 4)
                    {
                        strArrays[4] = Conversions.ToString(Conversions.ToDouble(strArrays[4]) + 1);
                    }
                    if (Convert.ToDateTime(dataTable.Rows[i]["Date Billed"].ToString()).Month == 5)
                    {
                        strArrays[5] = Conversions.ToString(Conversions.ToDouble(strArrays[5]) + 1);
                    }
                    if (Convert.ToDateTime(dataTable.Rows[i]["Date Billed"].ToString()).Month == 6)
                    {
                        strArrays[6] = Conversions.ToString(Conversions.ToDouble(strArrays[6]) + 1);
                    }
                    if (Convert.ToDateTime(dataTable.Rows[i]["Date Billed"].ToString()).Month == 7)
                    {
                        strArrays[7] = Conversions.ToString(Conversions.ToDouble(strArrays[7]) + 1);
                    }
                    if (Convert.ToDateTime(dataTable.Rows[i]["Date Billed"].ToString()).Month == 8)
                    {
                        strArrays[8] = Conversions.ToString(Conversions.ToDouble(strArrays[8]) + 1);
                    }
                    if (Convert.ToDateTime(dataTable.Rows[i]["Date Billed"].ToString()).Month == 9)
                    {
                        strArrays[9] = Conversions.ToString(Conversions.ToDouble(strArrays[9]) + 1);
                    }
                    if (Convert.ToDateTime(dataTable.Rows[i]["Date Billed"].ToString()).Month == 10)
                    {
                        strArrays[10] = Conversions.ToString(Conversions.ToDouble(strArrays[10]) + 1);
                    }
                    if (Convert.ToDateTime(dataTable.Rows[i]["Date Billed"].ToString()).Month == 11)
                    {
                        strArrays[11] = Conversions.ToString(Conversions.ToDouble(strArrays[11]) + 1);
                    }
                    if (Convert.ToDateTime(dataTable.Rows[i]["Date Billed"].ToString()).Month == 12)
                    {
                        strArrays[12] = Conversions.ToString(Conversions.ToDouble(strArrays[12]) + 1);
                    }
                }
            }
            this.lbl_vstats_YTD.Text = string.Concat("YTD Searches Completed: ", strArrays[13]);
            this.lbl_vstats_Jan.Text = string.Concat("Jan: ", strArrays[1]);
            this.lbl_vstats_Feb.Text = string.Concat("Feb: ", strArrays[2]);
            this.lbl_vstats_Mar.Text = string.Concat("Mar: ", strArrays[3]);
            this.lbl_vstats_Apr.Text = string.Concat("Apr: ", strArrays[4]);
            this.lbl_vstats_May.Text = string.Concat("May: ", strArrays[5]);
            this.lbl_vstats_Jun.Text = string.Concat("Jun: ", strArrays[6]);
            this.lbl_vstats_Jul.Text = string.Concat("Jul: ", strArrays[7]);
            this.lbl_vstats_Aug.Text = string.Concat("Aug: ", strArrays[8]);
            this.lbl_vstats_Sep.Text = string.Concat("Sep: ", strArrays[9]);
            this.lbl_vstats_Oct.Text = string.Concat("Oct: ", strArrays[10]);
            this.lbl_vstats_Nov.Text = string.Concat("Nov: ", strArrays[11]);
            this.lbl_vstats_Dec.Text = string.Concat("Dec: ", strArrays[12]);*/
        }

        private void pboxAbstr_SOP_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\Education\\Online Abstracting\\ONLINE ABSTRACTING PROCEDURES.doc");
        }

        private void pboxCopy1_MouseClick(object sender, MouseEventArgs e)
        {
            string str = string.Concat(this.lblTxAuth1.Text, "\r\n", this.txtTaxOffice1.Text, "\r\n");
            Clipboard.SetDataObject(str);
        }

        private void pboxCopy3_MouseClick(object sender, MouseEventArgs e)
        {
            Clipboard.SetDataObject(this.txtTaxOffice3.Text);
        }

        private void pboxCopy4_MouseClick(object sender, MouseEventArgs e)
        {
            Clipboard.SetDataObject(this.txtTaxOffice4.Text);
        }

        private void pboxCopy5_MouseClick(object sender, MouseEventArgs e)
        {
            Clipboard.SetDataObject(this.txtTaxOffice5.Text);
        }

        private void pboxOpenClearance_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\Title Customers\\TITLE CLEARANCE CUSTOMER SPECIFICS .xls");
        }

        private void pboxOpenCredCard_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\Credit Card Usage tracking.xls");
        }

         private void pboxOpenEtitleWkshare_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\ONLINE ABSTRACTING\\_ORB\\ORB_files-dontmoveordelete\\iMS Title Insurance Workshare Procedures.doc");
        }

        private void pboxOpenORT_Wkshare_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\ONLINE ABSTRACTING\\_ORB\\ORB_files-dontmoveordelete\\ortic_workshare_faq.doc");
        }

        private void pboxOpenRunSheet_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\ONLINE ABSTRACTING\\_ORB\\ORB_files-dontmoveordelete\\IMS ONLINE ABSTRACT RUN SHEET.doc");
        }

        private void pboxOpenTitleProdSpecs_Click(object sender, EventArgs e)
        {
            Process.Start("T:\\Title Research & Review\\Typing-Review\\Typing-Review Customer Specifics 7-2008.doc");
        }

        private void pbxCopy2_Mouseclick(object sender, MouseEventArgs e)
        {
            Clipboard.SetDataObject(this.txtTaxOffice2.Text);
        }

        private void pbxExport_Click(object sender, EventArgs e)
        {
            string str = "";
            string[] text = new string[] { this.txtTaxOffice1.Text, "\r\n\r\n", this.txtTaxOffice2.Text, "\r\n\r\n", this.txtTaxOffice3.Text, "\r\n\r\n", this.txtTaxOffice4.Text, "\r\n\r\n", this.txtTaxOffice5.Text };
            str = string.Concat(text);
            Clipboard.SetDataObject(str);
            Process.Start("T:\\ONLINE ABSTRACTING\\_ORB\\ORB_files-dontmoveordelete\\tax_sheet.doc");
            StreamWriter streamWriter = File.CreateText("T:\\ONLINE ABSTRACTING\\_ORB\\ORB_files-dontmoveordelete\\tax_sheet.doc");
            streamWriter.WriteLine(str);
            streamWriter.Flush();
            streamWriter.Close();
            Process.Start("T:\\ONLINE ABSTRACTING\\_ORB\\ORB_files-dontmoveordelete\\tax_sheet.doc");
        }

        private void resetVis()
        {
            this.lbl_attyState.Visible = false;
            this.Panel2.Visible = false;
            this.LinkLabelCounty.Visible = false;
            this.LinkLabel_MyFlCountiesURL.Visible = false;
            this.lbl_MyFlaCounties.Visible = false;
            this.LabelCountyURL.Visible = false;
            this.LinkLabelCourt.Visible = false;
            this.LabelCourt.Visible = false;
            this.LinkLabelTax.Visible = false;
            this.LabelCountyTax.Visible = false;
            this.LinkLabelMaps.Visible = false;
            this.LabelMapsGIS.Visible = false;
            this.LinkLabelProthon.Visible = false;
            this.LabelProthon.Visible = false;
            this.LinkLabelAssessor.Visible = false;
            this.LabelAssessor.Visible = false;
            this.LinkLabelProbate.Visible = false;
            this.LabelProbate.Visible = false;
            this.LinkLabelCoHome.Visible = false;
            this.LabelCountyHome.Visible = false;
            this.LinkLabelPlats.Visible = false;
            this.LinkLabelForeclosure.Visible = false;
            this.LabelForeclosures.Visible = false;
            this.LinkLabelOtherTax.Visible = false;
            this.LabelOtherTax.Visible = false;
            this.LinkLabel_OtherURL.Visible = false;
            this.LabelOtherURL.Visible = false;
            this.LinkLabelMuniCourt.Visible = false;
            this.LabelMuniCourt.Visible = false;
            this.LinkLabelSheriff.Visible = false;
            this.LabelSheriff.Visible = false;
            this.txtComments.Visible = false;
            this.Label_user.Visible = false;
            this.Label_pwd.Visible = false;
            this.txt_login_landP.Visible = false;
            this.txt_login_landU.Visible = false;
            this.txt_myfl_U.Visible = false;
            this.txt_myfl_P.Visible = false;
            this.txt_login_courtU.Visible = false;
            this.txt_login_courtP.Visible = false;
            this.txt_login_tax1U.Visible = false;
            this.txt_login_tax1P.Visible = false;
            this.txt_login_prothonU.Visible = false;
            this.txt_login_prothonP.Visible = false;
            this.txt_login_tax2U.Visible = false;
            this.txt_login_tax2P.Visible = false;
            this.txt_login_probateU.Visible = false;
            this.txt_login_probateP.Visible = false;
            this.txt_login_muniU.Visible = false;
            this.txt_login_muniP.Visible = false;
            this.txt_login_asrU.Visible = false;
            this.txt_login_asrP.Visible = false;
            this.txt_login_otherU.Visible = false;
            this.txt_login_otherP.Visible = false;
            this.txtTaxOffice1.Visible = false;
            this.txtTaxOffice2.Visible = false;
            this.txtTaxOffice3.Visible = false;
            this.txtTaxOffice4.Visible = false;
            this.txtTaxOffice5.Visible = false;
            this.lblTxAuth1.Visible = false;
            this.lblTxAuth2.Visible = false;
            this.lblTxAuth3.Visible = false;
            this.lblTxAuth4.Visible = false;
            this.lblTxAuth5.Visible = false;
            this.linkLocTax1.Visible = false;
            this.linkLocTax2.Visible = false;
            this.linkLocTax3.Visible = false;
            this.linkLocTax4.Visible = false;
            this.linkLocTax5.Visible = false;
            this.pbxCopy1.Visible = false;
            this.pbxCopy2.Visible = false;
            this.pbxCopy3.Visible = false;
            this.pbxCopy4.Visible = false;
            this.pbxCopy5.Visible = false;
            this.lbl_verifDate1.Visible = false;
            this.lbl_verifDate2.Visible = false;
            this.lbl_verifDate3.Visible = false;
            this.lbl_verifDate4.Visible = false;
            this.lbl_verifDate5.Visible = false;
            this.lbl_verified_taxoff1.Visible = false;
            this.lbl_verified_taxoff2.Visible = false;
            this.lbl_verified_taxoff3.Visible = false;
            this.lbl_verified_taxoff4.Visible = false;
            this.lbl_verified_taxoff5.Visible = false;
            this.LabelUseTap.Visible = false;
            this.LabelUseRV.Visible = false;
            this.LabelUseDtree.Visible = false;
            this.lblSOL_Mtg.Visible = false;
            this.Label_mtg.Visible = false;
            this.lblSOL_Heloc.Visible = false;
            this.Label_heloc.Visible = false;
            this.lblSOL_Mech.Visible = false;
            this.Label_mechLien.Visible = false;
            this.lblSOL_Notice.Visible = false;
            this.Label_NOC.Visible = false;
            this.lblSOL_lispen.Visible = false;
            this.Label_lisPendens.Visible = false;
            this.lblSOL_HOA.Visible = false;
            this.Label_HOA.Visible = false;
            this.lblSOL_Hosp.Visible = false;
            this.Label_hospLien.Visible = false;
            this.lblSOL_ClaimLien.Visible = false;
            this.Label_claimLien.Visible = false;
            this.lblSOL_Jgmt.Visible = false;
            this.Label_jgmt.Visible = false;
            this.lblSOL_Support.Visible = false;
            this.Label_support.Visible = false;
            this.lblSOL_StateJgmt.Visible = false;
            this.Label_stateJgmt.Visible = false;
            this.lblSOL_AftAcq.Visible = false;
            this.Label_aftacq.Visible = false;
            this.lblSOL_TERule.Visible = false;
            this.Label_teRule.Visible = false;
            this.lblSOL_Creditor_Claims.Visible = false;
            this.Label_credclaim.Visible = false;
            this.lblSOL_PersTax.Visible = false;
            this.Label_persTax.Visible = false;
            this.lblSOL_Tax_RedemPer.Visible = false;
            this.Label_taxTakRedem.Visible = false;
            this.lblSOL_forecl_redem_per.Visible = false;
            this.Label_forclRedem.Visible = false;
            this.lblSOL_Spousal.Visible = false;
            this.Label_spousal.Visible = false;
            this.txtSOL_notes.Visible = false;
            this.Label_statutecomments.Visible = false;
            this.txt_foreclosure_notes.Visible = false;
            this.Label_fc.Visible = false;
            this.txt_ProbateInfo.Visible = false;
            this.Label_probate.Visible = false;
            this.lblSOL_being_Clause.Visible = false;
            this.LinkLabel_DeptIns.Visible = false;
            this.Label_DOI.Visible = false;
            this.LinkLabel_SecState.Visible = false;
            this.Label_secState.Visible = false;
            this.LinkLabel_State_Code.Visible = false;
            this.Label_stCode.Visible = false;
            this.LinkLabel_UCC.Visible = false;
            this.LabelUCC.Visible = false;
            this.LabelCopy_source.ResetText();
            this.LabelIndex_source.ResetText();
            this.LabelImage_date.ResetText();
            this.LabelIndex_date.ResetText();
            this.LabelCopyPmtType.ResetText();
            this.lbl_copyFeeAmt.ResetText();
            this.lbl_courtIndexDate.ResetText();
            this.lbl_courtImgDate.ResetText();
            this.LabelSubNeeded.ResetText();
            this.lbl_Free.ResetText();
            this.lbl_WeSubscribe.ResetText();
            this.lbl_SubTerm.ResetText();
            this.lbl_IndexPmtMethod.ResetText();
            this.lbl_IndexFeeAmt.ResetText();
            this.LabelUseIns.ResetText();
            this.LabelUseProps.ResetText();
            this.LabelUseCopy.ResetText();
            this.lbl_CoOnlineStats.ResetText();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {
            long i;
            this.onlineStats();
         //   this.txt_StatsCounties.Text = "";
         //+   this.madStat(this.ComboBoxState.Text);
            this.cbox_StatsStates.Text = this.ComboBoxState.Text;
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(this.ComboBoxState.Text, "", false) != 0)
            {
                DataTable dataTable = new DataTable();
                DataTable dataTable1 = new DataTable();
                this.cmd.CommandType = CommandType.TableDirect;
                this.cmd.CommandText = string.Concat("Select * From [", this.sheetNm1, "$]");
                this.cmd.Connection = new OleDbConnection(this.dsn);
                this.da.SelectCommand = this.cmd;
                this.cmdBuilder.DataAdapter = this.da;
                this.da.Fill(dataTable);
                this.da.Dispose();
                decimal[] numArray = new decimal[11];
                string[] strArrays = new string[] { "land_url", "inHouse", "courts", "taxes", "txOffc", "inhouseCounties", "countyCount", "taxCount", "taxesOnline", null, null };
                long j = (long)1;
                for (i = (long)0; i < (long)11; i = checked(i + (long)1))
                {
                    numArray[checked((int)i)] = new decimal();
                }
                i = (long)0;
                for (j = (long)1; j < (long)dataTable.Rows.Count; j = checked(j + (long)1))
                {
                    if (dataTable.Rows[checked((int)j)]["land_url"].ToString().StartsWith("www") | dataTable.Rows[checked((int)j)]["land_url"].ToString().StartsWith("http"))
                    {
                        numArray[0] = decimal.Add(numArray[0], decimal.One);
                    }
                    if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[checked((int)j)]["ins"].ToString(), "Yes", false) == 0 | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable.Rows[checked((int)j)]["props"].ToString(), "Yes", false) == 0)
                    {
                        numArray[1] = decimal.Add(numArray[1], decimal.One);
                    }
                    if (dataTable.Rows[checked((int)j)]["court_url"].ToString().StartsWith("www") | dataTable.Rows[checked((int)j)]["court_url"].ToString().StartsWith("http"))
                    {
                        numArray[2] = decimal.Add(numArray[2], decimal.One);
                    }
                    if (dataTable.Rows[checked((int)j)]["tax_url"].ToString().StartsWith("www") | dataTable.Rows[checked((int)j)]["tax_url"].ToString().StartsWith("http"))
                    {
                        numArray[3] = decimal.Add(numArray[3], decimal.One);
                    }
                }
                this.lbl_OrbStat1.Text = string.Concat(Conversions.ToString(numArray[0]), " or ", Conversions.ToString(Math.Round(decimal.Multiply(decimal.Divide(numArray[0], new decimal(checked(j - (long)1))), new decimal((long)100)))), " %");
                this.lbl_OrbStat2.Text = string.Concat(Conversions.ToString(numArray[1]), " or ", Conversions.ToString(Math.Round(decimal.Multiply(decimal.Divide(numArray[1], new decimal(checked(j - (long)1))), new decimal((long)100)))), " %");
                this.lbl_OrbStat3.Text = string.Concat(Conversions.ToString(numArray[2]), " or ", Conversions.ToString(Math.Round(decimal.Multiply(decimal.Divide(numArray[2], new decimal(checked(j - (long)1))), new decimal((long)100)))), " %");
                this.lbl_OrbStat4.Text = string.Concat(Conversions.ToString(numArray[3]), " or ", Conversions.ToString(Math.Round(decimal.Multiply(decimal.Divide(numArray[3], new decimal(checked(j - (long)1))), new decimal((long)100)))), " %");
                this.cmd.CommandType = CommandType.TableDirect;
                this.cmd.CommandText = string.Concat("Select * From [", this.sheetNm2, "$]");
                this.cmd.Connection = new OleDbConnection(this.dsn);
                this.da.SelectCommand = this.cmd;
                this.cmdBuilder.DataAdapter = this.da;
                this.da.Fill(dataTable1);
                this.da.Dispose();
                for (i = (long)1; i < (long)dataTable1.Rows.Count; i = checked(i + (long)1))
                {
                    if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(dataTable1.Rows[checked((int)i)]["payee"].ToString(), null, false) != 0)
                    {
                        numArray[4] = decimal.Add(numArray[4], decimal.One);
                    }
                }
                this.lbl_OrbStats.Text = Conversions.ToString(dataTable.Rows.Count);
                this.lbl_OrbStat5.Text = string.Concat(Conversions.ToString(numArray[4]), " or ", Conversions.ToString(Math.Round(decimal.Multiply(decimal.Divide(numArray[4], new decimal(checked(i - (long)1))), new decimal((long)100)))), " %");
                this.lbl_OrbStat6.Text = Conversions.ToString(dataTable1.Rows.Count);
            }
        }

 
    }
}
