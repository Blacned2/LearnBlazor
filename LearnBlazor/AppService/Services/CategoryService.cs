using AutoMapper;
using LearnBlazor.AppService.Interface;
using LearnBlazor.AppService.Model;
using LearnBlazor.AutoMapper.Dtos;
using LearnBlazor.Context;
using LearnBlazor.Data;

namespace LearnBlazor.AppService.Services
{
    public class CategoryService : BaseAppService, ICategoryService
    {
        private readonly IMapper _mapper;
        public CategoryService(BlazorDbContext context,IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        public int CategorySize()
        {
            return _context.Categories.Count();
        }

        public ResultObj<Category> CreateOrEdit(CategoryDto request)
        {
            ResultObj<Category> searchResult = new ResultObj<Category>();

            try
            {
                var result = (from u in _context.Categories
                              where u.CategoryID == request.CategoryID
                              select u).FirstOrDefault();

                if (result == null)
                {
                    searchResult.ResultObject = _mapper.Map<Category>(request);
                    searchResult.MessageType = MessageType.Success;
                    searchResult.Message = "Created";
                    _context.Add(request);
                    _context.SaveChanges();
                }
                else
                {
                    searchResult.ResultObject = _mapper.Map<Category>(request);
                    result.CategoryName = searchResult.ResultObject.CategoryName;
                    result.Description = searchResult.ResultObject.Description;
                    _context.Update(result);
                    _context.SaveChanges();
                    searchResult.Message = "Updated";
                    searchResult.MessageType = MessageType.Success;
                }
            }
            catch (Exception ex)
            {
                searchResult.MessageType = MessageType.Error;
                searchResult.Message = ex.Message;
            }
            
            return searchResult;
        }

        public ResultObj<int> Delete(int id)
        {
            ResultObj<int> searchResult = new ResultObj<int>();

            try
            {
                var result = (from u in _context.Categories
                              where u.CategoryID == id
                              select u).FirstOrDefault();
                if(result == null)
                {
                    searchResult.ResultObject = 1;
                    searchResult.MessageType = MessageType.Error;
                    searchResult.Message = "Error";
                }
                else
                {
                    _context.Categories.Remove(result);
                    _context.SaveChanges();
                    searchResult.ResultObject = 0;
                    searchResult.Message = String.Empty;
                    searchResult.MessageType = MessageType.Success;
                }
            }
            catch (Exception ex)
            {
                searchResult.Message = ex.Message;
                searchResult.MessageType = MessageType.Error;
            }

            return searchResult;
        }
         
        public ResultObj<List<Category>> GetCategories()
        {
            ResultObj<List<Category>> searchResult = new ResultObj<List<Category>>();

            try
            {
                searchResult.ResultObject = _context.Categories.ToList();
                if(searchResult.ResultObject.Count > 0)
                {
                    searchResult.Message = String.Empty;
                    searchResult.MessageType = MessageType.Success;
                }
                else
                {
                    searchResult.Message = "Empty";
                    searchResult.MessageType = MessageType.Error;
                }
            }
            catch (Exception ex)
            {
                searchResult.Message = ex.Message;
                searchResult.MessageType = MessageType.Error;
            }
            return searchResult;
        }

        public ResultObj<List<Category>> GetCategories(int skip, int take)
        {
            ResultObj<List<Category>> searchResult = new ResultObj<List<Category>>();

            try
            {
                searchResult.ResultObject = _context.Categories.Skip(skip).Take(take).ToList();
                if (searchResult.ResultObject.Count > 0)
                {
                    searchResult.Message = String.Empty;
                    searchResult.MessageType = MessageType.Success;
                }
                else
                {
                    searchResult.Message = "Empty";
                    searchResult.MessageType = MessageType.Error;
                }
            }
            catch (Exception ex)
            {
                searchResult.Message = ex.Message;
                searchResult.MessageType = MessageType.Error;
            }
            return searchResult;
        }

        public ResultObj<List<Category>> Search(CategorySearchObj searchObj)
        {
            ResultObj<List<Category>> searchResult = new ResultObj<List<Category>>();

            try
            {
                var results = (from u in _context.Categories
                               where u.CategoryID == null || u.CategoryID == searchObj.CategoryID &&
                               string.IsNullOrEmpty(searchObj.CategoryName) || u.CategoryName.Contains(searchObj.CategoryName)
                               select u).ToList();

                if (results.Any())
                {
                    searchResult.ResultObject = results;
                    searchResult.MessageType = MessageType.Success;
                    searchResult.Message = string.Empty;
                }
                else
                {
                    searchResult.MessageType = MessageType.Error;
                    searchResult.Message = "Sonuc bulunamadı";
                }
            }
            catch (Exception ex)
            {
                searchResult.ResultObject = null;
                searchResult.Message = ex.Message;
                searchResult.MessageType = MessageType.Error;
            }
            return searchResult;
        }
    }
}
