using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentScheduler.Core.Entity;
using AppointmentScheduler.Core.Interface;
using AppointmentScheduler.Core.Model;
using Microsoft.Extensions.Logging;

namespace AppointmentScheduler.Core.Service
{
    public class ChildService : IChildService
    {
        private readonly IChildRepository _childRepository;
        private readonly IEmailService _emailService;
        private readonly ILogger<ChildService> _logger;

        public ChildService(IChildRepository childRepository, IEmailService emailService, ILogger<ChildService> logger)
        {
            _childRepository = childRepository;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Child> Register(Registration registration)
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
                HudumaNamba = registration.CareGiver.HudumaNamba,
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
                HudumaNamba = registration.Child.HudumaNamba,
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
                var result = await Task.Run(() => _childRepository.Insert(child));
                //send notification email
                try
                {
                    string message = $"Hello {careGiver.FirstName}\r\n\r\nYour child {person.FirstName} {person.LastName} has been successfully registered on the MCH Appointment Scheduling system.\r\n\r\nKind Regards, MCH Appointments Team\r\n\r\n";
                    await Task.Run(() =>
                    {
                        if (careGiver.PersonContacts != null && careGiver.PersonContacts.FirstOrDefault() != null)
                            _emailService.Send("mchappointments@gmail.com", careGiver.PersonContacts.FirstOrDefault()?.Email, "Child Registration",
                                message);
                    });
                }
                catch (Exception e)
                {
                    _logger.LogError("Error sending registration email", e);
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}