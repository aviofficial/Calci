using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator.Lib;
using System.Reflection;
using System.Resources;
namespace Calculator.Win
{
    public partial class Calci : Form
    {
        #region Declarations
        private string Ans="0";
        private System.Windows.Forms.MenuStrip topMenuStrip;
        private ToolStripMenuItem menuItemHelp;
        private ToolStripMenuItem menuItemEdit;
        private ToolStripMenuItem menuItemExit;
        private ToolStripMenuItem menuItemCopy;
        private ToolStripMenuItem menuItemPaste;
        private ToolStripMenuItem menuItemCut;
        private SplitContainer containerMain;
        private Button btnEquals;
        private Button btnPlus;
        private Button btnMinus;
        private Button btnMultiply;
        private Button btnDivide;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btn0;
        private Button btnClosingBraces;
        private Button btnOpeningBraces;
        private Button btnSign;
        private Button btnBackspace;
        private Button btnDecimal;
        private Button btnTan;
        private Button btnLog;
        private Button btnCos;
        private Button btnSin;
        private Button btnSinIn;
        private Button btnTanIn;
        private Button btnCosIn;
        private Button btnLn;
        private Button btnRcpl;
        private Button btnSquare;
        private Button btnCube;
        private Button btnPower;
        private Button btnSqrRoot;
        private Button btnCubeRoot;
        private Button btnRoot;
        private Button btnMR;
        private Button btnM_Add;
        private Button btnM_Sub;
        private Button btnMS;
        private Button btnMC;
        private Button btnClear;
        private Button btnAns;
        private Button btnPercent;
        private Button btnMod;
        private Label lblLogo;
        private TextBox txtMain;
        private Double storedWord;
        ToolTip toolTip;
        public double StoredWord{
            get {
                return (storedWord);
            }
            set {
                storedWord = value;
            }
        }
        #endregion

        public Calci()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Calci_Load);
        }

        public void Calci_Load(object sender, EventArgs e) {
            #region Initialization of Controls
            this.topMenuStrip = new MenuStrip();
            this.menuItemHelp = new ToolStripMenuItem();
            this.menuItemEdit = new ToolStripMenuItem();
            this.menuItemExit = new ToolStripMenuItem();
            this.menuItemCopy = new ToolStripMenuItem();
            this.menuItemCut = new ToolStripMenuItem();
            this.menuItemPaste = new ToolStripMenuItem();
            this.containerMain = new SplitContainer();
            this.txtMain = new TextBox();
            this.btnEquals = new Button();
            this.btnPlus = new Button();
            this.btnMinus = new Button();
            this.btnMultiply = new Button();
            this.btnDivide = new Button();
            this.btn1 = new Button();
            this.btn2 = new Button();
            this.btn3 = new Button();
            this.btn4 = new Button();
            this.btn5 = new Button();
            this.btn6 = new Button();
            this.btn7 = new Button();
            this.btn8 = new Button();
            this.btn9 = new Button();
            this.btn0 = new Button();
            this.btnSin = new Button();
            this.btnCos = new Button();
            this.btnTan = new Button();
            this.btnCosIn = new Button();
            this.btnSinIn = new Button();
            this.btnTanIn = new Button();
            this.btnLog = new Button();
            this.btnLn = new Button();
            this.btnRcpl = new Button();
            this.btnSquare = new Button();
            this.btnCube = new Button();
            this.btnPower = new Button();
            this.btnSqrRoot = new Button();
            this.btnCubeRoot = new Button();
            this.btnRoot = new Button();
            this.btnClosingBraces = new Button();
            this.btnOpeningBraces = new Button();
            this.btnSign = new Button();
            this.btnBackspace = new Button();
            this.btnDecimal = new Button();
            this.btnMC = new Button();
            this.btnMR = new Button();
            this.btnM_Add = new Button();
            this.btnM_Sub = new Button();
            this.btnMS = new Button();
            this.btnPercent = new Button();
            this.btnClear = new Button();
            this.btnAns = new Button();
            this.btnMod = new Button();
            this.toolTip = new ToolTip();
            this.lblLogo = new Label();
            #endregion
            this.SuspendLayout();

            #region Menu Strip and its Controls
            //menu
            this.topMenuStrip.Name = "topMenu";
            this.topMenuStrip.Items.AddRange(new ToolStripMenuItem[] { this.menuItemEdit, this.menuItemExit, this.menuItemHelp });
            this.topMenuStrip.ShowItemToolTips = true;
            //Help Menu
            this.menuItemHelp.Name = "HelpMenu";
            this.menuItemHelp.Text = "Help";
            this.menuItemHelp.Click += new System.EventHandler(this.menuItemHelp_Click);
            this.menuItemHelp.ToolTipText = "Help";
            //Edit Menu
            this.menuItemEdit.Name = "EditMenu";
            this.menuItemEdit.Text = "Edit";
            this.menuItemEdit.DropDownItems.AddRange(new ToolStripMenuItem[] { this.menuItemCut, this.menuItemCopy, this.menuItemPaste });
            this.menuItemEdit.ToolTipText = "Cut,Copy,Paste";
            //Copy
            this.menuItemCopy.Name = "Copy";
            this.menuItemCopy.Text = "Copy";
            this.menuItemCopy.Click += new System.EventHandler(this.menuItemCopyCut_Click);
            this.menuItemCopy.ShortcutKeys = Keys.Control | Keys.C;
            this.menuItemCopy.ToolTipText = toolTipText("Copy");
            //Cut
            this.menuItemCut.Name = "Cut";
            this.menuItemCut.Text = "Cut";
            this.menuItemCut.Click += new System.EventHandler(this.menuItemCopyCut_Click);
            this.menuItemCut.ShortcutKeys = Keys.Control | Keys.X;
            this.menuItemCut.ToolTipText = toolTipText("Cut");
            //Paste
            this.menuItemPaste.Name = "Paste";
            this.menuItemPaste.Text = "Paste";
            this.menuItemPaste.ShortcutKeys = Keys.Control | Keys.V;
            this.menuItemPaste.Click += new System.EventHandler(this.menuItemPaste_Click);
            this.menuItemPaste.ToolTipText = toolTipText("Paste");
            //ExitMenuItem
            this.menuItemExit.Name = "ExitMenuItem";
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.ToolTipText = "Exit the Application";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            #endregion


            //Main Container
            this.containerMain.Orientation = Orientation.Horizontal;
            this.containerMain.Dock = DockStyle.Fill;
            this.containerMain.Size = new System.Drawing.Size(600, 500);
            this.containerMain.SplitterWidth = 1;
            this.containerMain.SplitterDistance = System.Convert.ToInt32(120);
            //textbox Main
            this.txtMain.Name = "MainLabel";
            this.txtMain.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            this.txtMain.TabIndex = 0;
            this.txtMain.Location = new System.Drawing.Point(40, 45);
            this.txtMain.Size = new System.Drawing.Size(600, 50);
            this.txtMain.BorderStyle = BorderStyle.None;
            this.txtMain.ReadOnly = true;
            this.txtMain.ScrollBars = ScrollBars.Horizontal;
            this.txtMain.ForeColor = System.Drawing.Color.White;
            this.txtMain.BackColor = System.Drawing.Color.Black;
            this.txtMain.Font = new System.Drawing.Font("Arial", 20, System.Drawing.FontStyle.Bold);
            this.txtMain.TextAlign = HorizontalAlignment.Right;

            //upper panel
            this.containerMain.Panel1.BackColor = System.Drawing.Color.Black;
            this.containerMain.Panel1.Controls.Add(this.txtMain);
            //label logo
            this.lblLogo.Text = "Calculator";
            this.toolTip.SetToolTip(this.lblLogo, "Calculator Apllication");
            this.lblLogo.Location = new System.Drawing.Point(90, 137);
            this.lblLogo.Size = new System.Drawing.Size(150, 50);
            this.lblLogo.Font = new System.Drawing.Font("Chiller", 30);
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            #region Buttons
            //button equals
            this.btnEquals.Text = "=";
            this.btnEquals.Size = new System.Drawing.Size(50, 40);
            this.btnEquals.Location = new System.Drawing.Point(650, 240);
            this.btnEquals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEquals.Click += new System.EventHandler(this.btnEquals_Click);
            this.btnEquals.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnEquals.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button +
            this.btnPlus.Text = "+";
            this.btnPlus.Size = new System.Drawing.Size(50, 40);
            this.btnPlus.Location = new System.Drawing.Point(650, 190);
            this.btnPlus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPlus.Click += new System.EventHandler(this.btnNumAndBasic_Click);
            this.btnPlus.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnPlus.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button -
            this.btnMinus.Text = "-";
            this.btnMinus.Size = new System.Drawing.Size(50, 40);
            this.btnMinus.Location = new System.Drawing.Point(650, 140);
            this.btnMinus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMinus.Click += new System.EventHandler(this.btnNumAndBasic_Click);
            this.btnMinus.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnMinus.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button x
            this.btnMultiply.Text = "\u00D7";
            this.btnMultiply.Size = new System.Drawing.Size(50, 40);
            this.btnMultiply.Location = new System.Drawing.Point(650, 90);
            this.btnMultiply.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMultiply.Click += new System.EventHandler(this.btnNumAndBasic_Click);
            this.btnMultiply.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnMultiply.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button /
            this.btnDivide.Text = "\u00F7";
            this.btnDivide.Size = new System.Drawing.Size(50, 40);
            this.btnDivide.Location = new System.Drawing.Point(650, 40);
            this.btnDivide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDivide.Click += new System.EventHandler(this.btnNumAndBasic_Click);
            this.btnDivide.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnDivide.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button backspace
            this.btnBackspace.Text = "\u232B";
            this.btnBackspace.Size = new System.Drawing.Size(50, 40);
            this.btnBackspace.Location = new System.Drawing.Point(590, 40);
            this.btnBackspace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBackspace.Click += new System.EventHandler(this.btnBackspace_Click);
            this.btnBackspace.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnBackspace.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button decimal
            this.btnDecimal.Text = ".";
            this.btnDecimal.Size = new System.Drawing.Size(50, 40);
            this.btnDecimal.Location = new System.Drawing.Point(590, 240);
            this.btnDecimal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDecimal.Click += new System.EventHandler(this.btnNumAndBasic_Click);
            this.btnDecimal.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnDecimal.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button 3
            this.btn3.Text = "3";
            this.btn3.Size = new System.Drawing.Size(50, 40);
            this.btn3.Location = new System.Drawing.Point(590, 190);
            this.btn3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn3.Click += new System.EventHandler(this.btnNumAndBasic_Click);
            this.btn3.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btn3.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button 6
            this.btn6.Text = "6";
            this.btn6.Size = new System.Drawing.Size(50, 40);
            this.btn6.Location = new System.Drawing.Point(590, 140);
            this.btn6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn6.Click += new System.EventHandler(this.btnNumAndBasic_Click);
            this.btn6.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btn6.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button 9
            this.btn9.Text = "9";
            this.btn9.Size = new System.Drawing.Size(50, 40);
            this.btn9.Location = new System.Drawing.Point(590, 90);
            this.btn9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn9.Click += new System.EventHandler(this.btnNumAndBasic_Click);
            this.btn9.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btn9.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button 0
            this.btn0.Text = "0";
            this.btn0.Size = new System.Drawing.Size(50, 40);
            this.btn0.Location = new System.Drawing.Point(530, 240);
            this.btn0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn0.Click += new System.EventHandler(this.btnNumAndBasic_Click);
            this.btn0.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btn0.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button 2
            this.btn2.Text = "2";
            this.btn2.Size = new System.Drawing.Size(50, 40);
            this.btn2.Location = new System.Drawing.Point(530, 190);
            this.btn2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn2.Click += new System.EventHandler(this.btnNumAndBasic_Click);
            this.btn2.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btn2.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button 5
            this.btn5.Text = "5";
            this.btn5.Size = new System.Drawing.Size(50, 40);
            this.btn5.Location = new System.Drawing.Point(530, 140);
            this.btn5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn5.Click += new System.EventHandler(this.btnNumAndBasic_Click);
            this.btn5.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btn5.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button 8
            this.btn8.Text = "8";
            this.btn8.Size = new System.Drawing.Size(50, 40);
            this.btn8.Location = new System.Drawing.Point(530, 90);
            this.btn8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn8.Click += new System.EventHandler(this.btnNumAndBasic_Click);
            this.btn8.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btn8.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button )
            this.btnClosingBraces.Text = ")";
            this.btnClosingBraces.Size = new System.Drawing.Size(50, 40);
            this.btnClosingBraces.Location = new System.Drawing.Point(530, 40);
            this.btnClosingBraces.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClosingBraces.Click += new System.EventHandler(this.btnNumAndBasic_Click);
            this.btnClosingBraces.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnClosingBraces.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button sign
            this.btnSign.Text = "\u00B1";
            this.btnSign.Size = new System.Drawing.Size(50, 40);
            this.btnSign.Location = new System.Drawing.Point(470, 240);
            this.btnSign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            this.btnSign.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnSign.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button 1
            this.btn1.Text = "1";
            this.btn1.Size = new System.Drawing.Size(50, 40);
            this.btn1.Location = new System.Drawing.Point(470, 190);
            this.btn1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn1.Click += new System.EventHandler(this.btnNumAndBasic_Click);
            this.btn1.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btn1.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button 4
            this.btn4.Text = "4";
            this.btn4.Size = new System.Drawing.Size(50, 40);
            this.btn4.Location = new System.Drawing.Point(470, 140);
            this.btn4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn4.Click += new System.EventHandler(this.btnNumAndBasic_Click);
            this.btn4.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btn4.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button 7
            this.btn7.Text = "7";
            this.btn7.Size = new System.Drawing.Size(50, 40);
            this.btn7.Location = new System.Drawing.Point(470, 90);
            this.btn7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn7.Click += new System.EventHandler(this.btnNumAndBasic_Click);
            this.btn7.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btn7.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button (
            this.btnOpeningBraces.Text = "(";
            this.btnOpeningBraces.Size = new System.Drawing.Size(50, 40);
            this.btnOpeningBraces.Location = new System.Drawing.Point(470, 40);
            this.btnOpeningBraces.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOpeningBraces.Click += new System.EventHandler(this.btnNumAndBasic_Click);
            this.btnOpeningBraces.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnOpeningBraces.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);

            //button root
            this.btnRoot.Text = "\u207f\u221Ax";
            this.btnRoot.Size = new System.Drawing.Size(60, 40);
            this.btnRoot.Location = new System.Drawing.Point(370, 240);
            this.btnRoot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRoot.Click += new System.EventHandler(this.btnRoot_Click);
            this.btnRoot.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnRoot.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button power
            this.btnPower.Text = "^";
            this.btnPower.Size = new System.Drawing.Size(60, 40);
            this.btnPower.Location = new System.Drawing.Point(370, 190);
            this.btnPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPower.Click += new System.EventHandler(this.btnWithBraces_Click);
            this.btnPower.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnPower.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button reciprocal
            this.btnRcpl.Text = "1/x";
            this.btnRcpl.Size = new System.Drawing.Size(60, 40);
            this.btnRcpl.Location = new System.Drawing.Point(370, 140);
            this.btnRcpl.Font = new System.Drawing.Font("Arial", 10);
            this.btnRcpl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRcpl.Click += new System.EventHandler(this.btnRcpl_Click);
            this.btnRcpl.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnRcpl.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button tanin
            this.btnTanIn.Text = "tan\u207B\u00B9";
            this.btnTanIn.Size = new System.Drawing.Size(60, 40);
            this.btnTanIn.Location = new System.Drawing.Point(370, 90);
            this.btnTanIn.Font = new System.Drawing.Font("Arial", 15);
            this.btnTanIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTanIn.Click += new System.EventHandler(this.btnWithBraces_Click);
            this.btnTanIn.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnTanIn.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button tan
            this.btnTan.Text = "tan";
            this.btnTan.Size = new System.Drawing.Size(60, 40);
            this.btnTan.Location = new System.Drawing.Point(370, 40);
            this.btnTan.Font = new System.Drawing.Font("Arial", 15);
            this.btnTan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTan.Click += new System.EventHandler(this.btnWithBraces_Click);
            this.btnTan.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnTan.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button CubeRoot
            this.btnCubeRoot.Text = "\u221B";
            this.btnCubeRoot.Size = new System.Drawing.Size(60, 40);
            this.btnCubeRoot.Location = new System.Drawing.Point(300, 240);
            this.btnCubeRoot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCubeRoot.Click += new System.EventHandler(this.btnWithBraces_Click);
            this.btnCubeRoot.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnCubeRoot.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button cube
            this.btnCube.Text = "x\u00B3";
            this.btnCube.Size = new System.Drawing.Size(60, 40);
            this.btnCube.Location = new System.Drawing.Point(300, 190);
            this.btnCube.Font = new System.Drawing.Font("Arial", 15);
            this.btnCube.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCube.Click += new System.EventHandler(this.btnCube_Click);
            this.btnCube.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnCube.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button ln
            this.btnLn.Text = "Ln";
            this.btnLn.Size = new System.Drawing.Size(60, 40);
            this.btnLn.Location = new System.Drawing.Point(300, 140);
            this.btnLn.Font = new System.Drawing.Font("Arial", 15);
            this.btnLn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLn.Click += new System.EventHandler(this.btnWithBraces_Click);
            this.btnLn.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnLn.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button Cosin
            this.btnCosIn.Text = "cos\u207B\u00B9";
            this.btnCosIn.Size = new System.Drawing.Size(60, 40);
            this.btnCosIn.Location = new System.Drawing.Point(300, 90);
            this.btnCosIn.Font = new System.Drawing.Font("Arial", 12);
            this.btnCosIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCosIn.Click += new System.EventHandler(this.btnWithBraces_Click);
            this.btnCosIn.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnCosIn.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button cos
            this.btnCos.Text = "cos";
            this.btnCos.Size = new System.Drawing.Size(60, 40);
            this.btnCos.Location = new System.Drawing.Point(300, 40);
            this.btnCos.Font = new System.Drawing.Font("Arial", 15);
            this.btnCos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCos.Click += new System.EventHandler(this.btnWithBraces_Click);
            this.btnCos.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnCos.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button SqrRoot
            this.btnSqrRoot.Text = "\u221A";
            this.btnSqrRoot.Size = new System.Drawing.Size(60, 40);
            this.btnSqrRoot.Location = new System.Drawing.Point(230, 240);
            this.btnSqrRoot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSqrRoot.Click += new System.EventHandler(this.btnWithBraces_Click);
            this.btnSqrRoot.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnSqrRoot.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button Square
            this.btnSquare.Text = "x\u00B2";
            this.btnSquare.Size = new System.Drawing.Size(60, 40);
            this.btnSquare.Location = new System.Drawing.Point(230, 190);
            this.btnSquare.Font = new System.Drawing.Font("Arial", 15);
            this.btnSquare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSquare.Click += new System.EventHandler(this.btnSquare_Click);
            this.btnSquare.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnSquare.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button Log
            this.btnLog.Text = "Log";
            this.btnLog.Size = new System.Drawing.Size(60, 40);
            this.btnLog.Location = new System.Drawing.Point(230, 140);
            this.btnLog.Font = new System.Drawing.Font("Arial", 15);
            this.btnLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLog.Click += new System.EventHandler(this.btnWithBraces_Click);
            this.btnLog.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnLog.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button SinIn
            this.btnSinIn.Text = "sin\u207B\u00B9";
            this.btnSinIn.Size = new System.Drawing.Size(60, 40);
            this.btnSinIn.Location = new System.Drawing.Point(230, 90);
            this.btnSinIn.Font = new System.Drawing.Font("Arial", 15);
            this.btnSinIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSinIn.Click += new System.EventHandler(this.btnWithBraces_Click);
            this.btnSinIn.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnSinIn.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button Sin
            this.btnSin.Text = "sin";
            this.btnSin.Size = new System.Drawing.Size(60, 40);
            this.btnSin.Location = new System.Drawing.Point(230, 40);
            this.btnSin.Font = new System.Drawing.Font("Arial", 15);
            this.btnSin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSin.Click += new System.EventHandler(this.btnWithBraces_Click);
            this.btnSin.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnSin.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);

            //button Clear
            this.btnClear.Text = "AC";
            this.btnClear.Size = new System.Drawing.Size(60, 40);
            this.btnClear.Location = new System.Drawing.Point(120, 240);
            this.btnClear.Font = new System.Drawing.Font("Arial", 15);
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClear.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnClear.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            this.btnClear.Click += new EventHandler(this.btnChoosed_Click);
            //button Ans
            this.btnAns.Text = "Ans";
            this.btnAns.Size = new System.Drawing.Size(60, 40);
            this.btnAns.Location = new System.Drawing.Point(120, 190);
            this.btnAns.Font = new System.Drawing.Font("Arial", 15);
            this.btnAns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAns.Click += new EventHandler(this.btnChoosed_Click);
            this.btnAns.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnAns.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            

            //button Mod
            this.btnMod.Text = " Mod ";
            this.btnMod.Size = new System.Drawing.Size(60, 40);
            this.btnMod.Location = new System.Drawing.Point(120, 90);
            this.btnMod.Font = new System.Drawing.Font("Arial", 10);
            this.btnMod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMod.Click += new EventHandler(this.btnNumAndBasic_Click);
            this.btnMod.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnMod.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button Percent
            this.btnPercent.Text = "%";
            this.btnPercent.Size = new System.Drawing.Size(60, 40);
            this.btnPercent.Location = new System.Drawing.Point(120, 40);
            this.btnPercent.Font = new System.Drawing.Font("Arial", 15);
            this.btnPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPercent.Click += new EventHandler(this.btnNumAndBasic_Click);
            this.btnPercent.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnPercent.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);

            //button MS
            this.btnMS.Text = "MS";
            this.btnMS.Size = new System.Drawing.Size(60, 40);
            this.btnMS.Location = new System.Drawing.Point(20, 240);
            this.btnMS.Font = new System.Drawing.Font("Arial", 15);
            this.btnMS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMS.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnMS.Click += new EventHandler(this.btnMS_click);
            this.btnMR.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            //button MR
            this.btnMR.Text = "MR";
            this.btnMR.Size = new System.Drawing.Size(60, 40);
            this.btnMR.Location = new System.Drawing.Point(20, 190);
            this.btnMR.Font = new System.Drawing.Font("Arial", 15);
            this.btnMR.BackColor = System.Drawing.Color.White;
            this.btnMR.Enabled = false;
            this.btnMR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMR.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnMR.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            this.btnMR.Click += new EventHandler(this.btnChoosed_Click);
            //button MC
            this.btnMC.Text = "MC";
            this.btnMC.BackColor = System.Drawing.Color.White;
            this.btnMC.Enabled = false;
            this.btnMC.Size = new System.Drawing.Size(60, 40);
            this.btnMC.Location = new System.Drawing.Point(20, 140);
            this.btnMC.Font = new System.Drawing.Font("Arial", 15);
            this.btnMC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMC.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnMC.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            this.btnMC.Click += new System.EventHandler(this.btnMC_Click);
            //button M_Add
            this.btnM_Add.Text = "M+";
            this.btnM_Add.BackColor = System.Drawing.Color.White;
            this.btnM_Add.Enabled = false;
            this.btnM_Add.Size = new System.Drawing.Size(60, 40);
            this.btnM_Add.Location = new System.Drawing.Point(20, 90);
            this.btnM_Add.Font = new System.Drawing.Font("Arial", 15);
            this.btnM_Add.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnM_Add.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnM_Add.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            this.btnM_Add.Click += new EventHandler(this.btnM_Add_Click);
            //button M_sub
            this.btnM_Sub.Text = "M-";
            this.btnM_Sub.BackColor = System.Drawing.Color.White;
            this.btnM_Sub.Enabled = false;
            this.btnM_Sub.Size = new System.Drawing.Size(60, 40);
            this.btnM_Sub.Location = new System.Drawing.Point(20, 40);
            this.btnM_Sub.Font = new System.Drawing.Font("Arial", 15);
            this.btnM_Sub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnM_Sub.MouseDown += new MouseEventHandler(this.btnChoice_ToolTip);
            this.btnM_Sub.MouseUp += new MouseEventHandler(this.btnChoice_HideToolTip);
            this.btnM_Sub.Click += new EventHandler(this.btnM_Sub_Click);
            #endregion

            //lower panel
            this.containerMain.Panel2.BackColor = System.Drawing.Color.Black;
            this.containerMain.Panel2.Controls.AddRange(new Button[] { this.btnEquals,
                this.btnPlus,
                this.btnMinus,
                this.btnMultiply,
                this.btnDivide,
                this.btnBackspace,
                this.btnDecimal,this.btnSign,
                this.btn9,this.btn6,this.btn3,this.btn2,this.btn0,this.btn5,this.btn8,this.btn1,this.btn4,this.btn7,
                this.btnClosingBraces,this.btnOpeningBraces,
                this.btnTan,this.btnCos,this.btnSin,
                this.btnTanIn,this.btnCosIn,this.btnSinIn,
                this.btnRcpl,this.btnLn,this.btnLog,
                this.btnPower,this.btnCube,this.btnSquare,
                this.btnRoot,this.btnCubeRoot,this.btnSqrRoot,
                this.btnMS,this.btnMR,this.btnMC,this.btnM_Sub,this.btnM_Add,
                this.btnClear,this.btnAns,this.btnMod,this.btnPercent,
            });
            this.containerMain.Panel2.Controls.Add(this.lblLogo);

            // Calci
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(720,420);
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Controls.Add(this.topMenuStrip);
            this.Controls.Add(containerMain);
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(this.formCalci_KeyDown);
            this.ForeColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Arial", 20);
            this.AcceptButton = this.btnEquals;
            this.Name = "formCalci";
            this.Text = "Calculator";
            this.ResumeLayout(false);
        }

        #region Event Handlers
        public void menuItemExit_Click(object sender, System.EventArgs e) {
            System.Environment.Exit(0);
        }

        public void btnNumAndBasic_Click(object sender, System.EventArgs e) {
                this.txtMain.AppendText(((Button)sender).Text);
        }
        
        public void btnWithBraces_Click(object sender, System.EventArgs e)
        {
            this.txtMain.AppendText(((Button)sender).Text+"(");
        }
        public void btnSquare_Click(object sender, System.EventArgs e) {
            this.txtMain.AppendText("Sqr(");
        }
        public void btnCube_Click(object sender, System.EventArgs e)
        {
            this.txtMain.AppendText("Cube(");
        }
        public void btnRoot_Click(object sender, System.EventArgs e)
        {
            this.txtMain.AppendText("root(");
        }
        public void btnRcpl_Click(object sender, System.EventArgs e)
        {
            this.txtMain.AppendText("rcpl(");
        }
        public void btnSign_Click(object sender, System.EventArgs e)
        {
            this.txtMain.AppendText("sign(");
        }
        public void btnBackspace_Click(object sender, System.EventArgs e)
        {
            if (this.txtMain.SelectionLength > 0)
            {
                this.txtMain.Text = this.txtMain.Text.Remove(this.txtMain.SelectionStart, this.txtMain.SelectionLength);
            }
            else
            {
                if (this.txtMain.Text.Length > 0)
                {
                    this.txtMain.Text = this.txtMain.Text.Substring(0, this.txtMain.Text.Length - 1);
                }
            }
        }
        public void btnChoosed_Click(object sender, System.EventArgs e) {
            Button choice = sender as Button;
            switch (choice.Text) {
                case "Ans":
                    this.txtMain.Text += Ans;
                    break;
                case "AC":
                    this.txtMain.Text = "";
                    break;
                case "MR":
                    if (this.storedWord > 0) {
                        this.txtMain.Text = this.txtMain.Text + storedWord;
                    }
                    break;
            }
        }
        public void btnMS_click(object sender, EventArgs e) {
            double temp;
            if (Double.TryParse(this.txtMain.Text,out temp)) {
                this.storedWord = temp;
                this.btnMC.BackColor = System.Drawing.Color.Black;
                this.btnMC.Enabled = true;
                this.btnMR.BackColor = System.Drawing.Color.Black;
                this.btnMR.Enabled = true;
                this.btnM_Add.BackColor = System.Drawing.Color.Black;
                this.btnM_Add.Enabled = true;
                this.btnM_Sub.BackColor = System.Drawing.Color.Black;
                this.btnM_Sub.Enabled = true;
            }
        }
        public void btnMC_Click(object sender, EventArgs e) {
            this.storedWord = 0;
            this.btnMC.BackColor = System.Drawing.Color.White;
            this.btnMC.Enabled = false;
            this.btnMR.BackColor = System.Drawing.Color.White;
            this.btnMR.Enabled = false;
            this.btnM_Add.BackColor = System.Drawing.Color.White;
            this.btnM_Add.Enabled = false;
            this.btnM_Sub.BackColor = System.Drawing.Color.White;
            this.btnM_Sub.Enabled = false;
        }
        
        public void btnM_Add_Click(object sender, EventArgs e) {
            double temp;
            if (Double.TryParse(this.txtMain.Text, out temp)) {
                this.storedWord += temp;
            }
        }
        public void btnM_Sub_Click(object sender, EventArgs e)
        {
            double temp;
            if (Double.TryParse(this.txtMain.Text, out temp))
            {
                this.storedWord -= temp;
            }
        }
        public void btnEquals_Click(object sender, System.EventArgs e) {
            string expression = this.txtMain.Text;
            expression = expression.Replace("\u00F7", "/");
            expression = expression.Replace("Mod", "modx");
            expression = expression.Replace("\u00D7", "*");
            expression = expression.Replace("sin\u207B\u00B9", "sini");
            expression = expression.Replace("cos\u207B\u00B9", "cosi");
            expression = expression.Replace("tan\u207B\u00B9", "tani");
            expression = expression.Replace("ln", "loge");
            expression = expression.Replace("\u221A", "sqrt");
            expression = expression.Replace("\u221B", "cbrt");
            Lib.CalcEngine result = new Lib.CalcEngine();
            try
            {
                this.txtMain.Text = result.Evaluate("0" + expression);
                Ans = this.txtMain.Text;
            }
            catch (Exception ex) {
                this.txtMain.Text = ex.Message;
            }
            
        }
        public void btnChoice_ToolTip(object sender, MouseEventArgs e)
        {
            Dictionary<Button, String> toolTipDict = new Dictionary<Button, string>()
            {   { this.btn1,"1"},{ this.btn2,"2"},{ this.btn3,"3"},{ this.btn4,"4"},{ this.btn5,"5"},{ this.btn6,"6"},{ this.btn7,"7"},{ this.btn8,"8"},{ this.btn9,"9"},{ this.btn0,"0"},
                {this.btnSin,"sin"},{this.btnCos,"cos"},{this.btnTan,"tan"},{this.btnSinIn,"sini"},{this.btnCosIn,"cosi"},{this.btnTanIn,"tani"},{this.btnOpeningBraces,"openbrace"},
                {this.btnLog,"log"},{this.btnLn,"ln"},{this.btnRcpl,"rcpl"},{this.btnPower,"power"},{this.btnRoot,"root"},{this.btnBackspace,"backspace"},{this.btnClosingBraces,"closebrace"},
                {this.btnCubeRoot,"cuberoot"},{this.btnSqrRoot,"sqrroot"},{this.btnCube,"cube"},{this.btnSquare,"square"},{this.btnDecimal,"decimal"},{this.btnEquals,"EqualsTo"},
                {this.btnMS,"MS"},{this.btnMR,"MR"},{this.btnM_Add,"Madd"},{this.btnM_Sub,"Mminus"},{this.btnMC,"MC"},{this.btnClear,"AC"},{this.btnSign,"sign"},
                {this.btnAns,"Ans"},{this.btnMod,"mod"},{this.btnPercent,"percent"},{this.btnPlus,"plus"},{this.btnMinus,"minus"},{this.btnMultiply,"multiply"},{this.btnDivide,"divide"},
            };
            if (e.Button == MouseButtons.Right) {
                Button btn = sender as Button;
                String id;
                if (toolTipDict.TryGetValue(btn, out id))
                {
                    this.toolTip.SetToolTip(btn, toolTipText(id));
                }
            }
        }
        public void btnChoice_HideToolTip(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.toolTip.RemoveAll();
                
            }
        }
        public void menuItemCopyCut_Click(object sender, EventArgs e) {
            if (this.txtMain.SelectionLength > 0)
            {
                this.txtMain.Copy();
            }
            else {
                this.txtMain.SelectionStart = 0;
                this.txtMain.SelectionLength = this.txtMain.TextLength;
                this.txtMain.Copy();
            }
            ToolStripMenuItem menuItemX = sender as ToolStripMenuItem;
            if (menuItemX.Name == "Cut") {
                this.txtMain.Text= "";
            }
        }
        public void menuItemPaste_Click(object sender, EventArgs e) {
            if (Clipboard.GetText() == String.Empty) {
                return;
            }
            string temp=Clipboard.GetText();
                if (this.txtMain.SelectionLength > 0)
                {
                    this.txtMain.Text = this.txtMain.Text.Remove(this.txtMain.SelectionStart, this.txtMain.SelectionLength);
                    this.txtMain.Text += temp;
                }
                else
                {
                    this.txtMain.Text += temp;
                }
            
        }
        public void menuItemHelp_Click(object sender, EventArgs e) {
            String helpFile = @".\HelpForm.txt";
            if (System.IO.File.Exists(helpFile))
            {
                System.Diagnostics.Process.Start("notepad.exe", helpFile);
            }
            else {
                MessageBox.Show("Help File Not Found");
            }
        }
        public string toolTipText(string btn) {
            //returns tooltip text from the resource file
            ResourceManager rm = new ResourceManager("Calculator.Win.ToolTipText",Assembly.GetExecutingAssembly());
            return (rm.GetString(btn));
        }
        public void formCalci_KeyDown(object sender, KeyEventArgs e) {

            Dictionary<Keys, Button> ctrlDict = new Dictionary<Keys, Button>()
            {{Keys.S,this.btnMS},{Keys.R,this.btnMR},{Keys.W,this.btnM_Add},{Keys.E,this.btnM_Sub},{Keys.D,this.btnMC},{Keys.D1,this.btnRoot},{Keys.D2,this.btnCubeRoot},{Keys.D3,this.btnSqrRoot},
            };

            Dictionary<Keys, Button> simpleDict = new Dictionary<Keys, Button>()
            {   {Keys.D1,this.btn1},{ Keys.D2,this.btn2},{ Keys.D3,this.btn3},{ Keys.D4,this.btn4},{ Keys.D5,this.btn5},{Keys.D6, this.btn6},{ Keys.D7,this.btn7},{ Keys.D8,this.btn8},{ Keys.D9,this.btn9},{ Keys.D0,this.btn0},
                {Keys.NumPad1,this.btn1},{ Keys.NumPad2,this.btn2},{ Keys.NumPad3,this.btn3},{ Keys.NumPad4,this.btn4},{ Keys.NumPad5,this.btn5},{Keys.NumPad6, this.btn6},{ Keys.NumPad7,this.btn7},{ Keys.NumPad8,this.btn8},{ Keys.NumPad9,this.btn9},{ Keys.NumPad0,this.btn0},
                {Keys.S,this.btnSin},{Keys.C,this.btnCos},{Keys.T,this.btnTan}, {Keys.L,this.btnLog},{Keys.Add,this.btnPlus},{Keys.OemMinus,this.btnMinus},{Keys.Subtract,this.btnMinus},{Keys.Multiply,this.btnMultiply},{Keys.Divide,this.btnDivide},
                {Keys.Back,this.btnBackspace},{Keys.OemPeriod,this.btnDecimal},{Keys.Decimal,this.btnDecimal},{Keys.R,this.btnRcpl},{Keys.A,this.btnAns},{Keys.M,this.btnMod},{Keys.OemQuestion,this.btnDivide},
                {Keys.Oemplus,this.btnEquals}};

            Dictionary<Keys, Button> shiftDict = new Dictionary<Keys,Button>()
            {   
                {Keys.S,this.btnSinIn},{Keys.C,this.btnCosIn},{Keys.T,this.btnTanIn},{Keys.D9,this.btnOpeningBraces},
               {Keys.L,this.btnLn},{Keys.D6,this.btnPower},{Keys.D0,this.btnClosingBraces},
                {Keys.D3,this.btnCube},{Keys.D2,this.btnSquare},
                {Keys.A,this.btnClear},{Keys.R,this.btnSign},
                {Keys.D5,this.btnPercent},{Keys.Oemplus,this.btnPlus},{Keys.D8,this.btnMultiply}
            };

            Button pressed;
            if (e.Shift)
            {
                if (shiftDict.TryGetValue(e.KeyCode, out pressed))
                {
                    pressed.PerformClick();
                    e.Handled = true;
                }
            }
            else if (e.Control) {
                if (ctrlDict.TryGetValue(e.KeyCode, out pressed))
                {
                    pressed.PerformClick();
                    e.Handled = true;
                }
            }
            else
            {
                if (simpleDict.TryGetValue(e.KeyCode, out pressed))
                {
                    pressed.PerformClick();
                    e.Handled = true;
                }

                else if (e.KeyCode == Keys.Escape)
                {
                    menuItemExit.PerformClick();
                    e.Handled = true;
                }
               
            }
        }
        #endregion
    }
}