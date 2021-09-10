using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ExcelExportHelper
    {
        static XSSFWorkbook _workbook = new();
        /// <summary>
        /// 导出excel文件，返回文件名(完整路径)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">文件绝对路径，不包含文件名</param>
        /// <param name="list">数据集合</param>
        /// <returns>文件完整路径</returns>
        public static string Export<T>(string path, List<T> list, string dateDirFormat = "yyyyMMdd") where T : class, new()
        {
            CheckParams(path, list);

            const string suffix = ".xlsx";
            var fileName = Guid.NewGuid().ToString().Replace("-", "") + suffix;
            var absolutePath = Path.Combine(path, DateTime.Now.ToString(string.IsNullOrEmpty(dateDirFormat) ? "yyyyMMdd" : dateDirFormat));

            if (!Directory.Exists(absolutePath))
            {
                Directory.CreateDirectory(absolutePath);
            }

            var first = list.First();
            var tAttr = first.GetType().GetCustomAttributes(typeof(ExportAttribute), true).FirstOrDefault();
            var sheet = _workbook.CreateSheet(tAttr is ExportAttribute ea ? ea.SheetName : first.GetType().Name);

            FillHeader(first, sheet);

            foreach (T item in list)
            {
                FillContent(item, sheet);
            }
            var savePath = Path.Combine(absolutePath, fileName);
            var fs = File.Create(savePath);
            _workbook.Write(fs);

            return savePath;
        }

        /// <summary>
        /// 校验参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">绝对路径</param>
        /// <param name="list">数据集合</param>
        private static void CheckParams<T>(string path, List<T> list)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("文件路径不能为空");
            if (list == null || list.Count.Equals(0)) throw new ArgumentException($"{nameof(T)}数据集合不能为null或者空集");
        }

        /// <summary>
        /// 填充表头
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="sheet"></param>
        private static void FillHeader<T>(T item, ISheet sheet) where T : class, new()
        {
            FillValue(item, sheet, true);
        }

        /// <summary>
        /// 填充数据内容
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="sheet"></param>
        private static void FillContent<T>(T item, ISheet sheet) where T : class, new()
        {
            FillValue(item, sheet, false);
        }

        /// <summary>
        /// 填充数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="sheet"></param>
        /// <param name="isHeader"></param>
        private static void FillValue<T>(T item, ISheet sheet, bool isHeader) where T : class, new()
        {
            Dictionary<string, string> error = (Dictionary<string, string>)item.GetType().GetProperty("Error")?.GetValue(item);

            var row = sheet.CreateRow(isHeader ? 0 : sheet.LastRowNum + 1);
            int i = 0;
            foreach (var property in item.GetType().GetProperties().Where(p => !p.Name.Equals("Error")))
            {
                var value = isHeader ? property.Name : property.GetValue(item);
                if (isHeader)
                {
                    var attr = property.GetCustomAttributes(typeof(ExportHeaderAttribute), true).FirstOrDefault();
                    if (attr is ExportHeaderAttribute ea)
                    {
                        value = ea.DisplayName;
                    }
                }
                var cell = row.CreateCell(i);
                if (error != null && error.Count > 0 && error.ContainsKey(property.Name) && !isHeader)
                {
                    cell.SetErrorStyle(_workbook, sheet, error[property.Name]);
                }
                cell.SetCellValue(value.ToString());
                i++;
            }
        }
    }


    public static class NPOIExt
    {
        /// <summary>
        /// 设置错误单元格字体为红色
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="workbook"></param>
        /// <returns></returns>
        public static ICell SetErrorStyle(this ICell cell, IWorkbook workbook, ISheet sheet = null, string errorMsg = null)
        {

            if (cell == null) throw new NullReferenceException("ICell不能为null");
            IFont font = workbook.CreateFont();
            font.Color = HSSFColor.Red.Index;
            ICellStyle style = workbook.CreateCellStyle();
            style.SetFont(font);
            cell.CellStyle = style;
            if (!string.IsNullOrEmpty(errorMsg) && sheet != null)
            {
                cell.CellComment = Comment();
            }
            return cell;

            XSSFComment Comment()
            {
                var patr = sheet.CreateDrawingPatriarch();
                var comment = (XSSFComment)patr.CreateCellComment(new XSSFClientAnchor(0, 0, 0, 0, 1, 2, 4, 16));
                comment.String = new XSSFRichTextString(errorMsg);
                comment.Author = "Acow.Parking";
                return comment;
            }

        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ExportHeaderAttribute : Attribute
    {
        public ExportHeaderAttribute(string displayName)
        {
            DisplayName = displayName;
        }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class ExportAttribute : Attribute
    {
        public ExportAttribute(string sheetName)
        {
            SheetName = sheetName;
        }
        /// <summary>
        /// sheet名称
        /// </summary>
        public string SheetName { get; }
    }

    public class ExportBase
    {
        public Dictionary<string, string> Error { get; set; }
    }

    [Export("学生信息")]
    public class Student : ExportBase
    {
        /// <summary>
        /// 年龄
        /// </summary>
        [ExportHeader(displayName: "年龄")]
        public int Age { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [ExportHeader(displayName: "姓名")]
        public string Name { get; set; }

        public int Test { get; set; }
        public int Test2 { get; set; }
        public int Test3 { get; set; }
    }
}
