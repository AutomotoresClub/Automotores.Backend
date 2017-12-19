using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Automotores.Backend.Core.Services
{
    public class UploadService : IUploadService
    {

        private readonly IErrorReporter reporter;
        IAmazonS3 s3Client;
        private readonly IHostingEnvironment host;

        public UploadService(IErrorReporter reporter, IHostingEnvironment host)
        {
            this.host = host;
            this.reporter = reporter;
            this.s3Client = new AmazonS3Client(new AmazonS3Config
            {
                Timeout = TimeSpan.FromSeconds(10),
                MaxErrorRetry = 2,
                RegionEndpoint = RegionEndpoint.USWest2
            });
        }

        public async Task<string> UploadFile(IFormFile file, string bucketName)
        {
            var uploadsFolderPath = Path.Combine(host.ContentRootPath, "assets/tmp");
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);
            var fileContentType = file.ContentType;

            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                };
                try
                {
                    PutObjectRequest putRequest = new PutObjectRequest
                    {
                        BucketName = bucketName,
                        Key = fileName,
                        FilePath = filePath,
                        ContentType = fileContentType,
                        CannedACL = S3CannedACL.PublicRead
                    };

                    PutObjectResponse response = await s3Client.PutObjectAsync(putRequest);

                    if (response.HttpStatusCode == HttpStatusCode.OK)
                    {
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                    }

                    return "https://d14gy5s8yv1ger.cloudfront.net/" + fileName;
                }
                catch (AmazonS3Exception amazonS3Exception)
                {
                    await reporter.CaptureAsync(amazonS3Exception);
                    return "";
                }
            }
            catch (Exception exception)
            {
                await reporter.CaptureAsync(exception);
                return "";

            }
        }
    }
}