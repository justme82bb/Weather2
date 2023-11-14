namespace Weather2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ButtonGetCities = new Button();
            label1 = new Label();
            labelLog = new Label();
            dataGridView1 = new DataGridView();
            ButtonGetWeather = new Button();
            label2 = new Label();
            buttonGetApi = new Button();
            buttonSave = new Button();
            buttonRaport = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // ButtonGetCities
            // 
            ButtonGetCities.Location = new Point(691, 27);
            ButtonGetCities.Name = "ButtonGetCities";
            ButtonGetCities.Size = new Size(97, 23);
            ButtonGetCities.TabIndex = 0;
            ButtonGetCities.Text = "Aktualizacja";
            ButtonGetCities.UseVisualStyleBackColor = true;
            ButtonGetCities.Click += ButtonGetCities_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(691, 9);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 1;
            label1.Text = "Miasta";
            // 
            // labelLog
            // 
            labelLog.AutoSize = true;
            labelLog.Location = new Point(12, 426);
            labelLog.Name = "labelLog";
            labelLog.Size = new Size(38, 15);
            labelLog.TabIndex = 2;
            labelLog.Text = "label2";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(673, 426);
            dataGridView1.TabIndex = 3;
            // 
            // ButtonGetWeather
            // 
            ButtonGetWeather.Location = new Point(691, 232);
            ButtonGetWeather.Name = "ButtonGetWeather";
            ButtonGetWeather.Size = new Size(95, 23);
            ButtonGetWeather.TabIndex = 4;
            ButtonGetWeather.Text = "Pobierz miasta";
            ButtonGetWeather.UseVisualStyleBackColor = true;
            ButtonGetWeather.Click += ButtonGetWeather_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(691, 214);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 5;
            label2.Text = "Pogoda";
            // 
            // buttonGetApi
            // 
            buttonGetApi.Location = new Point(691, 261);
            buttonGetApi.Name = "buttonGetApi";
            buttonGetApi.Size = new Size(97, 23);
            buttonGetApi.TabIndex = 6;
            buttonGetApi.Text = "API";
            buttonGetApi.UseVisualStyleBackColor = true;
            buttonGetApi.Click += buttonGetApi_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(691, 301);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(97, 23);
            buttonSave.TabIndex = 7;
            buttonSave.Text = "Zapisz";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonRaport
            // 
            buttonRaport.Location = new Point(691, 415);
            buttonRaport.Name = "buttonRaport";
            buttonRaport.Size = new Size(75, 23);
            buttonRaport.TabIndex = 8;
            buttonRaport.Text = "Raporty";
            buttonRaport.UseVisualStyleBackColor = true;
            buttonRaport.Click += buttonRaport_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonRaport);
            Controls.Add(buttonSave);
            Controls.Add(buttonGetApi);
            Controls.Add(label2);
            Controls.Add(ButtonGetWeather);
            Controls.Add(dataGridView1);
            Controls.Add(labelLog);
            Controls.Add(label1);
            Controls.Add(ButtonGetCities);
            Name = "Form1";
            Text = "WeatherData";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonGetCities;
        private Label label1;
        private Label labelLog;
        private DataGridView dataGridView1;
        private Button ButtonGetWeather;
        private Label label2;
        private Button buttonGetApi;
        private Button buttonSave;
        private Button buttonRaport;
    }
}