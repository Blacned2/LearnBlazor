using LearnBlazor.Data;
using LearnBlazor.AppService.Model;
using LearnBlazor.AutoMapper.Dtos;

namespace LearnBlazor.AppService.Interface
{
    public interface ICategoryService
    {
        ResultObj<List<Category>> GetCategories();
        ResultObj<List<Category>> GetCategories(int skip,int take);
        ResultObj<List<Category>> Search(CategorySearchObj searchObj);
        ResultObj<int> Delete(int id);
        ResultObj<Category> CreateOrEdit(CategoryDto request);
        int CategorySize();
    }
}
