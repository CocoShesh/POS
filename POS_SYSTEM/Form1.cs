using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_SYSTEM
{
    public partial class Form1 : Form
     {
        public Form1()
        {
            InitializeComponent();
        }

        public double Cost_of_Items()
        {
            Double sum = 0;
            int i = 0;

            for (i = 0; i < dataView.Rows.Count;
            i++)
                {
                sum = sum + Convert.ToDouble(dataView.Rows[i].Cells[2].Value);
            }
            return sum;
                 
        }
        private void AddCost()
        {
            Double tax, q;
            tax = 3.9;
            if(dataView.Rows.Count >0)
            {
                lblTax.Text = String.Format("{0:c2}", (((Cost_of_Items() * tax) / 100)));
                lblSubTotal.Text = String.Format("{0:c2}", (Cost_of_Items()));
                q = ((Cost_of_Items() * tax )/ 100);
                lblTotal.Text = String.Format("{0:c2}", ((Cost_of_Items() + q)));
            }
        }

        private void Change()

        {
            Double tax, q, c;
            tax = 3.9;
            if (dataView.Rows.Count > 0)
            {
                q = ((Cost_of_Items() * tax) / 100)+ Cost_of_Items();
                c = Convert.ToInt32(lblCash.Text);
                lblChange.Text = String.Format("{0:c2}", c - q);
            }
        }


        Bitmap bmp;
        

        private void button3_Click(object sender, EventArgs e)
        {
            dataView.Rows.Clear();
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           

            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            int height = dataView.Height;
            dataView.Height = dataView.RowCount * dataView.RowTemplate.Height * 2;
            bmp = new Bitmap(dataView.Width, dataView.Height);
            dataView.DrawToBitmap(bmp, new Rectangle(0, 0, dataView.Width, dataView.Height));
            dataView.Height = Height;
            printPreviewDialog1.ShowDialog();
            printPreviewDialog1.PrintPreviewControl.Zoom = 2;
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            cboPayment.Items.Add("Cash");
            cboPayment.Items.Add("Credit Card");
            cboPayment.Items.Add("Gcash");
        }

        
        private void NumbersOnly(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (lblCash.Text == "0")
            {
                lblCash.Text = "";
                lblCash.Text = b.Text;
            }
            else if (b.Text == ("."))

            {
                if (!lblCash.Text.Contains("."))
                {
                    lblCash.Text = lblCash.Text + b.Text;
                }
            }
            else
                lblCash.Text = lblCash.Text + b.Text;

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if(cboPayment.Text =="Cash")
            {
                Change();
            }
            else
            {
                lblChange.Text = "";
                lblCash.Text = "0";
            }
        }

       

        private void btnGatorade_Click(object sender, EventArgs e)
        {
            Double CostofItem = 38.75;
            foreach (DataGridViewRow row in this.dataView.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Gatorade"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                    AddCost();
                }

            }
            dataView.Rows.Add("Gatorade", "1", CostofItem);
            AddCost();


        }

       
        private void btnReset_Click(object sender, EventArgs e)
        {
            lblCash.Text = "0";
            lblChange.Text = "";
            lblSubTotal.Text = "";
            lblTax.Text = "";
            lblTotal.Text = "";
            dataView.Rows.Clear();
            dataView.Refresh();
            cboPayment.Text = "";

        }

        private void btnC_Click(object sender, EventArgs e)
        {
            lblCash.Text = "0";

        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in this.dataView.SelectedRows)
            {
                dataView.Rows.Remove(row);

            }
            AddCost();
            if (cboPayment.Text == "Cash")
            {
                Change();
            }
            else
            {
                lblChange.Text = "";
                lblCash.Text = "0";
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Double CostofItem = 23.25;
            foreach (DataGridViewRow row in this.dataView.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Coca-Cola"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                    AddCost();
                }

            }
            dataView.Rows.Add("Cola-Cola", "1", CostofItem);
            AddCost();

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

            Double CostofItem = 21.50;
            foreach (DataGridViewRow row in this.dataView.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Pepsi"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                    AddCost();
                }

            }
            dataView.Rows.Add("Pepsi", "1", CostofItem);
            AddCost();

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

            Double CostofItem = 22.25;
            foreach (DataGridViewRow row in this.dataView.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Mirinda"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                    AddCost();
                }

            }
            dataView.Rows.Add("Mirinda", "1", CostofItem);
            AddCost();

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

            Double CostofItem = 21.75;
            foreach (DataGridViewRow row in this.dataView.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "Mountain Dew"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItem;
                    AddCost();
                }

            }
            dataView.Rows.Add("Mountain Dew", "1", CostofItem);
            AddCost();

        }
    }
}
