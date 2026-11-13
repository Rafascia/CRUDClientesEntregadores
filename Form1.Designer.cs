namespace CRUDClientesEntregadores
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cLIENTESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eNTREGADORESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sAIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cLIENTESToolStripMenuItem,
            this.eNTREGADORESToolStripMenuItem,
            this.sAIRToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cLIENTESToolStripMenuItem
            // 
            this.cLIENTESToolStripMenuItem.Name = "cLIENTESToolStripMenuItem";
            this.cLIENTESToolStripMenuItem.Size = new System.Drawing.Size(102, 29);
            this.cLIENTESToolStripMenuItem.Text = "CLIENTES";
            this.cLIENTESToolStripMenuItem.Click += new System.EventHandler(this.cLIENTESToolStripMenuItem_Click);
            // 
            // eNTREGADORESToolStripMenuItem
            // 
            this.eNTREGADORESToolStripMenuItem.Name = "eNTREGADORESToolStripMenuItem";
            this.eNTREGADORESToolStripMenuItem.Size = new System.Drawing.Size(160, 29);
            this.eNTREGADORESToolStripMenuItem.Text = "ENTREGADORES";
            // 
            // sAIRToolStripMenuItem
            // 
            this.sAIRToolStripMenuItem.Name = "sAIRToolStripMenuItem";
            this.sAIRToolStripMenuItem.Size = new System.Drawing.Size(66, 29);
            this.sAIRToolStripMenuItem.Text = "SAIR";
            this.sAIRToolStripMenuItem.Click += new System.EventHandler(this.sAIRToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cLIENTESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eNTREGADORESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sAIRToolStripMenuItem;
    }
}

