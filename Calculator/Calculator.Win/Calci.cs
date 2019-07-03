using System;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
namespace Calculator.Win
{
    public partial class Calci : Form
    {
        #region Declarations
        private string _ans="0";
        private System.Windows.Forms.MenuStrip topMenuStrip;
        private ToolStripMenuItem menuItemHelp;
        private ToolStripMenuItem menuItemEdit;
        private ToolStripMenuItem menuItemExit;
        private ToolStripMenuItem menuItemCopy;
        private ToolStripMenuItem menuItemPaste;
        private ToolStripMenuItem menuItemCut;
        private SplitContainer containerMain;
        private ButtonX btnEquals;
        private ButtonX btnPlus;
        private ButtonX btnMinus;
        private ButtonX btnMultiply;
        private ButtonX btnDivide;
        private ButtonX btn1;
        private ButtonX btn2;
        private ButtonX btn3;
        private ButtonX btn4;
        private ButtonX btn5;
        private ButtonX btn6;
        private ButtonX btn7;
        private ButtonX btn8;
        private ButtonX btn9;
        private ButtonX btn0;
        private ButtonX btnClosingBraces;
        private ButtonX btnOpeningBraces;
        private ButtonX btnSign;
        private ButtonX btnBackspace;
        private ButtonX btnDecimal;
        private ButtonX btnTan;
        private ButtonX btnLog;
        private ButtonX btnCos;
        private ButtonX btnSin;
        private ButtonX btnSinIn;
        private ButtonX btnTanIn;
        private ButtonX btnCosIn;
        private ButtonX btnLn;
        private ButtonX btnRcpl;
        private ButtonX btnSquare;
        private ButtonX btnCube;
        private ButtonX btnPower;
        private ButtonX btnSqrRoot;
        private ButtonX btnCubeRoot;
        private ButtonX btnRoot;
        private ButtonX btnMR;
        private ButtonX btnM_Add;
        private ButtonX btnM_Sub;
        private ButtonX btnMS;
        private ButtonX btnMC;
        private ButtonX btnClear;
        private ButtonX btnAns;
        private ButtonX btnPercent;
        private ButtonX btnMod;
        private Label lblLogo;
        private TextBox txtMain;
        private Double _storedWord;
        ToolTip toolTip;
        public double StoredWord{
            get {
                return (_storedWord);
            }
            set {
                _storedWord = value;
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
            this.btnEquals = new ButtonX();
            this.btnPlus = new ButtonX();
            this.btnMinus = new ButtonX();
            this.btnMultiply = new ButtonX();
            this.btnDivide = new ButtonX();
            this.btn1 = new ButtonX();
            this.btn2 = new ButtonX();
            this.btn3 = new ButtonX();
            this.btn4 = new ButtonX();
            this.btn5 = new ButtonX();
            this.btn6 = new ButtonX();
            this.btn7 = new ButtonX();
            this.btn8 = new ButtonX();
            this.btn9 = new ButtonX();
            this.btn0 = new ButtonX();
            this.btnSin = new ButtonX();
            this.btnCos = new ButtonX();
            this.btnTan = new ButtonX();
            this.btnCosIn = new ButtonX();
            this.btnSinIn = new ButtonX();
            this.btnTanIn = new ButtonX();
            this.btnLog = new ButtonX();
            this.btnLn = new ButtonX();
            this.btnRcpl = new ButtonX();
            this.btnSquare = new ButtonX();
            this.btnCube = new ButtonX();
            this.btnPower = new ButtonX();
            this.btnSqrRoot = new ButtonX();
            this.btnCubeRoot = new ButtonX();
            this.btnRoot = new ButtonX();
            this.btnClosingBraces = new ButtonX();
            this.btnOpeningBraces = new ButtonX();
            this.btnSign = new ButtonX();
            this.btnBackspace = new ButtonX();
            this.btnDecimal = new ButtonX();
            this.btnMC = new ButtonX();
            this.btnMR = new ButtonX();
            this.btnM_Add = new ButtonX();
            this.btnM_Sub = new ButtonX();
            this.btnMS = new ButtonX();
            this.btnPercent = new ButtonX();
            this.btnClear = new ButtonX();
            this.btnAns = new ButtonX();
            this.btnMod = new ButtonX();
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
            this.menuItemHelp.Click += new System.EventHandler(this.MenuItemHelp_Click);
            this.menuItemHelp.ToolTipText = ToolTipText("menuHelp");
            //Edit Menu
            this.menuItemEdit.Name = "EditMenu";
            this.menuItemEdit.Text = "Edit";
            this.menuItemEdit.DropDownItems.AddRange(new ToolStripMenuItem[] { this.menuItemCut, this.menuItemCopy, this.menuItemPaste });
            this.menuItemEdit.ToolTipText = ToolTipText("menuEdit");
            //Copy
            this.menuItemCopy.Name = "Copy";
            this.menuItemCopy.Text = "Copy";
            this.menuItemCopy.Click += new System.EventHandler(this.MenuItemCopyCut_Click);
            this.menuItemCopy.ShortcutKeys = Keys.Control | Keys.C;
            this.menuItemCopy.ToolTipText = ToolTipText("Copy");
            //Cut
            this.menuItemCut.Name = "Cut";
            this.menuItemCut.Text = "Cut";
            this.menuItemCut.Click += new System.EventHandler(this.MenuItemCopyCut_Click);
            this.menuItemCut.ShortcutKeys = Keys.Control | Keys.X;
            this.menuItemCut.ToolTipText = ToolTipText("Cut");
            //Paste
            this.menuItemPaste.Name = "Paste";
            this.menuItemPaste.Text = "Paste";
            this.menuItemPaste.ShortcutKeys = Keys.Control | Keys.V;
            this.menuItemPaste.Click += new System.EventHandler(this.MenuItemPaste_Click);
            this.menuItemPaste.ToolTipText = ToolTipText("Paste");
            //ExitMenuItem
            this.menuItemExit.Name = "ExitMenuItem";
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.ToolTipText = ToolTipText("exit");
            this.menuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
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
            this.toolTip.SetToolTip(this.lblLogo, "Calculator Application");
            this.lblLogo.Location = new System.Drawing.Point(90, 137);
            this.lblLogo.Size = new System.Drawing.Size(150, 50);
            this.lblLogo.Font = new System.Drawing.Font("Chiller", 30);
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            #region Buttons
            //button equals
            this.btnEquals.Text = "=";            
            this.btnEquals.Location = new System.Drawing.Point(650, 240);
            this.btnEquals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEquals.Click += new System.EventHandler(this.BtnEquals_Click);
            this.btnEquals.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnEquals.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button +
            this.btnPlus.Text = "+";            
            this.btnPlus.Location = new System.Drawing.Point(650, 190);
            this.btnPlus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPlus.AppendText = "+";
            this.btnPlus.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnPlus.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnPlus.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button -
            this.btnMinus.Text = "-";
            this.btnMinus.AppendText = "-";
            this.btnMinus.Location = new System.Drawing.Point(650, 140);
            this.btnMinus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMinus.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnMinus.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnMinus.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button x
            this.btnMultiply.Text = "\u00D7";
            this.btnMultiply.AppendText = "\u00D7";
            this.btnMultiply.Location = new System.Drawing.Point(650, 90);
            this.btnMultiply.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMultiply.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnMultiply.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnMultiply.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button /
            this.btnDivide.Text = "\u00F7";
            this.btnDivide.AppendText = "\u00F7";
            this.btnDivide.Location = new System.Drawing.Point(650, 40);
            this.btnDivide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDivide.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnDivide.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnDivide.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button backspace
            this.btnBackspace.Text = "\u232B";            
            this.btnBackspace.Location = new System.Drawing.Point(590, 40);
            this.btnBackspace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBackspace.Click += new System.EventHandler(this.BtnBackspace_Click);
            this.btnBackspace.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnBackspace.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button decimal
            this.btnDecimal.Text = ".";
            this.btnDecimal.AppendText = ".";
            this.btnDecimal.Location = new System.Drawing.Point(590, 240);
            this.btnDecimal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDecimal.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnDecimal.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnDecimal.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button 3
            this.btn3.Text = "3";
            this.btn3.AppendText = "3";
            this.btn3.Location = new System.Drawing.Point(590, 190);
            this.btn3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn3.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btn3.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btn3.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button 6
            this.btn6.Text = "6";
            this.btn6.AppendText = "6";
            this.btn6.Location = new System.Drawing.Point(590, 140);
            this.btn6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn6.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btn6.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btn6.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button 9
            this.btn9.Text = "9";
            this.btn9.AppendText = "9";
            this.btn9.Location = new System.Drawing.Point(590, 90);
            this.btn9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn9.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btn9.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btn9.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button 0
            this.btn0.Text = "0";
            this.btn0.AppendText = "0";
            this.btn0.Location = new System.Drawing.Point(530, 240);
            this.btn0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn0.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btn0.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btn0.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button 2
            this.btn2.Text = "2";
            this.btn2.AppendText = "2";
            this.btn2.Location = new System.Drawing.Point(530, 190);
            this.btn2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn2.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btn2.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btn2.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button 5
            this.btn5.Text = "5";
            this.btn5.AppendText = "5";
            this.btn5.Location = new System.Drawing.Point(530, 140);
            this.btn5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn5.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btn5.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btn5.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button 8
            this.btn8.Text = "8";
            this.btn8.AppendText = "8";
            this.btn8.Location = new System.Drawing.Point(530, 90);
            this.btn8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn8.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btn8.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btn8.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button )
            this.btnClosingBraces.Text = ")";
            this.btnClosingBraces.AppendText = ")";
            this.btnClosingBraces.Location = new System.Drawing.Point(530, 40);
            this.btnClosingBraces.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClosingBraces.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnClosingBraces.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnClosingBraces.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button sign
            this.btnSign.Text = "\u00B1";
            this.btnSign.AppendText = "sign(";
            this.btnSign.Location = new System.Drawing.Point(470, 240);
            this.btnSign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSign.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnSign.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnSign.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button 1
            this.btn1.Text = "1";
            this.btn1.AppendText = "1";
            this.btn1.Location = new System.Drawing.Point(470, 190);
            this.btn1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn1.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btn1.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btn1.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button 4
            this.btn4.Text = "4";
            this.btn4.AppendText = "4";
            this.btn4.Location = new System.Drawing.Point(470, 140);
            this.btn4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn4.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btn4.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btn4.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button 7
            this.btn7.Text = "7";
            this.btn7.AppendText = "7";
            this.btn7.Location = new System.Drawing.Point(470, 90);
            this.btn7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn7.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btn7.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btn7.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button (
            this.btnOpeningBraces.Text = "(";
            this.btnOpeningBraces.AppendText = "(";
            this.btnOpeningBraces.Location = new System.Drawing.Point(470, 40);
            this.btnOpeningBraces.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOpeningBraces.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnOpeningBraces.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnOpeningBraces.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);

            //button root
            this.btnRoot.Text = "\u207f\u221Ax";
            this.btnRoot.AppendText = "root(";
            this.btnRoot.Size = new System.Drawing.Size(60, 40);
            this.btnRoot.Location = new System.Drawing.Point(370, 240);
            this.btnRoot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRoot.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnRoot.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnRoot.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button power
            this.btnPower.Text = "^";
            this.btnPower.AppendText = "^(";
            this.btnPower.Size = new System.Drawing.Size(60, 40);
            this.btnPower.Location = new System.Drawing.Point(370, 190);
            this.btnPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPower.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnPower.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnPower.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button reciprocal
            this.btnRcpl.Text = "1/x";
            this.btnRcpl.AppendText = "rcpl(";
            this.btnRcpl.Size = new System.Drawing.Size(60, 40);
            this.btnRcpl.Location = new System.Drawing.Point(370, 140);
            this.btnRcpl.Font = new System.Drawing.Font("Arial", 10);
            this.btnRcpl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRcpl.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnRcpl.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnRcpl.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button tanin
            this.btnTanIn.Text = "tan\u207B\u00B9";
            this.btnTanIn.AppendText = "tan\u207B\u00B9(";
            this.btnTanIn.Size = new System.Drawing.Size(60, 40);
            this.btnTanIn.Location = new System.Drawing.Point(370, 90);
            this.btnTanIn.Font = new System.Drawing.Font("Arial", 15);
            this.btnTanIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTanIn.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnTanIn.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnTanIn.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button tan
            this.btnTan.Text = "tan";
            this.btnTan.AppendText = "tan(";
            this.btnTan.Size = new System.Drawing.Size(60, 40);
            this.btnTan.Location = new System.Drawing.Point(370, 40);
            this.btnTan.Font = new System.Drawing.Font("Arial", 15);
            this.btnTan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTan.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnTan.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnTan.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button CubeRoot
            this.btnCubeRoot.Text = "\u221B";
            this.btnCubeRoot.AppendText = "\u221B(";
            this.btnCubeRoot.Size = new System.Drawing.Size(60, 40);
            this.btnCubeRoot.Location = new System.Drawing.Point(300, 240);
            this.btnCubeRoot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCubeRoot.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnCubeRoot.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnCubeRoot.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button cube
            this.btnCube.Text = "x\u00B3";
            this.btnCube.AppendText = "cube(";
            this.btnCube.Size = new System.Drawing.Size(60, 40);
            this.btnCube.Location = new System.Drawing.Point(300, 190);
            this.btnCube.Font = new System.Drawing.Font("Arial", 15);
            this.btnCube.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCube.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnCube.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnCube.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button ln
            this.btnLn.Text = "Ln";
            this.btnLn.AppendText = "Ln(";
            this.btnLn.Size = new System.Drawing.Size(60, 40);
            this.btnLn.Location = new System.Drawing.Point(300, 140);
            this.btnLn.Font = new System.Drawing.Font("Arial", 15);
            this.btnLn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLn.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnLn.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnLn.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button Cosin
            this.btnCosIn.Text = "cos\u207B\u00B9";
            this.btnCosIn.AppendText = "cos\u207B\u00B9(";
            this.btnCosIn.Size = new System.Drawing.Size(60, 40);
            this.btnCosIn.Location = new System.Drawing.Point(300, 90);
            this.btnCosIn.Font = new System.Drawing.Font("Arial", 12);
            this.btnCosIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCosIn.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnCosIn.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnCosIn.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button cos
            this.btnCos.Text = "cos";
            this.btnCos.AppendText = "cos(";
            this.btnCos.Size = new System.Drawing.Size(60, 40);
            this.btnCos.Location = new System.Drawing.Point(300, 40);
            this.btnCos.Font = new System.Drawing.Font("Arial", 15);
            this.btnCos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCos.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnCos.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnCos.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button SqrRoot
            this.btnSqrRoot.Text = "\u221A";
            this.btnSqrRoot.AppendText = "\u221A(";
            this.btnSqrRoot.Size = new System.Drawing.Size(60, 40);
            this.btnSqrRoot.Location = new System.Drawing.Point(230, 240);
            this.btnSqrRoot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSqrRoot.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnSqrRoot.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnSqrRoot.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button Square
            this.btnSquare.Text = "x\u00B2";
            this.btnSquare.AppendText = "sqr(";
            this.btnSquare.Size = new System.Drawing.Size(60, 40);
            this.btnSquare.Location = new System.Drawing.Point(230, 190);
            this.btnSquare.Font = new System.Drawing.Font("Arial", 15);
            this.btnSquare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSquare.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnSquare.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnSquare.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button Log
            this.btnLog.Text = "Log";
            this.btnLog.AppendText = "Log(";
            this.btnLog.Size = new System.Drawing.Size(60, 40);
            this.btnLog.Location = new System.Drawing.Point(230, 140);
            this.btnLog.Font = new System.Drawing.Font("Arial", 15);
            this.btnLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLog.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnLog.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnLog.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button SinIn
            this.btnSinIn.Text = "sin\u207B\u00B9";
            this.btnSinIn.AppendText = "sin\u207B\u00B9(";
            this.btnSinIn.Size = new System.Drawing.Size(60, 40);
            this.btnSinIn.Location = new System.Drawing.Point(230, 90);
            this.btnSinIn.Font = new System.Drawing.Font("Arial", 15);
            this.btnSinIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSinIn.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnSinIn.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnSinIn.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button Sin
            this.btnSin.Text = "sin";
            this.btnSin.AppendText = "sin(";
            this.btnSin.Size = new System.Drawing.Size(60, 40);
            this.btnSin.Location = new System.Drawing.Point(230, 40);
            this.btnSin.Font = new System.Drawing.Font("Arial", 15);
            this.btnSin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSin.Click += new System.EventHandler(this.Btn_Click_Append);
            this.btnSin.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnSin.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);

            //button Clear
            this.btnClear.Text = "AC";
            this.btnClear.Size = new System.Drawing.Size(60, 40);
            this.btnClear.Location = new System.Drawing.Point(120, 240);
            this.btnClear.Font = new System.Drawing.Font("Arial", 15);
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClear.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnClear.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            this.btnClear.Click += new EventHandler(this.BtnChoosed_Click);
            //button Ans
            this.btnAns.Text = "Ans";
            this.btnAns.Size = new System.Drawing.Size(60, 40);
            this.btnAns.Location = new System.Drawing.Point(120, 190);
            this.btnAns.Font = new System.Drawing.Font("Arial", 15);
            this.btnAns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAns.Click += new EventHandler(this.BtnChoosed_Click);
            this.btnAns.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnAns.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            

            //button Mod
            this.btnMod.Text = " Mod ";
            this.btnMod.AppendText = " Mod ";
            this.btnMod.Size = new System.Drawing.Size(60, 40);
            this.btnMod.Location = new System.Drawing.Point(120, 90);
            this.btnMod.Font = new System.Drawing.Font("Arial", 10);
            this.btnMod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMod.Click += new EventHandler(this.Btn_Click_Append);
            this.btnMod.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnMod.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button Percent
            this.btnPercent.Text = "%";
            this.btnPercent.AppendText = "%";
            this.btnPercent.Size = new System.Drawing.Size(60, 40);
            this.btnPercent.Location = new System.Drawing.Point(120, 40);
            this.btnPercent.Font = new System.Drawing.Font("Arial", 15);
            this.btnPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPercent.Click += new EventHandler(this.Btn_Click_Append);
            this.btnPercent.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnPercent.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);

            //button MS
            this.btnMS.Text = "MS";
            this.btnMS.Size = new System.Drawing.Size(60, 40);
            this.btnMS.Location = new System.Drawing.Point(20, 240);
            this.btnMS.Font = new System.Drawing.Font("Arial", 15);
            this.btnMS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMS.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnMS.Click += new EventHandler(this.BtnMS_Click);
            this.btnMR.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            //button MR
            this.btnMR.Text = "MR";
            this.btnMR.Size = new System.Drawing.Size(60, 40);
            this.btnMR.Location = new System.Drawing.Point(20, 190);
            this.btnMR.Font = new System.Drawing.Font("Arial", 15);
            this.btnMR.BackColor = System.Drawing.Color.White;
            this.btnMR.Enabled = false;
            this.btnMR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMR.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnMR.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            this.btnMR.Click += new EventHandler(this.BtnChoosed_Click);
            //button MC
            this.btnMC.Text = "MC";
            this.btnMC.BackColor = System.Drawing.Color.White;
            this.btnMC.Enabled = false;
            this.btnMC.Size = new System.Drawing.Size(60, 40);
            this.btnMC.Location = new System.Drawing.Point(20, 140);
            this.btnMC.Font = new System.Drawing.Font("Arial", 15);
            this.btnMC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMC.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnMC.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            this.btnMC.Click += new System.EventHandler(this.BtnMC_Click);
            //button M_Add
            this.btnM_Add.Text = "M+";
            this.btnM_Add.BackColor = System.Drawing.Color.White;
            this.btnM_Add.Enabled = false;
            this.btnM_Add.Size = new System.Drawing.Size(60, 40);
            this.btnM_Add.Location = new System.Drawing.Point(20, 90);
            this.btnM_Add.Font = new System.Drawing.Font("Arial", 15);
            this.btnM_Add.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnM_Add.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnM_Add.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            this.btnM_Add.Click += new EventHandler(this.BtnM_Add_Click);
            //button M_sub
            this.btnM_Sub.Text = "M-";
            this.btnM_Sub.BackColor = System.Drawing.Color.White;
            this.btnM_Sub.Enabled = false;
            this.btnM_Sub.Size = new System.Drawing.Size(60, 40);
            this.btnM_Sub.Location = new System.Drawing.Point(20, 40);
            this.btnM_Sub.Font = new System.Drawing.Font("Arial", 15);
            this.btnM_Sub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnM_Sub.MouseDown += new MouseEventHandler(this.BtnChoice_ToolTip);
            this.btnM_Sub.MouseUp += new MouseEventHandler(this.BtnChoice_HideToolTip);
            this.btnM_Sub.Click += new EventHandler(this.BtnM_Sub_Click);

            //button Tooltips Id
            {
                this.btn1.TooltipId = "1";
                this.btn2.TooltipId = "2";
                this.btn3.TooltipId = "3";
                this.btn4.TooltipId = "4";
                this.btn5.TooltipId = "5";
                this.btn6.TooltipId = "6";
                this.btn7.TooltipId = "7";
                this.btn8.TooltipId = "8";
                this.btn9.TooltipId = "9";
                this.btn0.TooltipId = "0";
                this.btnSin.TooltipId = "sin";
                this.btnCos.TooltipId = "cos";
                this.btnTan.TooltipId = "tan";
                this.btnSinIn.TooltipId = "sini";
                this.btnCosIn.TooltipId = "cosi";
                this.btnTanIn.TooltipId = "tani";
                this.btnOpeningBraces.TooltipId = "openbrace";
                this.btnLog.TooltipId = "log";
                this.btnLn.TooltipId = "ln";
                this.btnRcpl.TooltipId = "rcpl";
                this.btnPower.TooltipId = "power";
                this.btnRoot.TooltipId = "root";
                this.btnBackspace.TooltipId = "backspace";
                this.btnClosingBraces.TooltipId = "closebrace";
                this.btnCubeRoot.TooltipId = "cuberoot";
                this.btnSqrRoot.TooltipId = "sqrroot";
                this.btnCube.TooltipId = "cube";
                this.btnSquare.TooltipId = "square";
                this.btnDecimal.TooltipId = "decimal";
                this.btnEquals.TooltipId = "EqualsTo";
                this.btnMS.TooltipId = "MS";
                this.btnMR.TooltipId = "MR";
                this.btnM_Add.TooltipId = "Madd";
                this.btnM_Sub.TooltipId = "Mminus";
                this.btnMC.TooltipId = "MC";
                this.btnClear.TooltipId = "AC";
                this.btnSign.TooltipId = "sign";
                this.btnAns.TooltipId = "Ans";
                this.btnMod.TooltipId = "mod";
                this.btnPercent.TooltipId = "percent";
                this.btnPlus.TooltipId = "plus";
                this.btnMinus.TooltipId = "minus";
                this.btnMultiply.TooltipId = "multiply";
                this.btnDivide.TooltipId = "divide";
            }

            //Button ShortCuts
            {
                this.btnMS.ShortcutKey = Keys.S;
                this.btnMS.ModifierKey = Keys.Control;
                this.btnMR.ShortcutKey = Keys.R;
                this.btnMR.ModifierKey = Keys.Control;
                this.btnM_Add.ShortcutKey = Keys.W;
                this.btnM_Add.ModifierKey = Keys.Control;
                this.btnM_Sub.ShortcutKey = Keys.E;
                this.btnM_Sub.ModifierKey = Keys.Control;
                this.btnMC.ShortcutKey = Keys.D;
                this.btnMC.ModifierKey = Keys.Control;
                this.btnRoot.ShortcutKey = Keys.D1;
                this.btnRoot.ModifierKey = Keys.Control;
                this.btnCubeRoot.ShortcutKey = Keys.D2;
                this.btnCubeRoot.ModifierKey = Keys.Control;
                this.btnSqrRoot.ShortcutKey = Keys.D3;
                this.btnSqrRoot.ModifierKey = Keys.Control;
                this.btn1.ShortcutKey = Keys.D1;
                this.btn1.ModifierKey = Keys.None;
                this.btn2.ShortcutKey = Keys.D2;
                this.btn2.ModifierKey = Keys.None;
                this.btn3.ShortcutKey = Keys.D3;
                this.btn3.ModifierKey = Keys.None;
                this.btn4.ShortcutKey = Keys.D4;
                this.btn4.ModifierKey = Keys.None;
                this.btn5.ShortcutKey = Keys.D5;
                this.btn5.ModifierKey = Keys.None;
                this.btn6.ShortcutKey = Keys.D6;
                this.btn6.ModifierKey = Keys.None;
                this.btn7.ShortcutKey = Keys.D7;
                this.btn7.ModifierKey = Keys.None;
                this.btn8.ShortcutKey = Keys.D8;
                this.btn8.ModifierKey = Keys.None;
                this.btn9.ShortcutKey = Keys.D9;
                this.btn9.ModifierKey = Keys.None;
                this.btn0.ShortcutKey = Keys.D0;
                this.btn0.ModifierKey = Keys.None;
                this.btnSin.ShortcutKey = Keys.S;
                this.btnSin.ModifierKey = Keys.None;
                this.btnCos.ShortcutKey = Keys.C;
                this.btnCos.ModifierKey = Keys.None;
                this.btnTan.ShortcutKey = Keys.T;
                this.btnTan.ModifierKey = Keys.None;
                this.btnLog.ShortcutKey = Keys.L;
                this.btnLog.ModifierKey = Keys.None;
                this.btnMinus.ShortcutKey = Keys.OemMinus;
                this.btnMinus.ModifierKey = Keys.None;
                this.btnBackspace.ShortcutKey = Keys.Back;
                this.btnBackspace.ModifierKey = Keys.None;
                this.btnDecimal.ShortcutKey = Keys.OemPeriod;
                this.btnDecimal.ModifierKey = Keys.None;
                this.btnRcpl.ShortcutKey = Keys.R;
                this.btnRcpl.ModifierKey = Keys.None;
                this.btnAns.ShortcutKey = Keys.A;
                this.btnAns.ModifierKey = Keys.None;
                this.btnMod.ShortcutKey = Keys.M;
                this.btnMod.ModifierKey = Keys.None;
                this.btnDivide.ShortcutKey = Keys.OemQuestion;
                this.btnDivide.ModifierKey = Keys.None;
                this.btnEquals.ShortcutKey = Keys.Oemplus;
                this.btnEquals.ModifierKey = Keys.None;
                this.btnSinIn.ShortcutKey = Keys.S;
                this.btnSinIn.ModifierKey = Keys.Shift;
                this.btnCosIn.ShortcutKey = Keys.C;
                this.btnCosIn.ModifierKey = Keys.Shift;
                this.btnTanIn.ShortcutKey = Keys.T;
                this.btnTanIn.ModifierKey = Keys.Shift;
                this.btnOpeningBraces.ShortcutKey = Keys.D9;
                this.btnOpeningBraces.ModifierKey = Keys.Shift;
                this.btnLn.ShortcutKey = Keys.L;
                this.btnLn.ModifierKey = Keys.Shift;
                this.btnPower.ShortcutKey = Keys.D6;
                this.btnPower.ModifierKey = Keys.Shift;
                this.btnClosingBraces.ShortcutKey = Keys.D0;
                this.btnClosingBraces.ModifierKey = Keys.Shift;
                this.btnCube.ShortcutKey = Keys.D3;
                this.btnCube.ModifierKey = Keys.Shift;
                this.btnSquare.ShortcutKey = Keys.D2;
                this.btnSquare.ModifierKey = Keys.Shift;
                this.btnClear.ShortcutKey = Keys.A;
                this.btnClear.ModifierKey = Keys.Shift;
                this.btnSign.ShortcutKey = Keys.R;
                this.btnSign.ModifierKey = Keys.Shift;
                this.btnPercent.ShortcutKey = Keys.D5;
                this.btnPercent.ModifierKey = Keys.Shift;
                this.btnPlus.ShortcutKey = Keys.Oemplus;
                this.btnPlus.ModifierKey = Keys.Shift;
                this.btnMultiply.ShortcutKey = Keys.D8;
                this.btnMultiply.ModifierKey = Keys.Shift;


            }
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
            this.KeyDown += new KeyEventHandler(this.FormCalci_KeyDown);
            this.ForeColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Arial", 20);
            this.AcceptButton = this.btnEquals;
            this.Name = "formCalci";
            this.Text = "Calculator";
            this.ResumeLayout(false);
        }

        #region Event Handlers
        public void MenuItemExit_Click(object sender, System.EventArgs e) {
            System.Environment.Exit(0);
        }

        public void Btn_Click_Append(object sender, System.EventArgs e) {
                this.txtMain.AppendText(((ButtonX)sender).AppendText);
        }
       
        public void BtnBackspace_Click(object sender, System.EventArgs e)
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
        public void BtnChoosed_Click(object sender, System.EventArgs e) {
            Button choice = sender as Button;
            switch (choice.Text) {
                case "Ans":
                    this.txtMain.Text += _ans;
                    break;
                case "AC":
                    this.txtMain.Text = "";
                    break;
                case "MR":
                    if (this._storedWord > 0) {
                        this.txtMain.Text = this.txtMain.Text + _storedWord;
                    }
                    break;
            }
        }
        public void BtnMS_Click(object sender, EventArgs e) {
            double temp;
            if (Double.TryParse(this.txtMain.Text,out temp)) {
                this._storedWord = temp;
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
        public void BtnMC_Click(object sender, EventArgs e) {
            this._storedWord = 0;
            this.btnMC.BackColor = System.Drawing.Color.White;
            this.btnMC.Enabled = false;
            this.btnMR.BackColor = System.Drawing.Color.White;
            this.btnMR.Enabled = false;
            this.btnM_Add.BackColor = System.Drawing.Color.White;
            this.btnM_Add.Enabled = false;
            this.btnM_Sub.BackColor = System.Drawing.Color.White;
            this.btnM_Sub.Enabled = false;
        }
        
        public void BtnM_Add_Click(object sender, EventArgs e) {
            double temp;
            if (Double.TryParse(this.txtMain.Text, out temp)) {
                this._storedWord += temp;
            }
        }
        public void BtnM_Sub_Click(object sender, EventArgs e)
        {
            double temp;
            if (Double.TryParse(this.txtMain.Text, out temp))
            {
                this._storedWord -= temp;
            }
        }
        public void BtnEquals_Click(object sender, System.EventArgs e) {
            string expression = this.txtMain.Text;
            expression = Regex.Replace(expression, "(sin|cos|tan)\u207B\u00B9", @"$1i");
            expression = Regex.Replace(expression, "\u00F7", @"/");
            expression = Regex.Replace(expression, "Mod", @"modx");
            expression = Regex.Replace(expression, "\u00D7", @"*");
            expression = Regex.Replace(expression, "Ln", @"loge");
            expression = Regex.Replace(expression, "\u221A", @"sqrt");
            expression = Regex.Replace(expression, "\u221B", @"cbrt");
            Lib.CalcEngine result = new Lib.CalcEngine();
            try
            {
                this.txtMain.Text = result.Evaluate("0" + expression);
                _ans = this.txtMain.Text;
            }
            catch (Exception ex) {
                this.txtMain.Text = ex.Message;
            }
            
        }
        public void BtnChoice_ToolTip(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                ButtonX btn = sender as ButtonX;
                this.toolTip.SetToolTip(btn,ToolTipText(btn.TooltipId));
            }
        }
        public void BtnChoice_HideToolTip(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.toolTip.RemoveAll();
                
            }
        }
        public void MenuItemCopyCut_Click(object sender, EventArgs e) {
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
        public void MenuItemPaste_Click(object sender, EventArgs e) {
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
        public void MenuItemHelp_Click(object sender, EventArgs e) {

            Help helpForm = new Help();
            helpForm.Show();
        }
        public string ToolTipText(string btn) {
            //returns tooltip text from the resource file
            ResourceManager rm = new ResourceManager("Calculator.Win.ToolTipText",Assembly.GetExecutingAssembly());
            return (rm.GetString(btn));
        }

        public void FormCalci_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                menuItemExit.PerformClick();
            }
            foreach (ButtonX btnItem in containerMain.Panel2.Controls.OfType<ButtonX>())
            {
                if (e.Modifiers == btnItem.ModifierKey)
                {
                    if (e.KeyCode == btnItem.ShortcutKey)
                    {
                        btnItem.PerformClick();
                        break;
                    }
                    continue;
                }
            }
            e.Handled = true;
            
        }
        #endregion
    }
}