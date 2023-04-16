using ContactAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ContactAPI.Services
{
    public interface IContact
    {
        string Name { get; set; }

        string Surname { get; set; }

        //public System.DateTime? DateOfBirth { get; set; }

    }
}