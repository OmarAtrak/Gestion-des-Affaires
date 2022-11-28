
namespace GestionAffaire
{
    partial class FraisForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FraisForm));
            this.BoxFrais = new System.Windows.Forms.GroupBox();
            this.btnSupprimerFrais = new System.Windows.Forms.Button();
            this.cmbNumeroFrais = new System.Windows.Forms.ComboBox();
            this.btnAjouterFrais = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFraisFrais = new System.Windows.Forms.TextBox();
            this.txtDateFrais = new System.Windows.Forms.DateTimePicker();
            this.label40 = new System.Windows.Forms.Label();
            this.cmbPCFrais = new System.Windows.Forms.ComboBox();
            this.cmbTypeFrais = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.BoxFrais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // BoxFrais
            // 
            this.BoxFrais.BackColor = System.Drawing.Color.LightGray;
            this.BoxFrais.Controls.Add(this.btnSupprimerFrais);
            this.BoxFrais.Controls.Add(this.cmbNumeroFrais);
            this.BoxFrais.Controls.Add(this.btnAjouterFrais);
            this.BoxFrais.Controls.Add(this.label2);
            this.BoxFrais.Controls.Add(this.txtFraisFrais);
            this.BoxFrais.Controls.Add(this.txtDateFrais);
            this.BoxFrais.Controls.Add(this.label40);
            this.BoxFrais.Controls.Add(this.cmbPCFrais);
            this.BoxFrais.Controls.Add(this.cmbTypeFrais);
            this.BoxFrais.Controls.Add(this.label6);
            this.BoxFrais.Controls.Add(this.label7);
            this.BoxFrais.Controls.Add(this.label8);
            this.BoxFrais.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxFrais.Location = new System.Drawing.Point(40, 43);
            this.BoxFrais.Name = "BoxFrais";
            this.BoxFrais.Size = new System.Drawing.Size(864, 195);
            this.BoxFrais.TabIndex = 26;
            this.BoxFrais.TabStop = false;
            this.BoxFrais.Text = "Saisir Les Donnees :";
            // 
            // btnSupprimerFrais
            // 
            this.btnSupprimerFrais.BackColor = System.Drawing.SystemColors.Control;
            this.btnSupprimerFrais.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimerFrais.Location = new System.Drawing.Point(670, 17);
            this.btnSupprimerFrais.Name = "btnSupprimerFrais";
            this.btnSupprimerFrais.Size = new System.Drawing.Size(159, 38);
            this.btnSupprimerFrais.TabIndex = 22;
            this.btnSupprimerFrais.Text = "Supprimer";
            this.btnSupprimerFrais.UseVisualStyleBackColor = false;
            // 
            // cmbNumeroFrais
            // 
            this.cmbNumeroFrais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNumeroFrais.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNumeroFrais.FormattingEnabled = true;
            this.cmbNumeroFrais.Location = new System.Drawing.Point(195, 17);
            this.cmbNumeroFrais.Name = "cmbNumeroFrais";
            this.cmbNumeroFrais.Size = new System.Drawing.Size(418, 28);
            this.cmbNumeroFrais.TabIndex = 21;
            // 
            // btnAjouterFrais
            // 
            this.btnAjouterFrais.BackColor = System.Drawing.SystemColors.Control;
            this.btnAjouterFrais.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouterFrais.Location = new System.Drawing.Point(670, 61);
            this.btnAjouterFrais.Name = "btnAjouterFrais";
            this.btnAjouterFrais.Size = new System.Drawing.Size(159, 38);
            this.btnAjouterFrais.TabIndex = 18;
            this.btnAjouterFrais.Text = "Ajouter";
            this.btnAjouterFrais.UseVisualStyleBackColor = false;
            this.btnAjouterFrais.Click += new System.EventHandler(this.btnAjouterFrais_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Numero de Frais :";
            // 
            // txtFraisFrais
            // 
            this.txtFraisFrais.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFraisFrais.Location = new System.Drawing.Point(195, 127);
            this.txtFraisFrais.Name = "txtFraisFrais";
            this.txtFraisFrais.Size = new System.Drawing.Size(418, 26);
            this.txtFraisFrais.TabIndex = 17;
            this.txtFraisFrais.Text = "0.00";
            // 
            // txtDateFrais
            // 
            this.txtDateFrais.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateFrais.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDateFrais.Location = new System.Drawing.Point(195, 164);
            this.txtDateFrais.Name = "txtDateFrais";
            this.txtDateFrais.Size = new System.Drawing.Size(418, 26);
            this.txtDateFrais.TabIndex = 16;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(116, 169);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(52, 20);
            this.label40.TabIndex = 15;
            this.label40.Text = "Date :";
            // 
            // cmbPCFrais
            // 
            this.cmbPCFrais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPCFrais.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPCFrais.FormattingEnabled = true;
            this.cmbPCFrais.Items.AddRange(new object[] {
            "Bon",
            "Facture",
            "Ticket",
            "Sans"});
            this.cmbPCFrais.Location = new System.Drawing.Point(195, 89);
            this.cmbPCFrais.Name = "cmbPCFrais";
            this.cmbPCFrais.Size = new System.Drawing.Size(418, 28);
            this.cmbPCFrais.TabIndex = 11;
            this.cmbPCFrais.SelectedIndexChanged += new System.EventHandler(this.cmbPCFrais_SelectedIndexChanged);
            // 
            // cmbTypeFrais
            // 
            this.cmbTypeFrais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeFrais.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTypeFrais.FormattingEnabled = true;
            this.cmbTypeFrais.Location = new System.Drawing.Point(195, 51);
            this.cmbTypeFrais.Name = "cmbTypeFrais";
            this.cmbTypeFrais.Size = new System.Drawing.Size(418, 28);
            this.cmbTypeFrais.TabIndex = 10;
            this.cmbTypeFrais.SelectedIndexChanged += new System.EventHandler(this.cmbTypeFrais_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(117, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Type :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(116, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Frais :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Piece Comptable :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FraisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1280, 618);
            this.Controls.Add(this.BoxFrais);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FraisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FraisForm";
            this.Load += new System.EventHandler(this.FraisForm_Load);
            this.BoxFrais.ResumeLayout(false);
            this.BoxFrais.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox BoxFrais;
        private System.Windows.Forms.ComboBox cmbNumeroFrais;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFraisFrais;
        private System.Windows.Forms.DateTimePicker txtDateFrais;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ComboBox cmbPCFrais;
        private System.Windows.Forms.ComboBox cmbTypeFrais;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAjouterFrais;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnSupprimerFrais;
    }
}