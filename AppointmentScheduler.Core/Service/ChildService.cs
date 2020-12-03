using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using AppointmentScheduler.Core.Model;

namespace AppointmentScheduler.Core.Service
{
    public class ChildService : IChildService
    {
        private readonly IChildRepository _childRepository;

        public ChildService(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        public async Task<bool> Register(Registration registration)
        {
            List<PersonContact> personContacts = new List<PersonContact>();
            List<PersonRelative> personRelatives = new List<PersonRelative>();
            var contact = new PersonContact()
            {
                AlternateNumber = registration.Contact.AlternateNumber,
                CountyId = registration.Contact.CountyId,
                Email = registration.Contact.Email,
                PhoneNumber = registration.Contact.PhoneNumber,
                PhysicalAddress = registration.Contact.PhysicalAddress,
                PostalAddress = registration.Contact.PostalAddress,
            };
            var relative = new PersonRelative()
            {
                PostalAddress = registration.Relative.PostalAddress,
                Email = registration.Relative.Email,
                PhoneNumber = registration.Relative.PhoneNumber,
                PhysicalAddress = registration.Relative.PhysicalAddress,
                Name = registration.Relative.Name,
                RelationshipId = registration.Relative.RelationshipId
            };
            personContacts.Add(contact);
            personRelatives.Add(relative);
            var careGiver = new Person()
            {
                DateOfBirth = registration.CareGiver.DateOfBirth,
                FacilityId = registration.CareGiver.FacilityId,
                FirstName = registration.CareGiver.FirstName,
                MiddleName = registration.CareGiver.MiddleName,
                LastName = registration.CareGiver.LastName,
                GenderId = registration.CareGiver.GenderId,
                MaritalStatusId = registration.CareGiver.MaritalStatusId,
                PersonContacts = personContacts,
                PersonRelatives = personRelatives,
            };

            var person = new Person()
            {
                DateOfBirth = registration.Child.DateOfBirth,
                FacilityId = registration.Child.FacilityId,
                FirstName = registration.Child.FirstName,
                MiddleName = registration.Child.MiddleName,
                LastName = registration.Child.LastName,
                GenderId = registration.Child.GenderId,
                MaritalStatusId = registration.Child.MaritalStatusId,
                PersonContacts = personContacts,
                PersonRelatives = personRelatives,
            };
            var child = new Child()
            {
                UniqueNumber = registration.Child.UniqueNumber,
                CareGiver = careGiver,
                Person = person,
            };
            try
            {
                await Task.Run(() => _childRepository.Insert(child));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}