using CatHut;
using Timer = System.Windows.Forms.Timer;

namespace Multiplication
{
    public partial class FormMain : Form
    {
        private List<Button> buttons = new List<Button>();
        private Button nextButton;
        private DisplayControlClass displayControlClass;
        private ProgressBar progressBar;
        private Timer timer;
        private AppSetting<AnswerDataClass> AS;
        private QuestionSetClass questionSetClass;
        private int totalSeconds = 90;
        private int interval;


        public FormMain()
        {
            InitializeComponent();
            Initialize();

        }


        private void Initialize()
        {
            AS = new AppSetting<AnswerDataClass>();
            if(AS.Data.AnswerData == null)
            {
                AS.Data.Initialize(); 
            }

            //���\���p�̃A�C�e���ǉ�
            {
                displayControlClass = new DisplayControlClass(this);
            }

            //���̐���
            {
                questionSetClass = new QuestionSetClass(1, 12, displayControlClass);
            }




            //�񓚗p�̐����{�^���ǉ�
            {
                int xOffset = 10; // ������X�I�t�Z�b�g
                int yOffset = 500; // Y�I�t�Z�b�g�i�ύX�\�j

                for (int i = 0; i < 10; i++)
                {
                    Button button = new Button();
                    button.Text = i.ToString();
                    button.Size = new Size(188, 120); // �{�^���̃T�C�Y�i�ύX�\�j
                    button.Location = new Point(xOffset, yOffset);

                    xOffset += button.Size.Width; // ���̃{�^���̂��߂ɃI�t�Z�b�g���X�V

                    button.Click += new EventHandler(Button_Click); // �C�x���g�n���h���[�̓o�^

                    buttons.Add(button);
                    this.Controls.Add(button);
                }
            }

            //�񓚌��OK�{�^��
            {
                //int xOffset = 10; // ������X�I�t�Z�b�g
                //int yOffset = 500; // Y�I�t�Z�b�g�i�ύX�\�j

                //Button button = new Button();
                //button.Text = "OK!";
                //button.Size = new Size(120 * 10, 120); // �{�^���̃T�C�Y�i�ύX�\�j
                //button.Location = new Point(xOffset, yOffset);

                //button.Click += new EventHandler(Button_Click); // �C�x���g�n���h���[�̓o�^
                //this.Controls.Add(button);
                //button.BringToFront();

            }


            //���̖��J�ڑ҂�PictureBox
            {
                int xOffset = 10; // ������X�I�t�Z�b�g
                int yOffset = 500; // Y�I�t�Z�b�g�i�ύX�\�j

                // ������PictureBox�̍쐬
                nextButton = new Button
                {
                    Visible = false,  // ������Ԃł͔�\��
                    Size = new Size(1920, 120), // �{�^���̃T�C�Y�i�ύX�\�j
                    Location = new Point(xOffset, yOffset),
                    Text = "Next!"
                };
                nextButton.Click += nextButton_Click;
                this.Controls.Add(nextButton);
                nextButton.BringToFront();

            }


            //�ŏ��̖��\��
            {
                var question = questionSetClass.GetNextQuestion();
                displayControlClass.RefreshQuestion(question);
            }

            //ProgressBar�̏�����
            {
                progressBar = new ProgressBar();
                progressBar.Maximum = 100;  // 100%�Ƃ��Ĉ���
                progressBar.Value = 100;
                progressBar.Dock = DockStyle.Top;
                this.Controls.Add(progressBar);
            }

            //Timer�̐ݒ�
            {
                timer = new Timer();
                interval = (int)Math.Round(1000.0 * totalSeconds / progressBar.Maximum);
                timer.Interval = interval;  // �v���O���X�o�[�̍ő�l�Ɋ�Â��ăC���^�[�o����ݒ�
                timer.Tick += Timer_Tick;
                timer.Start();
            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button? clickedButton = sender as Button;
            if (clickedButton != null)
            {
                // �{�^���ɏ����ꂽ�e�L�X�g�i�����j���擾
                string buttonText = clickedButton.Text;

                var val = int.Parse(buttonText);

                var ret = questionSetClass.InputAnswer(val);

                if (ret)
                {
                    timer.Stop();

                    // PictureBox��\�����ăN���b�N�ҋ@��L����
                    nextButton.Visible = true;
                }
            }
        }

        private void StartTimer()
        {
            progressBar.Value = progressBar.Maximum; // �v���O���X�o�[���ő�l�Ƀ��Z�b�g
            timer.Start(); // �^�C�}�[���~
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressBar.Value > 0)
            {
                progressBar.Value--;
            }
            else
            {
                // ���Ԑ؂�̏���
                //timer.Stop();
                //MessageBox.Show("���Ԑ؂�ł��I");
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (displayControlClass == null) return;

            displayControlClass.Draw(e.Graphics);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            AS.Save();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void nextButton_Click(object sender, EventArgs e)
        {

            nextButton.Visible = false;

            //���̖��ֈڍs
            var question = questionSetClass.GetNextQuestion();
            displayControlClass.RefreshQuestion(question);

            StartTimer();
        }
    }
}