using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace CreateCord
{
    public partial class CodeMain : Form
    {
        string ConnectionString = string.Empty;
        public CodeMain(string ConnectionStrings)
        {
            InitializeComponent();
            ConnectionString = ConnectionStrings;
        }
        private string String;

        public string str_jsonschame
        {
            get { return String; }
            set { String = value; }
        }
        public CodeMain()
        {
            InitializeComponent();
        }
        ICreateType IcreateType = null;
        string subPathName = string.Empty;
        private void button1_Click(object sender, EventArgs e)
        {
            //if (t_path.Text.Trim() == "")
            //{
            //    MessageBox.Show("请选择存放的路径！！");
            //    return;
            //}
            //subPathName = "" + t_path.Text + "Code"; //创建文件夹
            //if (false == System.IO.Directory.Exists(subPathName))
            //{
            //    //创建pic文件夹
            //    System.IO.Directory.CreateDirectory(subPathName);
            //}
            //CreateModel();
            if (t_path.Text.Trim() == "")
            {
                MessageBox.Show("请选择存放的路径！！");
                return;
            }
            subPathName = "" + t_path.Text + "Code"; //创建文件夹
            if (false == System.IO.Directory.Exists(subPathName))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPathName);
            }

            int count = dgvColumns.Rows.Count; //获取每张表中的列是json格式的
            for (int i = 0; i < count; i++)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();   //实例化一个能够序列化数据的类
                string str_json_out = dgvColumns.Rows[i].Cells["Json格式"].Value.ToString();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Dictionary<string, Object> json = (Dictionary<string, Object>)serializer.DeserializeObject(str_json_out);

                //获取当前文件夹路径
                //string currPath = Application.StartupPath;
                //检查是否存在文件夹
                string subPath = subPathName + "\\Model";
                if (false == System.IO.Directory.Exists(subPath))
                {
                    //创建pic文件夹
                    System.IO.Directory.CreateDirectory(subPath);
                }
                Find1(json);
                IList<string> allKeys = json.Keys.ToList();
                List<string> code_list = new List<string>();
                code_list.Add("using System;");
                code_list.Add("namespace Model");
                code_list.Add("{");
                code_list.Add("public   class " + this.tvTables.SelectedNode.Text + "");
                code_list.Add("{");
                for (int j = 0; j < allKeys.Count; j++)
                {
                    code_list.Add("public   string    " + allKeys[j].ToString() + "  {get;set;}");
                }
                CreateManger(this.tvTables.SelectedNode.Text);


                foreach (KeyValuePair<string, object> item in json)
                {
                    if (item.Value.GetType() == typeof(Dictionary<string, Object>))
                    {
                        code_list.Add("public   " + item.Key + "Content   " + item.Key + "  {get;set;}");
                        Dictionary<string, Object> list = item.Value as Dictionary<string, Object>;
                        List<string> code_lists = new List<string>();
                        code_lists.Add("using System;");
                        code_lists.Add("namespace Model");
                        code_lists.Add("{");
                        code_lists.Add("public   " + item.Key + "Content   " + item.Key + " ");
                        code_lists.Add("{");
                        CreateManger(item.Key + "Content");
                        foreach (KeyValuePair<string, object> items in list)
                        {
                            code_lists.Add("public string " + items.Key + " {get;set;}");
                        }
                        code_lists.Add("}");
                        code_lists.Add("}");
                        FileOperate.FileWrite(code_lists, "" + subPath + "\\ " + item.Key + "Content .cs");
                    }

                    if (item.Value.GetType() == typeof(Object[]))
                    {
                        code_list.Add("public   List<" + item.Key + "Content>  " + item.Key + "  {get;set;}");
                        object[] list = item.Value as Object[];
                        List<string> code_listss = new List<string>();
                        code_listss.Add("using System;");
                        code_listss.Add("namespace Model");
                        code_listss.Add("{");
                        code_listss.Add("public   " + item.Key + "Content   " + item.Key + " ");
                        code_listss.Add("{");
                        CreateManger(item.Key + "Content");
                        Dictionary<string, Object> a = list[0] as Dictionary<string, Object>;
                        foreach (KeyValuePair<string, Object> items in a)
                        {
                            code_listss.Add("public string " + items.Key + " {get;set;}");
                        }
                        code_listss.Add("}");
                        code_listss.Add("}");
                        FileOperate.FileWrite(code_listss, "" + subPath + "\\ " + item.Key + "Content .cs");
                    }
                }
                code_list.Add("}");
                code_list.Add("}");
                FileOperate.FileWrite(code_list, "" + subPath + "\\" + this.tvTables.SelectedNode.Text + ".cs");

            }
        }


        public void Find1(Dictionary<string, object> obj)
        {
            IList<string> allKeys = obj.Keys.ToList();
            foreach (KeyValuePair<string, object> item in obj)
            {
                string name = item.Key;
                if (item.Value == null)
                {



                }
                else
                {
                    if (item.Value.GetType() == typeof(Dictionary<string, Object>))
                    {

                        Dictionary<string, Object> list = item.Value as Dictionary<string, Object>;
                        List<string> code_lists = new List<string>();

                        foreach (KeyValuePair<string, object> items in list)
                        {
                            string Name = items.Key.ToString();
                            Find1(item.Value as Dictionary<string, Object>);
                        }

                    }

                    if (item.Value.GetType() == typeof(Object[]))
                    {
                        object[] list = item.Value as Object[];
                        for (int i = 0; i < list.Length; i++)
                        {
                            Dictionary<string, Object> listValue = list[i] as Dictionary<string, Object>;
                            Find1(listValue);

                        }
                    }
                    if (item.Value.GetType() == typeof(int) || item.Value.GetType() == typeof(string))
                    {


                    }
                }





            }
        }

        #region 自动创建实体===================
        /// <summary>
        /// 创建实体
        /// </summary>
        private void CreateModel()
        {
            //获取当前文件夹路径
            //string currPath = Application.StartupPath;
            //检查是否存在文件夹
            string subPath = subPathName + "\\Model";
            if (false == System.IO.Directory.Exists(subPath))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPath);
            }
            DataTable dt_Cloumns = this.dgvColumns.DataSource as DataTable;
            List<string> code_list = new List<string>();
            code_list.Add("using System;");

            code_list.Add("public class  " + this.tvTables.SelectedNode.Text + "");
            code_list.Add("{");
            foreach (DataRow row in dt_Cloumns.Rows)
            {
                string c_type = FileOperate.SqlTypeTope(row["type"].ToString());
                string c_name = row["name"].ToString();
                code_list.Add("public " + c_type + " " + c_name.Substring(0, 1).ToUpper() + c_name.Substring(1) + "{get; set;}");
            }
            code_list.Add("}");
            FileOperate.FileWrite(code_list, "" + subPath + "\\" + this.tvTables.SelectedNode.Text + ".cs");
            //CreateManger();

        }
        #endregion
        #region 自动生成数据访问层=============
        /// <summary>
        /// 自动生成数据访问层
        /// </summary>
        private void CreateManger(string ClassName)
        {

            //获取当前文件夹路径
            //string currPath = Application.StartupPath;
            //检查是否存在文件夹
            string subPath = subPathName + "/Manager";
            if (false == System.IO.Directory.Exists(subPath))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPath);
            }
            string targetPath = subPath + "\\ManagerBase.cs";//结果保存到桌面
            //  FileStream fs = new FileStream(targetPath, FileMode.Append);
            string sourcePath = PathName() + "\\ManagerBase.cs";

            bool isrewrite = false;


            if (!File.Exists(targetPath))     // 返回bool类型，存在返回true，不存在返回false                                     
            {
                System.IO.File.Copy(sourcePath, targetPath, isrewrite);      //不存在则复制文件
            }
            List<string> code_list = new List<string>();
            code_list.Add("using System;");
            code_list.Add("using Model;");
            code_list.Add("using System.Collections.Generic;");
            code_list.Add("using System.Linq;");
            code_list.Add("using System.Text;");
            code_list.Add(" using System.Threading.Tasks;");
            code_list.Add(" namespace Manager");
            code_list.Add("{");
            code_list.Add(" public class " + ClassName + "Manager :ManagerBase<" + ClassName + ">");
            code_list.Add("{");
            code_list.Add("}");
            code_list.Add("}");
            FileOperate.FileWrite(code_list, "" + subPath + "/" + ClassName + "Manager.cs");
            CreateComponent(ClassName);

        }
        #endregion
        #region 自动生成逻辑层=================
        /// <summary>
        /// 自动生成逻辑层
        /// </summary>

        public void CreateComponent(string className)
        {
            //获取当前文件夹路径
            //string currPath = Application.StartupPath;
            //检查是否存在文件夹
            string subPath = subPathName + "/Component";
            if (false == System.IO.Directory.Exists(subPath))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPath);
            }

            string targetPath = subPath + "\\ComponentBase.cs";//结果保存到桌面
            //  FileStream fs = new FileStream(targetPath, FileMode.Append);
            string sourcePath = PathName() + "\\ComponentBase.cs"; ;

            bool isrewrite = false;


            if (!File.Exists(targetPath))     // 返回bool类型，存在返回true，不存在返回false                                     
            {
                System.IO.File.Copy(sourcePath, targetPath, isrewrite);      //不存在则复制文件
            }



            List<string> code_list = new List<string>();
            code_list.Add("using System;");
            code_list.Add("using System.Collections.Generic;");
            code_list.Add("using System.Linq;");
            code_list.Add("using System.Text;");
            code_list.Add(" using System.Threading.Tasks;");
            code_list.Add("using Manager;");
            code_list.Add("using Model;");
            code_list.Add(" namespace Component");
            code_list.Add("{");
            code_list.Add(" public class " + className + "Component :ComponentBase<" + className + "," + className + "Manager>");
            code_list.Add("{");
            code_list.Add(" public IList<" + className + "> GetAll()");
            code_list.Add("{");
            code_list.Add(" return manager.GetAll();");
            code_list.Add("}");
            code_list.Add("public int Update(" + className + " dl)");
            code_list.Add("{");
            code_list.Add("return manager.Update(dl);");
            code_list.Add("}");
            code_list.Add("public int Delete(" + className + " dl)");
            code_list.Add("{");
            code_list.Add("return manager.Delete(dl);");
            code_list.Add("}");



            code_list.Add("}");
            code_list.Add("}");
            FileOperate.FileWrite(code_list, "" + subPath + "/" + className + "Component.cs");
            Controllers(className);

        }
        #endregion
        #region 自动生成控制器=================
        /// <summary>
        /// 自动生成控制器
        /// </summary>

        public void Controllers(string className)
        {
            //获取当前文件夹路径
            //string currPath = Application.StartupPath;
            //检查是否存在文件夹
            string subPath = subPathName + "/Controllers";
            if (false == System.IO.Directory.Exists(subPath))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPath);
            }
            List<string> code_list = new List<string>();
            code_list.Add("using System;");
            code_list.Add("using Component;");
            code_list.Add("using System.Collections.Generic;");
            code_list.Add(" using System.Linq;");
            code_list.Add("using System.Text;");
            code_list.Add("using System.Threading.Tasks;");
            code_list.Add(" namespace Controllers");
            code_list.Add("{");
            code_list.Add("public class " + className + "Controller : Controller");
            code_list.Add("{");

            code_list.Add("" + className + "Component cp=new " + className + "Component()");

            code_list.Add("public ActionResult Index()");
            code_list.Add("{");

            code_list.Add("" + className + "  com = new " + className + "();");
            code_list.Add(" cp.GetAll();");
            code_list.Add(" cp.Delete(com);");
            code_list.Add(" cp.Update(com);");



            code_list.Add("return View();");
            code_list.Add("}");
            code_list.Add("}");
            code_list.Add("}");
            FileOperate.FileWrite(code_list, "" + subPath + "/" + className + "Controller.cs");
            MessageBox.Show("在目录中Code文件夹查看分！！！");
        }
        #endregion
        #region 获取项目根目录地址=============
        /// <summary>
        /// 获取项目地址
        /// </summary>
        /// <returns></returns>
        public string PathName()
        {
            //使用appdomain获取当前应用程序集的执行目录
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            //使用path获取当前应用程序集的执行的上级目录
            //dir = Path.GetFullPath("..");
            ////使用path获取当前应用程序集的执行目录的上级的上级目录
            //dir = Path.GetFullPath("../..");
            //dir = Path.GetFullPath("../../..");
            return dir;
        }
        #endregion
        private void CodeMain_Load(object sender, EventArgs e)
        {
            IcreateType = new PGCreateCode(ConnectionString);
            DataTable dt_Tables = IcreateType.GetTables();
            foreach (DataRow row in dt_Tables.Rows)
            {
                TreeNode tn = new TreeNode();//创建树节点
                tn.Text = row["name"].ToString();
                this.tvTables.Nodes.Add(tn);//添加到树上面
            }
        }
        private void tvTables_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            string dataName = this.tvTables.SelectedNode.Text;

            DataRow[] list = IcreateType.GetColumns(dataName).Select("type='jsonb' or type='json'");
            DataTable lists = IcreateType.GetData(dataName);
            string name = string.Empty;
            DataTable dt = new DataTable();
            dt.Columns.Add("表名称");
            dt.Columns.Add("Json列");
            dt.Columns.Add("Json格式");
            if (lists.Rows.Count > 0)
            {
                for (int i = 0; i < list.Length; i++)
                {
                    name = list[i][0].ToString();
                    string strvalue = lists.Rows[0]["" + name + ""].ToString();
                    DataRow dr = dt.NewRow();
                    dr[0] = this.tvTables.SelectedNode.Text;
                    dr[1] = name;
                    dr[2] = strvalue;
                    dt.Rows.Add(dr);
                }
                this.dgvColumns.DataSource = dt;

            }


        }
        private void b_choice_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowserDialog = new FolderBrowserDialog();
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string resultFile = FolderBrowserDialog.SelectedPath;
                t_path.Text = resultFile;
            }
        }
        private void dgvColumns_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex + 1 == 0)
            {
                return;
            }
            string colName = this.dgvColumns.Columns[e.ColumnIndex].Name;
            if (colName == "JsonEdit")
            {

                MessageBox.Show("选中行" + (e.RowIndex + 1));
                string str_json_out = dgvColumns.Rows[e.RowIndex].Cells["Json格式"].Value.ToString();//获取选中行指定列的值
                openJsonEdit(str_json_out);
                dgvColumns.Rows[e.RowIndex].Cells["Json格式"].Value = str_jsonschame;
            }
        }
        private void openJsonEdit(string str_json_schame)
        {
            JsonEditForm JsonEdit = new JsonEditForm();
            JsonEdit.str_json_column = str_json_schame;
            JsonEdit.ShowDialog(this);

        }

        
    }
}
