using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace LogHelper
{
    //桌面文件管理类
    public class LogHelper
    {
        /// <summary>
        /// 当前日志文件的文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 当前日志全名称
        /// </summary>
        private string _FullName;

        #region 初始化构造器
        public LogHelper()
        {
            this.FileName = "log";
            _FullName = GetFileName();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="filename">文件名或文件全名</param>
        /// <param name="IsFullName">是否是文件全名</param>
        public LogHelper(string filename, bool IsFullName = false)
        {
            if (IsFullName)
            {
                FileInfo info = new FileInfo(filename);
                //如果不存在创建文件
                if (info.Exists == false)
                {
                    //判断文件夹是否存在
                    if (info.Directory.Exists == false)
                    {
                        info.Directory.Create();
                    }
                    info.Create().Close();
                }
                //if (info.IsReadOnly)
                //    throw new Exception("初始化日志文件为只读文件");
                this.FileName = info.Name;
                this._FullName = info.FullName;
            }
            else
            {
                this.FileName = filename;
                _FullName = GetFileName();
            }
        }
        #endregion

        /// <summary>
        /// 如果仅指定日志的文件名
        /// 获取文件全路径
        /// </summary>
        /// <returns></returns>
        public string GetFileName()
        {
            string filename = "";
            try
            {
                filename = "e:\\" + FileName + ".txt";
            }
            catch
            {
                filename = LocalPathHelper.DesktopPath + "\\" + FileName + ".txt";
            }
            if (File.Exists(filename) == false)
            {
                using (File.Create(filename))
                {
                }
            }
            return filename;
        }
        /// <summary>
        /// 向文件中最佳一行内容，指定格式
        /// 时间+content
        /// </summary>
        /// <param name="content">写入内容</param>
        public void WriteLine(string content)
        {
            using (StreamWriter sw = new StreamWriter(_FullName, true, Encoding.Default))
            {
                sw.WriteLine(DateTime.Now.ToString() + ":  " + content);
                sw.Flush();
            }
        }
        /// <summary>
        /// 写入 Unicode 文本
        /// </summary>
        /// <param name="content">写入内容</param>
        public void WriteLineUnicode(string content)
        {
            using (StreamWriter sw = new StreamWriter(_FullName, true, Encoding.Unicode))
            {
                sw.WriteLine(DateTime.Now.ToString() + ":  " + content);
                sw.Flush();
            }
        }
    }
}
