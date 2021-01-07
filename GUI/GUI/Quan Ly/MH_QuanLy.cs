using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MH_QuanLy : Form
    {
        public MH_QuanLy()
        {
            InitializeComponent();
            LoadPanelTop10KH();
        }
        
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", 16.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void MH_QuanLy_Load(object sender, EventArgs e)
        {
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            MH_BanHang mh = new MH_BanHang();
            mh.Show();
        }
        /// <summary>
        /// Tao panel và content trong panel top 10 KH 
        /// </summary>
        private void LoadPanelTop10KH()
        {
            //pnl_top10KH
            Panel pnl_top10KH = new Panel();
            this.pnl_bieudo.Controls.Add(pnl_top10KH);
            pnl_top10KH.Location = new Point(0, 942);
            pnl_top10KH.Size = new Size(698, 465);
            pnl_top10KH.BackColor = Color.LightGray;
            //lb_top10KH
            Label lb_top10KH = new Label();
            pnl_top10KH.Controls.Add(lb_top10KH);
            lb_top10KH.Text = "Top 10 khách hàng mua nhiều nhất";
            lb_top10KH.Location = new Point(3, 4);
            lb_top10KH.AutoSize = true;
            //cbx_top10KH
            ComboBox cbx_top10KH = new ComboBox();
            pnl_top10KH.Controls.Add(cbx_top10KH);
            cbx_top10KH.Location = new Point(583, 0);
            cbx_top10KH.Size = new Size(115, 30);
            cbx_top10KH.Text = "Tháng này";
            cbx_top10KH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //chrt_top10KH
            System.Windows.Forms.DataVisualization.Charting.Chart chrt_top10KH = new System.Windows.Forms.DataVisualization.Charting.Chart();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            chartArea3.Name = "ChartArea1";
            chrt_top10KH.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chrt_top10KH.Legends.Add(legend3);
            chrt_top10KH.Location = new Point(6, 36);
            chrt_top10KH.Size = new Size(687, 417);
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chrt_top10KH.Series.Add(series3);
            chrt_top10KH.Name = "Top10KH";
            pnl_top10KH.Controls.Add(chrt_top10KH);
        }
    }
}
