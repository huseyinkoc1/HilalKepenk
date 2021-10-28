
namespace HilalKepenk.Formlar
{
    partial class FrmGiderler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGiderler));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.lblControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.txtTutar = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtAciklama = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtTarih = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tBLGIDERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBHilalKepenkDataSet12 = new HilalKepenk.DBHilalKepenkDataSet12();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGIDERID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGIDERACIKLAMA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tBLGIDERTableAdapter = new HilalKepenk.DBHilalKepenkDataSet12TableAdapters.TBLGIDERTableAdapter();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarih.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLGIDERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBHilalKepenkDataSet12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(117, 218);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(271, 22);
            this.txtId.TabIndex = 22;
            // 
            // lblControl1
            // 
            this.lblControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.lblControl1.Appearance.Options.UseFont = true;
            this.lblControl1.Location = new System.Drawing.Point(56, 220);
            this.lblControl1.Name = "lblControl1";
            this.lblControl1.Size = new System.Drawing.Size(54, 17);
            this.lblControl1.TabIndex = 21;
            this.lblControl1.Text = "Gider ID:\r\n";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnGuncelle.Appearance.Options.UseFont = true;
            this.btnGuncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuncelle.ImageOptions.Image")));
            this.btnGuncelle.Location = new System.Drawing.Point(117, 587);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(271, 55);
            this.btnGuncelle.TabIndex = 19;
            this.btnGuncelle.Text = "GÜNCELLE";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSil.Appearance.Options.UseFont = true;
            this.btnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.ImageOptions.Image")));
            this.btnSil.Location = new System.Drawing.Point(117, 510);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(271, 55);
            this.btnSil.TabIndex = 18;
            this.btnSil.Text = "SİL";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ImageOptions.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(117, 434);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(271, 55);
            this.btnKaydet.TabIndex = 9;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(117, 329);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Properties.BeepOnError = false;
            this.txtTutar.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtTutar.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.txtTutar.Properties.MaskSettings.Set("mask", "n");
            this.txtTutar.Properties.UseMaskAsDisplayFormat = true;
            this.txtTutar.Size = new System.Drawing.Size(271, 22);
            this.txtTutar.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(72, 331);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(38, 17);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Tutar:";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(117, 255);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(271, 22);
            this.txtAciklama.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(53, 257);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 17);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Açıklama:";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.txtTarih);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtId);
            this.groupControl1.Controls.Add(this.lblControl1);
            this.groupControl1.Controls.Add(this.btnGuncelle);
            this.groupControl1.Controls.Add(this.btnSil);
            this.groupControl1.Controls.Add(this.btnKaydet);
            this.groupControl1.Controls.Add(this.txtTutar);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtAciklama);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(1465, -4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(431, 741);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "ÜRÜN İŞLEMLERİ";
            // 
            // txtTarih
            // 
            this.txtTarih.Location = new System.Drawing.Point(117, 292);
            this.txtTarih.Name = "txtTarih";
            this.txtTarih.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtTarih.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txtTarih.Properties.Appearance.Options.UseBackColor = true;
            this.txtTarih.Properties.Appearance.Options.UseForeColor = true;
            this.txtTarih.Properties.BeepOnError = false;
            this.txtTarih.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.DateTimeMaskManager));
            this.txtTarih.Properties.MaskSettings.Set("mask", "d");
            this.txtTarih.Size = new System.Drawing.Size(271, 22);
            this.txtTarih.TabIndex = 23;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(76, 293);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(35, 17);
            this.labelControl2.TabIndex = 24;
            this.labelControl2.Text = "Tarih:";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tBLGIDERBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(7, -4);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1452, 760);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tBLGIDERBindingSource
            // 
            this.tBLGIDERBindingSource.DataMember = "TBLGIDER";
            this.tBLGIDERBindingSource.DataSource = this.dBHilalKepenkDataSet12;
            // 
            // dBHilalKepenkDataSet12
            // 
            this.dBHilalKepenkDataSet12.DataSetName = "DBHilalKepenkDataSet12";
            this.dBHilalKepenkDataSet12.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.gridView1.Appearance.Row.BorderColor = System.Drawing.Color.Gray;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseBorderColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGIDERID,
            this.colGIDERACIKLAMA,
            this.colTARIH,
            this.colTUTAR});
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            formatConditionRuleValue1.Appearance.Options.UseFont = true;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colGIDERID
            // 
            this.colGIDERID.FieldName = "GIDERID";
            this.colGIDERID.MinWidth = 25;
            this.colGIDERID.Name = "colGIDERID";
            this.colGIDERID.Visible = true;
            this.colGIDERID.VisibleIndex = 0;
            this.colGIDERID.Width = 94;
            // 
            // colGIDERACIKLAMA
            // 
            this.colGIDERACIKLAMA.FieldName = "GIDERACIKLAMA";
            this.colGIDERACIKLAMA.MinWidth = 25;
            this.colGIDERACIKLAMA.Name = "colGIDERACIKLAMA";
            this.colGIDERACIKLAMA.Visible = true;
            this.colGIDERACIKLAMA.VisibleIndex = 1;
            this.colGIDERACIKLAMA.Width = 94;
            // 
            // colTARIH
            // 
            this.colTARIH.FieldName = "TARIH";
            this.colTARIH.MinWidth = 25;
            this.colTARIH.Name = "colTARIH";
            this.colTARIH.Visible = true;
            this.colTARIH.VisibleIndex = 2;
            this.colTARIH.Width = 94;
            // 
            // colTUTAR
            // 
            this.colTUTAR.FieldName = "TUTAR";
            this.colTUTAR.MinWidth = 25;
            this.colTUTAR.Name = "colTUTAR";
            this.colTUTAR.Visible = true;
            this.colTUTAR.VisibleIndex = 3;
            this.colTUTAR.Width = 94;
            // 
            // tBLGIDERTableAdapter
            // 
            this.tBLGIDERTableAdapter.ClearBeforeFill = true;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(117, 662);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(271, 55);
            this.simpleButton1.TabIndex = 25;
            this.simpleButton1.Text = "YAZDIR";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FrmGiderler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 753);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmGiderler";
            this.Text = "FrmGiderler";
            this.Load += new System.EventHandler(this.FrmGiderler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTutar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTarih.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLGIDERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBHilalKepenkDataSet12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.LabelControl lblControl1;
        private DevExpress.XtraEditors.SimpleButton btnGuncelle;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.TextEdit txtTutar;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtAciklama;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DBHilalKepenkDataSet12 dBHilalKepenkDataSet12;
        private System.Windows.Forms.BindingSource tBLGIDERBindingSource;
        private DBHilalKepenkDataSet12TableAdapters.TBLGIDERTableAdapter tBLGIDERTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colGIDERID;
        private DevExpress.XtraGrid.Columns.GridColumn colGIDERACIKLAMA;
        private DevExpress.XtraGrid.Columns.GridColumn colTARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTAR;
        private DevExpress.XtraEditors.TextEdit txtTarih;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}