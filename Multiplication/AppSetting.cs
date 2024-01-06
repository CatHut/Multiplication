using System;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Text;

namespace CatHut
{
    public class AppSetting<T> where T : new()
    {
        private string fileName;

        /// <summary>
        /// 任意の保存データクラス
        /// 要件：シリアライズ可能であること
        /// 要件：引数なしコンストラクタを実装すること
        /// 注意：Dicitonaryで使用する場合、SerializableDicitonaryを使用すること。
        ///       また、デフォルトコンストラクタ後にシリアライズ処理が実行されるため、
        ///       ディクショナリのキー登録はコンストラクタ内では行わないこと。
        /// </summary>
        public T Data { get; set; }

        public AppSetting(string file)
        {
            fileName = file;
            Initialize();
        }

        public AppSetting()
        {
            fileName = "AppSetting.xml";
            Initialize();
        }

        // 終了時の呼び出し
        public void Exit()
        {
            Save();
        }

        // XMLファイルをT型オブジェクトに復元する
        public void Initialize()
        {
            Load();
        }

        // XMLファイルをT型オブジェクトに復元する
        public void Load()
        {
            // XmlSerializerオブジェクトを作成
            var serializer = CreateXmlSerializer();

            // ファイルが存在するか確認してから処理
            if (File.Exists(fileName))
            {
                try
                {
                    // 読み込むファイルを開く
                    using (var sr = new StreamReader(fileName, new UTF8Encoding(false)))
                    {
                        // XMLファイルから読み込み、逆シリアル化する
                        Data = (T)serializer.Deserialize(sr);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("XMLファイル読み込み失敗: " + ex.Message);
                    Data = new T(); // T型のデフォルト値を設定
                }
            }
            else
            {
                Data = new T(); // ファイルが存在しない場合はデフォルト値を設定
            }
        }

        // XMLファイルを書き出し
        public void Save()
        {
            var serializer = CreateXmlSerializer();

            try
            {
                // 書き込むファイルを開く（UTF-8 BOMなし）
                using (var sw = new StreamWriter(fileName, false, new UTF8Encoding(false)))
                {
                    // シリアル化し、XMLファイルに保存する
                    serializer.Serialize(sw, Data);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("書き込み先" + fileName + "に書き込めません: " + ex.Message);
            }
        }

        private XmlSerializer CreateXmlSerializer()
        {
            return new XmlSerializer(typeof(T));
        }
    }
}
