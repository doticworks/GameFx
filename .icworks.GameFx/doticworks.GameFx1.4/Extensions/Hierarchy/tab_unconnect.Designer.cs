/*
 * 由SharpDevelop创建。
 * 用户： DELL
 * 日期: 2021/2/4
 * 时间: Go home day！ 10:30
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace Hierarchy
{
	partial class tab_unconnect
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label labtitle;
		private System.Windows.Forms.Label labtitleline;
		private System.Windows.Forms.Label labtip;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.labtitle = new System.Windows.Forms.Label();
			this.labtitleline = new System.Windows.Forms.Label();
			this.labtip = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labtitle
			// 
			this.labtitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labtitle.Font = new System.Drawing.Font("Segoe UI", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labtitle.ForeColor = System.Drawing.Color.DarkGray;
			this.labtitle.Location = new System.Drawing.Point(464, 315);
			this.labtitle.Name = "labtitle";
			this.labtitle.Size = new System.Drawing.Size(269, 76);
			this.labtitle.TabIndex = 0;
			this.labtitle.Text = "Hierarchy";
			// 
			// labtitleline
			// 
			this.labtitleline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labtitleline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.labtitleline.Location = new System.Drawing.Point(470, 334);
			this.labtitleline.Name = "labtitleline";
			this.labtitleline.Size = new System.Drawing.Size(2, 65);
			this.labtitleline.TabIndex = 1;
			// 
			// labtip
			// 
			this.labtip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labtip.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labtip.ForeColor = System.Drawing.Color.DarkGray;
			this.labtip.Location = new System.Drawing.Point(476, 380);
			this.labtip.Name = "labtip";
			this.labtip.Size = new System.Drawing.Size(187, 22);
			this.labtip.TabIndex = 2;
			this.labtip.Text = "Unconnected to GameFx";
			// 
			// tab_unconnect
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.Controls.Add(this.labtip);
			this.Controls.Add(this.labtitleline);
			this.Controls.Add(this.labtitle);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "tab_unconnect";
			this.Size = new System.Drawing.Size(764, 442);
			this.ResumeLayout(false);

		}
	}
}
