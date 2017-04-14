using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Pantone
{
public partial class MainForm : Form
{
    #region Свойства
    //Постоянная часть адреса
    private const string GITHUB = @"https://raw.githubusercontent.com/jpederson/Pantoner/gh-pages/xml/";

    //имена файлов
    private readonly string[] _files =
    {
        "pantone-coated.xml",
        "pantone-color-of-the-year.xml",
        "pantone-metallic.xml",
        "pantone-pastels-neons.xml",
        "pantone-skin.xml",
        "pantone-uncoated.xml"
    };

    #endregion

    public MainForm()
    {
        InitializeComponent();
        new Thread(LoadFromGitHub).Start();
    }

    private void LoadFromGitHub()
    {
        foreach (var file in _files)
            //читаем файл с гитхаба
            using (var rawXml = new WebClient().OpenRead(GITHUB + file))
            {
                if (rawXml == null) continue;
                //читаем данные
                using (var ghReader = new StreamReader(rawXml))
                {
                    //дополняем корневым элементом до валидного XML
                    using (var strReader =
                        new StringReader(
                            string.Format("<colors name=\"{0}\">{1}</colors>", file, ghReader.ReadToEnd())))
                    {
                        //читаем XML
                        using (var xmlReader = XmlReader.Create(strReader))
                        {
                            var d = new XmlSerializer(typeof(PantonColors));
                            //Десериализуем
                            var item = (PantonColors) d.Deserialize(xmlReader);
                            //Создаём новый контрол для выбора цвета
                            var chooser = new PantonColorChooser(item.SetName.Replace(".xml", string.Empty));
                            chooser.SetColors(item);
                            //Добавляем на форму
                            this.InvokeEx(
                                () => { flowLayoutPanel1.Controls.Add(chooser); });
                        }
                    }
                }
            }
    }
}
}