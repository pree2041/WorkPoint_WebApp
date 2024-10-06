using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkPoint_WebApp.Data;
using WorkPoint_WebApp.Entities.Models;
using WorkPoint_WebApp.Exceptions;
using WorkPoint_WebApp.Service.Contract;
using WorkPoint_WebApp.Shared.DataTransferObjects;
using WorkPoint_WebApp.Shared.Parameters;

namespace WorkPoint_WebApp.Services
{
    public class NewsService : INewsService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly HttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public class UploadDto
        {
            public string? Title { get; set; }
            public IFormFile? File { get; set; }
            public string? FileName { get; set; }
        }

        public class GenerateFileDto
        {
            public bool status { get; set; } 
            public string? fileName { get; set; } 
            public int? errorType { get; set; } 
            public string? msg { get; set; } 
        }

        public NewsService(IConfiguration configuration, ApplicationDbContext context,IMapper mapper) 
        {
            _configuration = configuration;
            _context = context; // กำหนดค่า _context
            _mapper = mapper;
        }
        

        public async Task<bool> CreateNewsAsync(NewsDto newsDto)
        {
            string dNow = DateTime.Now.ToString("yyyyMMdd");
            string tNow = DateTime.Now.ToString("HHmmss");
            Guid id = Guid.NewGuid();

            List<UploadDto> uploads = new List<UploadDto>()
            { 
                new UploadDto{ Title="Picture1", File= newsDto.Picture1,FileName = ""},
                new UploadDto{ Title="Picture2", File= newsDto.Picture2,FileName = ""},
                new UploadDto{ Title="Picture3", File= newsDto.Picture3, FileName = ""},
                new UploadDto{ Title="Picture4", File= newsDto.Picture4, FileName = ""},
                new UploadDto{ Title="Picture5", File= newsDto.Picture5, FileName = ""},
                new UploadDto{ Title="Picture6", File= newsDto.Picture6, FileName = ""},
                new UploadDto{ Title="Picture7", File= newsDto.Picture7, FileName = ""},
                new UploadDto{ Title="Picture8", File= newsDto.Picture8, FileName = ""},
                new UploadDto{ Title="Picture9", File= newsDto.Picture9, FileName = ""},
                new UploadDto{ Title="Picture10", File= newsDto.Picture10,FileName = ""},

            };
            foreach (var upload in uploads)
            {
                if (upload.File != null)
                {
                    var result = GenerateFileUpload(upload.File, dNow, tNow, id, upload.Title ?? "", _configuration["config:fileSize"] ?? "", _configuration["filePath:rootPath"] ?? "");
                    upload.FileName = result.fileName;
                    if (!result.status)
                    {
                        throw new Exception(result.msg);
                    }
                }
            }

            News newsEntity = new News();
            newsEntity.Id = id;
            newsEntity.Title = newsDto.Title;
            newsEntity.Detail1 = newsDto.Detail1;
            newsEntity.Detail2 = newsDto.Detail2;
            newsEntity.Detail3 = newsDto.Detail3;
            newsEntity.CreatedDate = dNow;
            newsEntity.CreatedTime = tNow;
            if (newsDto.Picture1 != null) newsEntity.Picture1 = uploads[0].FileName;
            if (newsDto.Picture2 != null) newsEntity.Picture2 = uploads[1].FileName;
            if (newsDto.Picture3 != null) newsEntity.Picture3 = uploads[2].FileName;
            if (newsDto.Picture4 != null) newsEntity.Picture4 = uploads[3].FileName;
            if (newsDto.Picture5 != null) newsEntity.Picture5 = uploads[4].FileName;
            if (newsDto.Picture6 != null) newsEntity.Picture6 = uploads[5].FileName;
            if (newsDto.Picture7 != null) newsEntity.Picture7 = uploads[6].FileName;
            if (newsDto.Picture8 != null) newsEntity.Picture8 = uploads[7].FileName;
            if (newsDto.Picture9 != null) newsEntity.Picture9 = uploads[8].FileName;
            if (newsDto.Picture10 != null) newsEntity.Picture10 = uploads[9].FileName;

            _context.Add(newsEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<NewsReturnDto> GetNewsAsync(Guid id)
        {
            var data = await _context.News.FindAsync(id);
            if(data == null)
            {
                throw new NotFoundException("News not found.");
            }

            var dataToReturn = _mapper.Map<NewsReturnDto>(data);
            return dataToReturn;

        }

        public async Task<PagedList<NewsReturnDto>> GetNewsListAsync(NewsParameters newsParam)
        {
            var query = _context.News.AsQueryable();

            var totalCount = await query.CountAsync();

            // Apply pagination
            var dataList = await query
                .Skip((newsParam.PageNumber - 1) * newsParam.PageSize) 
                .Take(newsParam.PageSize)
                .ToListAsync();

            var dataListToReturn = _mapper.Map<IEnumerable<NewsReturnDto>>(dataList);
            return new PagedList<NewsReturnDto>(dataListToReturn.ToList(), totalCount, newsParam.PageNumber, newsParam.PageSize);
        }

        public async Task<bool> UpdateNewsAsync(Guid id,NewsDto newsDto)
        {
            var newsDb = await _context.News.AsTracking().FirstOrDefaultAsync(n => n.Id == id);
            if (newsDb == null)
            {
                throw new NotFoundException("News not found.");
            }
            string dNow = DateTime.Now.ToString("yyyyMMdd");
            string tNow = DateTime.Now.ToString("HHmmss");

            List<UploadDto> uploads = new List<UploadDto>()
            {
                new UploadDto{ Title="Picture1", File= newsDto.Picture1,FileName = ""},
                new UploadDto{ Title="Picture2", File= newsDto.Picture2,FileName = ""},
                new UploadDto{ Title="Picture3", File= newsDto.Picture3, FileName = ""},
                new UploadDto{ Title="Picture4", File= newsDto.Picture4, FileName = ""},
                new UploadDto{ Title="Picture5", File= newsDto.Picture5, FileName = ""},
                new UploadDto{ Title="Picture6", File= newsDto.Picture6, FileName = ""},
                new UploadDto{ Title="Picture7", File= newsDto.Picture7, FileName = ""},
                new UploadDto{ Title="Picture8", File= newsDto.Picture8, FileName = ""},
                new UploadDto{ Title="Picture9", File= newsDto.Picture9, FileName = ""},
                new UploadDto{ Title="Picture10", File= newsDto.Picture10,FileName = ""},

            };
            foreach (var upload in uploads)
            {
                if (upload.File != null)
                {
                    var result = GenerateFileUpload(upload.File, dNow, tNow, id, upload.Title ?? "", _configuration["config:fileSize"] ?? "", _configuration["filePath:rootPath"] ?? "");
                    upload.FileName = result.fileName;
                    if (!result.status)
                    {
                        throw new Exception(result.msg);
                    }
                }
            }

            _mapper.Map(newsDto, newsDb);

            newsDb.CreatedDate = dNow;
            newsDb.CreatedTime = tNow;
            if (newsDto.Picture1 != null) newsDb.Picture1 = uploads[0].FileName;
            if (newsDto.Picture2 != null) newsDb.Picture2 = uploads[1].FileName;
            if (newsDto.Picture3 != null) newsDb.Picture3 = uploads[2].FileName;
            if (newsDto.Picture4 != null) newsDb.Picture4 = uploads[3].FileName;
            if (newsDto.Picture5 != null) newsDb.Picture5 = uploads[4].FileName;
            if (newsDto.Picture6 != null) newsDb.Picture6 = uploads[5].FileName;
            if (newsDto.Picture7 != null) newsDb.Picture7 = uploads[6].FileName;
            if (newsDto.Picture8 != null) newsDb.Picture8 = uploads[7].FileName;
            if (newsDto.Picture9 != null) newsDb.Picture9 = uploads[8].FileName;
            if (newsDto.Picture10 != null) newsDb.Picture10 = uploads[9].FileName;

            await _context.SaveChangesAsync();

            return true;
        }

        public static GenerateFileDto GenerateFileUpload(IFormFile file, string dNow, string tNow, Guid idRef, string fileTitle, string uploadConfig, string pathConfig)
        {
            var result = new GenerateFileDto();
            result.status = true;
            result.fileName = "";
            var fileType = Path.GetExtension(file.FileName);
            if (fileType == ".HEIC" || fileType == ".heic") fileType = ".png";
            else if (fileType == null || fileType == "") fileType = ".png";

            if (fileType != ".png" && fileType != ".jpeg" && fileType != ".jpg")
            {
                result.status = false;
                result.msg = "ประเภทไฟล์อัปโหลดไม่ถูกต้อง";
                result.errorType = 0;
                return result;
            }


            // checkSize
            if (file.Length > Convert.ToInt64(uploadConfig))
            {
                result.status = false;
                result.msg = "ขนาดไฟล์ไม่ถูกต้อง";
                result.errorType = 1;
                return result;
            }
            result.fileName = $"{fileTitle}_{idRef}_{dNow}_{tNow}{fileType}";

            try
            {
                var path = Path.Combine(pathConfig, "Picture");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var pathFile = string.Concat(path, "/", result.fileName);

                using (FileStream fs = System.IO.File.Create(pathFile))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            catch (Exception ex)
            {
                result.status = false;
                result.msg = "ไม่สามารถอัปโหลดไฟล์ได้";
                result.errorType = 2;
                return result;
            }
            return result;
        }
    }
}
