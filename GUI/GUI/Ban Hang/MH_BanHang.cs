﻿using System;
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
    public partial class MH_BanHang : Form
    {
        private byte tab_count;
        public MH_BanHang()
        {
            InitializeComponent();
            tabControl1.DrawItem += TabControl1_DrawItem;
            tab_count = 1;
        }
        
   
        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
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

        /// <summary>
        /// Cài đặt size cho màn hình
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MH_BanHang_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1290, 695);
        }

        /// <summary>
        /// Thêm tab hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            TabPage new_tab = new TabPage();
            this.tabcontrl_hoadon.TabPages.Add(new_tab);
            new_tab.Text = "Hóa đơn " + ++tab_count;
            SetNewtab(new_tab, "tabpage_BH_hd" + tab_count);
        }

        /// <summary>
        /// Cài đặt thuộc tính cho new tab
        /// </summary>
        private void SetNewtab(TabPage new_tab, String tab_name)
        {
            new_tab.Location = new System.Drawing.Point(4, 38);
            new_tab.Name = tab_name;
            new_tab.Padding = new System.Windows.Forms.Padding(3);
            new_tab.Size = new System.Drawing.Size(899, 590);
            new_tab.UseVisualStyleBackColor = true;
            new_tab.Show();
            ListView new_lst_hoadon = new ListView();
            new_tab.Controls.Add(new_lst_hoadon);
            SetListHD(new_lst_hoadon);
        }

        private void SetListHD(ListView lst_hoadon)
        {
            lst_hoadon.Columns.Add("STT", 70, HorizontalAlignment.Center);
            lst_hoadon.Columns.Add("Mã sp", 100);
            lst_hoadon.Columns.Add("Tên sp", 160, HorizontalAlignment.Center);
            lst_hoadon.Columns.Add("SL", 70, HorizontalAlignment.Center);
            lst_hoadon.Columns.Add("Đơn giá", 140, HorizontalAlignment.Center);
            lst_hoadon.Columns.Add("Thành tiền", 140, HorizontalAlignment.Center);
            lst_hoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lst_hoadon.HideSelection = false;
            lst_hoadon.Location = new System.Drawing.Point(-1, 0);
            lst_hoadon.Name = "lst_hoadon";
            lst_hoadon.Size = new System.Drawing.Size(903, 590);
            lst_hoadon.UseCompatibleStateImageBehavior = false;
            lst_hoadon.View = System.Windows.Forms.View.Details;

        }
    }

        
    
}
