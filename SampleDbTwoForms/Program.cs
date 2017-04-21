using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        internal static MapDbDataSet SharedMapDataSet;
        internal static BindingSource SharedMapBindingSource;
        internal static MapDbDataSetTableAdapters.MapDataTableAdapter SharedMapDataTableAdapter;
        internal static MapDbDataSetTableAdapters.TableAdapterManager SharedAdapterManager;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetDataBase();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void SetDataBase()
        {
            SharedMapDataSet = new MapDbDataSet();
            SharedMapBindingSource = new BindingSource();
            SharedMapDataTableAdapter = new MapDbDataSetTableAdapters.MapDataTableAdapter();
            SharedAdapterManager= new MapDbDataSetTableAdapters.TableAdapterManager();

            ((System.ComponentModel.ISupportInitialize)SharedMapDataSet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SharedMapBindingSource).BeginInit();
            SharedAdapterManager.BackupDataSetBeforeUpdate = false;
            SharedAdapterManager.MapDataTableAdapter = SharedMapDataTableAdapter;
            SharedAdapterManager.UpdateOrder = MapDbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;

            SharedMapDataSet.DataSetName = "MapDbDataSet";
            SharedMapDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mapDataBindingSource
            // 
            SharedMapBindingSource.DataMember = "MapData";
            SharedMapBindingSource.DataSource = SharedMapDataSet;
            // 
            // mapDataTableAdapter
            // 
            SharedMapDataTableAdapter.ClearBeforeFill = true;
            ((System.ComponentModel.ISupportInitialize)(SharedMapDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(SharedMapBindingSource)).EndInit();

        }
    }
}
