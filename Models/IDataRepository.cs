namespace MariaAspNet.Models.Contracts;

public interface IDataRepository
{
    Task<IEnumerable<StudentModel>> GetAllAsync();
    Task<StudentModel?> GetAsync(string nocontrol);
    Task AddAsync(StudentModel entity);
    Task UpdateAsync(StudentModel entityToUpdate, StudentModel updatedEntity);
    Task DeleteAsync(StudentModel entity);
}
