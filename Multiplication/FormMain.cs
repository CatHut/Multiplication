using CatHut;

namespace Multiplication
{
    public partial class FormMain : Form
    {
        private List<Button> buttons = new List<Button>();
        private DisplayControlClass displayControlClass;
        private AppSetting<AnswerDataClass> AS;
        private QuestionSetClass questionSetClass;


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

            //���̐���
            {
                questionSetClass = new QuestionSetClass(7, 9);

            }

            //���\���p�̃A�C�e���ǉ�
            {
                displayControlClass = new DisplayControlClass(this);
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


            //�ŏ��̖��\��
            {
                var question = questionSetClass.GetNextQuestion();
                displayControlClass.RefreshQuestion(question);

            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button? clickedButton = sender as Button;
            if (clickedButton != null)
            {
                // �{�^���ɏ����ꂽ�e�L�X�g�i�����j���擾
                string buttonText = clickedButton.Text;

                // �����łǂ̃{�^���������ꂽ���ɉ��������������s
                // ��: �e�L�X�g�{�b�N�X�ɕ\��
                //textBoxDisplay.Text = "�����ꂽ�{�^��: " + buttonText;
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
    }
}