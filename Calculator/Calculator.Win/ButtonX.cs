using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator.Win
{
    class ButtonX : System.Windows.Forms.Button 
    {
        private Keys _shortcutKey;
        private Keys _modifierKey;
        private string _tooltipID;
        private string _appendText;

        public ButtonX() {
            this.Size = new System.Drawing.Size(50, 40);
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }
        public Keys ShortcutKey {
            get { return _shortcutKey; }
            set { _shortcutKey = value; }
                }

        public Keys ModifierKey {
            get { return _modifierKey; }
            set { if (value == Keys.Shift || value == Keys.Control || value == Keys.Alt || value== Keys.None)
                {
                    _modifierKey = value;
                }
                else {
                    throw new Exception("Invalid Value of Modifier Key");
                }
            }
        }
        public string AppendText {
            get { return _appendText; }
            set { _appendText = value; }
        }
        public string TooltipId {
            get { return _tooltipID; }
            set { _tooltipID = value; }
        }
        
        
    }
}
