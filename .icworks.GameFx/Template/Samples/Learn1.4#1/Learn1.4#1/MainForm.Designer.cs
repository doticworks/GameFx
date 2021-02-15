/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2021/2/15
 * 时间: 20:48
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace Learn1.__1
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.gamebox1 = new doticworks.GameFx.GameBox();
			this.SuspendLayout();
			// 
			// gamebox1
			// 
			this.gamebox1.BackColor = System.Drawing.Color.Black;
			this.gamebox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gamebox1.BackgroundImage")));
			this.gamebox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.gamebox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gamebox1.Font = new System.Drawing.Font("Segoe UI Symbol", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gamebox1.Location = new System.Drawing.Point(0, 0);
			this.gamebox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gamebox1.Name = "gamebox1";
			this.gamebox1.Size = new System.Drawing.Size(994, 446);
			this.gamebox1.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(994, 446);
			this.Controls.Add(this.gamebox1);
			this.Name = "MainForm";
			this.Text = "Learn1.4#1";
			this.ResumeLayout(false);

		}

		private doticworks.GameFx.GameBox gamebox1;
	}
}
