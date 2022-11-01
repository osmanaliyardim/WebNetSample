using WebNetSample.Entity.Dtos;
using WebNetSample.Business.Abstract;
using WebNetSample.DataAccess.Abstract;
using WebNetSample.Entity.Concrete;
using AutoMapper;

namespace WebNetSample.Business.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryManager(ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDetailDto> GetByIdAsync(Guid categoryId)
    {
        var categoryInfo = await _categoryRepository.GetAsync(entity => entity.Id == categoryId);

        var mappedCategory = _mapper.Map<CategoryDetailDto>(categoryInfo);

        return mappedCategory;
    } 

    public async Task<List<CategoryDetailDto>> GetListAsync()
    {
        var categoryListInfo = await _categoryRepository.GetListAsync();

        var mappedCategoryList = _mapper.Map<List<CategoryDetailDto>>(categoryListInfo);

        return mappedCategoryList;
    }  

    public async Task AddAsync(CategoryDetailDto category)
    {
        var categoryInfo = _mapper.Map<Category>(category);

        await _categoryRepository.AddAsync(categoryInfo);
    }
        

    public async Task UpdateAsync(CategoryDetailDto category)
    {
        var categoryInfo = _mapper.Map<Category>(category);

        var FileName = Path.GetFileNameWithoutExtension(categoryInfo.ImagePath);

        var FileExtension = Path.GetExtension(categoryInfo.ImagePath);

        FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName?.Trim() + FileExtension;

        var UploadPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Images\\";

        categoryInfo.ImagePath = UploadPath + FileName;

        using (Stream fileStream = new FileStream(categoryInfo.ImagePath, FileMode.Create, FileAccess.Write))
        {
            category.ImageFile.CopyTo(fileStream);
        }

        const string imageDirectory = "\\Images\\";

        categoryInfo.ImagePath = imageDirectory + FileName;

        await _categoryRepository.UpdateAsync(categoryInfo);
    }
}