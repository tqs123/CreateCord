using System;
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
    public partial class createCode : Form
    {
        public createCode()
        {
            InitializeComponent();
        }
        string ConnectionString = string.Empty;
        public createCode(string ConnectionStrings)
        {
            InitializeComponent();
            ConnectionString = ConnectionStrings;
        }
        string subPathName = string.Empty;
        ICreateType IcreateType = null;
        string subPath = string.Empty;//实体路径
        string MgPath = string.Empty;//数据层路径
        string CpPath = string.Empty;//逻辑层路径
        private void createCode_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            subPathName = "" + t_path.Text + "" + fileName.Text + ""; //创建文件夹
            if (false == System.IO.Directory.Exists(subPathName))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPathName);
            }


            string strJson = "{\"diag_report_id\":\"22c960f1-02cd-4d5e-abe5-eeb40785fb5e\",\"lspcm_plcmach_time\":\"2019-06-18 10:37;10\",\"lspcm_plcmach_sno\":\"S0005\",\"status\":\"final\",\"pid\":5,\"pat_name\":\"沸羊羊\",\"pat_sex_name\":\"男\",\"lspcm_list\":\"血清样本 \",\"lspcm\":{\"lspcm_subj_id\":105,\"lspcm_subj_name\":\"血清样本\",\"tqsxx\":[{\"lspcm_subj_id\":105,\"lspcm_subj_name\":\"血清样本\"}]},\"lspcm_info\":[{\"lspcm_subj_id\":105,\"lspcm_subj_name\":\"血清样本\"}],\"oprtr_info\":[{\"oprtr_id\":\"1ca41624-a111-411f-8c63-db9757d815e5\",\"oprtr_name\":\"周桥\",\"oprtr_type\":\"填制人\",\"xx\":[{\"refer_min_value\":\"4\",\"refer_min_unit\":\"10^9/L\",\"refer_max_value\":\"10\",\"refer_max_unit\":\"10^9/L\"}]}],\"result_info\":[{\"result_id\":11,\"loitem_id\":\"DAA61584-2CE6-4346-846F-CD00484997B11\",\"loitem_code\":\"WBC\",\"loitem_name\":\"白细胞数目\",\"loitem_unit\":\"10^9/L\",\"loitem_obsvalue\":\"1\",\"loitem_result\":\"7\",\"comparator\":null,\"lab_rgnt_id\":\"1111\",\"lab_rgnt_name\":\"测试试剂1\",\"lspcm_dtmtd_id\":\"1111\",\"lspcm_dtmtd_name\":\"测试方法\",\"lspcm_subj_id\":\"101\",\"lspcm_subj_name\":\"血清样本\",\"lspcm_loitem_result_time\":\"2019-06-05 14:00:00\",\"result_status\":\"1\",\"labistrmt_id\":\"1111\",\"labistrmt_name\":\"迈瑞5300\",\"dept_id\":\"1111\",\"dept_name\":\"检验科\",\"refer_info\":[{\"refer_min_value\":\"4\",\"refer_min_unit\":\"10^9/L\",\"refer_max_value\":\"10\",\"refer_max_unit\":\"10^9/L\",\"tqs\":[{\"refer_min_value\":\"4\",\"refer_min_unit\":\"10^9/L\",\"refer_max_value\":\"10\",\"refer_max_unit\":\"10^9/L\"}]}]}]}";
            CreateModel(strJson);




        }
        public void CreateModel(string strJson)
        {
            subPath = subPathName + "\\" + ModelName.Text + "";
            if (false == System.IO.Directory.Exists(subPath))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPath);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, Object> json = (Dictionary<string, Object>)serializer.DeserializeObject(strJson);
            List<string> keys = json.Keys.ToList();
            FileOperate.FWrite("using System;\r\nnamespace Model\r\n{\r\npublic class test\r\n{\r\n", "" + subPath + "\\" + this.tvTables.SelectedNode.Text + ".cs");
            foreach (var s in keys)
            {
                findNode(json[s], s, "test", true);
            }
            FileOperate.FWrite("}\r\n}\r\n", "" + subPath + "\\" + this.tvTables.SelectedNode.Text + ".cs");
            CreateManger(this.tvTables.SelectedNode.Text);
            CreateComponent(this.tvTables.SelectedNode.Text);
        }
        public void findNode(object obj, string fileName, string fastName, bool IsF)
        {
            if (null == obj)
            {
                if (IsF)
                {
                    FileOperate.FWrite("public string " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + this.tvTables.SelectedNode.Text + ".cs");
                }
                else
                {
                    FileOperate.FWrite("public string " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + fastName + "Content.cs");
                }


                return;
            }
            var type = obj.GetType();
            if (type == typeof(int))
            {
                if (IsF)
                {
                    FileOperate.FWrite("public int " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + this.tvTables.SelectedNode.Text + ".cs");
                }
                else
                {
                    FileOperate.FWrite("public int " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + fastName + "Content.cs");
                }

                return;
            }
            else if (type == typeof(string))
            {
                if (IsF)
                {
                    FileOperate.FWrite("public string " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + this.tvTables.SelectedNode.Text + ".cs");
                }
                else
                {
                    FileOperate.FWrite("public string " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + fastName + "Content.cs");
                }

                return;
            }
            else if (type == typeof(Dictionary<string, Object>))//键值对
            {
                Dictionary<string, Object> chi = obj as Dictionary<string, Object>;
                List<string> keys = chi.Keys.ToList();
                if (IsF)
                {
                    FileOperate.FWrite("public " + fileName + "Content  " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + this.tvTables.SelectedNode.Text + ".cs");
                }
                else
                {
                    FileOperate.FWrite("public " + fileName + "Content  " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + fastName + "Content.cs");
                }
                FileOperate.FWrite("using System;\r\nnamespace Model\r\n{\r\npublic class " + fileName + "Content\r\n{\r\n", "" + subPath + "\\" + fileName + "Content.cs");
                int i = 0;
                foreach (var s in keys)
                {
                    i++;
                    findNode(chi[s], s, fileName, false);
                    if (i == keys.Count)
                    {
                        FileOperate.FWrite("}\r\n}\r\n", "" + subPath + "\\" + fileName + "Content.cs");
                        CreateManger("" + fileName + "Content");
                        CreateComponent("" + fileName + "Content");
                    }
                }
            }
            else //集合
            {
                Object[] objArr = obj as Object[];
                Dictionary<string, Object> chi = objArr[0] as Dictionary<string, Object>;
                List<string> keys = chi.Keys.ToList();
                if (IsF)
                {
                    FileOperate.FWrite("public List<" + fileName + "Content>  " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + this.tvTables.SelectedNode.Text + ".cs");
                }
                else
                {
                    FileOperate.FWrite("public List<" + fileName + "Content>  " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + fastName + "Content.cs");
                }
                FileOperate.FWrite("using System;\r\nnamespace Model\r\n{\r\npublic class " + fileName + "Content\r\n{\r\n", "" + subPath + "\\" + fileName + "Content.cs");
                int i = 0;
                foreach (var s in keys)
                {
                    i++;
                    
                    findNode(chi[s], s, fileName, false);
                    if (i == keys.Count)
                    {
                        FileOperate.FWrite("}\r\n}\r\n", "" + subPath + "\\" + fileName + "Content.cs");
                        CreateManger("" + fileName + "Content");
                        CreateComponent("" + fileName + "Content");
                    }


                }
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

        #region 自动生成数据访问层=================
        /// <summary>
        /// 自动生成数据访问层
        /// </summary>
        private void CreateManger(string ClassName)
        {
            //检查是否存在文件夹
            MgPath = subPathName + "/" + ManagerName.Text + "";
            if (false == System.IO.Directory.Exists(MgPath))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(MgPath);
            }
            string targetPath = MgPath + "\\ManagerBase.cs";//结果保存到桌面
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
            FileOperate.FileWrite(code_list, "" + MgPath + "/" + ClassName + "Manager.cs");

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
            CpPath = subPathName + "\\" + ConpontentName.Text + "";
            if (false == System.IO.Directory.Exists(CpPath))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(CpPath);
            }

            string targetPath = CpPath + "\\ComponentBase.cs";//结果保存到桌面
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
            FileOperate.FileWrite(code_list, "" + CpPath + "/" + className + "Component.cs");
           

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

        private void tvTables_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string dataName = this.tvTables.SelectedNode.Text;

            
        
            string name = string.Empty;
            DataTable dt = new DataTable();
            dt.Columns.Add("表名称");
            dt.Columns.Add("服务名");
            dt.Columns.Add("类型");
            dt.Columns.Add("查询条件");
            string[] strArr = { "insert", "update","delete","getall"};
            for (int i = 0; i < strArr.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = this.tvTables.SelectedNode.Text;
                dr[1] = strArr[i];
              
                dt.Rows.Add(dr);
            }
            this.dgvColumns.DataSource = dt;
            ((DataGridViewComboBoxColumn)dgvColumns.Columns["类型"]).DefaultCellStyle.NullValue = "HttpGet";

        }
    }
}
