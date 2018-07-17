using DemoSite.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DemoSite.Repository;

namespace DemoSite.Services
{
    public interface IVehicleService
    {
        Vehicle GetById(object id);
        IEnumerable<Vehicle> GetAll();
        IEnumerable<Vehicle> FindBy(Expression<Func<Vehicle, bool>> predicate);
        bool Add(Vehicle entity);
        bool Delete(Vehicle entity);
        bool Edit(Vehicle entity);
        bool Save();
        IDictionary<string, string> Validate(Vehicle _class);
    }

    public class VehicleService : IVehicleService
    {
        private readonly IGenericRepository<Vehicle> _repository;

        public VehicleService(IGenericRepository<Vehicle> repo)
        {
            _repository = repo;
        }

        public Vehicle GetById(object id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Vehicle> FindBy(Expression<Func<Vehicle, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }

        public bool Add(Vehicle entity)
        {
            // Database logic
            try
            {
                _repository.Add(entity);
                _repository.Save();
            }
            catch (SqlException ex)
            {
                return false;
            }

            return true;
        }

        public bool Delete(Vehicle entity)
        {
            try
            {
                Delete(entity);
                Save();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Edit(Vehicle entity)
        {
            try
            {
                _repository.Edit(entity);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool Save()
        {
            try
            {
                _repository.Save();

            }
            catch
            {
                return false;
            }

            return true;
        }

        public IDictionary<string, string> Validate(Vehicle entity)
        {
            IDictionary<string, string> errors = new Dictionary<string, string>();
            // Add model erros e.g.:
            return errors;
        }
    }

}