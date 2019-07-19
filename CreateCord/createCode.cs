﻿using System;
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
        public string TableName = string.Empty;
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
        string strvalue = string.Empty;
        private void createCode_Load(object sender, EventArgs e)
        {
            IcreateType = new PGCreateCode(ConnectionString);
            DataTable dt_Tables = IcreateType.GetTables();
     
            dgridTable.DataSource = dt_Tables;
            dgridTable.ClearSelection();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (null == dgvColumns.DataSource)
            {
                MessageBox.Show("请选择需要生成的表", "提示");
                return;
            }
            subPathName = "" + t_path.Text + "" + fileName.Text + ""; //创建文件夹
            if (false == System.IO.Directory.Exists(subPathName))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPathName);
            }
            DataRow[] list = IcreateType.GetColumns(TableName).Select("type='jsonb' or type='json'");
            DataTable lists = IcreateType.GetData(TableName);

            if (list.Length != 0)
            {
                string name = list[0][0].ToString();
                strvalue = string.Empty;
                if (lists.Rows.Count > 0)
                {

                    strvalue = lists.Rows[0]["" + name + ""].ToString();
                }
            }
            CreateModel(strvalue);
        }
      
        public void findNode(object obj, string fileName, string fastName, bool IsF)
        {
            if (null == obj)
            {
                if (IsF)
                {
                    FileOperate.FWrite("public string " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + TableName + ".cs");
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
                    FileOperate.FWrite("public int " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + TableName + ".cs");
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
                    FileOperate.FWrite("public string " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + TableName + ".cs");
                }
                else
                {
                    FileOperate.FWrite("public string " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + fastName + "Content.cs");
                }

                return;
            }
            else if (type == typeof(bool))
            {
                if (IsF)
                {
                    FileOperate.FWrite("public bool " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + TableName + ".cs");
                }
                else
                {
                    FileOperate.FWrite("public bool " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + fastName + "Content.cs");
                }

                return;
            }
            else if (type == typeof(Dictionary<string, Object>))//键值对
            {
                Dictionary<string, Object> chi = obj as Dictionary<string, Object>;
                List<string> keys = chi.Keys.ToList();
                if (IsF)
                {
                    FileOperate.FWrite("public " + fileName + "Content  " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + TableName + ".cs");
                }
                else
                {
                    FileOperate.FWrite("public " + fileName + "Content  " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + fastName + "Content.cs");
                }
                FileOperate.FWrite("using System;\r\nusing System.Collections.Generic;\r\nnamespace " + ModelName.Text.Trim() + "\r\n{\r\npublic class " + fileName + "Content\r\n{\r\n", "" + subPath + "\\" + fileName + "Content.cs");
                int i = 0;
                foreach (var s in keys)
                {
                    i++;
                    findNode(chi[s], s, fileName, false);
                    if (i == keys.Count)
                    {
                        FileOperate.FWrite("}\r\n}\r\n", "" + subPath + "\\" + fileName + "Content.cs");

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
                    FileOperate.FWrite("public List<" + fileName + "Content>  " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + TableName + ".cs");
                }
                else
                {
                    FileOperate.FWrite("public List<" + fileName + "Content>  " + fileName + "  {get;set;}\r\n", "" + subPath + "\\" + fastName + "Content.cs");
                }
                FileOperate.FWrite("using System;\r\nusing System.Collections.Generic;\r\nnamespace " + ModelName.Text.Trim() + "\r\n{\r\npublic class " + fileName + "Content\r\n{\r\n", "" + subPath + "\\" + fileName + "Content.cs");
                int i = 0;
                foreach (var s in keys)
                {
                    i++;

                    findNode(chi[s], s, fileName, false);
                    if (i == keys.Count)
                    {
                        FileOperate.FWrite("}\r\n}\r\n", "" + subPath + "\\" + fileName + "Content.cs");

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

        #region 自动生成实体类=======================
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

            FileOperate.FWrite("using System;\r\nusing System.Collections.Generic;\r\nnamespace " + ModelName.Text.Trim() + "\r\n{\r\npublic class " + TableName + "\r\n{\r\n", "" + subPath + "\\" + TableName + ".cs");
            if (json != null)
            {
                List<string> keys = json.Keys.ToList();
                foreach (var s in keys)
                {
                    findNode(json[s], s, "test", true);
                }
            }


            DataRow[] Rowlist = IcreateType.GetColumns(TableName).Select("type <> 'jsonb' and type <>'json'");
            for (int i = 0; i < Rowlist.Length; i++)
            {
                string classType = FileOperate.SqlTypeTope(Rowlist[i][1].ToString());
                if (classType == "")
                {
                    classType = "string";
                }
                string className = Rowlist[i][0].ToString();
                FileOperate.FWrite("public  " + classType + "  " + className + "    {get;set;}\r\n", "" + subPath + "\\" + TableName + ".cs");

            }
            FileOperate.FWrite("}\r\n}\r\n", "" + subPath + "\\" + TableName + ".cs");
            CreateManger(TableName);
            CreateComponent((DataTable)dgvColumns.DataSource);
            CreateControllers((DataTable)dgvColumns.DataSource);
        } 
        #endregion
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

            code_list.Add(string.Format("using {0};",ModelName.Text.Trim()));
            code_list.Add("using System.Collections.Generic;");
            code_list.Add("using System.Linq;");
            code_list.Add("using System.Text;");
            code_list.Add(" using System.Threading.Tasks;");
            code_list.Add(" namespace "+ManagerName.Text.Trim()+"");
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
        ///  自动生成逻辑层
        /// </summary>
        /// <param name="datasource">服务表</param>
        public void CreateComponent(DataTable datasource)
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
            code_list.Add(string.Format("using {0};", ManagerName.Text.Trim()));
            code_list.Add(string.Format("using {0};", ModelName.Text.Trim()));
            code_list.Add(" namespace "+ConpontentName.Text.Trim()+"");
            code_list.Add("{");
            code_list.Add(" public class " + TableName + "Component :ComponentBase<" + TableName + "," + TableName + "Manager>");
            code_list.Add("{");

            foreach (DataRow dr in datasource.Rows)
            {
                string strTypeName = dr["服务名"].ToString();
                string strQueryCondition = dr["查询条件"].ToString();
                if (strTypeName == "GetAll")
                {

                    code_list.Add(string.Format(" public int {0} ({1})", strTypeName, strQueryCondition));
                    code_list.Add("{");

                    List<string> typeVlue = retSrtName(strQueryCondition);
                    string para = string.Empty;
                    foreach (string s in typeVlue)
                    {
                        para += s + ",";
                    }
                    if (para.Length > 0)
                        para = para.Substring(0, para.Length - 1);
                    code_list.Add(string.Format("return manager.{0}({1});", strTypeName, para));
                    code_list.Add("}");
                }
                else
                {
                    code_list.Add(string.Format(" public int {0} ({1})", strTypeName, strQueryCondition));
                    code_list.Add("{");
                    List<string> typeVlue = retSrtName(strQueryCondition);
                    string para = string.Empty;
                    foreach (string s in typeVlue)
                    {
                        para += s + ",";
                    }
                    if (para.Length > 0)
                        para = para.Substring(0, para.Length - 1);
                    code_list.Add(string.Format("return manager.{0}({1});", strTypeName, para));
                    code_list.Add("}");
                }
            }
            code_list.Add("}");
            code_list.Add("}");
            FileOperate.FileWrite(code_list, "" + CpPath + "/" + TableName + "Component.cs");
        }

        #endregion
        #region 自动生成控制器==============
        /// <summary>
        /// 自动生成控制器
        /// </summary>
        /// <param name="dataJson">服务表</param>
        public void CreateControllers(DataTable dataJson)
        {
            //获取当前文件夹路径
            //string currPath = Application.StartupPath;
            //检查是否存在文件夹
            string subPath = subPathName + "\\" + ControllersName.Text;
            if (false == System.IO.Directory.Exists(subPath))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPath);
            }
            string className = dataJson.Rows[0][0].ToString();
            List<string> code_list = new List<string>();
            code_list.Add("using System;");
            code_list.Add("using " + ConpontentName.Text + ";");
            code_list.Add("using System.Collections.Generic;");
            code_list.Add("using System.Linq;");
            code_list.Add("using System.Text;");
            code_list.Add("using System.Web.Mvc;");
            code_list.Add("using WebApiModel;");
            code_list.Add("using System.Threading.Tasks;");
            code_list.Add("namespace Controllers");
            code_list.Add("{");
            code_list.Add("public class " + className + "Controller : Controller");
            code_list.Add("{");

            code_list.Add("public string Get()");
            code_list.Add("{");
            code_list.Add("string str = BaseFunction.GetControllerInfo<"+ className + "Controller>();");
            code_list.Add("return str;");
            code_list.Add("}");
            int i = 0;
            foreach (DataRow dr in dataJson.Rows)
            {
                string strServerName = dr["服务名"].ToString();
                if (null == strServerName || strServerName == "" || strServerName.Length == 0) continue;
                string strType = this.dgvColumns.Rows[i].Cells["类型"].FormattedValue.ToString();
                string strQueryCondition = dr["查询条件"].ToString();
                code_list.Add(string.Format("[{0}(\"{1}\")]", strType, strServerName));
                code_list.Add("[displayname(name=\"\")]");
                code_list.Add("[note(name=\"\")]");
                code_list.Add("[paraoutname(name=\"\")]");
                code_list.Add("[schemaVal(name=\"\")]");
                if (strServerName == "GetAll")
                    code_list.Add(string.Format("public List<{0}> {1}({2})", className, strServerName, strQueryCondition));
                else
                    code_list.Add(string.Format("public int {0}({1})", strServerName, strQueryCondition));
                code_list.Add("{");
                code_list.Add(className + "Component cp=new " + className + "Component();");

                List<string> typeVlue = retSrtName(strQueryCondition);
                string para = string.Empty;
                foreach (string s in typeVlue)
                {
                    para += s + ",";
                }
                if (para.Length > 0)
                    para = para.Substring(0, para.Length - 1);
                code_list.Add(string.Format("return cp.{0}({1});", strServerName, para));
                code_list.Add("}");
                i++;
            }

            code_list.Add("}");
            code_list.Add("}");
            FileOperate.FileWrite(code_list, "" + subPath + "/" + className + "Controller.cs");
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
        #region 分割字符串==============
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="str">查询字符串</param>
        /// <returns></returns>
        public List<string> retSrtName(string str)
        {
            List<string> LStr = new List<string>();
            if (null == str || str.Length == 0) return LStr;
            str = str.Trim();
            string[] fArr = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in fArr)
            {
                string ss = s.Trim();
                string[] sArr = ss.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (sArr.Length == 2)
                    LStr.Add(sArr[1].Trim());
            }
            return LStr;

        }
        #endregion

        private void dgridTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string dataName = dgridTable.Rows[e.RowIndex].Cells["name"].Value.ToString();

            string name = string.Empty;
            DataTable dt = new DataTable();
            dt.Columns.Add("表名称");
            dt.Columns.Add("服务名");
            dt.Columns.Add("类型");
            dt.Columns.Add("查询条件");
            string[] strArr = { "Insert", "Update", "Delete", "GetAll" };
            for (int i = 0; i < strArr.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = dataName;
                dr[1] = strArr[i];

                dt.Rows.Add(dr);
            }
            this.dgvColumns.DataSource = dt;
            ((DataGridViewComboBoxColumn)dgvColumns.Columns["类型"]).DefaultCellStyle.NullValue = "HttpGet";
            TableName = dataName;

        }
        /// <summary>
        /// 获取需要生成表的名称
        /// </summary>
        /// <returns></returns>
        public string GetTableName()
        {
            return dgridTable.SelectedRows[0].Cells["name"].Value.ToString();
        }

        private void BtnAddRow_Click(object sender, EventArgs e)
        {
            if (null == dgvColumns.DataSource)
            {
                MessageBox.Show("请选择需要生成的表", "提示");
                return;
            }
            DataTable table = dgvColumns.DataSource as DataTable;
            DataRow dr = table.NewRow();
            dr[0] = TableName;
            table.Rows.Add(dr);
            dgvColumns.Rows[table.Rows.Count - 1].Cells[1].ReadOnly = false;
            

        }
    }
}
