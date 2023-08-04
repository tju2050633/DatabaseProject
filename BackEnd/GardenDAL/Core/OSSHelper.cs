using Aliyun.OSS;
using Aliyun.OSS.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Garden.DAL.Core
{
    public static class OSSHelper
    {
        static string accessKeyId = "LTAI5tC6nc26iJYDa7iWJFRZ";
        static string accessKeySecret = "tZEndrhkAdUFo1PDUQcInGfwJKynm0";
        static string endpoint = "oss-cn-hangzhou.aliyuncs.com";
        static string bucketName = "sharing-garden";    //OSS图片存储空间

        public static bool PutObjectFromLocalFile(string objectName, string localFilename)
        {
            OssClient client = new(endpoint, accessKeyId, accessKeySecret);
            try
            {
                var obj = client.PutObject(bucketName, objectName, localFilename);
                if (obj != null && obj.HttpStatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (OssException ex)
            {
                Console.WriteLine(string.Format("Failed with error code: {0}; Error info: {1}. \nRequestID:{2}\tHostID:{3},BucketName:{4},fileName:{5}",
                    ex.ErrorCode, ex.Message, ex.RequestId, ex.HostId, bucketName, objectName));
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Failed with error info: {0},BucketName:{1},fileName:{2}", ex.Message, bucketName, objectName));
                return false;
            }
        }
    }
}
