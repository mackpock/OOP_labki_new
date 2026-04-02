using Model;

namespace View
{
    partial class AddForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            ExerciseGroupBox = new GroupBox();
            ComboBoxExercise = new ComboBox();
            LabelName = new Label();
            TextBoxName = new TextBox();
            LabelParameters = new Label();
            PanelRunning = new Panel();
            LabelRunningDistanceUnit = new Label();
            NumericRunningDistance = new NumericUpDown();
            LabelRunningDistance = new Label();
            LabelIntensityUnit = new Label();
            NumericIntensity = new NumericUpDown();
            LabelIntensity = new Label();
            PanelSwimming = new Panel();
            LabelSwimmingDistanceUnit = new Label();
            NumericSwimmingDistance = new NumericUpDown();
            LabelSwimmingDistance = new Label();
            ComboBoxStyle = new ComboBox();
            LabelStyle = new Label();
            PanelBenchPress = new Panel();
            LabelRepetitionsUnit = new Label();
            NumericRepetitions = new NumericUpDown();
            LabelRepetitions = new Label();
            LabelWeightUnit = new Label();
            NumericWeight = new NumericUpDown();
            LabelWeight = new Label();
            ButtonCreate = new Button();
            ButtonClose = new Button();
            ButtonCreateRandom = new Button();
            ExerciseGroupBox.SuspendLayout();
            PanelRunning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericRunningDistance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericIntensity).BeginInit();
            PanelSwimming.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericSwimmingDistance).BeginInit();
            PanelBenchPress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericRepetitions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericWeight).BeginInit();
            SuspendLayout();
            // 
            // ExerciseGroupBox
            // 
            ExerciseGroupBox.Controls.Add(ComboBoxExercise);
            ExerciseGroupBox.Location = new Point(14, 14);
            ExerciseGroupBox.Margin = new Padding(4);
            ExerciseGroupBox.Name = "ExerciseGroupBox";
            ExerciseGroupBox.Padding = new Padding(4);
            ExerciseGroupBox.Size = new Size(258, 58);
            ExerciseGroupBox.TabIndex = 0;
            ExerciseGroupBox.TabStop = false;
            ExerciseGroupBox.Text = "Выбор упражнения";
            //
            // ComboBoxExercise
            //
            ComboBoxExercise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ComboBoxExercise.FlatStyle = FlatStyle.Flat;
            ComboBoxExercise.FormattingEnabled = true;
            ComboBoxExercise.Location = new Point(7, 22);
            ComboBoxExercise.Margin = new Padding(4);
            ComboBoxExercise.Name = "ComboBoxExercise";
            ComboBoxExercise.Size = new Size(244, 23);
            ComboBoxExercise.TabIndex = 0;
            ComboBoxExercise.SelectedIndexChanged += ComboBoxExercise_SelectedIndexChanged;
            // 
            // LabelName
            // 
            LabelName.AutoSize = true;
            LabelName.Location = new Point(14, 86);
            LabelName.Margin = new Padding(4, 0, 4, 0);
            LabelName.Name = "LabelName";
            LabelName.Size = new Size(62, 15);
            LabelName.TabIndex = 1;
            LabelName.Text = "Название:";
            // 
            // TextBoxName
            // 
            TextBoxName.Location = new Point(91, 83);
            TextBoxName.Margin = new Padding(4);
            TextBoxName.MaxLength = ExerciseBase.MaxNameLength;
            TextBoxName.Name = "TextBoxName";
            TextBoxName.Size = new Size(174, 23);
            TextBoxName.TabIndex = 2;
            // 
            // LabelParameters
            // 
            LabelParameters.AutoSize = true;
            LabelParameters.Location = new Point(14, 121);
            LabelParameters.Margin = new Padding(4, 0, 4, 0);
            LabelParameters.Name = "LabelParameters";
            LabelParameters.Size = new Size(74, 15);
            LabelParameters.TabIndex = 3;
            LabelParameters.Text = "Параметры:";
            // 
            // PanelRunning
            // 
            PanelRunning.Controls.Add(LabelRunningDistanceUnit);
            PanelRunning.Controls.Add(NumericRunningDistance);
            PanelRunning.Controls.Add(LabelRunningDistance);
            PanelRunning.Controls.Add(LabelIntensityUnit);
            PanelRunning.Controls.Add(NumericIntensity);
            PanelRunning.Controls.Add(LabelIntensity);
            PanelRunning.Location = new Point(14, 140);
            PanelRunning.Margin = new Padding(4);
            PanelRunning.Name = "PanelRunning";
            PanelRunning.Size = new Size(258, 92);
            PanelRunning.TabIndex = 4;
            // 
            // LabelRunningDistanceUnit
            // 
            LabelRunningDistanceUnit.AutoSize = true;
            LabelRunningDistanceUnit.Location = new Point(220, 54);
            LabelRunningDistanceUnit.Margin = new Padding(4, 0, 4, 0);
            LabelRunningDistanceUnit.Name = "LabelRunningDistanceUnit";
            LabelRunningDistanceUnit.Size = new Size(22, 15);
            LabelRunningDistanceUnit.TabIndex = 5;
            LabelRunningDistanceUnit.Text = "км";
            // 
            // NumericRunningDistance
            // 
            NumericRunningDistance.DecimalPlaces = 2;
            NumericRunningDistance.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            NumericRunningDistance.Location = new Point(108, 52);
            NumericRunningDistance.Margin = new Padding(4);
            NumericRunningDistance.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            NumericRunningDistance.Name = "NumericRunningDistance";
            NumericRunningDistance.Size = new Size(105, 23);
            NumericRunningDistance.TabIndex = 3;
            NumericRunningDistance.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            // 
            // LabelRunningDistance
            // 
            LabelRunningDistance.AutoSize = true;
            LabelRunningDistance.Location = new Point(4, 54);
            LabelRunningDistance.Margin = new Padding(4, 0, 4, 0);
            LabelRunningDistance.Name = "LabelRunningDistance";
            LabelRunningDistance.Size = new Size(69, 15);
            LabelRunningDistance.TabIndex = 2;
            LabelRunningDistance.Text = "Дистанция:";
            // 
            // LabelIntensityUnit
            // 
            LabelIntensityUnit.AutoSize = true;
            LabelIntensityUnit.Location = new Point(220, 20);
            LabelIntensityUnit.Margin = new Padding(4, 0, 4, 0);
            LabelIntensityUnit.Name = "LabelIntensityUnit";
            LabelIntensityUnit.Size = new Size(34, 15);
            LabelIntensityUnit.TabIndex = 4;
            LabelIntensityUnit.Text = "км/ч";
            // 
            // NumericIntensity
            // 
            NumericIntensity.DecimalPlaces = 2;
            NumericIntensity.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            NumericIntensity.Location = new Point(108, 18);
            NumericIntensity.Margin = new Padding(4);
            NumericIntensity.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            NumericIntensity.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            NumericIntensity.Name = "NumericIntensity";
            NumericIntensity.Size = new Size(105, 23);
            NumericIntensity.TabIndex = 1;
            NumericIntensity.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            // 
            // LabelIntensity
            // 
            LabelIntensity.AutoSize = true;
            LabelIntensity.Location = new Point(4, 20);
            LabelIntensity.Margin = new Padding(4, 0, 4, 0);
            LabelIntensity.Name = "LabelIntensity";
            LabelIntensity.Size = new Size(94, 15);
            LabelIntensity.TabIndex = 0;
            LabelIntensity.Text = "Интенсивность:";
            // 
            // PanelSwimming
            // 
            PanelSwimming.Controls.Add(LabelSwimmingDistanceUnit);
            PanelSwimming.Controls.Add(NumericSwimmingDistance);
            PanelSwimming.Controls.Add(LabelSwimmingDistance);
            PanelSwimming.Controls.Add(ComboBoxStyle);
            PanelSwimming.Controls.Add(LabelStyle);
            PanelSwimming.Location = new Point(14, 140);
            PanelSwimming.Margin = new Padding(4);
            PanelSwimming.Name = "PanelSwimming";
            PanelSwimming.Size = new Size(258, 92);
            PanelSwimming.TabIndex = 5;
            // 
            // LabelSwimmingDistanceUnit
            // 
            LabelSwimmingDistanceUnit.AutoSize = true;
            LabelSwimmingDistanceUnit.Location = new Point(220, 54);
            LabelSwimmingDistanceUnit.Margin = new Padding(4, 0, 4, 0);
            LabelSwimmingDistanceUnit.Name = "LabelSwimmingDistanceUnit";
            LabelSwimmingDistanceUnit.Size = new Size(16, 15);
            LabelSwimmingDistanceUnit.TabIndex = 4;
            LabelSwimmingDistanceUnit.Text = "м";
            // 
            // NumericSwimmingDistance
            // 
            NumericSwimmingDistance.DecimalPlaces = 2;
            NumericSwimmingDistance.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            NumericSwimmingDistance.Location = new Point(108, 52);
            NumericSwimmingDistance.Margin = new Padding(4);
            NumericSwimmingDistance.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NumericSwimmingDistance.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericSwimmingDistance.Name = "NumericSwimmingDistance";
            NumericSwimmingDistance.Size = new Size(105, 23);
            NumericSwimmingDistance.TabIndex = 3;
            NumericSwimmingDistance.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // LabelSwimmingDistance
            // 
            LabelSwimmingDistance.AutoSize = true;
            LabelSwimmingDistance.Location = new Point(4, 54);
            LabelSwimmingDistance.Margin = new Padding(4, 0, 4, 0);
            LabelSwimmingDistance.Name = "LabelSwimmingDistance";
            LabelSwimmingDistance.Size = new Size(69, 15);
            LabelSwimmingDistance.TabIndex = 2;
            LabelSwimmingDistance.Text = "Дистанция:";
            //
            // ComboBoxStyle
            //
            ComboBoxStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ComboBoxStyle.FormattingEnabled = true;
            ComboBoxStyle.Location = new Point(108, 18);
            ComboBoxStyle.Margin = new Padding(4);
            ComboBoxStyle.Name = "ComboBoxStyle";
            ComboBoxStyle.Size = new Size(106, 23);
            ComboBoxStyle.TabIndex = 1;
            // 
            // LabelStyle
            // 
            LabelStyle.AutoSize = true;
            LabelStyle.Location = new Point(4, 21);
            LabelStyle.Margin = new Padding(4, 0, 4, 0);
            LabelStyle.Name = "LabelStyle";
            LabelStyle.Size = new Size(43, 15);
            LabelStyle.TabIndex = 0;
            LabelStyle.Text = "Стиль:";
            // 
            // PanelBenchPress
            // 
            PanelBenchPress.Controls.Add(LabelRepetitionsUnit);
            PanelBenchPress.Controls.Add(NumericRepetitions);
            PanelBenchPress.Controls.Add(LabelRepetitions);
            PanelBenchPress.Controls.Add(LabelWeightUnit);
            PanelBenchPress.Controls.Add(NumericWeight);
            PanelBenchPress.Controls.Add(LabelWeight);
            PanelBenchPress.Location = new Point(14, 140);
            PanelBenchPress.Margin = new Padding(4);
            PanelBenchPress.Name = "PanelBenchPress";
            PanelBenchPress.Size = new Size(258, 92);
            PanelBenchPress.TabIndex = 6;
            // 
            // LabelRepetitionsUnit
            // 
            LabelRepetitionsUnit.AutoSize = true;
            LabelRepetitionsUnit.Location = new Point(220, 54);
            LabelRepetitionsUnit.Margin = new Padding(4, 0, 4, 0);
            LabelRepetitionsUnit.Name = "LabelRepetitionsUnit";
            LabelRepetitionsUnit.Size = new Size(25, 15);
            LabelRepetitionsUnit.TabIndex = 5;
            LabelRepetitionsUnit.Text = "раз";
            // 
            // NumericRepetitions
            // 
            NumericRepetitions.Location = new Point(108, 52);
            NumericRepetitions.Margin = new Padding(4);
            NumericRepetitions.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            NumericRepetitions.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericRepetitions.Name = "NumericRepetitions";
            NumericRepetitions.Size = new Size(105, 23);
            NumericRepetitions.TabIndex = 3;
            NumericRepetitions.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // LabelRepetitions
            // 
            LabelRepetitions.AutoSize = true;
            LabelRepetitions.Location = new Point(4, 54);
            LabelRepetitions.Margin = new Padding(4, 0, 4, 0);
            LabelRepetitions.Name = "LabelRepetitions";
            LabelRepetitions.Size = new Size(77, 15);
            LabelRepetitions.TabIndex = 2;
            LabelRepetitions.Text = "Повторения:";
            // 
            // LabelWeightUnit
            // 
            LabelWeightUnit.AutoSize = true;
            LabelWeightUnit.Location = new Point(220, 20);
            LabelWeightUnit.Margin = new Padding(4, 0, 4, 0);
            LabelWeightUnit.Name = "LabelWeightUnit";
            LabelWeightUnit.Size = new Size(18, 15);
            LabelWeightUnit.TabIndex = 4;
            LabelWeightUnit.Text = "кг";
            // 
            // NumericWeight
            // 
            NumericWeight.DecimalPlaces = 2;
            NumericWeight.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            NumericWeight.Location = new Point(108, 18);
            NumericWeight.Margin = new Padding(4);
            NumericWeight.Maximum = new decimal(new int[] { 341, 0, 0, 0 });
            NumericWeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericWeight.Name = "NumericWeight";
            NumericWeight.Size = new Size(105, 23);
            NumericWeight.TabIndex = 1;
            NumericWeight.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // LabelWeight
            // 
            LabelWeight.AutoSize = true;
            LabelWeight.Location = new Point(4, 20);
            LabelWeight.Margin = new Padding(4, 0, 4, 0);
            LabelWeight.Name = "LabelWeight";
            LabelWeight.Size = new Size(29, 15);
            LabelWeight.TabIndex = 0;
            LabelWeight.Text = "Вес:";
            // 
            // ButtonCreate
            // 
            ButtonCreate.Location = new Point(280, 24);
            ButtonCreate.Margin = new Padding(4);
            ButtonCreate.Name = "ButtonCreate";
            ButtonCreate.Size = new Size(122, 35);
            ButtonCreate.TabIndex = 7;
            ButtonCreate.Text = "Создать";
            ButtonCreate.UseVisualStyleBackColor = true;
            ButtonCreate.Click += ButtonCreate_Click;
            // 
            // ButtonClose
            // 
            ButtonClose.Location = new Point(281, 189);
            ButtonClose.Margin = new Padding(4);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(121, 35);
            ButtonClose.TabIndex = 8;
            ButtonClose.Text = "Закрыть";
            ButtonClose.UseVisualStyleBackColor = true;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // ButtonCreateRandom
            // 
            ButtonCreateRandom.Location = new Point(280, 111);
            ButtonCreateRandom.Margin = new Padding(4);
            ButtonCreateRandom.Name = "ButtonCreateRandom";
            ButtonCreateRandom.Size = new Size(120, 35);
            ButtonCreateRandom.TabIndex = 9;
            ButtonCreateRandom.Text = "Создать случайное";
            ButtonCreateRandom.UseVisualStyleBackColor = true;
            ButtonCreateRandom.Click += ButtonCreateRandom_Click;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 237);
            Controls.Add(PanelSwimming);
            Controls.Add(ButtonCreateRandom);
            Controls.Add(ButtonClose);
            Controls.Add(ButtonCreate);
            Controls.Add(LabelParameters);
            Controls.Add(TextBoxName);
            Controls.Add(LabelName);
            Controls.Add(PanelBenchPress);
            Controls.Add(ExerciseGroupBox);
            Controls.Add(PanelRunning);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавить упражнение";
            ExerciseGroupBox.ResumeLayout(false);
            PanelRunning.ResumeLayout(false);
            PanelRunning.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericRunningDistance).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericIntensity).EndInit();
            PanelSwimming.ResumeLayout(false);
            PanelSwimming.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericSwimmingDistance).EndInit();
            PanelBenchPress.ResumeLayout(false);
            PanelBenchPress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericRepetitions).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericWeight).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ExerciseGroupBox;
        private System.Windows.Forms.ComboBox ComboBoxExercise;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Label LabelParameters;
        private System.Windows.Forms.Panel PanelRunning;
        private System.Windows.Forms.NumericUpDown NumericRunningDistance;
        private System.Windows.Forms.Label LabelRunningDistance;
        private System.Windows.Forms.NumericUpDown NumericIntensity;
        private System.Windows.Forms.Label LabelIntensity;
        private System.Windows.Forms.Panel PanelSwimming;
        private System.Windows.Forms.NumericUpDown NumericSwimmingDistance;
        private System.Windows.Forms.Label LabelSwimmingDistance;
        private System.Windows.Forms.ComboBox ComboBoxStyle;
        private System.Windows.Forms.Label LabelStyle;
        private System.Windows.Forms.Panel PanelBenchPress;
        private System.Windows.Forms.NumericUpDown NumericRepetitions;
        private System.Windows.Forms.Label LabelRepetitions;
        private System.Windows.Forms.NumericUpDown NumericWeight;
        private System.Windows.Forms.Label LabelWeight;
        private System.Windows.Forms.Button ButtonCreate;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Button ButtonCreateRandom;
        private System.Windows.Forms.Label LabelIntensityUnit;
        private System.Windows.Forms.Label LabelRunningDistanceUnit;
        private System.Windows.Forms.Label LabelSwimmingDistanceUnit;
        private System.Windows.Forms.Label LabelWeightUnit;
        private System.Windows.Forms.Label LabelRepetitionsUnit;
    }
}
