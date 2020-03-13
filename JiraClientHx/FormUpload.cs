using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JiraClientHx
{
    public static class FormUpload
    {
        /// <summary>
        /// 字符编码格式
        /// </summary>
        private static readonly Encoding encoding = Encoding.UTF8;
        private const string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        /// <summary>
        /// 上传图像和参数
        /// </summary>
        /// <param name="url">上传地址</param>
        /// <param name="image">图像byte数组</param>
        /// <param name="imageName">图像名称，带扩展名</param>
        /// <param name="data">参数</param>
        /// <returns>响应内容</returns>
        public static string UploadImageAndData(string url, byte[] image, string imageName, string sprint,string username,string password,string email)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("file", new FormUpload.FileParameter(image, imageName));
            dic.Add("sprint", sprint);
            dic.Add("username", username);
            dic.Add("password", password);
            dic.Add("email", email);

            try
            {
                HttpWebResponse r = FormUpload.MultipartFormDataPost(url, DefaultUserAgent, dic);
                Stream instream = r.GetResponseStream();
                StreamReader sr = new StreamReader(instream, Encoding.UTF8);
                //返回结果网页(html)代码 
                string retValue = sr.ReadToEnd();
                sr.Close();
                return retValue;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static HttpWebResponse MultipartFormDataPost(string postUrl, string userAgent, Dictionary<string, object> postParameters)
        {
            //分割标记
            string formDataBoundary = String.Format("----------{0:N}", Guid.NewGuid());
            //内容类型
            string contentType = "multipart/form-data; boundary=" + formDataBoundary;
            byte[] formData = GetMultipartFormData(postParameters, formDataBoundary);
            return PostForm(postUrl, userAgent, contentType, formData);
        }

        private static HttpWebResponse PostForm(string postUrl, string userAgent, string contentType, byte[] formData)
        {
            HttpWebRequest request = WebRequest.Create(postUrl) as HttpWebRequest;
            if (request == null)
            {
                throw new NullReferenceException("request is not a http request");
            }
            // Set up the request properties. 
            request.Method = "POST";
            request.ContentType = contentType;
            //request.ContentType = "application/json;charset=utf-8";
            request.UserAgent = userAgent;
            request.CookieContainer = new CookieContainer();
            request.ContentLength = formData.Length;
            request.Timeout = 1000 * 60;
            // You could add authentication here as well if needed: 
            // request.PreAuthenticate = true; 
            // request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested; 
            // request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes("username" + ":" + "password"))); 
            // Send the form data to the request. 
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(formData, 0, formData.Length);
                requestStream.Close();
            }
            return request.GetResponse() as HttpWebResponse;
        }

        private static byte[] GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
        {
            Stream formDataStream = new System.IO.MemoryStream();
            bool needsCLRF = false;
            foreach (var param in postParameters)
            {
                // Thanks to feedback from commenters, add a CRLF to allow multiple parameters to be added. 
                // Skip it on the first parameter, add it to subsequent parameters. 
                if (needsCLRF)
                {
                    formDataStream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));
                }
                needsCLRF = true;
                if (param.Value is FileParameter)
                {
                    FileParameter fileToUpload = (FileParameter)param.Value;
                    // Add just the first part of this param, since we will write the file data directly to the Stream 
                    string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: {3}\r\n\r\n", boundary, param.Key, fileToUpload.FileName ?? param.Key, fileToUpload.ContentType ?? "application/octet-stream");
                    formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));
                    // Write the file data directly to the Stream, rather than serializing it to a string. 
                    formDataStream.Write(fileToUpload.File, 0, fileToUpload.File.Length);
                }
                else
                {
                    string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}", boundary, param.Key, param.Value);
                    formDataStream.Write(encoding.GetBytes(postData), 0, encoding.GetByteCount(postData));
                }
            }
            // Add the end of the request. Start with a newline 
            string footer = "\r\n--" + boundary + "--\r\n";
            formDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));
            // Dump the Stream into a byte[] 
            formDataStream.Position = 0;
            byte[] formData = new byte[formDataStream.Length];
            formDataStream.Read(formData, 0, formData.Length); formDataStream.Close();
            return formData;
        }

        /// <summary>
        /// 文件参数对象
        /// </summary>
        public class FileParameter
        {
            /// <summary>
            /// 文件二进制数组
            /// </summary>
            public byte[] File { get; set; }
            /// <summary>
            /// 文件名称，带扩展名，例如：aaa.jpg
            /// </summary>
            public string FileName { get; set; }
            /// <summary>
            /// 内容类型，默认application/octet-stream
            /// </summary>
            public string ContentType { get; set; }
            public FileParameter(byte[] file)
                : this(file, null)
            {
            }
            public FileParameter(byte[] file, string filename)
                : this(file, filename, null)
            {
            }
            public FileParameter(byte[] file, string filename, string contenttype)
            {
                File = file;
                FileName = filename;
                ContentType = contenttype;
            }
        }
    }
}
