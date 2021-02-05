/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/1/16
 * 时间: 19:27
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace Tester
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private doticworks.GameFx.GameBox gameBox1;
		
		/// <summary>
		/// Disposes resources used by the form.
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
			this.gameBox1 = new doticworks.GameFx.GameBox();
			this.SuspendLayout();
			// 
			// gameBox1
			// 
			this.gameBox1.BackColor = System.Drawing.Color.DimGray;
			this.gameBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.gameBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gameBox1.Font = new System.Drawing.Font("Segoe UI Symbol", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gameBox1.Location = new System.Drawing.Point(0, 0);
			this.gameBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gameBox1.Name = "gameBox1";
			this.gameBox1.Size = new System.Drawing.Size(531, 169);
			this.gameBox1.TabIndex = 0;
			this.gameBox1.Click += new System.EventHandler(this.GameBox1Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ClientSize = new System.Drawing.Size(531, 169);
			this.Controls.Add(this.gameBox1);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tester";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
			this.Shown += new System.EventHandler(this.MainFormShown);
			this.ResumeLayout(false);

		}
	}
}
