using Microsoft.EntityFrameworkCore;
using MariaAspNet.Models.Contracts;
namespace MariaAspNet.Models.DataRepository;

public class StudentRepository(ApplicationContext context) : IDataRepository
{
    readonly ApplicationContext _studentContext = context;
    public async Task AddAsync(StudentModel entity)
    {
        _studentContext.student.Add(entity);
        await _studentContext.SaveChangesAsync();
    }
    public async Task<StudentModel?> GetAsync(string nocontrol) => await _studentContext.student.FindAsync(nocontrol);
    public async Task UpdateAsync(StudentModel entityToUpdate, StudentModel entity)
    {
        entityToUpdate.nocontrol = entity.nocontrol;
        entityToUpdate.fullname = entity.fullname;
        entityToUpdate.career = entity.career;
        entityToUpdate.curp = entity.curp;
        entityToUpdate.currentgrade = entity.currentgrade;
        await _studentContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(StudentModel entity)
    {
        _studentContext.Remove(entity);
        await _studentContext.SaveChangesAsync();
    }
    public async Task<IEnumerable<StudentModel>> GetAllAsync()
    {
        return await _studentContext.student.ToListAsync<StudentModel>();
    }
}

