using ProxmarkInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxmarkUI
{
    public partial class MainForm : Form
    {
        static readonly char[] hexChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', ' ' };
        IProxmarkLibImport import = ProxmarkLibImport.Select();
        public MainForm()
        {
            InitializeComponent();
        }

        private void printResult(string result)
        {
            textBoxResult.Text = textBoxResult.Text + result + System.Environment.NewLine;
        }

        private void buttonGetMACReader_Click(object sender, EventArgs e)
        {
            string csnString = textBoxCSN.Text.Replace(" ", "");
            string keyString = textBoxKey.Text.Replace(" ", "");
            string ccString = textBoxCC.Text.Replace(" ", "");
            string nrString = textBoxNR.Text.Replace(" ", "");


            //import.ProcessData(1, 10, s => textBox1.Text = s);
            if (csnString.Length != 0 && csnString.Length != 16)
            {
                showInputLengthErrorMessage("16", "CNC");
                return;
            }
            if (keyString.Length != 0 && keyString.Length != 16)
            {
                showInputLengthErrorMessage("16", "KEY");
                return;
            }
            if (ccString.Length != 0 && ccString.Length != 16)
            {
                showInputLengthErrorMessage("16", "CC");
                return;
            }
            if (nrString.Length != 0 && nrString.Length != 8)
            {
                showInputLengthErrorMessage("8", "NR");
                return;
            }
            byte[] key = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] csn = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] ccNr = new byte[12] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            
            HexHelper.FillArrayFromString(csnString, ref csn);
            HexHelper.FillArrayFromString(keyString, ref key);            
            HexHelper.FillArrayFromString(ccString, ref ccNr);
            HexHelper.FillArrayFromString(nrString, ref ccNr, 8);
           

            import.ComputeReaderMAC(key, csn, ccNr, s => printResult(s));
        }
        private void showInputLengthErrorMessage(string len, string property)
        {
            string mess = property + " length must be " + len;
            MessageBox.Show(mess, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBoxHexNums_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (!hexChars.Contains(Char.ToUpper(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
        }

        private void buttonGetCRC_Click(object sender, EventArgs e)
        {
            string mess;// = property + " length must be " + len;
            if (textBoxDataForCRC.Text.Length == 0)
            {
                mess = "Data for CRC can't be less than 1 byte";
                MessageBox.Show(mess, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((textBoxDataForCRC.Text.Length % 2) != 0)
            {
                mess = "Data for CRC must be even";
                MessageBox.Show(mess, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                byte[] data = new byte[(textBoxDataForCRC.Text.Length / 2)];
                //byte[] data = Encoding.ASCII.GetBytes(textBoxDataForCRC.Text);
                HexHelper.FillArrayFromString(textBoxDataForCRC.Text, ref data);
                import.ComputeCRC(data, data.Length, s => printResult(s));
            }
        }

        private void encryptDecriptBlock(int mode)
        {
            string dataString = textBoxDataForEncrypt.Text.Replace(" ", "");
            if (dataString.Length != 0 && dataString.Length != 16)
            {
                showInputLengthErrorMessage("16", "Data for encrypt");
                return;
            }
            byte[] data = new byte[(dataString.Length / 2)];
            byte[] key = { 0 };
            HexHelper.FillArrayFromString(dataString, ref data);
            import.EncryptBlock(data, key, mode, s => printResult(s));
        }

        private void buttonEncryptBlock_Click(object sender, EventArgs e)
        {
            encryptDecriptBlock(1);
        }

        private void buttonDecryptBlock_Click(object sender, EventArgs e)
        {
            encryptDecriptBlock(0);
        }

        private void buttonGetMAC_Click(object sender, EventArgs e)
        {
            string divKeyString = textBoxDivKey.Text.Replace(" ", "");
            string dataString = textBoxDataForMAC.Text.Replace(" ", "");

            if (divKeyString.Length != 0 && divKeyString.Length != 16)
            {
                showInputLengthErrorMessage("16", "KEY");
                return;
            }
            int isOptimize = 0;
            
            if (checkBoxOptimizeMAC.Checked == true)
            {
                isOptimize = 1;
                if (dataString.Length < 24)
                {
                    string mess = "Data for MAC length must be 24: 16 - cc and 8 - NR!";
                    MessageBox.Show(mess, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            byte[] divKey = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            HexHelper.FillArrayFromString(divKeyString, ref divKey);
            byte[] data = new byte[(dataString.Length / 2)];
            HexHelper.FillArrayFromString(dataString, ref data);
            import.ComputeMAC(divKey, data, data.Length,isOptimize, s => printResult(s));
        }

        private void buttonGetMACTag_Click(object sender, EventArgs e)
        {
            string csnString = textBoxCSN.Text.Replace(" ", "");
            string keyString = textBoxKey.Text.Replace(" ", "");
            string ccString = textBoxCC.Text.Replace(" ", "");
            string nrString = textBoxNR.Text.Replace(" ", "");

            if (csnString.Length != 0 && csnString.Length != 16)
            {
                showInputLengthErrorMessage("16", "CNC");
                return;
            }
            if (keyString.Length != 0 && keyString.Length != 16)
            {
                showInputLengthErrorMessage("16", "KEY");
                return;
            }
            if (ccString.Length != 0 && ccString.Length != 16)
            {
                showInputLengthErrorMessage("16", "CC");
                return;
            }
            if (nrString.Length != 0 && nrString.Length != 8)
            {
                showInputLengthErrorMessage("8", "NR");
                return;
            }
            const int dataLength = 8 + 8 + 8 + 4;
            byte[] data = new byte[dataLength];            

            HexHelper.FillArrayFromString(keyString, ref data);
            HexHelper.FillArrayFromString(csnString, ref data, 8);
            HexHelper.FillArrayFromString(ccString, ref data,  8+8);
            HexHelper.FillArrayFromString(nrString, ref data,  8+8+8);

            import.ComputeMAC(new byte[8], data, data.Length, 1, s => printResult(s));

        }

        private void buttonClearResultList_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "";
        }
    }
}
