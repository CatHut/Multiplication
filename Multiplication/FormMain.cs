using CatHut;

namespace Multiplication
{
    public partial class FormMain : Form
    {
        private List<Button> buttons = new List<Button>();


        public FormMain()
        {
            InitializeComponent();
            Initialize();

        }


        private void Initialize()
        {

            //�񓚗p�̐����{�^���ǉ�
            {
                int xOffset = 10; // ������X�I�t�Z�b�g
                int yOffset = 500; // Y�I�t�Z�b�g�i�ύX�\�j

                for (int i = 0; i < 10; i++)
                {
                    Button button = new Button();
                    button.Text = i.ToString();
                    button.Size = new Size(120, 120); // �{�^���̃T�C�Y�i�ύX�\�j
                    button.Location = new Point(xOffset, yOffset);

                    xOffset += button.Size.Width; // ���̃{�^���̂��߂ɃI�t�Z�b�g���X�V

                    button.Click += new EventHandler(Button_Click); // �C�x���g�n���h���[�̓o�^

                    buttons.Add(button);
                    this.Controls.Add(button);
                }
            }

            //�񓚌��OK�{�^��
            {
                int xOffset = 10; // ������X�I�t�Z�b�g
                int yOffset = 500; // Y�I�t�Z�b�g�i�ύX�\�j

                Button button = new Button();
                button.Text = "OK!";
                button.Size = new Size(120 * 10, 120); // �{�^���̃T�C�Y�i�ύX�\�j
                button.Location = new Point(xOffset, yOffset);

                button.Click += new EventHandler(Button_Click); // �C�x���g�n���h���[�̓o�^
                this.Controls.Add(button);
                button.BringToFront();

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
    }
}