﻿namespace ReferenceGenerator
{
    partial class WorkPreview
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
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.publisher = new System.Windows.Forms.TextBox();
            this.location = new System.Windows.Forms.TextBox();
            this.release = new System.Windows.Forms.TextBox();
            this.pp1 = new System.Windows.Forms.TextBox();
            this.vol = new System.Windows.Forms.NumericUpDown();
            this.no = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.site = new System.Windows.Forms.RadioButton();
            this.journal = new System.Windows.Forms.RadioButton();
            this.book = new System.Windows.Forms.RadioButton();
            this.pp2 = new System.Windows.Forms.TextBox();
            this.url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorAdd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.no)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(286, 330);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(384, 330);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(13, 13);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(100, 20);
            this.name.TabIndex = 2;
            // 
            // publisher
            // 
            this.publisher.Location = new System.Drawing.Point(12, 39);
            this.publisher.Name = "publisher";
            this.publisher.Size = new System.Drawing.Size(100, 20);
            this.publisher.TabIndex = 3;
            // 
            // location
            // 
            this.location.Location = new System.Drawing.Point(12, 65);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(100, 20);
            this.location.TabIndex = 4;
            // 
            // release
            // 
            this.release.Location = new System.Drawing.Point(12, 91);
            this.release.Name = "release";
            this.release.Size = new System.Drawing.Size(100, 20);
            this.release.TabIndex = 5;
            // 
            // pp1
            // 
            this.pp1.Location = new System.Drawing.Point(73, 253);
            this.pp1.Name = "pp1";
            this.pp1.Size = new System.Drawing.Size(63, 20);
            this.pp1.TabIndex = 6;
            this.pp1.Visible = false;
            // 
            // vol
            // 
            this.vol.Location = new System.Drawing.Point(12, 288);
            this.vol.Name = "vol";
            this.vol.Size = new System.Drawing.Size(120, 20);
            this.vol.TabIndex = 7;
            this.vol.Visible = false;
            // 
            // no
            // 
            this.no.Location = new System.Drawing.Point(12, 314);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(120, 20);
            this.no.TabIndex = 8;
            this.no.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.site);
            this.groupBox1.Controls.Add(this.journal);
            this.groupBox1.Controls.Add(this.book);
            this.groupBox1.Location = new System.Drawing.Point(13, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 95);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type";
            // 
            // site
            // 
            this.site.AutoSize = true;
            this.site.Location = new System.Drawing.Point(7, 66);
            this.site.Name = "site";
            this.site.Size = new System.Drawing.Size(43, 17);
            this.site.TabIndex = 2;
            this.site.TabStop = true;
            this.site.Text = "Site";
            this.site.UseVisualStyleBackColor = true;
            this.site.CheckedChanged += new System.EventHandler(this.site_CheckedChanged);
            // 
            // journal
            // 
            this.journal.AutoSize = true;
            this.journal.Location = new System.Drawing.Point(7, 43);
            this.journal.Name = "journal";
            this.journal.Size = new System.Drawing.Size(59, 17);
            this.journal.TabIndex = 1;
            this.journal.TabStop = true;
            this.journal.Text = "Journal";
            this.journal.UseVisualStyleBackColor = true;
            this.journal.CheckedChanged += new System.EventHandler(this.journal_CheckedChanged);
            // 
            // book
            // 
            this.book.AutoSize = true;
            this.book.Location = new System.Drawing.Point(7, 20);
            this.book.Name = "book";
            this.book.Size = new System.Drawing.Size(50, 17);
            this.book.TabIndex = 0;
            this.book.TabStop = true;
            this.book.Text = "Book";
            this.book.UseVisualStyleBackColor = true;
            this.book.CheckedChanged += new System.EventHandler(this.book_CheckedChanged);
            // 
            // pp2
            // 
            this.pp2.Location = new System.Drawing.Point(183, 253);
            this.pp2.Name = "pp2";
            this.pp2.Size = new System.Drawing.Size(59, 20);
            this.pp2.TabIndex = 10;
            this.pp2.Visible = false;
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(12, 218);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(100, 20);
            this.url.TabIndex = 11;
            this.url.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Publisher";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Release day";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Pages from";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(149, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "To";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(122, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "url";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(138, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "vol.";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(138, 316);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "no";
            this.label9.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.author});
            this.dataGridView2.Location = new System.Drawing.Point(248, 16);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(211, 257);
            this.dataGridView2.TabIndex = 21;
            // 
            // author
            // 
            this.author.HeaderText = "Author";
            this.author.Name = "author";
            this.author.ReadOnly = true;
            // 
            // authorAdd
            // 
            this.authorAdd.Location = new System.Drawing.Point(248, 280);
            this.authorAdd.Name = "authorAdd";
            this.authorAdd.Size = new System.Drawing.Size(58, 23);
            this.authorAdd.TabIndex = 22;
            this.authorAdd.Text = "Add";
            this.authorAdd.UseVisualStyleBackColor = true;
            this.authorAdd.Click += new System.EventHandler(this.authorAdd_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(323, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(401, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // WorkPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 380);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.authorAdd);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.url);
            this.Controls.Add(this.pp2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.no);
            this.Controls.Add(this.vol);
            this.Controls.Add(this.pp1);
            this.Controls.Add(this.release);
            this.Controls.Add(this.location);
            this.Controls.Add(this.publisher);
            this.Controls.Add(this.name);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Name = "WorkPreview";
            this.Text = "WorkPreview";
            ((System.ComponentModel.ISupportInitialize)(this.vol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.no)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox publisher;
        private System.Windows.Forms.TextBox location;
        private System.Windows.Forms.TextBox release;
        private System.Windows.Forms.TextBox pp1;
        private System.Windows.Forms.NumericUpDown vol;
        private System.Windows.Forms.NumericUpDown no;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton journal;
        private System.Windows.Forms.RadioButton book;
        private System.Windows.Forms.TextBox pp2;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.RadioButton site;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn author;
        private System.Windows.Forms.Button authorAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}