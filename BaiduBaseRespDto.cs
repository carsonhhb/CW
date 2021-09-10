using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BaiduBaseRespDto<T>
    {
        public string error_code { get; set; }
        public string error_msg { get; set; }

        public T result { get; set; }
    }

    public class BaiduSearchRespDto
    {
        /// <summary>
        /// 人脸标志
        /// </summary>
        public string face_token { get; set; }
        /// <summary>
        /// 匹配的用户信息列表
        /// </summary>
        public List<BaiduSearchUserRespDto> user_list { get; set; }

    }
    public class BaiduSearchUserRespDto
    {
        /// <summary>
        /// 用户所属的group_id
        /// </summary>
        public string group_id { get; set; }
        /// <summary>
        /// 用户的user_id
        /// </summary>
        public string user_id { get; set; }
        /// <summary>
        /// 注册用户时携带的user_info
        /// </summary>
        public string user_info { get; set; }
        /// <summary>
        /// 用户的匹配得分
        /// </summary>
        public float score { get; set; }
    }

}
