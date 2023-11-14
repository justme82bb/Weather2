namespace Weather2
{
    partial class Form2
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
            buttonLoadWeather = new Button();
            dataGridRaport = new DataGridView();
            dateTimeFrom = new DateTimePicker();
            dateTimeTo = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridRaport).BeginInit();
            SuspendLayout();
            // 
            // buttonLoadWeather
            // 
            buttonLoadWeather.Location = new Point(1084, 217);
            buttonLoadWeather.Name = "buttonLoadWeather";
            buttonLoadWeather.Size = new Size(141, 23);
            buttonLoadWeather.TabIndex = 0;
            buttonLoadWeather.Text = "Wczytaj dane";
            buttonLoadWeather.UseVisualStyleBackColor = true;
            buttonLoadWeather.Click += buttonLoadWeather_Click;
            // 
            // dataGridRaport
            // 
            dataGridRaport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridRaport.Location = new Point(12, 12);
            dataGridRaport.Name = "dataGridRaport";
            dataGridRaport.RowTemplate.Height = 25;
            dataGridRaport.Size = new Size(601, 426);
            dataGridRaport.TabIndex = 1;
            // 
            // dateTimeFrom
            // 
            dateTimeFrom.Location = new Point(1025, 159);
            dateTimeFrom.Name = "dateTimeFrom";
            dateTimeFrom.Size = new Size(200, 23);
            dateTimeFrom.TabIndex = 2;
            // 
            // dateTimeTo
            // 
            dateTimeTo.Location = new Point(1025, 188);
            dateTimeTo.Name = "dateTimeTo";
            dateTimeTo.Size = new Size(200, 23);
            dateTimeTo.TabIndex = 3;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1237, 623);
            Controls.Add(dateTimeTo);
            Controls.Add(dateTimeFrom);
            Controls.Add(dataGridRaport);
            Controls.Add(buttonLoadWeather);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridRaport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonLoadWeather;
        private DataGridView dataGridRaport;
        private DateTimePicker dateTimeFrom;
        private DateTimePicker dateTimeTo;
    }
}