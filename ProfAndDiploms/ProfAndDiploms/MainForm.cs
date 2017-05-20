using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ProfAndDiploms
{
    public partial class MainForm : Form
    {
        private WordReader _wordReader;
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            Load += MainForm_Load;
            professorsListBox.SelectedIndexChanged += ProfessorsListBoxSelectedIndexChanged;
        }

        private void ProfessorsListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            var selProf = professorsListBox.SelectedItem as Professor;
            if (selProf == null)
            {
                return;
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = selProf.Diplomas.Select(
                d => new
                {
                    Тема = d.Topic,
                    Группа = d.Student.Group,
                    Студент = d.Student.Name
                }).ToList();
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            new Thread(LoadProfs).Start();
        }
        //Загрузка списка преподавателей в отдельном потоке
        private void LoadProfs()
        {
            _wordReader = new WordReader(Path.GetFullPath("Приказ о закреплении тем на ДП.docx"));
            //Подписываемся на добавление нового преподавателя.
            _wordReader.ProfRead += Wr_ProfRead;
            _wordReader.GetProfs();
            _wordReader.ProfRead -= Wr_ProfRead;
            _wordReader = null;
        }

        private void Wr_ProfRead(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(SetListBoxDataSource));
            }
            else
            {
                SetListBoxDataSource();
            }
        }

        private void SetListBoxDataSource()
        {
            var index = professorsListBox.SelectedIndex;
            professorsListBox.DataSource = null;
            professorsListBox.DataSource = _wordReader.Professors;
            professorsListBox.DisplayMember = "Name";
            professorsListBox.SelectedIndex = index;
        }
    }
}
