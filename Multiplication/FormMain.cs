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

            //問題の生成
            {
                questionSetClass = new QuestionSetClass(7, 9);

            }

            //問題表示用のアイテム追加
            {
                displayControlClass = new DisplayControlClass(this);
            }


            //回答用の数字ボタン追加
            {
                int xOffset = 10; // 初期のXオフセット
                int yOffset = 500; // Yオフセット（変更可能）

                for (int i = 0; i < 10; i++)
                {
                    Button button = new Button();
                    button.Text = i.ToString();
                    button.Size = new Size(188, 120); // ボタンのサイズ（変更可能）
                    button.Location = new Point(xOffset, yOffset);

                    xOffset += button.Size.Width; // 次のボタンのためにオフセットを更新

                    button.Click += new EventHandler(Button_Click); // イベントハンドラーの登録

                    buttons.Add(button);
                    this.Controls.Add(button);
                }
            }

            //回答後のOKボタン
            {
                //int xOffset = 10; // 初期のXオフセット
                //int yOffset = 500; // Yオフセット（変更可能）

                //Button button = new Button();
                //button.Text = "OK!";
                //button.Size = new Size(120 * 10, 120); // ボタンのサイズ（変更可能）
                //button.Location = new Point(xOffset, yOffset);

                //button.Click += new EventHandler(Button_Click); // イベントハンドラーの登録
                //this.Controls.Add(button);
                //button.BringToFront();

            }


            //最初の問題表示
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
                // ボタンに書かれたテキスト（数字）を取得
                string buttonText = clickedButton.Text;

                // ここでどのボタンが押されたかに応じた処理を実行
                // 例: テキストボックスに表示
                //textBoxDisplay.Text = "押されたボタン: " + buttonText;
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